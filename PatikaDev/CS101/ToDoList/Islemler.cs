using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList;

namespace ToDoUygulama
{
    internal class Islemler
    {
        public static void KartEkle()
        {
            Console.WriteLine("Kart Ekleme");
            Console.WriteLine("-----------");
            Line line = Line.Basla();

            while (true)
            {
                Console.Write("Başlık Giriniz: ");
                string baslik = Console.ReadLine();
                Console.Write("İçerik Giriniz: ");
                string icerik = Console.ReadLine();
                Console.Write("Büyüklük Seçiniz -> XS(1),S(2),M(3),L(4),XL(5): ");
                string buyukluk = Kart.KartBuyuklugu();
                Console.Write("Kişi Seçiniz (ID - 110,120,130,140,150): ");
                int atananKisi = Convert.ToInt32(Console.ReadLine());
                if (!Kontrol.IDKontrol(atananKisi))
                {
                    continue;
                }
                Kart yeniKart = new Kart(baslik, icerik, buyukluk, atananKisi);
                line.Todoline.Add(yeniKart);
                Console.WriteLine($"{baslik} kartı başarıyla eklendi.");
                break;
            }
        }
        public static void KartSil()
        {
            Console.WriteLine("Kart Silme");
            Console.WriteLine("----------");
            Line line = Line.Basla();

            while (true)
            {
                Console.Write("Silmek istediğiniz kart başlığını giriniz: ");

                while (true)
                {
                    string bilgi = Console.ReadLine();
                    List<Kart> silinecekKartlar = KartAra(bilgi);
                    if (silinecekKartlar == null)
                    {
                        return;
                    }
                    else if (silinecekKartlar.Count==0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine();
                        foreach (var s in silinecekKartlar)
                        {
                            Console.WriteLine($"'{s.Baslik}' kartı silinecektir.");
                        }

                        Console.WriteLine("Silme işlemlerini onaylıyor musunuz? (Y/N)");
                        string onay = Console.ReadLine();
                        if (onay.ToUpper() == "Y")
                        {
                            foreach (var s in silinecekKartlar)
                            {
                                line.Todoline.Remove(s);
                                line.Inprogressline.Remove(s);
                                line.Doneline.Remove(s);
                                Console.WriteLine($"'{s.Baslik}' kartı başarıyla silinmiştir.");
                            }
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
        public static void KartGuncelle()
        {
            Console.WriteLine("Kart Güncelleme");
            Console.WriteLine("---------------");
            Line line = Line.Basla();

            while (true)
            {
                Console.Write("Güncellemek istediğiniz kart başlığını giriniz: ");
                string bilgi = Console.ReadLine();
                List<Kart> guncellenecekKart = KartAra(bilgi);
                if (guncellenecekKart == null)
                {
                    return;
                }
                else if (guncellenecekKart.Count == 0)
                {
                    break;
                }
                else
                {
                    Console.Write("Yeni Kart Başlığı: ");
                    string yeniBaslik = Console.ReadLine();
                    Console.Write("Yeni Kart İçeriği: ");
                    string yeniIcerik = Console.ReadLine();
                    Console.Write("Yeni Kart Büyüklüğü -> XS(1),S(2),M(3),L(4),XL(5): ");
                    string yeniBuyukluk = Kart.KartBuyuklugu();
                    Console.Write("Yeni Atanan Kişi (ID - 110,120,130,140,150): ");
                    int yeniAtananKisi = Convert.ToInt32(Console.ReadLine());
                    if (!Kontrol.IDKontrol(guncellenecekKart[0].AtananKisiID))
                    {
                        continue;
                    }
                    Console.WriteLine("Kartın güncellenmesi yeni bilgilerle gerçekleştirilecektir. Onaylıyor musunuz? (Y/N)");
                    string onay = Console.ReadLine();
                    if (onay.ToUpper() == "Y")
                    {
                        guncellenecekKart[0].Baslik = yeniBaslik;
                        guncellenecekKart[0].Icerik = yeniIcerik;
                        guncellenecekKart[0].Buyukluk = yeniBuyukluk;
                        guncellenecekKart[0].AtananKisiID = yeniAtananKisi;
                        Console.WriteLine("Kart güncelleme işlemi başarıyla gerçekleştirildi.");
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
        public static void KartTasi()
        {
            Console.WriteLine("Kart Taşıma");
            Console.WriteLine("-----------");
            Line line = Line.Basla();

            while (true)
            {
                Console.Write("Taşımak istediğiniz kart başlığını giriniz: ");

                while (true)
                {
                    string bilgi = Console.ReadLine();
                    List<Kart> tasinacakKart = KartAra(bilgi);
                    int linetipi = tasinacakKart[0].Linetipi;

                    if (tasinacakKart == null)
                    {
                        return;
                    }
                    else if (tasinacakKart.Count == 0)
                    {
                        break;
                    }
                    else
                    {
                        foreach (var s in tasinacakKart)
                        {
                            switch (linetipi)
                            {
                                case 1:
                                    Console.WriteLine($"Line: TODO");
                                    Console.WriteLine();
                                    break;
                                case 2:
                                    Console.WriteLine($"Line: IN PROGRESS");
                                    Console.WriteLine();
                                    break;
                                case 3:
                                    Console.WriteLine($"Line: DONE");
                                    Console.WriteLine();
                                    break;
                                default:
                                    break;
                            }

                            Console.WriteLine($"{s.Baslik} kartı taşınacaktır.");

                        }
                        Console.WriteLine("Lütfen taşımak istediğiniz Line'ı seçiniz: (1) TODO (2) IN PROGRESS (3) DONE");
                        string tasi = Console.ReadLine();
                        switch (linetipi)
                        {
                            case 1:
                                line.Todoline.Remove(tasinacakKart[0]);
                                break;
                            case 2:
                                line.Inprogressline.Remove(tasinacakKart[0]);
                                break;
                            case 3:
                                line.Doneline.Remove(tasinacakKart[0]);
                                break;
                            default:
                                break;
                        }
                        switch (tasi)
                        {
                            case "1":
                                tasinacakKart[0].Linetipi = 1;
                                line.Todoline.Add(tasinacakKart[0]);
                                break;
                            case "2":
                                tasinacakKart[0].Linetipi = 2;
                                line.Inprogressline.Add(tasinacakKart[0]);
                                break;
                            case "3":
                                tasinacakKart[0].Linetipi = 3;
                                line.Doneline.Add(tasinacakKart[0]);
                                break;
                            default:
                                Console.WriteLine("Geçersiz giriş. Lütfen tekrar deneyin.");
                                break;
                        }

                        Console.WriteLine($"{tasinacakKart[0].Baslik} kartı başarılı bir şekilde taşınmıştır.");
                        break;
                    }
                }
                break;
            }

        }
        public static void BoardListele()
        {
            Console.WriteLine("Board Listesi");
            Console.WriteLine("-------------");
            Line line = Line.Basla();

            Console.WriteLine("TODO LINE");
            Console.WriteLine("*******************");
            if (line.Todoline.Count == 0)
                Console.WriteLine("- BOŞ -");
            foreach (var s in line.Todoline)
            {
                KartYazdir(s);
            }
            Console.WriteLine();
            Console.WriteLine("IN PROGRESS LINE");
            Console.WriteLine("*******************");
            if (line.Inprogressline.Count == 0)
                Console.WriteLine("- BOŞ -");
            foreach (var s in line.Inprogressline)
            {
                KartYazdir(s);
            }
            Console.WriteLine();
            Console.WriteLine("DONE LINE");
            Console.WriteLine("*******************");
            if (line.Doneline.Count == 0)
                Console.WriteLine("- BOŞ -");
            foreach (var s in line.Doneline)
            {
                KartYazdir(s);
            }
        }
        public static List<Kart> KartAra(string baslik)
        {
            Line line = Line.Basla();
            List<Kart> aramaSonuclari = new List<Kart>();
            bool kontrol = false;
            //line.Todoline.Sort();
            //line.Inprogressline.Sort();
            //line.Doneline.Sort();
            while (true)
            {
                foreach (var b in line.Todoline)
                {
                    string baslikKucuk = b.Baslik.ToLower();

                    if (baslikKucuk.Contains(baslik))
                    {
                        KartYazdir(b);
                        aramaSonuclari.Add(b);
                        kontrol = true;
                    }
                }
                foreach (var b in line.Inprogressline)
                {
                    string baslikKucuk = b.Baslik.ToLower();

                    if (baslikKucuk.Contains(baslik))
                    {
                        KartYazdir(b);
                        aramaSonuclari.Add(b);
                        kontrol = true;
                    }
                }
                foreach (var b in line.Doneline)
                {
                    string baslikKucuk = b.Baslik.ToLower();

                    if (baslikKucuk.Contains(baslik))
                    {
                        KartYazdir(b);
                        aramaSonuclari.Add(b);
                        kontrol = true;
                    }
                }

                if (!kontrol)
                {
                    Console.WriteLine("Aradığınız kart bulunamadı! Lütfen bir seçim yapınız: ");
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
        public static void KartYazdir(Kart kart)
        {
            Line line = Line.Basla();

            Console.WriteLine($"\nBaşlık:      {kart.Baslik}");
            Console.WriteLine($"İçerik:      {kart.Icerik}");
            Console.WriteLine($"Büyüklük:    {kart.Buyukluk}");
            Console.WriteLine($"Atanan Kişi: {Kart.AtananKisiler1[kart.AtananKisiID]}");
        }

    }
}
