# FBS-BlogProject (Feature-Based Clean MVC Blog)

Bu proje geliştirilirken, değerli eğitmen [**Murat Yücedağ**](https://www.udemy.com/course/kurumsal-mimaride-mvc5-ile-blog-projesi-gelistirelim)'ın güncel kurumsal mimari eğitimindeki temel veri şeması, ilişkisel kurgu ve iş senaryoları referans alınmıştır.

Geleneksel spagetti MVC yapılarının ve katman enflasyonunun ötesine geçerek, **Feature-Based Structure (Özellik Tabanlı Yapı)** ve **Clean MVC** prensipleriyle geliştirilmiş modern bir Blog platformudur. Proje, mimari sürdürülebilirlik, veri gizliliği ve yüksek kullanıcı deneyimi (UX) odaklı hibrit bir SPA yaklaşımı sunmaktadır.

<img width="2535" height="1345" alt="resim" src="https://github.com/user-attachments/assets/aad974a0-84e5-4dac-b53a-ad38f4b7ed74" />


## 🏗️ Mimari ve Tasarım Yaklaşımları

### 1. Feature-Based Structure (FBS) & Clean MVC
Klasik katmanlı mimarilerdeki teknik ayrım (`Controllers`, `Services`, `Repositories`) yerine; kod tabanı işlevsel özelliklere göre dikey olarak organize edilmiştir. Bu sayede her özelliğin (Feature) kendi kuralları, DTO'ları ve sunum mantığı bir arada yaşar. Cohesion (bağlılık) artarken, Coupling (bağımlılık) minimuma indirilmiştir.

### 2. Güvenli Veri Akışı & Kapsülleme
* **DTO Tabanlı Veri Aktarımı:** Sunum katmanı ile veri tabanı varlıkları (Entities) tamamen izole edilmiştir. Veri aktarımı istisnasız bir şekilde DTO'lar (Data Transfer Objects) üzerinden gerçekleştirilir.
* **Veri Gizliliği (Data Privacy):** Admin rolü dahil hiç kimse kullanıcıların e-posta ve şifre gibi hassas kişisel verilerini göremez veya değiştiremez. Admin sadece kullanıcı adı güncelleyebilir ve rol yönetebilir.

### 3. Esnek Rol Yönetimi (RBAC)
Sistemde `Admin` ve `Author` ayrı birer entity değil, tek bir `User` yapısına bağlı **Rollerdir**.
* **Admin:** Tüm sisteme tam erişim. Kullanıcılara yazar rolü atama/geri alma yetkisi. *Güvenlik önlemi olarak sistem adminin kendisini veya rolünü silmesini engeller.* Girişte özel bir Dashboard'a sahiptir.
* **Yazar (Author):** Yalnızca kendi oluşturduğu postlar ve bu postlara gelen yorumlar üzerinde tam CRUD ve onay/ret yetkisine sahiptir.

<img width="2547" height="858" alt="resim" src="https://github.com/user-attachments/assets/83ba2870-0a9b-434f-816b-565f681b30ae" />
<img width="2559" height="781" alt="resim" src="https://github.com/user-attachments/assets/c99cb1e4-1819-41a9-8707-c5c170a6bd79" />


---

## 🛠️ Teknik Özellikler

* **Framework:** .NET Core MVC
* **Kimlik Doğrulama & Yetkilendirme:** Cookie-Based Authentication & Role-Based Authorization.
* **Doğrulama (Validation):** FluentValidation entegrasyonu ile merkezi ve deklaratif girdi kontrolü.
* **Hata Yönetimi:** Global Exception Handling middleware'i ile uygulamanın çökmesi engellenerek tüm hatalar merkezi olarak yönetilir.

---

## 🎨 Ön Yüz Dünyası & Hibrit SPA Yaklaşımı (UX/UI)

Kullanıcı, yazar ve admin deneyimini en üst seviyeye çıkarmak için statik sayfa yenileme hantallığından kaçınılmıştır:

* **Hybrid SPA (Single Page Application) Deneyimi:** Kategori ve yorum yönetimi ekranları, kullanıcıyı yeni bir sayfaya yönlendirmeden (post-view olmadan) liste ekranı üzerinde **Modal'lar** ve **Accordion** yapıları ile çözülür. Sayfa içi asenkron eylemler sayesinde HTML render maliyeti düşürülmüş ve akıcı bir UX sağlanmıştır.
<img width="1975" height="910" alt="resim" src="https://github.com/user-attachments/assets/f84c5d73-0132-462f-88fd-cd832805c091" />
<img width="822" height="420" alt="resim" src="https://github.com/user-attachments/assets/39db75d6-40be-4ee0-8796-b019bc7da3db" />

* **Hızlı Giriş Modalı:** Kullanıcı girişi için ekstra bir sayfaya gitme zorunluluğu ortadan kaldırılmış, ufak bir modal üzerinden authentication sağlanmıştır. (Yönlendirme mekanizması admin/yazar panelleri için alternatif olarak korunmuştur).

<img width="1156" height="897" alt="resim" src="https://github.com/user-attachments/assets/054eb0aa-4c4e-4f00-b731-cf6d6f50f70c" />

* **Karanlık Mod (Dark Mode):** Hem ziyaretçi blog tarafında hem de Admin/Yazar yönetim panellerinde tam entegre karanlık mod desteği mevcuttur.

<img width="2536" height="1225" alt="resim" src="https://github.com/user-attachments/assets/71704881-664f-4edb-b81f-4c6bd971cc22" />
<img width="2536" height="871" alt="resim" src="https://github.com/user-attachments/assets/cf2d2eb6-232e-4459-85c7-55420c83fe42" />


---

## 📊 Veri Modeli ve İlişkiler

* **User:** Sistemdeki tüm kullanıcıları, yazarları ve admini temsil eder.
* **Post (Blog Yazısı):** Her post bir kategoriye ve bir yazara (User) aittir.
* **Category:** Postların gruplandırılmasını sağlar (1-to-Many).
* **Comment:** Herkes (giriş yapmayan ziyaretçiler dahil) postlara yorum yapabilir. Yorumlar, ilgili postun altında hiyerarşik olarak listelenir ve admin/yazar onay mekanizmasından geçer.

> **Not:** `About` ve `Contact` yapıları entity ve veritabanı şeması olarak projeye dahil edilmiş olup, dinamik yönetim süreçleri gelecek fazlarda geliştirilmek üzere saklı tutulmuştur.

---
