using ChoiceSellSystems.Entity.DBContext;
using ChoiceSellSystems.Entity.Models;
using ChoiceSellSystems.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceSellSysytems.DAL.Repository
{
    public class KullaniciRepo
    {
        public static int GirisID(WMKullanici Kullanici)
        {
            using (DataDb db = new DataDb())
            {
                int ID;
                try
                {
                    var Bul = db.Kullanici.Where(p => p.Adi == Kullanici.Adi && p.Sifre == Kullanici.Sifre).FirstOrDefault();
                    return ID = Bul.KullaniciID;
                }
                catch
                {
                    return 0;
                }
            }
        }
        public static void KullanıcıEkle(KullaniciIslemleri kullanici)
        {
            using (DataDb db = new DataDb())
            {
                bool varmı = db.Kullanici.Any(p => p.Adi == kullanici.KatAdi && p.Sifre == kullanici.KatSifre);
                if (varmı == false)
                {
                    Kullanici ekle = new Kullanici();
                    ekle.Adi = kullanici.KatAdi;
                    ekle.Sifre = kullanici.KatSifre;

                    db.Kullanici.Add(ekle);
                    db.SaveChanges();
                }
            }
        }
        public static void KullanıcıSil(int id)
        {
            using (DataDb db = new DataDb())
            {
                bool varmı = db.Kullanici.Any(p => p.KullaniciID == id);
                if (varmı == true)
                {
                    var bul = db.Kullanici.Find(id);
                    db.Kullanici.Remove(bul);
                    db.SaveChanges();
                }
            }
        }
        public static void KullaniciDüzenle(KullaniciIslemleri kullanici)
        {
            using (DataDb db = new DataDb())
            {
                bool varmı = db.Kullanici.Any(p => p.KullaniciID == kullanici.KullaniciID);
                if (varmı == true)
                {
                    var ekle = db.Kullanici.Find(kullanici.KullaniciID);
                    ekle.Adi = kullanici.KatAdi;
                    ekle.Sifre = kullanici.KatSifre;

                    db.SaveChanges();
                }
            }
        }
        public static List<WMKullanici> KullanicilariListele()
        {
            using (DataDb db = new DataDb())
            {
                return db.Kullanici.Where(p => p.Master == false).Select(p => new WMKullanici
                {
                    Adi = p.Adi,
                    KullaniciID = p.KullaniciID,
                    Master = p.Master,
                    Sifre = p.Sifre
                }).ToList();
            }
        }
        public static WMCompany CompanyDok()
        {
            using (DataDb db = new DataDb())
            {
                var n = db.CompanyInfo.FirstOrDefault(p => p.CompanyInfoID == 1);
                WMCompany ekle = new WMCompany()
                {
                    CompanyInfoID = n.CompanyInfoID,
                    Adres = n.Adres,
                    Facebook = n.Facebook,
                    Twitter = n.Twitter,
                    Instagram = n.Instagram,
                    Whatsapp = n.Whatsapp,
                    MobilTelefon = n.MobilTelefon,
                    Telefon = n.Telefon
                };
                return ekle;
            }
        }
        public static void CompanyDuzenle(KullaniciIslemleri ekle)
        {
            using (DataDb db = new DataDb())
            {
                var com = db.CompanyInfo.FirstOrDefault(p => p.CompanyInfoID == 1);

                com.Adres = ekle.Adres;
                com.Facebook = ekle.Facebook;
                com.Twitter = ekle.Twitter;
                com.Instagram = ekle.Instagram;
                com.Whatsapp = ekle.Whatsapp;
                com.MobilTelefon = ekle.MobilTelefon;
                com.Telefon = ekle.Telefon;

                db.SaveChanges();
            }
        }
    }
}