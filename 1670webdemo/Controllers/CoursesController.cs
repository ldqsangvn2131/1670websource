using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _1670webdemo.Models;

namespace _1670webdemo.Controllers
{
    public class CoursesController : Controller
    {
        private hrContext db = new hrContext();

        // GET: Courses
        public ActionResult Index()
        {
            var courses = db.Courses.Include(c => c.Category).Include(c => c.Trainer);
            return View(courses.ToList());
        }
        public ActionResult Create()
        {
            ViewBag.CatID = new SelectList(db.Categories, "CatID", "CatName");
            ViewBag.TrainerID = new SelectList(db.Trainers, "TrainerID", "TrainerName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseID,CourseName,CourseDesc,CatID,TrainerID")] Course course)
        {ViewBag.CatID = new SelectList(db.Categories, "CatID", "CatName", course.CatID);
            ViewBag.TrainerID = new SelectList(db.Trainers, "TrainerID", "TrainerName", course.TrainerID);
            if (ModelState.IsValid)
            {
                var isCourseIDAlreadyExists = db.Courses.Any(x => x.CourseID == course.CourseID);
                if (isCourseIDAlreadyExists)
                {
                    return View(course);
                }
                var isCourseTrainerIDAlreadyExists = db.Courses.Any(x => x.TrainerID == course.TrainerID);
                if (isCourseTrainerIDAlreadyExists)
                {
                    return View(course);
                }
                var isCourseCatNameAlreadyExists = db.Courses.Any(x => x.CatID == course.CatID);
                if (isCourseCatNameAlreadyExists)
                {
                    return View(course);
                }

                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            
            return View(course);
        }
        public ActionResult Edit(string id)
        {
            Course course = db.Courses.Find(id);
            ViewBag.CatID = new SelectList(db.Categories, "CatID", "CatName", course.CatID);
            ViewBag.TrainerID = new SelectList(db.Trainers, "TrainerID", "TrainerName", course.TrainerID);
            return View(course);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseID,CourseName,CourseDesc,CatID,TrainerID")] Course course)
        {
            if (ModelState.IsValid)
            {
                var isCourseIDAlreadyExists = db.Courses.Any(x => x.CourseID == course.CourseID);
                if (isCourseIDAlreadyExists)
                {
                    return View(course);
                }
                var isCourseTrainerIDAlreadyExists = db.Courses.Any(x => x.TrainerID == course.TrainerID);
                if (isCourseTrainerIDAlreadyExists)
                {
                    return View(course);
                }
                var isCourseCatNameAlreadyExists = db.Courses.Any(x => x.CatID == course.CatID);
                if (isCourseCatNameAlreadyExists)
                {
                    return View(course);
                }
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CatID = new SelectList(db.Categories, "CatID", "CatName", course.CatID);
            ViewBag.TrainerID = new SelectList(db.Trainers, "TrainerID", "TrainerName", course.TrainerID);
            return View(course);
        }
        [HttpGet]
        public ActionResult Delete(string id)
        {

            Course course = db.Courses.Find(id);

            db.Courses.Remove(course);

            db.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}
