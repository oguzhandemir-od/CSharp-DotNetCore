# Asenkron Bildirim Merkezi Prototipi (Event-Driven Architecture)

Bu proje, modern mikroservis mimarilerinin en kritik kalıplarından biri olan **Olay Güdümlü Mimari (Event-Driven Architecture)** ve **Asenkron Mesajlaşma (Asynchronous Messaging)** konseptlerini deneyimlemek amacıyla geliştirilmiş bir backend prototipidir. 

Sistem; bir sipariş alındığında, siparişi işleyen ana sistem ile kullanıcıya bildirim (SMS/E-posta) gönderen alt sistemin birbirine doğrudan (senkron) bağımlı olmamasını, bunun yerine bir mesaj broker'ı üzerinden asenkron olarak haberleşmesini simüle eder.

## 🚀 Kullanılan Teknolojiler ve Sürümler
* **API & Worker:** .NET 10.0 (Modern Kestrel yapılandırması & Background Service)
* **Message Broker:** RabbitMQ 4.3 (Management plugin aktif)
* **Konteynerizasyon:** Docker & Docker Compose v3.8
* **API Dokümantasyon:** Microsoft OpenAPI & Scalar UI (DeepSpace Karanlık Tema)

## 🏗️ Mimari Yaklaşım ve Öne Çıkan Özellikler

### 1. Gevşek Bağlılık (Loosely Coupled) & Hata İzolasyonu (Fault Tolerance)
`Order.API` ve `Notification.Consumer` (Worker) servisleri birbirlerinin varlığından, IP adreslerinden veya teknolojilerinden tamamen bağımsızdır. Bildirim servisinde bir çökme veya kilitlenme yaşansa dahi, Sipariş API'si tıkır tıkır çalışmaya devam eder, mesajı kuyruğa bırakır ve kullanıcıya anında `200 OK` döner. Bildirim servisi ayağa kalktığı an, kuyrukta biriken mesajları tüketmeye kaldığı yerden devam eder; veri kaybı sıfıra indirilir.

### 2. Akıllı Yeniden Deneme Mekanizması (Resilience / Retry Pattern)
Konteynerizasyon süreçlerinde servislerin ayağa kalkma süreleri farklılık gösterebilir (Örn: RabbitMQ'nun tamamen hazır olması 10-15 saniye sürebilir). Worker servisinin ilk açılışta çökmesini önlemek amacıyla, RabbitMQ'ya asenkron olarak bağlanana kadar güvenli bir döngüde (`Task.Delay` ile) bekleyen saf C# **Retry Mekanizması** kurgulanmıştır.

### 3. İzole Docker Ağ Politikası (Isolated Bridge Network)
Konteynerların birbirlerini güvenli ve stabil bir şekilde görebilmesi için Docker üzerinde özel bir alt ağ (Subnet) ve statik IP havuzu tanımlanmıştır. DNS çözümleme gecikmelerini önlemek adına servisler birbirleriyle izole bridge ağ yapısı üzerinden haberleşir.

---

## 🎯 Erişim Noktaları

  Scalar API Arayüzü: http://localhost:5001/scalar/ (Sipariş isteklerini test etmek için)

  RabbitMQ Yönetim Paneli: http://localhost:15672 (Kuyruk hareketlerini ve mesaj akışını izlemek için - Kullanıcı: guest / Şifre: guest)

## 📊 Örnek Akış Testi

Scalar UI üzerinden POST /api/orders ucuna aşağıdaki gövde ile bir istek atıldığında:
JSON

    {
    "customerId": "user_2026",
    "totalAmount": 3450.75,
    "productIds": ["prod_net10", "prod_rabbitmq4"]
    }

Arka Plandaki Canlı Log Çıktısı (Docker Logs):
Plaintext

    info: Notification.Consumer.Worker[0]
      RabbitMQ'ya bağlanmaya çalışılıyor: 172.20.0.10
    warn: Notification.Consumer.Worker[0]
      RabbitMQ henüz hazır değil. 5 saniye içinde tekrar denenecek...
    info: Notification.Consumer.Worker[0]
      RabbitMQ bağlantısı başarıyla sağlandı!
    info: Notification.Consumer.Worker[0]
      Notification Consumer arka planda asenkron olarak kuyruğu dinliyor...
    info: Notification.Consumer.Worker[0]
      ==================================================
    info: Notification.Consumer.Worker[0]
      [BİLDİRİM SERVİSİ] Yeni bir sipariş olayı yakalandı!
    info: Notification.Consumer.Worker[0]
      Sipariş ID: 4fbc2e77-9b24-4f9e-bd32-b7e2c9041a54
    info: Notification.Consumer.Worker[0]
      Müşteri ID: user_2026
    info: Notification.Consumer.Worker[0]
      Toplam Tutar: ₺3.450,75
    info: Notification.Consumer.Worker[0]
      [SMS/E-POSTA] Kullanıcıya bildirim başarıyla simüle edildi.
    info: Notification.Consumer.Worker[0]
      ==================================================
