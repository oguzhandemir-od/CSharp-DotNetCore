using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi
{
    internal class Islemler
    {
        #region Menü İşlevleri
        public static void KisiKaydet()
        {
            Console.WriteLine("Yeni Kişi Kaydı");
            Console.WriteLine("---------------");
            Kisi kisi = Kisi.Basla();
            Rehber rehber = Rehber.Basla();

            while (true)
            {
                Console.Write("Lütfen isim giriniz: ");
                string isim = Console.ReadLine();

                Console.Write("Lütfen soyisim giriniz: ");
                string soyisim = Console.ReadLine();

                Console.Write("Lütfen telefon numarası giriniz: 05");
                string numara = Console.ReadLine();
                numara = "05" + kisi.Numara;

                if(!Kontrol.YazimKontrol())
                {
                    continue;
                }

                Kisi yeniKayit = new Kisi(isim, soyisim, numara);
                rehber.Kayitlar.Add(yeniKayit);
                Console.WriteLine("Kişi rehbere başarıyla kaydedildi.");
                break;
            }
        }
        public static void KisiSil()
        {
            Console.WriteLine("Kişi Silme");
            Console.WriteLine("----------");
            Kisi kisi = Kisi.Basla();
            Rehber rehber= Rehber.Basla();

            while (true)
            {
                Console.Write("Silmek istediğiniz kişinin ismini veya soyismini giriniz: ");

                string bilgi = Console.ReadLine();
                if (!Kontrol.AramaKontrol(bilgi))
                {
                    continue;
                }

                while (true)
                {
                    List<Kisi> silinecekKisi = KisiAra(bilgi);
                    if (silinecekKisi == null)
                    {
                        return;
                    }
                    else if (silinecekKisi.Count==0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"'{silinecekKisi[0].Isim} {silinecekKisi[0].Soyisim}' kişisi silinecektir, onaylıyor musunuz? (Y/N)");
                        string onay = Console.ReadLine();
                        if (onay.ToUpper() == "Y")
                        {
                            rehber.Kayitlar.Remove(silinecekKisi[0]);
                            Console.WriteLine($"'{silinecekKisi[0].Isim} {silinecekKisi[0].Soyisim}' kişisi başarıyla silinmiştir.");
                            return;
                        }
                        else if (onay.ToUpper() == "N")
                        {
                            Console.WriteLine("Silme işlemi iptal edildi.");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz giriş. Lütfen tekrar deneyin.");
                        }
                    }

                }

            }
        }
        public static void KisiGuncelle()
        {
            Console.WriteLine("Kişi Bilgileri Güncelleme");
            Console.WriteLine("-------------------------");
            Kisi kisi = Kisi.Basla();

            while (true)
            {
                Console.Write("Güncellemek istediğiniz kişinin ismini veya soyismini giriniz: ");

                string bilgi = Console.ReadLine();
                if (!Kontrol.AramaKontrol(bilgi))
                {
                    continue;
                }
                while (true)
                {
                    List<Kisi> guncellenecekKisi = KisiAra(bilgi);
                    if (guncellenecekKisi == null)
                    {
                        return;
                    }
                    else if (guncellenecekKisi.Count==0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"'{guncellenecekKisi[0].Isim} {guncellenecekKisi[0].Soyisim}' kişisi güncellenecektir.");
                        Console.Write("Lütfen yeni ismi giriniz: ");
                        string yeniIsim = Console.ReadLine();

                        Console.Write("Lütfen yeni soyismi giriniz: ");
                        string yeniSoyisim = Console.ReadLine();

                        Console.Write("Lütfen yeni telefon numarasını giriniz: 05");
                        string yeniNumara = Console.ReadLine();
                        yeniNumara = "05" + kisi.Numara;

                        if (!Kontrol.YazimKontrol())
                        {
                            continue;
                        }
                        guncellenecekKisi[0].Isim = yeniIsim;
                        guncellenecekKisi[0].Soyisim = yeniSoyisim;
                        guncellenecekKisi[0].Numara = yeniNumara;
                        Console.WriteLine("Kişi bilgisi başarıyla güncellendi.");
                        return;
                    }
                }

            }
        }
        public static void KisiListele()
        {
            Kisi kisi = Kisi.Basla();
            Rehber rehber = Rehber.Basla();

            Console.WriteLine("Rehberdeki kişileri nasıl sıralamak istiyorsunuz?");
            while (true)
            {
                Console.WriteLine("A-Z Sıralı: (1)");
                Console.WriteLine("Z-A Sıralı: (2)");
                string s = Console.ReadLine();
                if (s == "1")
                {
                    Console.WriteLine("Rehberdeki Kişiler (A-Z)");
                    Console.WriteLine("------------------");
                    rehber.Kayitlar.Sort((s1,s2)=>s1.Isim.CompareTo(s2.Isim));
                    foreach (var k in rehber.Kayitlar)
                    {
                        KisiYazdir(k);
                    }
                    break;
                }
                else if (s == "2")
                {
                    Console.WriteLine("Rehberdeki Kişiler (Z-A)");
                    Console.WriteLine("------------------");
                    rehber.Kayitlar.Sort((s1, s2) => s1.Isim.CompareTo(s2.Isim));
                    rehber.Kayitlar.Reverse();
                    foreach (var k in rehber.Kayitlar)
                    {
                        KisiYazdir(k);
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Geçersiz giriş. Lütfen tekrar deneyin.");
                }
            }
            
        }
        public static void KisiAra()
        {
            Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.");
            
            Kisi kisi = Kisi.Basla();
            Rehber rehber = Rehber.Basla();
            bool kontrol = false;
            rehber.Kayitlar.Sort((s1, s2) => s1.Isim.CompareTo(s2.Isim));
            while (true)
            {
                Console.WriteLine("İsim veya soyisime göre arama yapmak için: (1)");
                Console.WriteLine("Telefon numarasına göre arama yapmak için: (2) ");
                string secim = Console.ReadLine();
                if (secim == "1")
                {
                    while (true)
                    {
                        Console.Write("Aramak istediğiniz kişinin isim veya soyismini giriniz: ");
                        string kisiBilgi = Console.ReadLine();
                        if(!Kontrol.AramaKontrol(kisiBilgi))
                        {
                            continue;
                        }
                        else
                        {
                            foreach (var kayit in rehber.Kayitlar)
                            {
                                string kucukIsim = kayit.Isim.ToLower();
                                string kucukSoyisim = kayit.Soyisim.ToLower();

                                if (kucukIsim.Contains(kisiBilgi)||kucukSoyisim.Contains(kisiBilgi))
                                {
                                    KisiYazdir(kayit);
                                    kontrol = true;
                                }
                            }

                            if (!kontrol)
                            {
                                Console.WriteLine("Aradığınız kişi bulunamadı! Lütfen bir seçim yapınız: ");
                                if (!Kontrol.BulunamadiSecim())
                                {
                                    return;
                                }
                                else
                                {
                                    continue;
                                }

                            }
                            break;
                        }
                    }
                }
                else if (secim == "2")
                {
                    while (true)
                    {
                        Console.Write("Aramak istediğiniz kişinin numarasını giriniz: ");

                        string numara = Console.ReadLine();
                        if (!Kontrol.HepsiNumaraMi(numara))
                        {
                            Console.WriteLine("Telefon numarası yalnızca rakamlardan oluşmalıdır!");
                            continue;
                        }
                        else
                        {
                            foreach (var s in rehber.Kayitlar)
                            {
                                if (s.Numara.Contains(numara))
                                {
                                    KisiYazdir(s);
                                    kontrol = true;
                                }
                            }
                            if (!kontrol)
                            {
                                Console.WriteLine("Aradığınız numara bulunamadı! Lütfen bir seçim yapınız: ");
                                if (!Kontrol.BulunamadiSecim())
                                {
                                    return;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            break;
                        }

                    }
                }
                else
                {
                    Console.WriteLine("Geçersiz giriş. Lütfen tekrar deneyin.");
                    continue;
                }
                break;
            }
            

        }
        #endregion

        #region Ara İşlevler
        public static List<Kisi> KisiAra(string kisiBilgi)
        {
            Kisi kisi = Kisi.Basla();
            Rehber rehber = Rehber.Basla();
            List<Kisi> aramaSonuclari = new List<Kisi>();
            bool kontrol = false;
            rehber.Kayitlar.Sort((s1, s2) => s1.Isim.CompareTo(s2.Isim));

            while (true)
            {
                foreach (var kayit in rehber.Kayitlar)
                {
                    string kucukIsim = kayit.Isim.ToLower();
                    string kucukSoyisim = kayit.Soyisim.ToLower();

                    if (kucukIsim.Contains(kisiBilgi)||kucukSoyisim.Contains(kisiBilgi))
                    {
                        KisiYazdir(kayit);
                        aramaSonuclari.Add(kayit);
                        kontrol = true;
                    }
                }
                Console.WriteLine();
                if (!kontrol)
                {
                    Console.WriteLine("Aradığınız kişi bulunamadı! Lütfen bir seçim yapınız: ");
                    if (!Kontrol.BulunamadiSecim())
                    {
                        return null;
                    }
                    else
                    {
                        return aramaSonuclari;
                    }
                }
                return aramaSonuclari;
            }

        }
        public static void KisiYazdir(Kisi kayit)
        {
            Console.WriteLine($"İsim: {kayit.Isim,-10} Soyisim: {kayit.Soyisim,-10} Numara: {TelefonFormati(kayit.Numara),-15}");
        }
        public static string TelefonFormati(string numara)
        {
            string duzenlenenNumara = string.Format("0({0}) {1}-{2}-{3}",
                            numara.Substring(1, 3),
                            numara.Substring(4, 3),
                            numara.Substring(7, 2),
                            numara.Substring(9, 2));
            
            return duzenlenenNumara;
        }
        #endregion

    }
}
