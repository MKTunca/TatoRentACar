using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TatooRentACar.Models;

namespace TatooRentACar.Controllers
{
    
    public class uyeController : Controller
    {
        RentACarEntities baglan = new RentACarEntities();
        public ActionResult UyeEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UyeEkle(Uye u)
        {
            if ((u.email != null)&&(u.sifre!=null))
            {
                var eskiEmail = baglan.Uye.FirstOrDefault(m => m.email == u.email);
                if (eskiEmail==null)
                {
                    baglan.Uye.Add(u);
                    baglan.SaveChanges();
                    ViewBag.uyari = "Üye ekleme işlemi başarılı";
                    return View(u);
                }

                else
                {
                    ViewBag.uyari = "E-mail zaten kayıtlı";

                }
            }
            else
            {
                ViewBag.uyari = "E-mail ve şifre zorunlu";
            }



            return View();
        }
    }
}