using MVCBlog.Areas.Admin.Models.DTO;
using MVCBlog.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Areas.Admin.Controllers
{
    public class SiteMenuController : BaseController
    {
        // GET: Admin/SiteMenu
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddSiteMenu()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSiteMenu(SiteMenuVM model)
        {
            SiteMenu site = new SiteMenu();
            site.Name = model.Name;
            site.Url = model.Url;
            site.cssClass = model.cssClass;
            db.SiteMenus.Add(site);
            db.SaveChanges();
            ViewBag.IslemDurum = 1;

            return View();
        }
    }
}