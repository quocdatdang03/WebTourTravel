using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTourTravel.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult History(string idUser)
        { 
            return View();
        }
    }
}