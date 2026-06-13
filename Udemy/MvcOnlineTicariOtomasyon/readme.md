# Asp.Net Core ile Online Ticari Otomasyon ve Sistem Modernizasyonu 🚀

Bu proje; Murat Yücedağ'ın .NET MVC 5 (Legacy) mimarisiyle kurguladığı "Online Ticari Otomasyon" projesinin temel iş mantığı (business logic) referans alınarak, modern **.NET Core** ekosistemine sıfırdan uyarlanması ve refactor edilmesiyle geliştirilmiş bir backend/full-stack laboratuvar çalışmasıdır.

## 🎯 Projenin Amacı ve Mühendislik Yaklaşımı
Projenin ana motivasyonu, günümüz sektör standartlarının gerisinde kalan monolitik .NET Framework MVC 5 yapısını, güncel ve performanslı **.NET Core** mimarisine taşırken karşılaşılan uyumluluk, bağımlılık ve mimari değişikliklerin çözülmesidir. 

Bu süreçte, .NET MVC'de kullanılan eski veri erişim ve arayüz taşıma yöntemleri yerine, .NET Core'un modern ve güvenli yaklaşımları entegre edilmiştir.

<img width="2559" height="1344" alt="Ekran görüntüsü 2025-09-05 185629" src="https://github.com/user-attachments/assets/29a78994-a2df-4498-941a-eadf2cb2e935" />

---

## 🛠️ Teknolojik Stack & Mimari Bileşenler

*   **Backend Altyapısı:** .NET Core MVC
*   **Veri Tabanı & ORM:** MS SQL Server, Entity Framework Core (EF Core)
*   **Sorgu Optimizasyonu:** Gelişmiş LINQ (Language Integrated Query) Sorguları
*   **Veri Yönetimi & Güvenlik:** DTO (Data Transfer Object), ViewModel Yapıları, Rol Tabanlı Yetkilendirme (Role-Based Authorization)
*   **UI Modülerliği:** .NET Core ViewComponents
  
<img width="2559" height="1343" alt="Ekran görüntüsü 2025-09-05 185816" src="https://github.com/user-attachments/assets/e0dc5ce7-62eb-4ce8-89ae-887c95ad3725" />

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

<img width="2559" height="1341" alt="Ekran görüntüsü 2025-09-05 185836" src="https://github.com/user-attachments/assets/b1a5e30a-d54a-4e92-88b2-ce80e8db3d90" />

---

## 📐 Veri Tabanı İlişki Mimarisi
Proje kapsamında Entity Framework Core kod entegrasyonu ile yönetilen temel modüller:
*   **Cari & Personel Yönetimi**
*   **Stok & Ürün Yönetimi**
*   **Fatura & Detay Takip Mekanizması**
*   **Departman & Rol Tanımlamaları**
*   **Gelişmiş Raporlama Panelleri**

  <img width="2559" height="1338" alt="Ekran görüntüsü 2025-09-05 190007" src="https://github.com/user-attachments/assets/6e092150-aece-49f9-877f-e1f2a8383272" />

