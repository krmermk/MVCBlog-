﻿using MVCBlog.Areas.Admin.Models.DTO;
using MVCBlog.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Areas.Admin.Controllers
{
    public class CategoryController :BaseController
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            List<CategoryVM> model = db.Categories.Where(x => x.IsDeleted == false).OrderBy(x => x.AddDate).Select(x => new CategoryVM()
            {
                ID = x.ID,
                Name = x.Name,
                Description = x.Description
            }).ToList();
            return View(model);
        }

        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(CategoryVM model)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category();
                category.Name = model.Name;
                category.Description = model.Description;

                db.Categories.Add(category);
                db.SaveChanges();
                ViewBag.IslemDurum = 1;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.IslemDurum = 2;
                return View();
            }
           
        }


        public ActionResult UpdateCategory(int id)
        {
            Category category = db.Categories.FirstOrDefault(x => x.ID == id);
            CategoryVM categoryVM = new CategoryVM();
            categoryVM.Name = category.Name;
            categoryVM.Description = category.Description;
            return View(categoryVM);
        }
        [HttpPost]
        public ActionResult UpdateCategory(CategoryVM model)
        {
            if (ModelState.IsValid)
            {
                Category cat = db.Categories.FirstOrDefault(x => x.ID == model.ID);
                cat.Name = model.Name;
                cat.Description = model.Description;

                db.SaveChanges();
                ViewBag.IslemDurum = 1;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.IslemDurum = 2;
                return View();
            }
          
        }

        public JsonResult DeleteCategory(int id)
        {
            Category category = db.Categories.FirstOrDefault(x => x.ID == id);
            category.IsDeleted = true;
            category.DeleteDate = DateTime.Now;
            db.SaveChanges();
            return Json("");
        }
    }
}