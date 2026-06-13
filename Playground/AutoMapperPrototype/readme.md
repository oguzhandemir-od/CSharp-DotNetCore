# AutoMapper Entegrasyon ve Sürüm Çözüm Prototipi 🔄

Bu prototip çalışma; büyük ölçekli katmanlı mimarilerde sıklıkla karşılaşılan **AutoMapper sürüm uyumsuzlukları**, **Dependency Injection (DI) entegrasyon hataları** ve servis kayıt problemlerinin izole bir laboratuvar ortamında çözülmesi ve en iyi pratiklerin (Best Practices) doğrulanması amacıyla geliştirilmiştir.

## 🎯 Projenin Amacı ve Çözülen Problem
Yazılım geliştirme sürecinde, eski dokümantasyonlar veya deparatör bağımlılıklar nedeniyle `Program.cs` üzerinde `builder.Services.AddAutoMapper(typeof(Program))` veya `MapperConfiguration` yapılandırmaları runtime (çalışma zamanı) veya derleme hatalarına yol açabilmektedir. 

Bu prototipte, harici kütüphane bağımlılıklarını enjekte ederken karşılaşılan konfigürasyon krizleri, **doğrudan jenerik profil kaydı** yöntemiyle aşılmış ve sistem kararlı hale getirilmiştir.

<img width="2104" height="610" alt="Ekran görüntüsü 2026-06-13 102722" src="https://github.com/user-attachments/assets/5a53dd80-f0ed-465e-bfe7-d8ecc971e79e" />

---

## 🛠️ Teknolojik Stack & Yaklaşımlar
*   **Çalışma Ortamı:** .NET Core Web API (Playground / Lab)
*   **Kütüphane:** AutoMapper (Güncel Sürüm Entegrasyonu)
*   **Desenler:** Data Transfer Object (DTO), Dependency Injection (DI), Encapsulation

---

## 🧠 Uygulanan Mimari Çözüm

### 1. Güncel ve Hatasız DI Kaydı
Sistemde Reflection maliyetini azaltmak ve sürüm çakışmalarının önüne geçmek adına `Program.cs` içerisindeki servis ekleme fonksiyonu doğrudan ilgili eşleme profilini (`MappingProfile`) açıkça (explicitly) örnekleyecek şekilde yapılandırılmıştır:


```// En güncel ve hatasız DI kaydı:
builder.Services.AddAutoMapper(cfg => 
{
    cfg.AddProfile<MappingProfile>();
});
```

### 2. Çift Taraflı (Two-Way) Veri Haritalama

Gerçek dünya senaryolarını simüle etmek adına User (Domain Entity) ve UserDto (Veri Taşıma Nesnesi) sınıfları kurgulanmıştır.

Güvenlik: Kullanıcının dış dünyaya açılmaması gereken hassas verileri User nesnesinde izole edilmiş, arayüze sadece UserDto nesnesi taşınmıştır.

Esneklik: Haritalama profilinde ReverseMap() kullanılarak, API'ye gelen isteklerin (Request) Entity'ye dönüştürülmesi ve API'den dönen yanıtların (Response) DTO'ya dönüştürülmesi süreçleri çift taraflı olarak başarıyla test edilmiştir.

<img width="2092" height="689" alt="Ekran görüntüsü 2026-06-13 102804" src="https://github.com/user-attachments/assets/c513be50-2d07-40c9-8777-4e7639995d00" />

### 🧪 Doğrulama ve Test Senaryoları

Sahte Veri (Mock Data) Testi: Bellek üzerinde oluşturulan sahte User listesi API üzerinden talep edilmiş ve yalnızca DTO katmanında izin verilen alanların dış dünyaya sızdığı doğrulanmıştır.

API Veri Girişi Testi: HTTP Post isteği ile doğrudan API ucuna gönderilen ham veri, AutoMapper vasıtasıyla Domain Entity'sine haritalanmış ve veri tutarlılığı eksiksiz sağlanmıştır.

<img width="1981" height="1176" alt="Ekran görüntüsü 2026-06-13 102824" src="https://github.com/user-attachments/assets/5bec0aff-6f61-4531-b324-2bb5602b7fc9" />


### 💡 Kazanımlar

Bu prototip sayesinde edinilen hatasız DI ve haritalama altyapısı, geliştirilmekte olan Modern Kütüphane Yönetim Sistemi ve sonraki modüler mimarili ana projelere (Onion Architecture) doğrudan entegre edilebilir duruma getirilmiştir.
