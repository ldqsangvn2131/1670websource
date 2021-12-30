using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _1670webdemo.Models;
using System.Data;
using System.Data.Entity;

namespace webtest.Controllers
{ 
    public class CategoryController : Controller
    {
        hrContext db = new hrContext();
        // GET: Category
        public ActionResult Index()
        {
            var list = db.Categories.ToList<Category>();
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "CatID,CatName,CatDesc")] Category category)
        {
            if (ModelState.IsValid)
            {
                var isCatIDAlreadyExists = db.Categories.Any(x => x.CatID == category.CatID);
                if (isCatIDAlreadyExists)
                {
                    return View(category);
                }
                var isCatNameAlreadyExists = db.Categories.Any(x => x.CatName == category.CatName);
                if (isCatNameAlreadyExists)
                {
                    return View(category);
                }
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            Category category = db.Categories.Find(id);

            return View(category);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "CatID,CatName,CatDesc")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }


        [HttpGet]
        public ActionResult Delete(string id)
        {

            Category category = db.Categories.Find(id);

            db.Categories.Remove(category);

            db.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}