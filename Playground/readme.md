# 📂 Playground - Proje Kataloğu

Bu dizin, hobi olarak ve yeni öğrendiğim teknolojileri denemek adına C# ve .NET Core ile geliştirdiğim proje ve pratik uygulamaları içerir, bir laboratuvardır.

## 🚀 Proje Endeksi

Aşağıdaki tabloda bu klasör altındaki tüm projelerin listesi, teknik detayları ve ilerleme durumları yer almaktadır:

| Proje / Klasör Adı | Türü | Kullanılan Teknolojiler / Mimari | Durum | Açıklama |
| :--- | :--- | :--- | :--- | :--- |
| [Görev Yönetimi](./TaskManagementSystem) | Web API | .NET Core, EF Core, Onion Architecture, Repository Pattern, Dependency Injection (DI), FluentValidation, Global Exception Handling | ✅ Bitti | Domain kurallarının kapsüllendiği, katmanlar arası bağımlılıkların gevşetildiği ve merkezi hata yönetiminin kurgulandığı kurumsal mimari pratiği. |
| [E-Ticaret Altyapı Prototipi](./ECommerceSystem) | Web API | .NET Core, Onion Architecture, JWT Authentication & Role Security, Docker, Redis Distributed Caching, Global Exception Handling Middleware, Microsoft OpenAPI & Scalar UI | ✅ Bitti | Yüksek trafikli sistemler için tasarlanmış; token tabanlı güvenlik kalkanı, RAM tabanlı önbellekleme (Cache Invalidation) ve merkezi hata yönetimini barındıran performans odaklı backend prototipi. |
| [Asenkron Bildirim Merkezi](./MicroservicesNotificationCenter) | Microservices & Worker | .NET 10.0 (Web API & Background Service), RabbitMQ 4.3 (Management), Docker Compose, Isolated Bridge Network, Asynchronous Event Publishing, Resilience Retry Pattern | ✅ Bitti | Olay güdümlü mimari (Event-Driven) temelinde; sipariş API'si ile bildirim servisini mesaj kuyruğu üzerinden tamamen ayıran, hata izolasyonlu ve yüksek ölçeklenebilir asenkron haberleşme prototipi. |
| [AutoMapper Entegrasyon Prototipi](./Playground/AutoMapperPrototype) | Versiyon Uyumsuzluk Çözümü & Veri Eşleme | .NET Core Web API, AutoMapper, Dependency Injection (DI), DTO (Data Transfer Object) Deseni | ✅ Bitti | Büyük projelerde sürüm ve DI çakışması yaratan haritalama mekanizmasının, izole bir laboratuvar ortamında güncel servis kayıt yöntemleriyle çözüldüğü ve iki taraflı (Two-Way) nesne eşleme doğrulaması yapılan mimari prototip. |
| [xUnit & Moq ile İş Mantığı Test Prototipi](./Playground/UnitTestPrototype) | Unit Testing & Mocking Pratikleri | .NET Core Web API, xUnit, Moq Kütüphanesi, Repository Pattern Mocking, AAA (Arrange-Act-Assert) Deseni | ✅ Bitti | Katmanlı mimarilerde veri tabanı bağımlılığını izole ederek iş mantığını (Business Logic) ve kapsüllenmiş kuralları (stok limit kontrolü vb.) test etmek için kurgulanmış, projelere doğrudan entegre edilebilir xUnit şablonu. |
| [SaaS Yayıncılık Altyapısı](./GlobalPublishing.Ecosystem) | Web API | .NET Core, EF Core, Onion Architecture, Rich Domain Model, Multi-Tenancy Isolation, Global Query Filters, Unit of Work, Non-blocking Logging | ✅ Bitti | Veri güvenliği, kiracı izolasyonu ve veritabanı optimizasyonlarının üst seviyede kurgulandığı, her katmanı bağımsız ve test edilebilir çok kiracılı (Multi-Tenant) mimari prototipi. |



> *(Not: Yeni projeler eklendikçe bu tablo güncellenmektedir.)*

---
[⬅️ Ana Depoya Dön](..)
