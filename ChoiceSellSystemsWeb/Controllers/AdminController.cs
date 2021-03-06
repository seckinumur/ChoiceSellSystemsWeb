﻿using ChoiceSellSystems.Entity.ViewModels;
using ChoiceSellSysytems.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChoiceSellSystemsWeb.Controllers
{
    public class AdminController : Controller
    {
        
        public ActionResult Admin()
        {
            if (AdminCheckRepo.Check() == true)
            {
                return View();
            }
            else
            {
                return RedirectToAction("AdminYeni");
            }
        }
        [HttpPost]
        public ActionResult Admin(WMKullanici Kullanici)
        {
            Session["AdminID"] = Convert.ToString( KullaniciRepo.GirisID(Kullanici));
            if (Session["AdminID"] == null || Session["AdminID"].ToString()=="0")
            {
                return RedirectToAction("Admin");
            }
            else
            {
                return RedirectToAction("AdminPage");
            } 
        }
        public ActionResult Welcome()
        {
            return View();
        }
        public ActionResult AdminPage()
        {
            if (Session["AdminID"] == null || Session["AdminID"].ToString() == "0")
            {
                return RedirectToAction("Admin");
            }
            else
            {
                int Tumurunler = UrunRepo.UrunleriListele().Count;
                if(Tumurunler!=0)
                {
                    ViewBag.Kategori = KategorizeEt.KatogorileriListele();
                    ViewBag.TumUrunler = Tumurunler;
                    ViewBag.IndirimdekiUrunler = UrunRepo.IndirimliUrunleriListele().Count;
                    return View();
                }
                else
                {
                    return RedirectToAction("Welcome");
                }
            }
        }
        public ActionResult TumUrunler()
        {
            if (Session["AdminID"] == null || Session["AdminID"].ToString() == "0")
            {
                return RedirectToAction("Admin");
            }
            else
            {
                ViewBag.Kategori = KategorizeEt.KatogorileriListele();
                var Listele = UrunRepo.UrunleriListele();
                return View(Listele);
            }
        }
        [HttpPost]
        public ActionResult TumUrunler(WMUrunSil ID)
        {
            if (Session["AdminID"] == null || Session["AdminID"].ToString() == "0")
            {
                return RedirectToAction("Admin");
            }
            else
            {
                int id = int.Parse(ID.UrunID);
                UrunRepo.UrunSil(id);
                ViewBag.Kategori = KategorizeEt.KatogorileriListele();
                var Listele = UrunRepo.UrunleriListele();
                return View(Listele);
            }
        }
        public ActionResult UrunEkleIlk()
        {
            if(Session["AdminID"] == null || Session["AdminID"].ToString() == "0")
            {
                return RedirectToAction("Admin");
            }
            else
            {
                return View();
            }
        }
        public ActionResult HizliKurulum()
        {
            if (Session["AdminID"] == null || Session["AdminID"].ToString() == "0")
            {
                return RedirectToAction("Admin");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult HizliKurulum(HizliKurulumAl AI)
        {
            if (Session["AdminID"] == null || Session["AdminID"].ToString() == "0")
            {
                return RedirectToAction("Admin");
            }
            else
            {
                UrunRepo.HizliKurulum();
                return RedirectToAction("AdminPage");
            }
        }
        public ActionResult AdminYeni()
        {
            if (AdminCheckRepo.Check() == true)
            {
                return RedirectToAction("Admin");
            }
            else
            {
                ViewBag.HataKullanici = "Kullanıcı Adı Girin!";
                ViewBag.HataSifre = "Kullanıcı Şifresi Girin!";
                return View();
            }
        }
        [HttpPost]
        public ActionResult AdminYeni(WMKullanici Olustur)
        {
            if (AdminCheckRepo.Check() == true)
            {
                return RedirectToAction("Admin");
            }
            else
            {
                if(Olustur.Adi==null || Olustur.Adi==" ")
                {
                    ViewBag.HataKullanici = "Kullanıcı Adı Girilmeli!";
                    ViewBag.HataSifre = "Kullanıcı Şifresi Girin!";
                    return View();
                }
                else if(Olustur.Sifre==null || Olustur.Sifre==" ")
                {
                    ViewBag.HataSifre = "Kullanıcı Şifresi Girilmeli!";
                    ViewBag.HataKullanici = Olustur.Adi;
                    return View();
                }
                else
                {
                    UrunRepo.AdminIlk(Olustur);
                    return RedirectToAction("Admin");
                }
                
            }
        }
        public ActionResult IndirimdekiUrunler()
        {
            if (Session["AdminID"] == null || Session["AdminID"].ToString() == "0")
            {
                return RedirectToAction("Admin");
            }
            else
            {
                ViewBag.Kategori = KategorizeEt.KatogorileriListele();
                var Listele = UrunRepo.IndirimliUrunleriListele();
                return View(Listele);
            }
        }
        [HttpPost]
        public ActionResult IndirimdekiUrunler(WMIndirimDegistir Degistir)
        {
            if (Session["AdminID"] == null || Session["AdminID"].ToString() == "0")
            {
                return RedirectToAction("Admin");
            }
            else
            {
                if (Degistir.Indirim == null)
                {
                    WMIndirimDegistir yeni = new WMIndirimDegistir { UrununID = Degistir.UrununID, Indirim = "0" };
                    UrunRepo.IndirimDegistir(yeni);
                    ViewBag.Kategori = KategorizeEt.KatogorileriListele();
                    var Listele = UrunRepo.IndirimliUrunleriListele();
                    return View(Listele);
                }
                else
                {
                    UrunRepo.IndirimDegistir(Degistir);
                    ViewBag.Kategori = KategorizeEt.KatogorileriListele();
                    var Listele = UrunRepo.IndirimliUrunleriListele();
                    return View(Listele);
                }
                
            }
        }
        public ActionResult IndirimsizUrunler()
        {
            if (Session["AdminID"] == null || Session["AdminID"].ToString() == "0")
            {
                return RedirectToAction("Admin");
            }
            else
            {
                ViewBag.Kategori = KategorizeEt.KatogorileriListele();
                var Listele = UrunRepo.IndirimsizUrunleriListele();
                return View(Listele);
            }
        }
        [HttpPost]
        public ActionResult IndirimsizUrunler(WMIndirimDegistir Degistir)
        {
            if (Degistir.Indirim == null)
            {
                WMIndirimDegistir yeni = new WMIndirimDegistir { UrununID = Degistir.UrununID, Indirim = "0" };
                UrunRepo.IndirimDegistir(yeni);
                ViewBag.Kategori = KategorizeEt.KatogorileriListele();
                var Listele = UrunRepo.IndirimsizUrunleriListele();
                return View(Listele);
            }
            else
            {
                UrunRepo.IndirimDegistir(Degistir);
                ViewBag.Kategori = KategorizeEt.KatogorileriListele();
                var Listele = UrunRepo.IndirimsizUrunleriListele();
                return View(Listele);
            }
        }
        public ActionResult UrunDuzenle(int? id)
        {
            if (Session["AdminID"] == null || Session["AdminID"].ToString() == "0")
            {
                return RedirectToAction("Admin");
            }
            else if (id == null)
            {
                return RedirectToAction("Uyari", "Uyari");
            }
            else
            {
                int ID = id.Value;
                var urun = UrunRepo.UrunSec(ID);
                ViewBag.Kategori = KategorizeEt.KatogorileriListele();
                return View(urun);
            }
        }
        public ActionResult KategoriyeGoreListele(int? id)
        {
            if (Session["AdminID"] == null || Session["AdminID"].ToString() == "0")
            {
                return RedirectToAction("Admin");
            }
            else if (id == null)
            {
                return RedirectToAction("Uyari","Uyari");
            }
            else
            {
                int ID = id.Value;
                var urunKategori = UrunRepo.UrunKatogoriBul(ID);
                ViewBag.KategoriAdi = UrunRepo.KatogoriBul(ID);
                ViewBag.Kategori = KategorizeEt.KatogorileriListele();
                return View(urunKategori);
            }
        }
        
        public ActionResult KategoriSecimineGoreListele(int? id)
        {
            if (Session["AdminID"] == null || Session["AdminID"].ToString() == "0")
            {
                return RedirectToAction("Admin");
            }
            else if (id == null)
            {
                return RedirectToAction("Uyari", "Uyari");
            }
            else
            {
                int ID = id.Value;
                var urun = UrunRepo.KategoriyeGoreUrunlistele(ID);
                ViewBag.KategoriAdi = UrunRepo.UruneKategorisineGoreKatogoriBul(ID);
                ViewBag.UrunkategoriIsmi = UrunRepo.UrunKatogoriBulIsmi(ID);
                ViewBag.Kategori = KategorizeEt.KatogorileriListele();
                return View(urun);
            }
        }
        public ActionResult KategoriEkle()
        {
            if (Session["AdminID"] == null || Session["AdminID"].ToString() == "0")
            {
                return RedirectToAction("Admin");
            }
            else
            {
                var gonder = KategorizeEt.KategorilerinHepsi();
                ViewBag.Kategori = KategorizeEt.KatogorileriListele();
                return View(gonder);
            }
        }
        [HttpPost]
        public ActionResult KategoriEkle(KategoriIslemleri Al)
        {
            if (Session["AdminID"] == null || Session["AdminID"].ToString() == "0")
            {
                return RedirectToAction("Admin");
            }
            else
            {
                if(Al.Gorev== "Degistir")
                {
                    UrunRepo.KategoriDüzenle(Al);
                }
                else if(Al.Gorev== "Sil")
                {
                    UrunRepo.KategoriSil(Al);
                }
                else if(Al.Gorev== "Ekle")
                {
                    UrunRepo.KategoriEkle(Al);
                }
                var gonder = KategorizeEt.KategorilerinHepsi();
                ViewBag.Kategori = KategorizeEt.KatogorileriListele();
                return View(gonder);
            }
        }
        public ActionResult AltKategoriEkle()
        {
            if (Session["AdminID"] == null || Session["AdminID"].ToString() == "0")
            {
                return RedirectToAction("Admin");
            }
            else
            {
                var gonder = KategorizeEt.UrunKategorilerinHepsi();
                ViewBag.Kategori2 = KategorizeEt.KatogorileriListele();
                ViewBag.Kategori = KategorizeEt.KatogorileriListele();
                return View(gonder);
            }
        }
        [HttpPost]
        public ActionResult AltKategoriEkle(UrunKategoriIslemleri Al)
        {
            if (Session["AdminID"] == null || Session["AdminID"].ToString() == "0")
            {
                return RedirectToAction("Admin");
            }
            else
            {
                if (Al.Gorev == "Degistir")
                {
                    UrunRepo.UrunKategoriDüzenle(Al);
                }
                else if (Al.Gorev == "Sil")
                {
                    UrunRepo.UrunKategoriSil(Al);
                }
                else if (Al.Gorev == "Ekle")
                {
                    UrunRepo.UrunKategoriEkle(Al);
                }
                return RedirectToAction("AltKategoriEkle");
            }
        }
        public ActionResult UrunCinsiEkle()
        {
            if (Session["AdminID"] == null || Session["AdminID"].ToString() == "0")
            {
                return RedirectToAction("Admin");
            }
            else
            {
                var gonder = KategorizeEt.UrunCinslerininHepsi();
                ViewBag.Kategori = KategorizeEt.KatogorileriListele();
                return View(gonder);
            }
        }
        [HttpPost]
        public ActionResult UrunCinsiEkle(UrunCinsiIslemleri Al)
        {
            if (Session["AdminID"] == null || Session["AdminID"].ToString() == "0")
            {
                return RedirectToAction("Admin");
            }
            else
            {
                if (Al.Gorev == "Degistir")
                {
                    UrunRepo.UrunCinsiDüzenle(Al);
                }
                else if (Al.Gorev == "Sil")
                {
                    UrunRepo.UrunCinsiSil(Al);
                }
                else if (Al.Gorev == "Ekle")
                {
                    UrunRepo.UrunCinsiEkle(Al);
                }
                var gonder = KategorizeEt.UrunCinslerininHepsi();
                ViewBag.Kategori = KategorizeEt.KatogorileriListele();
                return View(gonder);
            }
        }
        public ActionResult UrunEkle()
        {
            if (Session["AdminID"] == null || Session["AdminID"].ToString() == "0")
            {
                return RedirectToAction("Admin");
            }
            else
            {
                ViewBag.UrunCinsi = KategorizeEt.UrunCinslerininHepsi();
                ViewBag.UrunKategori = KategorizeEt.UrunKategorilerinHepsi();
                ViewBag.Kategori = KategorizeEt.KatogorileriListele();
                ViewBag.MarkaVer = KategorizeEt.Markalar();
                var Kategorigonder = KategorizeEt.KatogorileriListele();
                return View(Kategorigonder);
            }
        }
        [HttpPost]
        public ActionResult UrunEkle(WMUrunEkle Ekle)
        {
            if (Session["AdminID"] == null || Session["AdminID"].ToString() == "0")
            {
                return RedirectToAction("Admin");
            }
            else
            {
                int Gelen = UrunRepo.UrunEkle(Ekle).UrunID;
                ViewBag.Kategori = KategorizeEt.KatogorileriListele();
                return RedirectToAction("UrunDuzenle",new { Gelen });
            }
        }
        public ActionResult Ayarlar()
        {
            if (Session["AdminID"] == null || Session["AdminID"].ToString() == "0")
            {
                return RedirectToAction("Admin");
            }
            else
            {
                var ekle = KullaniciRepo.CompanyDok();
                ViewBag.Adres = ekle.Adres;
                ViewBag.Telefon = ekle.Telefon;
                ViewBag.Facebook = ekle.Facebook;
                ViewBag.MobilTelefon = ekle.MobilTelefon;
                ViewBag.Twitter = ekle.Twitter;
                ViewBag.Whatsapp = ekle.Whatsapp;
                ViewBag.Instagram = ekle.Instagram;
                var listele = KullaniciRepo.KullanicilariListele();
                ViewBag.Kategori = KategorizeEt.KatogorileriListele();
                return View(listele);
            }
        }
        [HttpPost]
        public ActionResult Ayarlar(KullaniciIslemleri KUllanicial)
        {
            if (Session["AdminID"] == null || Session["AdminID"].ToString() == "0")
            {
                return RedirectToAction("Admin");
            }
            else
            {
                if (KUllanicial.Gorev == "Degistir")
                {
                    KullaniciRepo.KullaniciDüzenle(KUllanicial);
                }
                else if (KUllanicial.Gorev == "Sil")
                {
                    KullaniciRepo.KullanıcıSil(KUllanicial.KullaniciID);
                }
                else if (KUllanicial.Gorev == "Ekle")
                {
                    KullaniciRepo.KullanıcıEkle(KUllanicial);
                }
                else if (KUllanicial.Gorev== "Company")
                {
                    KullaniciRepo.CompanyDuzenle(KUllanicial);
                }
                else
                {
                    return RedirectToAction("Uyari", "Uyari");
                }
                return RedirectToAction("Ayarlar");
            }
        }
    }
}