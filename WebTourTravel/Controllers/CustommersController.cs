using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTourTravel.Models;
using System.Web.Security;
using WebTourTravel.Mapping_Model;
using WebTourTravel.Help;

namespace WebTourTravel.Controllers
{
    public class CustommersController : Controller
    {

        TourDuLichEntities _dbContext = new TourDuLichEntities(); 
        
        [HttpGet]
        public ActionResult Login()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }
        [HttpPost]
        public ActionResult Login(ModelLogin model)
        {
            if(ModelState.IsValid)
            {
                var nd = HelpCustommners.LoginCheck(_dbContext.NguoiDung.ToList(), model.UserName, model.PassWorld);

                if (nd!=null)
                {
                    FormsAuthentication.SetAuthCookie(nd.Gmail, false);
                    return Redirect("/Tour/TourDuLich");                 
                    
                }
                else
                {
                    ViewBag.Valiadation = "* Tên tài khoản hoặc mật khẩu không đúng";
                }
               
            }
           /* else
            {
                if (model.UserName == null) ViewBag.ValidationUser = "Tên tài khoản không được để trống";
                if (model.PassWorld == null) ViewBag.ValidationPassword = "Vui lòng nhập mật khẩu";
            } */   
            return Login();
           
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public ActionResult Register(ModelRegister modelRegister)
        {
            if(ModelState.IsValid)
            {
                if(HelpCustommners.IsEmailExits(_dbContext.NguoiDung.ToList(), modelRegister.Email))
                {
                    ViewBag.ValiadationEmail = "* Email đã được xử dụng";
                    return Register();
                }
                if(modelRegister.PassWord.Equals(modelRegister.ComfirmPassWorld))
                {
                    var newND = MapingNguoiDung.AccountToNguoiDung(modelRegister);
                    _dbContext.NguoiDung.Add(newND);
                    _dbContext.SaveChanges();
                    return View(nameof(Login));
                }
                else
                {
                    ViewBag.ValiadationConfirm = "* Hai mật khẩu không khớp nhau";
                }
            }
            return Register();
        }


        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }
}