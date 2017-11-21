using MVCBlog.Areas.Admin.Models.DTO;
using MVCBlog.Models.ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
namespace MVCBlog.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private BlogContext db =new BlogContext();
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            //İf satırı validationlar doğruysa if bloğu çalışır
            if (ModelState.IsValid)
            {
                //Any metodu içerisine aldığı sorgunenu doğru olup olmadığını kontrol ediyor
                if (db.AdminUsers.Any(x=>x.Email==model.Email&&x.Password==model.Password&&x.IsDeleted==false))
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true); //Kullanıcının mail adresini cookie de tutar.
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View();
                }
       
            }
            else
            {
                return View();
            }
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}