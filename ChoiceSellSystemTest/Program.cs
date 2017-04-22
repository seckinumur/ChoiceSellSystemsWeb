using ChoiceSellSystems.Entity.DBContext;
using ChoiceSellSystems.Entity.Models;
using ChoiceSellSystems.Entity.ViewModels;
using ChoiceSellSysytems.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChoiceSellSystemTest
{
    class Program
    { 
        public static void SıfırdanVeritabaniOlusturma()
        {
            using (DataDb db = new DataDb())
            {
                Kategori k1 = new Kategori();
                k1.KategoriAdi = "Köpek";

                db.Kategori.Add(k1);
                db.SaveChanges();

                Kategori k2 = new Kategori();
                k2.KategoriAdi = "Kedi";

                db.Kategori.Add(k2);
                db.SaveChanges();

                Kategori k3 = new Kategori();
                k3.KategoriAdi = "Kuş";

                db.Kategori.Add(k3);
                db.SaveChanges();

                Kategori k4 = new Kategori();
                k4.KategoriAdi = "Balık";

                db.Kategori.Add(k4);
                db.SaveChanges();

                Kategori k5 = new Kategori();
                k5.KategoriAdi = "Kemirgen";

                db.Kategori.Add(k5);
                db.SaveChanges();

                UrunKategori uk1 = new UrunKategori();
                uk1.UrunKategoriAdı = "Köpek Maması";
                uk1.KategoriID = 1;

                db.UrunKategori.Add(uk1);
                db.SaveChanges();

                UrunKategori uk2 = new UrunKategori();
                uk2.UrunKategoriAdı = "Kedi Maması";
                uk2.KategoriID = 2;

                db.UrunKategori.Add(uk2);
                db.SaveChanges();

                Uruncinsi uc1 = new Uruncinsi();
                uc1.Cinsi = "Yavru Köpek Maması (3 ay - 12 ay arası)";
                uc1.UrunKategoriID = 1;

                db.Uruncinsi.Add(uc1);
                db.SaveChanges();

                Uruncinsi uc2 = new Uruncinsi();
                uc2.Cinsi = "Yavru Kedi Mamaları (0-12 Ay)";
                uc2.UrunKategoriID = 2;

                db.Uruncinsi.Add(uc2);
                db.SaveChanges();

                Urun urunekle = new Urun();
                urunekle.Gramaj = "15KG";
                urunekle.Image = "/images/Sample/SampleUrun.png";
                urunekle.Indirim = "263,50";
                urunekle.IndirimVarmi = true;
                urunekle.KategoriID = 1;
                urunekle.UrunAciklama = "Royal Canin Maxi Junior Yavru Köpek Maması 15 KG + 21 Cm Kemik HEDİYELİ";
                urunekle.UrunAdi = "Royal Canin";
                urunekle.UruncinsiID = 1;
                urunekle.UrunFiyati = "310,00";
                urunekle.UrunKategoriID = 1;

                db.Urun.Add(urunekle);
                db.SaveChanges();
                Console.WriteLine("\n Veritabanı Başarıyla Oluşturuldu!");
                Console.WriteLine("\n Devam Etmek İçin Bir Tuşa Basın");
                Console.ReadKey();
            }
        }

        public static void UrunEkle()
        {
            using (DataDb db = new DataDb())
            {
                Urun urunekle = new Urun();
                urunekle.Gramaj = "15KG";
                urunekle.Image = "/images/Sample/SampleUrun.png";
                urunekle.Indirim = "-%15";
                urunekle.IndirimVarmi = true;
                urunekle.KategoriID = 1;
                urunekle.UrunAciklama = "Büyük ırk köpeklerin 2-15 aylık yavruları için özel olarak geliştirilen bu mama, yavru köpeklerin gelecekte daha sağlıklı ve enerjik olabilmeleri için en uygun içerikle hazırlanmaktadır. ";
                urunekle.UrunAdi = "Royal Canin";
                urunekle.UruncinsiID = 1;
                urunekle.UrunFiyati = "263,50";
                urunekle.UrunKategoriID = 1;

                db.Urun.Add(urunekle);
                db.SaveChanges();
                Console.WriteLine("\n Deneme Ürünü Oluşturuldu!");
                Console.WriteLine("\n Devam Etmek İçin Bir Tuşa Basın");
                Console.ReadKey();
            }
        }
        public static void Rapor()
        {
            using (DataDb db = new DataDb())
            {
                try
                {
                    var a = db.Kullanici.ToList();
                    var b = db.Kategori.ToList();
                    var c = db.UrunKategori.ToList();
                    var d = db.Uruncinsi.ToList();
                    var e = db.Urun.ToList();
                    Console.WriteLine("\n Kullanıcılar Listesi");
                    foreach (var item in a)
                    {
                        Console.WriteLine("\r Kullanıcı Adı: " + item.Adi + " Şifresi: " + item.Sifre);
                    }
                    Console.WriteLine("\n Kullanıcılar Listesi Tamamlandı!");
                    Console.WriteLine("\n Kategoriler Listesi");
                    foreach (var item in b)
                    {
                        Console.WriteLine("\r Kategori ID: " + item.KategoriID + " Kategori Adı: " + item.KategoriAdi);
                    }
                    Console.WriteLine("\n Kategoriler Listesi Tamamlandı!");
                    Console.WriteLine("\n Ürün Kategori Listesi");
                    foreach (var item in c)
                    {
                        Console.WriteLine("\r Ürün Kategori ID: " + item.UrunKategoriID + " Ürün Kategori Adı: " + item.UrunKategoriAdı);
                    }
                    Console.WriteLine("\n Ürün Kategoriler Listesi Tamamlandı!");
                    Console.WriteLine("\n Ürün Cinsi Listesi");
                    foreach (var item in d)
                    {
                        Console.WriteLine("\r Ürün Cinsi ID: " + item.UruncinsiID + " Ürün Cinsi Adı: " + item.Cinsi);
                    }
                    Console.WriteLine("\n Ürün Cinsi Listesi Tamamlandı!");
                    Console.WriteLine("\n Ürün Listesi");
                    foreach (var item in e)
                    {
                        Console.WriteLine("\r Ürün ID: " + item.UrunID + " Ürün Adı: " + item.UrunAdi);
                    }
                    Console.WriteLine("\n Ürün Listesi Tamamlandı!");
                    Console.WriteLine("\n Devam Etmek İçin Bir Tuşa Basın");
                    Console.ReadKey();
                }
                catch
                {
                    Console.WriteLine("\n Veritabanı Oluşturma İşlemi Başarısız!");
                    Console.WriteLine("\n Devam Etmek İçin Bir Tuşa Basın");
                    Console.ReadKey();
                }
            }
        }
        public static void AdminMode()
        {
            using (DataDb db = new DataDb())
            {
                Kullanici ekle = new Kullanici();
                ekle.Adi = "Admin";
                ekle.Sifre = "9916";

                db.Kullanici.Add(ekle);
                db.SaveChanges();
                Console.WriteLine("\n Admin oluşturuldu!");
                Console.WriteLine("\n Devam Etmek İçin Bir Tuşa Basın");
                Console.ReadKey();
            }
        }
        public static void MenuGoster()
        {
            bool Kontrol = false;
            int a = 0;
            int secim;
            while (a == 0)
            {
                Console.Clear();
                for (int i = 1; i < 62; i++)
                {
                    Console.SetCursorPosition(0 + i, 1);
                    Console.Write("*");
                    Thread.Sleep(5);
                }
                Console.WriteLine("\n *      ©2017 Choice Corp. Veritabanı Oluşturma Sistemi      *");
                for (int i = 1; i < 62; i++)
                {
                    Console.SetCursorPosition(0 + i, 4);
                    Console.Write("*");
                    Thread.Sleep(5);
                }
                Console.WriteLine("\n 1. Sıfırdan Veritabanı Oluştur.");
                Console.WriteLine("\r 2. Deneme Ürünü Oluştur");
                Console.WriteLine("\r 3. Admin oluştur");
                Console.WriteLine("\r 4. Veritabanını Listele");
                Console.WriteLine("\r 5. Çıkış");
                Console.Write("\n Seçim= ");
                
                
                if (!int.TryParse(Console.ReadLine(), out secim))
                {
                    Console.WriteLine("Seçim yanlış Sayı Girin Devam etmek İçin Bir Tuşa Basın.");
                    Console.ReadKey();
                }
                else
                {
                    if (secim < 1 || secim > 5)
                    {
                        Console.WriteLine("Seçim 1 ile 5 arasında olmalı Devam etmek İçin Bir Tuşa Basın.");
                        Console.ReadKey();
                    }
                    else
                    {
                        switch (secim)
                        {
                            case 1:
                                {
                                    SıfırdanVeritabaniOlusturma();
                                    Kontrol = true;
                                    break;
                                }
                            case 2:
                                {
                                    if (Kontrol == false)
                                    {
                                        Console.WriteLine("\nSıfırdan Bir Veritabanı Oluşturmadan Ürün Eklemeye Çalıştınız!");
                                        Console.WriteLine("\rEğer Veritabanını Daha Önce Oluşturmadıysanız Program Çökecektir.");
                                        Console.WriteLine("\n Devam Etmek İçin Bir Tuşa Basın");
                                        Console.ReadKey();
                                    }
                                    UrunEkle();
                                    break;
                                }
                            case 3:
                                {
                                    AdminMode();
                                    break;
                                }
                            case 4:
                                {
                                    Rapor();
                                    break;
                                }
                            case 5:
                                {
                                    a = 1;
                                    break;
                                }
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            MenuGoster();
        }
    }
}
