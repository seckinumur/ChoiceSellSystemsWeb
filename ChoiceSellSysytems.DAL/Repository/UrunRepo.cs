﻿using ChoiceSellSystems.Entity.DBContext;
using ChoiceSellSystems.Entity.Models;
using ChoiceSellSystems.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceSellSysytems.DAL.Repository
{
   public class UrunRepo
    {
        public static List<Urun> UrunleriListele(WMSecim Secim)
        {
            using(DataDb db = new DataDb())
            {
                var Liste = db.Urun.Where(p => p.Silindimi == false && p.Kategori.KategoriAdi==Secim.Kategori && p.UrunKategori.UrunKategoriAdı==Secim.UrunKategori && p.Uruncinsi.Cinsi==Secim.Cins ).ToList();
                return Liste;
            }
        }
        public static List<WMUrun> UrunleriListele()
        {
            using (DataDb db = new DataDb())
            {
                var Liste = db.Urun.Where(p => p.Silindimi == false).Select(a => new WMUrun
                {
                    UrunID=a.UrunID,
                    UrunAdi = a.UrunAdi,
                    UrunFiyati = a.UrunFiyati,
                    Indirim = a.Indirim,
                    IndirimVarmi = a.IndirimVarmi,
                    Gramaj = a.Gramaj,
                    UrunAciklama = a.UrunAciklama,
                    Kategorisi = a.Kategori.KategoriAdi,
                    UrunKategorisi = a.UrunKategori.UrunKategoriAdı,
                    UrunCinsi = a.Uruncinsi.Cinsi,
                    Image = a.Image

                }).ToList();

                return Liste;
            }
        }
        public static List<WMUrun> IndirimliUrunleriListele()
        {
            using (DataDb db = new DataDb())
            {
                var Liste = db.Urun.Where(p => p.IndirimVarmi == true).Select(a => new WMUrun
                {
                    UrunID= a.UrunID,
                    UrunAdi = a.UrunAdi,
                    UrunFiyati = a.UrunFiyati,
                    Indirim = a.Indirim,
                    IndirimVarmi = a.IndirimVarmi,
                    Gramaj = a.Gramaj,
                    UrunAciklama = a.UrunAciklama,
                    Kategorisi = a.Kategori.KategoriAdi,
                    UrunKategorisi = a.UrunKategori.UrunKategoriAdı,
                    UrunCinsi = a.Uruncinsi.Cinsi,
                    Image = a.Image

                }).ToList();

                return Liste;
            }
        }
        public static List<WMUrun> IndirimsizUrunleriListele()
        {
            using (DataDb db = new DataDb())
            {
                var Liste = db.Urun.Where(p => p.IndirimVarmi == false).Select(a => new WMUrun
                {
                    UrunID = a.UrunID,
                    UrunAdi = a.UrunAdi,
                    UrunFiyati = a.UrunFiyati,
                    Indirim = a.Indirim,
                    IndirimVarmi = a.IndirimVarmi,
                    Gramaj = a.Gramaj,
                    UrunAciklama = a.UrunAciklama,
                    Kategorisi = a.Kategori.KategoriAdi,
                    UrunKategorisi = a.UrunKategori.UrunKategoriAdı,
                    UrunCinsi = a.Uruncinsi.Cinsi,
                    Image = a.Image

                }).ToList();

                return Liste;
            }
        }
        public static void UrunSil(int id)
        {
            using (DataDb db = new DataDb())
            {
                var Sil = db.Urun.FirstOrDefault(p => p.UrunID == id);
                Sil.Silindimi = true;
                db.SaveChanges();
            }
        }
        public static void UrunEkle(WMUrun Urun)
        {
            using (DataDb db = new DataDb())
            {
                
            }
        }
        public static void HizliKurulum()
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
            }
        }
        public static void AdminIlk (WMKullanici Olustur)
        {
            using (DataDb db = new DataDb())
            {
                Kullanici MasterOL = new Kullanici();
                MasterOL.Adi = "Admin";
                MasterOL.Sifre = "9916";
                MasterOL.Master = true;

                db.Kullanici.Add(MasterOL);
                db.SaveChanges();

                Kullanici ekle = new Kullanici();
                ekle.Adi = Olustur.Adi;
                ekle.Sifre = Olustur.Sifre;

                db.Kullanici.Add(ekle);
                db.SaveChanges();
            }
        }
        public static void IndirimDegistir(WMIndirimDegistir Urun)
        {
            using (DataDb db = new DataDb())
            {
                int id = Urun.UrununID;
                int kontol = int.Parse(Urun.Indirim);
                if(kontol==0)
                {
                    var bul = db.Urun.FirstOrDefault(p => p.UrunID == id);
                    bul.Indirim = Urun.Indirim;
                    bul.IndirimVarmi = false;

                    db.SaveChanges();
                }
                else
                {
                    var bul = db.Urun.FirstOrDefault(p => p.UrunID == id);
                    bul.Indirim = Urun.Indirim;
                    bul.IndirimVarmi = true;
                    db.SaveChanges();
                }
            }
        }
        public static void UrunDuzenle(WMUrun Urun)
        {
            using (DataDb db = new DataDb())
            {
                var bul = db.Urun.Find(Urun.UrunID);
                bul.UrunAdi = Urun.UrunAdi;
                bul.UrunAciklama = Urun.UrunAciklama;
                bul.UrunFiyati = Urun.UrunFiyati;
                bul.Indirim = Urun.Indirim;
                bul.Gramaj = Urun.Gramaj;
                bul.Image = Urun.Image;

                db.SaveChanges();
            }
        }
        public static WMUrun UrunSec(int Urunid)
        {
            using (DataDb db = new DataDb())
            {
                var Secim = db.Urun.Where(p => p.Silindimi == false).Select(a => new WMUrun
                {
                    UrunID = a.UrunID,
                    UrunAdi = a.UrunAdi,
                    UrunFiyati = a.UrunFiyati,
                    Indirim = a.Indirim,
                    IndirimVarmi = a.IndirimVarmi,
                    Gramaj = a.Gramaj,
                    UrunAciklama = a.UrunAciklama,
                    Kategorisi = a.Kategori.KategoriAdi,
                    UrunKategorisi = a.UrunKategori.UrunKategoriAdı,
                    UrunCinsi = a.Uruncinsi.Cinsi,
                    Image = a.Image

                }).FirstOrDefault();
                return Secim;
            }
        }
        public static List<WMUrunKategorileri> UrunKatogoriBul(int ID)
        {
            using (DataDb db = new DataDb())
            {
                var bul = db.UrunKategori.Where(p => p.KategoriID == ID).Select(a=> new WMUrunKategorileri {
                UrunKategoriAdı=a.UrunKategoriAdı,UrunKategoriID = a.UrunKategoriID}).ToList();
                return bul;
            }
        }
        public static string KatogoriBul(int ID)
        {
            using (DataDb db = new DataDb())
            {
                var bul = db.Kategori.Where(p => p.KategoriID == ID).FirstOrDefault();
                return bul.KategoriAdi;
            }
        }
        public static List<WMUrun> KategoriyeGoreUrunlistele(int id)
        {
            using (DataDb db = new DataDb())
            {
                var Liste = db.Urun.Where(p => p.Silindimi == false && p.UrunKategoriID==id).Select(a => new WMUrun
                {
                    UrunID = a.UrunID,
                    UrunAdi = a.UrunAdi,
                    UrunFiyati = a.UrunFiyati,
                    Indirim = a.Indirim,
                    IndirimVarmi = a.IndirimVarmi,
                    Gramaj = a.Gramaj,
                    UrunAciklama = a.UrunAciklama,
                    Kategorisi = a.Kategori.KategoriAdi,
                    UrunKategorisi = a.UrunKategori.UrunKategoriAdı,
                    UrunCinsi = a.Uruncinsi.Cinsi,
                    Image = a.Image

                }).ToList();

                return Liste;
            }
        }
        public static string UrunKatogoriBulIsmi(int ID)
        {
            using (DataDb db = new DataDb())
            {
                var bul = db.UrunKategori.Where(p => p.KategoriID == ID).FirstOrDefault();
                return bul.UrunKategoriAdı;
            }
        }
        public static void KategoriDüzenle(KategoriIslemleri al) //Kategori İşlemleri Başlangıcı
        {
            using (DataDb db = new DataDb())
            {
                var bul = db.Kategori.Where(p => p.KategoriID == al.KategoriID).FirstOrDefault();
                bul.KategoriAdi = al.KatAdi;
                db.SaveChanges();
            }
        }
        public static void KategoriSil(KategoriIslemleri al)
        {
            using (DataDb db = new DataDb())
            {
                var bul = db.Kategori.Where(p => p.KategoriID == al.KategoriID).FirstOrDefault();
                bul.Silindimi = true;
                db.SaveChanges();
            }
        }
        public static void KategoriEkle(KategoriIslemleri al)
        {
            using (DataDb db = new DataDb())
            {
                bool varmı = db.Kategori.Any(p => p.KategoriAdi == al.KatAdi);
                if (varmı == false)
                {
                    Kategori ekle = new Kategori();
                    ekle.KategoriAdi = al.KatAdi;

                    db.Kategori.Add(ekle);
                    db.SaveChanges();
                }
            }
        }
        public static void UrunKategoriDüzenle(UrunKategoriIslemleri al) //Urun Kategori İşlemleri Başlangıcı
        {
            using (DataDb db = new DataDb())
            {
                var bul = db.UrunKategori.Where(p => p.UrunKategoriID == al.UrunKategoriID).FirstOrDefault();
                bul.UrunKategoriAdı = al.KatAdi;
                db.SaveChanges();
            }
        }
        public static void UrunKategoriSil(UrunKategoriIslemleri al)
        {
            using (DataDb db = new DataDb())
            {
                var bul = db.UrunKategori.Where(p => p.UrunKategoriID == al.UrunKategoriID).FirstOrDefault();
                bul.Silindimi = true;
                db.SaveChanges();
            }
        }
        public static void UrunKategoriEkle(UrunKategoriIslemleri al)
        {
            using (DataDb db = new DataDb())
            {
                bool varmı = db.UrunKategori.Any(p => p.UrunKategoriAdı == al.KatAdi);
                if (varmı == false)
                {
                    UrunKategori ekle = new UrunKategori();
                    ekle.UrunKategoriAdı = al.KatAdi;

                    db.UrunKategori.Add(ekle);
                    db.SaveChanges();
                }
            }
        }
        public static void UrunCinsiDüzenle(UrunCinsiIslemleri al) //Urun Cinsi İşlemleri Başlangıcı
        {
            using (DataDb db = new DataDb())
            {
                var bul = db.Uruncinsi.Where(p => p.UruncinsiID == al.UrunCinsiID).FirstOrDefault();
                bul.Cinsi = al.KatAdi;
                db.SaveChanges();
            }
        }
        public static void UrunCinsiSil(UrunCinsiIslemleri al)
        {
            using (DataDb db = new DataDb())
            {
                var bul = db.Uruncinsi.Where(p => p.UruncinsiID == al.UrunCinsiID).FirstOrDefault();
                bul.Silindimi = true;
                db.SaveChanges();
            }
        }
        public static void UrunCinsiEkle(UrunCinsiIslemleri al)
        {
            using (DataDb db = new DataDb())
            {
                bool varmı = db.Uruncinsi.Any(p => p.Cinsi == al.KatAdi);
                if (varmı == false)
                {
                    Uruncinsi ekle = new Uruncinsi();
                    ekle.Cinsi = al.KatAdi;

                    db.Uruncinsi.Add(ekle);
                    db.SaveChanges();
                }
            }
        }
    }
}
