using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.API.Models;
using RabbitMQ.Client;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;

namespace Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public OrdersController(IConfiguration configuration)
        {
            _configuration= configuration;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderCreateDto dto)
        {
            var generatedOrderId = Guid.NewGuid();

            var factory = new ConnectionFactory()
            {
                HostName = _configuration["RabbitMQ: HostName"]??"rabbitmq",
                UserName = "guest",
                Password = "guest"
            };

            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(
                queue: "order-created-queue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null
                );

            var orderEvent = new OrderCreatedEvent
            {
                OrderId = generatedOrderId,
                CustomerId = dto.CustomerId,
                TotalAmount = dto.TotalAmount
            };

            var messageJson = JsonSerializer.Serialize(orderEvent);
            var body = Encoding.UTF8.GetBytes(messageJson);

            await channel.BasicPublishAsync(
                exchange: string.Empty,
                routingKey: "order-created-queue",
                mandatory: false,
                basicProperties: new BasicProperties(),
                body: body
                );

            return Ok(new { Message = "Siperiş alındı ve bildirim kuyruğuna gönderildi.", OrderId = generatedOrderId });
        }
    }
}
