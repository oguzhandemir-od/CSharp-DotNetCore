# Decoupled Multi-Tier Library Management & Loan System 📚

Bu proje; Murat Yücedağ'ın monolitik .NET MVC kütüphane kurgusu temel alınarak; modern yazılım mimarilerine, **API-First (Decoupled)** prensibine ve katı iş kurallarına (Strict Business Rules) uygun olarak sıfırdan inşa edilmiş, full-stack bir sistem otomasyonudur. 

Proje, backend tarafında **Onion Architecture** üzerine kurulu gelişmiş bir .NET Core Web API altyapısına, frontend tarafında ise asenkron veri akışına sahip modern bir **React** uygulamasına sahiptir.

---

## 🛠️ Teknolojik Stack & Mimari Tercihler

### Backend (API Katmanı)
*   **Mimari:** Onion Architecture (Core, Domain, Application, Infrastructure, WebAPI)
*   **Tasarım Desenleri (Patterns):** Repository Pattern, Dependency Injection (DI)
*   **Güvenlik & Yetkilendirme:** JWT (JSON Web Token) tabanlı Politika Bazlı Erişim Kontrolü (Policy-Based Access Control - RBAC)
*   **Veri Doğrulama:** FluentValidation
*   **Dokümantasyon & UI:** MS OpenAPI & Scalar UI
*   **ORM / Veri Tabanı:** Entity Framework Core, MS SQL Server

### Frontend (Arayüz Katmanı)
*   **Framework:** React (Component-Based UI, State Management)
*   **Stil Altyapısı:** Tailwind CSS (Modern, Responsive & Minimalist Tasarım)

---

## 🔐 Gelişmiş Rol ve Yetkilendirme Matrisi

Sistem, güvenlik ve veri güvenilirliği amacıyla tamamen ayrıştırılmış 3 ana rol yapısı (RBAC) ile yönetilmektedir:

1.  **Üye (Member):** Katalog üzerinde arama/filtreleme yapabilir. Kendi ödünç geçmişini, aktif cezalarını görüntüleyebilir. Profil ve şifre bilgilerini güncelleyebilir.
2.  **Personel (Staff):** Özel ve gizli bir kimlik doğrulama kanalıyla sisteme erişir. Kitap, Kategori ve Yazar yönetiminin tüm CRUD süreçlerini yönetir. Üye bilgilerini güncelleyebilir, kitap ödünç verme ve iade alma süreçlerini işletir.
3.  **Yönetici (Admin):** Sistemde en yüksek yetkiye sahip sınırlı (1-2 kişi) hesaptır. Personellerin sahip olduğu yetkilerin yanında, personel kaydı, personel güncellenmesi/silinmesi ve üye silme gibi kritik yönetimsel inisiyatifleri yürütür.

---

## 🧠 Öne Çıkan Mühendislik Çözümleri & İş Kuralları

### 📦 Kapsüllenmiş (Encapsulated) Ceza Mekanizması
Sistemdeki finansal güvenliği sağlamak amacıyla ceza sistemi tamamen izole edilmiştir.
*   Ceza miktarları ve gecikme hesaplamaları **tamamen arka planda sistem tarafından otomatik olarak hesaplanır.**
*   Admin dahil olmak üzere hiçbir rol ceza miktarı üzerinde el ile değişiklik (CUD) yapamaz.
*   Personel veya Admin yalnızca üye cezayı fiziksel olarak ödediğinde cezayı "Ödendi" olarak işaretleme yetkisine sahiptir. Bu sayede veri manipülasyonunun önüne geçilmiştir.

### 📐 Katmanlı (Onion) Mimari ve Esneklik
Proje tek bir katmanda boğulmak yerine gevşek bağlı (loosely coupled) şekilde tasarlanmıştır. Veri tabanı bağımlılıkları en dış katmanda (Infrastructure) tutulurken, uygulamanın çekirdek iş mantığı (Core/Domain) dış dünyadan tamamen izole edilmiştir.

### ⚡ Performanslı ve Şık Arayüz (React & Tailwind)
Hantal sayfa yenilemeleri (page refresh) yerine React'in asenkron state yapısı kullanılarak akıcı bir kullanıcı deneyimi (UX) sunulmuştur. Personel paneli girişinde verileri analiz eden dinamik bir **İstatistik Dashboard**'u yer almaktadır.

---

## 📌 Proje Yapısı ve Klasör Dizini
```text
├── Backend/ (Onion Architecture Web API)
│   ├── Library.Domain/           # Domain Entities 
│   ├── Library.Application/      # Business Logic, DTOs & FluentValidation & Core Interfaces
│   ├── Library.Infrastructure/   # EF Core Context, Repositories & Migrations
│   └── Library.WebAPI/           # Controllers, JWT Config & Scalar UI
└── Frontend/ (React UI)
    ├── src/components/       # Reusable UI Components
    ├── src/pages/            # Dashboard, Catalog, Other Pages
    └── tailwind.config.js    # Tailwind Utility CSS Configuration
