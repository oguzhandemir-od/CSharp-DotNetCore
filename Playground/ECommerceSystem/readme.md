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

### 3. RAM Tabanlı Dağıtık Önbellekleme (Docker & Redis Caching)
* Veri tabanı (Disk I/O) darboğazlarını engellemek amacıyla **In-Memory** çalışan ultra hızlı **Redis** mimariye entegre edilmiştir.
* Sistem bilgisayarı kirletmeden **Docker Container** sandbox ortamında ayaklandırılmıştır.
* **Cache Strategy:** Sık çağrılan listeleme istekleri Redis üzerinden mikrosaniyeler içinde (RAM'den) döner.
* **Cache Invalidation:** Veri doğruluğunu (Data Consistency) korumak adına, Admin yeni bir ürün eklediği anda RAM'deki eski önbellek anahtarı (`products_list`) otomatik olarak imha edilir (Cache Eviction) ve ilk istekte sistemin en güncel veriyi çekmesi sağlanır.

### 4. Merkezi Hata Yakalama Kalkanı (Global Exception Middleware)
* Kodun hiçbir katmanında çirkin ve güvensiz `try-catch` hamallığına izin verilmemiştir.
* .NET'in modern `IExceptionHandler` arayüzü implemente edilerek merkezi bir hata yakalama filtresi kurulmuştur.
* Sistemde beklenmedik bir teknik hata fırlatıldığında, kalkan hatayı havada yakalar, arka planda güvenle loglar ve son kullanıcıya jilet gibi temiz, standart bir JSON nesnesi döner.

### 5. Modern API Dokümantasyonu (Microsoft OpenAPI & Scalar UI)
* .NET dünyasında geliştirilmesi durdurulan eski *Swashbuckle/Swagger* yerine, Microsoft'un .NET 9 standardı olan yerel **OpenAPI** motoru kullanılmıştır.
* Arayüz tarafında ise hantal yapay render motorları yerine modern, performanslı ve göz yormayan karanlık tema (Dark Mode) desteğine sahip **Scalar UI** tercih edilmiştir.
* OpenAPI boru hattına yazılan özel bir *Document Transformer* sınıfı ile JWT şeması Scalar arayüzüne global bir güvenlik gereksinimi olarak dinamik şekilde enjekte edilmiştir.

---
[⬅️ Proje Kataloğuna Dön](..)
