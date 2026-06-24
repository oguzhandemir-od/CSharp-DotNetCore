# GlobalPublishing SaaS API (Architecture Prototype)

Bu proje, modern yazılım mimarisi prensipleri ve kurumsal tasarım kalıpları (Design Patterns) kullanılarak geliştirilmiş, çok kiracılı (**Multi-Tenant**) ve güvenli bir yayıncılık sistemi backend prototipidir. Projenin temel odağı, veri bütünlüğünü koruyan, yüksek performanslı ve katmanlar arası bağımlılıkları minimize eden bir altyapı tasarımı sunmaktır.

---

## 🏗️ Mimari Yapı (Onion Architecture)

Proje, iş mantığını (Business Logic) dış etkenlerden ve veri erişim teknolojilerinden tamamen izole etmek amacıyla **Onion Architecture** mimarisi üzerine inşa edilmiştir:

* **Domain:** Mimarinin kalbidir. Hiçbir katmana bağımlılığı yoktur. Zengin Alan Modelleri (**Rich Domain Model**) ve veri tutarlılığını sağlayan korumalı iş kuralları içerir.
* **Application:** İş süreçlerini (Use Cases) yöneten, DTO eşlemelerini ve servis sözleşmelerini barındıran orkestra katmanıdır.
* **Infrastructure:** Veritabanı bağlamı (EF Core), jenerik repository somutlamaları ve JWT tabanlı kimlik çözme servislerinin yer aldığı katmandır.
* **WebApi:** Dış dünyaya açılan kapıdır. Sadece istekleri kabul eder, servisleri tetikler ve REST standartlarında HTTP yanıtları döner (**Thin Controller**).

---

## ⚡ Öne Çıkan Mühendislik Pratikleri & Yetkinlikler

### 1. Rich Domain Model & Encapsulation
Sistemdeki entity'ler (Örn: `Book`, `Author`), anemi (Anemic Model) veri torbaları yerine kendi canını ve kurallarını koruyan akıllı organizmalar olarak tasarlanmıştır. `Public set` özellikleri kapatılmış, nesne üretimleri ve ilişkiler (Çeviri ekleme vb.) korumalı constructor'lar ve özel metotlar üzerinden encapsulation prensiplerine uygun olarak kurgulanmıştır.

### 2. Otomatik Multi-Tenancy & Soft-Delete İzolasyonu
`IMustHaveTenant` gibi **Marker Interface (İşaretçi Arayüzler)** kullanılarak sistemdeki tablolar etiketlenmiştir. EF Core `OnModelCreating` aşamasında yazılan dinamik yansıma (**Reflection**) döngüsü sayesinde:
* Silinmiş verilerin sorgulara gelmemesi (**Soft-Delete**)
* Farklı yayınevlerinin sadece kendi verilerini görmesi (**Multi-Tenant Data Isolation**)
**Global Query Filters** mimarisiyle tek merkezden otomatikleştirilmiştir. Yazılımcının her sorguya elle filtre yazma riski ortadan kaldırılmıştır.

### 3. İleri Seviye EF Core & SQL Optimizasyonları
* **Deferred Execution (Ertelenmiş Çalışma):** Veri erişiminde `IQueryable` taslak motoru kullanılarak sorgular sadece ihtiyaç anında (`ToListAsync`) tetiklenmiş, network ve RAM maliyetleri optimize edilmiştir.
* **No-Tracking (`AsNoTracking`):** Salt okunur (Read-Only) listeleme operasyonlarında EF Core'un `Change Tracker` (Değişiklik Takipçisi) mekanizması kapatılarak bellek tüketimi minimuma indirilmiştir.
* **Projection (Projeksiyon):** Veriler DTO'lara dönüştürülürken `.Select()` blokları kullanılarak sadece gerekli kolonlar SQL seviyesinde çekilmiş, **N+1 Sorgu Problemi** kökten çözülmüştür.

### 4. Unit of Work & Transaction Yönetimi
Veritabanı yazma (Write) operasyonlarında ağ trafiğini azaltmak ve veri bütünlüğünü garanti altına almak için **Unit of Work** deseni uygulanmıştır. `Add` gibi metotlarla işlemler RAM'de sıraya alınmış, `SaveChangesAsync` ile tek bir veritabanı paketi (Transaction) halinde diske mühürlenmiştir.

### 5. SOLID & Program.cs Diyeti
Uygulama bağımlılıkları ve middleware boru hattı (**Pipeline**) yapılandırılırken `Program.cs` dosyasının şişmesi (**Fat Controller / Fat Program.cs** sendromu) engellenmiştir. **Extension Methods (Genişletme Metotları)** kullanılarak her katmanın kendi bağımlılığını kaydetmesi (Dependency Injection) sağlanmış, Single Responsibility ilkesi korunmuştur.

### 6. Pipeline Seviyesinde Global Exception Handling & Loglama
Uygulama genelinde oluşabilecek tüm hatalar, HTTP boru hattının en tepesine yerleştirilen merkezi bir **Middleware** tarafından yakalanır. 
* Hataların tipine göre (`ArgumentException` vb.) dinamik HTTP durum kodları (`400 Bad Request`, `500 Internal Error`) haritalanır.
* Hatalar kullanıcıya yansımadan önce `ILogger` ve **Serilog** altyapısı ile asenkron (Non-blocking) olarak loglanır.
* İstemciye (Frontend) sistem detaylarını sızdırmayan, standartlaştırılmış profesyonel JSON hata şablonları dönülür.

### 7. Dinamik JWT Claims Çözümleme
Kullanıcı giriş yaptığında token içerisine gömülen yayınevi bilgisi, API kapısında .NET `IHttpContextAccessor` gözcüsü kullanılarak dinamik olarak çözülür. İstek süresince (`Scoped`) çalışan `TenantService` aracılığıyla bu kimlik bilgisi `AppDbContext`'e beslenir ve veri izolasyon filtresi canlı verilerle beslenir.

---

## 🛠️ Kullanılan Teknolojiler

* **.NET Core**
* **Entity Framework Core**
* **ASP.NET Core Web API**
* **Serilog / ILogger**
* **JSON Web Tokens (JWT)**

---
[⬅️ Proje Kataloğuna Dön](..)
