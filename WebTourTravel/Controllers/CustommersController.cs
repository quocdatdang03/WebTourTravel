using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTourTravel.Models;

namespace WebTourTravel.Controllers
{
    public class CustommersController : Controller
    {
        
        public ActionResult Index()
        {
            return View("Login");
        }
        public ActionResult Login(string UserName , string PassWorld)
        {
            if(ModelState.IsValid)
            {
                if (UserName.Trim().Equals("Lagger") && PassWorld.Trim().Equals("123456789"))
                {
                    return Redirect("/Tour/TourDuLich");
                }
            }
            return View(nameof(Index));
           
        }
        public ActionResult Register(string UserName , string Passwrorld , string comfirmPass)
        {
            if(ModelState.IsValid)
            {
                if(true)
                {
                    return View(nameof(Index));
                }
            }
            return View(nameof(Register));
        }
    }
}