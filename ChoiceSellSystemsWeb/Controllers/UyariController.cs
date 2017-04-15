using ChoiceSellSysytems.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChoiceSellSystemsWeb.Controllers
{
    public class UyariController : Controller
    {
        public ActionResult Uyari()
        {
            if (Session["AdminID"] == null || Session["AdminID"].ToString() == "0")
            {
                return RedirectToAction("Admin");
            }
            else
            {
                ViewBag.Kategori = KategorizeEt.KatogorileriListele();
                return View();
            }
        }
    }
}