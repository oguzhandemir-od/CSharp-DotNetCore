using ATMUygulamasi;

internal class Program
{
    private static void Main(string[] args)
    {
        #region Nesneler
        List<Musteri> musteriler = new List<Musteri>();
        List<Loglar> loglar = new List<Loglar>();
        AtmMakine atm = new AtmMakine { BankaAdi = "Senin Finansın", AtmKodu = 1058, AtmKonumu = "Çankaya" };
        Musteri musteri1 = new Musteri { MusteriNumarasi = "10105566", MusteriSifresi = "123456", MusteriAdi = "Oğuzhan", MusteriSoyadi = "Demir", Bakiye = 20000 };
        Musteri musteri2 = new Musteri { MusteriNumarasi = "10102233", MusteriSifresi = "147852", MusteriAdi = "Berk", MusteriSoyadi = "Güney", Bakiye = 20000 };
        musteriler.Add(musteri1);
        musteriler.Add(musteri2);
        #endregion

        while (true)
        {
            #region İlk Değerler
            string musterino = "";
            string musterisifre = "";
            bool kontrol = true;
            bool noKontrol = true;
            bool sKontrol = true;
            string zaman = "";
            #endregion

            #region ATM Ekranı
            Menu.Giris(atm);
            while (kontrol)
            {
                zaman = DateTime.Now.ToLongTimeString();

                #region Müşteri Numarası Sorgusu
                Console.Write("Müşteri Numarası: ");
                musterino = Console.ReadLine();
                noKontrol = Musteri.MusteriNumarasiKontrol(musterino);
                if (noKontrol)
                {
                    continue;
                }
                #endregion

                #region Müşteri Şifrsi Sorgusu
                Console.Write("Müşteri Şifresi: ");
                musterisifre = Console.ReadLine();
                sKontrol = Musteri.MusteriSifresiKontrol(musterisifre);
                if (sKontrol)
                {
                    continue;
                }
                #endregion

                #region Bilgi Geçerliliği Kontrolü
                bool numaraGecerliMi = Musteri.MusteriVarMi(musteriler, musterino);
                if (numaraGecerliMi)
                {
                    Musteri gecici = Musteri.MusteriBul(musteriler, musterino);
                    if (Musteri.SifreGecerliMi(gecici, musterisifre))
                    {
                        kontrol = true;
                    }
                    else
                    {
                        Console.WriteLine("Hatalı müşteri şifresi.");

                        Loglar logGunSonu = new Loglar();
                        logGunSonu.LogTuru = "HATALI GİRİŞ";
                        logGunSonu.Zaman = $"Saat: {zaman}";
                        logGunSonu.MusteriNumarasi = $"Müşteri Numarası: {gecici.MusteriNumarasi}";
                        logGunSonu.Musteri = $"Müşteri: {gecici.MusteriAdi} {gecici.MusteriSoyadi}";
                        logGunSonu.IslemTuru = "Hatalı Şifre";
                        loglar.Add(logGunSonu);

                        continue;
                    }
                }
                #endregion
                                
                bool iKontrol = true;
                #region Yürütülecek İşlemler
                if (Musteri.MusteriVarMi(musteriler, musterino, musterisifre))
                {

                    zaman = DateTime.Now.ToLongTimeString();
                    Musteri girisYapan = Musteri.MusteriBul(musteriler, musterino);
                    Menu.AtmMenu(girisYapan);

                    Loglar logGunSonu = new Loglar();
                    logGunSonu.LogTuru = "HESAP GİRİŞİ";
                    logGunSonu.Zaman = $"Saat: {zaman}";
                    logGunSonu.MusteriNumarasi = $"Müşteri Numarası: {girisYapan.MusteriNumarasi}";
                    logGunSonu.Musteri = $"Müşteri: {girisYapan.MusteriAdi} {girisYapan.MusteriSoyadi}";
                    loglar.Add(logGunSonu);
                    
                    while (iKontrol)
                    {
                        string secim = Console.ReadLine();

                        Menu.SecimiUygula(secim, atm, girisYapan, musteriler, loglar);
                        if (secim == "6")
                        {
                            iKontrol = false;

                        }
                    }
                }
                else
                {
                    Console.WriteLine("Müşteri bulunamadı.");

                    Loglar logGunSonu = new Loglar();
                    logGunSonu.LogTuru = "BULUNAMAYAN MÜŞTERİ";
                    logGunSonu.Zaman = $"Saat: {zaman}";
                    logGunSonu.MusteriNumarasi = $"Girilen Müşteri Numarası: {musterino}";
                    logGunSonu.IslemTuru = "Müşteri Kayıtlarda Bulunamadı";
                    loglar.Add(logGunSonu);
                    kontrol = true;
                }
                #endregion
            }
            #endregion
        }
    }
}