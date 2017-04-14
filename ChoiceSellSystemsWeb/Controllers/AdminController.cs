using ChoiceSellSystems.Entity.ViewModels;
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
                UrunRepo.AdminIlk(Olustur);
                return RedirectToAction("Admin");
            }
        }
    }
}