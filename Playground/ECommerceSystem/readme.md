# 🛒 E-Ticaret Altyapı Prototipi (Performans & Güvenlik Odaklı Backend)

Bu proje, yüksek trafik altında çalışacak kurumsal bir e-ticaret platformunun en kritik iki sütununu (**Güvenlik** ve **Performans**) simüle etmek ve en doğru mimari çözümleri uygulamak adına geliştirilmiş bir laboratuvar çalışmasıdır.

Projede hazır şablonlar veya demode kütüphaneler yerine, modern .NET ekosisteminin en güncel yerel çözümleri tercih edilmiştir.

## 🛠️ Mimari ve Teknolojik Katmanlar

### 1. Katmanlı Mimari Tasarımı (Onion Architecture)
* Proje; bağımlılıkların dışarıdan içeriye doğru aktığı, iş kurallarının (Domain) merkezde kapsüllendiği gevşek bağlı (Loosely Coupled) bir mimari üzerine kurulmuştur.
* **Dependency Injection (DI)** prensibi etkin bir şekilde kullanılarak servislerin sürdürülebilirliği artırılmıştır.

### 2. Token Tabanlı Güvenlik Kalkanı (JWT & Role-Based Security)
* Kullanıcı kimlik doğrulama işlemleri **JWT (JSON Web Token)** ile mühürlenmiştir.
* Rol tabanlı yetkilendirme (Role-Based Authorization) kurgulanarak, kritik aksiyonlar (Örn: Ürün Ekleme/Düzenleme) sadece `Admin` rolüne sahip kullanıcılara asimetrik olarak kısıtlanmıştır.

<img width="2094" height="730" alt="Ekran görüntüsü 2026-06-13 093420" src="https://github.com/user-attachments/assets/f5e4bc12-74aa-498c-968f-8ed6a2430d5e" />


### 3. RAM Tabanlı Dağıtık Önbellekleme (Docker & Redis Caching)
* Veri tabanı (Disk I/O) darboğazlarını engellemek amacıyla **In-Memory** çalışan ultra hızlı **Redis** mimariye entegre edilmiştir.
* Sistem bilgisayarı kirletmeden **Docker Container** sandbox ortamında ayaklandırılmıştır.
* **Cache Strategy:** Sık çağrılan listeleme istekleri Redis üzerinden mikrosaniyeler içinde (RAM'den) döner.
* **Cache Invalidation:** Veri doğruluğunu (Data Consistency) korumak adına, Admin yeni bir ürün eklediği anda RAM'deki eski önbellek anahtarı (`products_list`) otomatik olarak imha edilir (Cache Eviction) ve ilk istekte sistemin en güncel veriyi çekmesi sağlanır.

<img width="1926" height="781" alt="Ekran görüntüsü 2026-06-13 093458" src="https://github.com/user-attachments/assets/ca78b9cb-3a08-4a97-8642-3400337e2044" />
<img width="2101" height="706" alt="Ekran görüntüsü 2026-06-13 093351" src="https://github.com/user-attachments/assets/16f7f112-de65-42c1-85b0-fb5d0fb1d240" />
<img width="2101" height="726" alt="Ekran görüntüsü 2026-06-13 093402" src="https://github.com/user-attachments/assets/f27fb41f-6588-4807-863f-2808b422edc7" />

### 4. Merkezi Hata Yakalama Kalkanı (Global Exception Middleware)
* Kodun hiçbir katmanında çirkin ve güvensiz `try-catch` hamallığına izin verilmemiştir.
* .NET'in modern `IExceptionHandler` arayüzü implemente edilerek merkezi bir hata yakalama filtresi kurulmuştur.
* Sistemde beklenmedik bir teknik hata fırlatıldığında, kalkan hatayı havada yakalar, arka planda güvenle loglar ve son kullanıcıya jilet gibi temiz, standart bir JSON nesnesi döner.

<img width="2096" height="633" alt="Ekran görüntüsü 2026-06-13 093742" src="https://github.com/user-attachments/assets/377737ae-4685-4172-bac8-35ddacb49f72" />

### 5. Modern API Dokümantasyonu (Microsoft OpenAPI & Scalar UI)
* .NET dünyasında geliştirilmesi durdurulan eski *Swashbuckle/Swagger* yerine, Microsoft'un .NET 9 standardı olan yerel **OpenAPI** motoru kullanılmıştır.
* Arayüz tarafında ise hantal yapay render motorları yerine modern, performanslı ve göz yormayan karanlık tema (Dark Mode) desteğine sahip **Scalar UI** tercih edilmiştir.
* OpenAPI boru hattına yazılan özel bir *Document Transformer* sınıfı ile JWT şeması Scalar arayüzüne global bir güvenlik gereksinimi olarak dinamik şekilde enjekte edilmiştir.

<img width="2559" height="1354" alt="Ekran görüntüsü 2026-06-13 092714" src="https://github.com/user-attachments/assets/e49aa47a-67f3-4155-9b2b-60d8c376ea95" />


---
[⬅️ Proje Kataloğuna Dön](..)
