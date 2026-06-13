# 📝 Görev Yönetimi Altyapı Prototipi (Task Management System)

Bu proje, modern kurumsal yazılım mimarisi standartları olan *Clean Architecture (Onion Architecture)* prensiplerini pekiştirmek, katmanlar arası bağımlılıkları minimuma indirmek ve sürdürülebilir bir backend altyapısı kurgulamak amacıyla geliştirilmiş bir *Web API* prototipidir.

Projede esneklik, test edilebilirlik ve veri güvenliği ön planda tutulmuş; gevşek bağımlılık (*Loose Coupling) ve sorumlulukların ayrılması (Separation of Concerns*) ilkeleri titizlikle uygulanmıştır.

<img width="2537" height="805" alt="Ekran görüntüsü 2026-06-13 110835" src="https://github.com/user-attachments/assets/4a91c3a6-6ba1-4eb1-a269-77aa68cafa1d" />

---

## 🏗️ Mimari Yapı (Onion Architecture)

Proje, geleneksel veritabanı bağımlı (N-Tier) mimarilerin aksine, iş kurallarını (Domain) merkeze alan ve dış dünyadaki (Veritabanı, API, UI) değişimlerden koruyan 4 ana katmandan oluşmaktadır:

1. *Domain (Merkez Katman):* Projenin anayasasıdır. Hiçbir dış katmana bağımlılığı yoktur. TaskItem entity'si, iş kuralları ve Enum yapıları (Status, Priority) bu katmanda yer alır. Veri temizliğini garanti etmek adına *Encapsulation (Kapsülleme)* ilkeleri uygulanmıştır.
2. *Application (İş Mantığı & Sözleşmeler):* Sistemdeki kullanım senaryolarını ve sözleşmeleri barındırır. Repository arayüzleri (ITaskRepository) ve dış dünya ile veri takasını güvenli kılan *DTO (Data Transfer Object)* yapıları bu katmandadır.
3. *Infrastructure (Dış Dünyaya Açılan Kaslar):* Veritabanı ve dış servis entegrasyonlarının yapıldığı katmandır. Veri tabanı teknolojisi *Entity Framework Core* kullanılarak soyutlanmış ve *Repository Pattern* ile sisteme entegre edilmiştir.
4. *WebAPI (Sunum Katmanı):* Uygulamanın dış dünyaya açılan kapısıdır. HTTP protokollerini yönetir, istekleri karşılar ve Dependency Injection (DI) vasıtasıyla Application katmanındaki sözleşmeleri tetikler.

<img width="2138" height="1338" alt="Ekran görüntüsü 2026-06-13 110854" src="https://github.com/user-attachments/assets/c263728f-9541-42d3-983f-e32176eb7ad7" />

---

## 🚀 Öne Çıkan Teknik Pratikler ve Teknolojiler

* *.NET Core & Web API:* Yüksek performanslı asenkron backend mimarisi.
* *Entity Framework Core (Code-First):* Veritabanı yönetiminin kod üzerinden soyutlanarak yürütülmesi.
* *Repository Pattern:* Veritabanı işlemlerinin iş mantığından tamamen yalıtılarak test edilebilirliğin artırılması.
* *DTO (Data Transfer Object) Kullanımı:* API'ye gelen isteklerin güvenli limana alınması, Id veya CreatedDate gibi kritik alanların dışarıdan manipüle edilmesinin engellenmesi.
* *FluentValidation (Request Validation):* İsteklerin henüz Controller'a ulaşmadan kapıda doğrulanması. Hatalı veya geçmiş tarihli görev isteklerinin sisteme yük bindirmeden *HTTP 400 Bad Request* ile reddedilmesi.
* *Global Exception Handling (Merkezi Hata Yönetimi):* Uygulama boru hattının (Request Pipeline) en başına yerleştirilen özel bir *Middleware* sayesinde, sistemde oluşabilecek öngörülemeyen tüm hataların havada yakalanması, loglanması ve dış dünyaya standart bir JSON formatında (ErrorDetails) fırlatılması.

<img width="2126" height="1102" alt="Ekran görüntüsü 2026-06-13 110955" src="https://github.com/user-attachments/assets/a34240d2-6ec6-4956-8898-e1deb3f72b6b" />

---

## 🎯 Kazanımlar

Geleneksel mimarilerdeki "Veritabanına sıkı sıkıya bağımlı olma" probleminden sıyrılıp, veritabanını sadece bir araç olarak konumlandırmayı (Persistence Ignorance) deneyimledim.

Hata ayıklama (Debugging) süreçlerinde, sorumlulukları ayrılmış katmanlar sayesinde hatayı el koymuş gibi (Validation hatası mı, DB hatası mı, API hatası mı) saniyeler içinde bulabilme konforunu kazandım.

try-catch yükünden kurtularak Middleware seviyesinde kurumsal bir hata yönetim mekanizması inşa ettim.
