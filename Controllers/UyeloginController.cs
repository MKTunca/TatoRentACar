using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TatooRentACar.Models;

namespace TatooRentACar.Controllers
{
    public class UyeloginController : Controller
    {
        RentACarEntities baglan = new RentACarEntities();
        public ActionResult login()
        {
            if (User.Identity.Name != "")
            { FormsAuthentication.SignOut(); }

            return View();
        }
        [HttpPost]
        public ActionResult login(Uye uy)
        {
            if (uy.email != null)
            {
                if (uy.sifre != null)
                {
                    var bilgi = baglan.Uye.FirstOrDefault(m => m.email == uy.email && m.sifre == uy.sifre);

                    if (bilgi != null)
                    {
                        FormsAuthentication.RedirectFromLoginPage(bilgi.ID.ToString(), false);
                        
                        return RedirectToAction("Index", "Sayfa");

                    }
                    else
                    {
                        ViewBag.uyari = "Bilgilerinizi kontrol ediniz.";
                    }
                }
                else
                {
                    ViewBag.uyari = "Şifrenizi yazınız.";
                }
            }
            else
            {
                ViewBag.uyari = "E-mail adresinizi yazınız.";
            }

            return View();
        }
    }
}