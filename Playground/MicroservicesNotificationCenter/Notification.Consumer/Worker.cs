using Notification.Consumer.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace Notification.Consumer
{
    public class Worker(ILogger<Worker> _logger, IConfiguration _configuration) : BackgroundService
    {
        private IConnection? _connection;
        private IChannel? _channel;        

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory()
            {
                HostName = Environment.GetEnvironmentVariable("RabbitMQ__HostName")
                           ?? _configuration["RabbitMQ:HostName"]
                           ?? "172.20.0.10",
                UserName = "guest",
                Password = "guest"
            };

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _logger.LogInformation("RabbitMQ'ya bağlanmaya çalışılıyor: {Host}", factory.HostName);

                    _connection = await factory.CreateConnectionAsync(stoppingToken);
                    _channel = await _connection.CreateChannelAsync(cancellationToken: stoppingToken);

                    _logger.LogInformation("RabbitMQ bağlantısı başarıyla sağlandı!");
                    break;
                }
                catch (Exception)
                {
                    _logger.LogWarning("RabbitMQ henüz hazır değil. 5 saniye içinde tekrar denenecek...");
                    await Task.Delay(5000, stoppingToken);
                }
            }            

            await _channel.QueueDeclareAsync(
                queue: "order-created-queue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null,
                cancellationToken: stoppingToken
            );


            var consumer = new AsyncEventingBasicConsumer(_channel);

            consumer.ReceivedAsync += async (model, ea) =>
            {
                try
                {
                    var body = ea.Body.ToArray();
                    var messageJson = Encoding.UTF8.GetString(body);

                    var orderEvent = JsonSerializer.Deserialize<OrderCreatedEvent>(messageJson);

                    if (orderEvent != null)
                    {
                        _logger.LogInformation("==================================================");
                        _logger.LogInformation("[BİLDİRİM SERVİSİ] Yeni bir sipariş olayı yakalandı!");
                        _logger.LogInformation($"Sipariş ID: {orderEvent.OrderId}");
                        _logger.LogInformation($"Müşteri ID: {orderEvent.CustomerId}");
                        _logger.LogInformation($"Toplam Tutar: {orderEvent.TotalAmount:C}");
                        _logger.LogInformation("[SMS/E-POSTA] Kullanıcıya bildirim başarıyla simüle edildi.");
                        _logger.LogInformation("==================================================");
                    }

                    await _channel.BasicAckAsync(deliveryTag: ea.DeliveryTag, multiple: false, cancellationToken: stoppingToken);

                }
                catch (Exception ex)
                {

                    _logger.LogError($"Mesaj işlenirken hata oluştu: {ex.Message}");
                    await _channel.BasicNackAsync(deliveryTag: ea.DeliveryTag, multiple: false, requeue: true, cancellationToken: stoppingToken);


                }
            };

            await _channel.BasicConsumeAsync(
                queue: "order-created-queue",
                autoAck: false,
                consumer: consumer,
                cancellationToken: stoppingToken
                );

            _logger.LogInformation("Notification Consumer arka planda asenkron olarak kuyruğu dinliyor...");


            while (!stoppingToken.IsCancellationRequested)
            {
                
                await Task.Delay(1000, stoppingToken);
            }
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            if (_channel != null) await _channel.CloseAsync(cancellationToken);
            if (_connection != null) await _connection.CloseAsync(cancellationToken);
            await base.StopAsync(cancellationToken);
        }

    }
}
