# Asp.Net Core ile Online Ticari Otomasyon ve Sistem Modernizasyonu 🚀

Bu proje; Murat Yücedağ'ın .NET MVC 5 (Legacy) mimarisiyle kurguladığı "Online Ticari Otomasyon" projesinin temel iş mantığı (business logic) referans alınarak, modern **.NET Core** ekosistemine sıfırdan uyarlanması ve refactor edilmesiyle geliştirilmiş bir backend/full-stack laboratuvar çalışmasıdır.

## 🎯 Projenin Amacı ve Mühendislik Yaklaşımı
Projenin ana motivasyonu, günümüz sektör standartlarının gerisinde kalan monolitik .NET Framework MVC 5 yapısını, güncel ve performanslı **.NET Core** mimarisine taşırken karşılaşılan uyumluluk, bağımlılık ve mimari değişikliklerin çözülmesidir. 

Bu süreçte, .NET MVC'de kullanılan eski veri erişim ve arayüz taşıma yöntemleri yerine, .NET Core'un modern ve güvenli yaklaşımları entegre edilmiştir.

---

## 🛠️ Teknolojik Stack & Mimari Bileşenler

*   **Backend Altyapısı:** .NET Core MVC
*   **Veri Tabanı & ORM:** MS SQL Server, Entity Framework Core (EF Core)
*   **Sorgu Optimizasyonu:** Gelişmiş LINQ (Language Integrated Query) Sorguları
*   **Veri Yönetimi & Güvenlik:** DTO (Data Transfer Object), ViewModel Yapıları, Rol Tabanlı Yetkilendirme (Role-Based Authorization)
*   **UI Modülerliği:** .NET Core ViewComponents

---

## 💻 Öne Çıkan Teknik Başarılar & Geliştirmeler

### 1. .NET MVC 5'ten .NET Core'a Göç (Migration)
*   Eski .NET yapısındaki konfigürasyon bağımlılıkları temizlenerek, .NET Core'un esnek ve performanslı yapısına geçiş sağlandı.
*   EF Core geçişiyle birlikte, çoklu ilişkisel veri tabanı tablolarının (One-to-Many, Many-to-Many) arka plandaki çalışma mantığı, verimli indexleme ve ezber dışı mimari kurgusu optimize edildi.

### 2. İleri Düzey LINQ Sorguları ve Veri Yönetimi
*   Ticari otomasyonun ihtiyaç duyduğu dinamik raporlamalar, stok takipleri, kritik seviye analizleri ve grafiksel veriler için yüksek performanslı LINQ sorguları kurgulandı. Veri tabanı üzerindeki bilişsel yük minimuma indirildi.

### 3. Modüler UI ve Veri Taşıma Stratejileri
*   Eski .NET mimarisinde kullanılan `PartialView` yapıları yerine, .NET Core'un asenkron ve performanslı çalışan **ViewComponent** yapısı entegre edilerek arayüz modüler hale getirildi.
*   Veri güvenliği ve katmanlar arası temiz veri transferi için **DTO** ve **ViewModel** desenleri (pattern) uygulandı.

### 4. Geniş Kapsamlı Kimlik Doğrulama & Yetkilendirme (Auth)
*   Basit düzeydeki giriş mekanizmaları genişletilerek; ticari sistemin güvenliğini sağlayacak, rol tabanlı (Admin, Personel, Cari) gelişmiş erişim kontrol mekanizmaları kurgulandı.

---

## 📐 Veri Tabanı İlişki Mimarisi
Proje kapsamında Entity Framework Core kod entegrasyonu ile yönetilen temel modüller:
*   **Cari & Personel Yönetimi**
*   **Stok & Ürün Yönetimi**
*   **Fatura & Detay Takip Mekanizması**
*   **Departman & Rol Tanımlamaları**
*   **Gelişmiş Raporlama Panelleri**
3. Package Manager Console veya CLI üzerinden `Update-Database` komutunu çalıştırarak veri tabanını ayağa kaldırın.
4. Projeyi çalıştırın (Run).
