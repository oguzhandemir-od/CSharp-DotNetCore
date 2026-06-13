# xUnit ve Moq ile İş Mantığı (Business Logic) Test Prototipi 🧪

Bu prototip çalışma; .NET Core ekosisteminde **Unit Test (Birim Testi)** kültürünü oturtmak, katmanlı mimarilerde veri tabanı bağımlılıklarını izole etmek ve projeler için tekrar kullanılabilir (Lego benzeri) bir test mimarisi şablonu oluşturmak amacıyla tasarlanmıştır.

## 🎯 Projenin Amacı ve Çözümü
Gerçek dünya projelerinde iş mantığını (Business Logic) test ederken, testlerin veri tabanına bağımlı olması (veri yazıp silmesi) testlerin yavaşlamasına ve kırılganlaşmasına neden olur. 

Bu prototipte, **Repository Pattern** arayüzleri **Moq** kütüphanesi yardımıyla taklit (mock) edilerek, veri tabanından tamamen bağımsız, sadece iş kurallarına ve nesne durumlarına (object state) odaklanan, milisaniyeler içinde çalışan test senaryoları kurgulanmıştır.
<img width="2020" height="1179" alt="Ekran görüntüsü 2026-06-13 095406" src="https://github.com/user-attachments/assets/282525d7-1060-40d4-ab66-03009590c384" />

---

## 🛠️ Teknolojik Stack & Standartlar
*   **Geliştirme Ortamı:** .NET Core Web API & xUnit Test Project
*   **Test Araçları:** Moq (Mocking Framework)
*   **Test Tasarım Deseni:** AAA (Arrange - Act - Assert) Standardı

---

## 🧠 Test Senaryosu ve İş Kuralları (Business Rules)

Prototip, bir **Ürün Stok Yönetimi** senaryosu üzerinden ilerlemektedir. `Product` sınıfı içindeki stok değişim mantığı ve kritik stok eşiği (`IsCriticalStock`) test edilmektedir.

### Uygulanan AAA (Arrange, Act, Assert) Standardı:
*   **Arrange (Düzenleme):** Test ortamı hazırlanır. Sahte veri oluşturulur ve `Moq` ile `IProductRepository`'nin o sahte veriyi döneceği kuralı (`Setup`) koyulur.
*   **Act (Eyleme Geçme):** Test edilecek olan asıl metot (Örn: `DeductStock`) çağrılır.
*   **Assert (Doğrulama):** Çıkan sonucun, beklenen sonuçla uyuşup uyuşmadığı (`Assert.Equal`, `Assert.True`) kontrol edilir.

---

## 🧪 Doğrulanan Senaryolar

1.  **SuccessfulStockDeduction_ShouldDecreaseStock:** Stokta yeterli ürün varken satış yapıldığında, stok miktarının doğru oranda düştüğü ve kritik eşiğin (`< 5`) aşılmadığı doğrulanır.
2.  **LowStock_ShouldTriggerCriticalStockFlag:** Satış sonrasında stok miktarı kritik seviyenin (5 adet) altına düştüğünde, entity içindeki `IsCriticalStock` bayrağının otomatik olarak `true` durumuna geçtiği doğrulanır.

---

## 💡 Bir Şablon Olarak Nasıl Kullanılır?
Bu repo, geliştirilen diğer projelerde (Task Management, Kütüphane Otomasyonu vb.) ihtiyaç duyulan servis ve repository testleri için bir **base şablon** niteliğindedir. Test projesinin mimari kurulumu, bağımlılıkların mocklanma yöntemi ve isimlendirme standartları kopyalanarak yeni test sınıflarına doğrudan uygulanabilir.
