using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TatooRentACar.Models;

namespace TatooRentACar.Controllers
{
    
    public class SayfaController : Controller
    {
        RentACarEntities baglan = new RentACarEntities();
        siteBilgileri sb = new siteBilgileri();
        public ActionResult Index()
        {
            sb.bilgiler();
            
            if (User.Identity.Name!="")
            {
                ViewBag.uyari = "Araç kiralanmıştır.";
            }
            else
            {
                ViewBag.uyari = "Araç kiralayabilmek için üye girişi yapınız.";
            }
                return View(sb);
            
        }
        
    }
}