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
    public class CourseDetailsController : Controller
    {
        private hrContext db = new hrContext();

        public ActionResult Index()
        {
            var courseDetails = db.CourseDetails.Include(c => c.Course).Include(c => c.Topic).Include(c => c.Trainee).Include(c => c.Trainer);
            return View(courseDetails.ToList());
        }

       
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName");
            ViewBag.TopicID = new SelectList(db.Topics, "TopicID", "TopicName");
            ViewBag.TraineeID = new SelectList(db.Trainees, "TraineeID", "TraineeName");
            ViewBag.TrainerID = new SelectList(db.Trainers, "TrainerID", "TrainerName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseDetailID,CourseID,TrainerID,TraineeID,TopicID")] CourseDetail courseDetail)
        {
            if (ModelState.IsValid)
            {
                db.CourseDetails.Add(courseDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", courseDetail.CourseID);
            ViewBag.TopicID = new SelectList(db.Topics, "TopicID", "TopicName", courseDetail.TopicID);
            ViewBag.TraineeID = new SelectList(db.Trainees, "TraineeID", "TraineeName", courseDetail.TraineeID);
            ViewBag.TrainerID = new SelectList(db.Trainers, "TrainerID", "TrainerName", courseDetail.TrainerID);
            return View(courseDetail);
        }

        public ActionResult Edit(string id)
        {
            CourseDetail courseDetail = db.CourseDetails.Find(id);
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", courseDetail.CourseID);
            ViewBag.TopicID = new SelectList(db.Topics, "TopicID", "TopicName", courseDetail.TopicID);
            ViewBag.TraineeID = new SelectList(db.Trainees, "TraineeID", "TraineeName", courseDetail.TraineeID);
            ViewBag.TrainerID = new SelectList(db.Trainers, "TrainerID", "TrainerName", courseDetail.TrainerID);
            return View(courseDetail);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseDetailID,CourseID,TrainerID,TraineeID,TopicID")] CourseDetail courseDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", courseDetail.CourseID);
            ViewBag.TopicID = new SelectList(db.Topics, "TopicID", "TopicName", courseDetail.TopicID);
            ViewBag.TraineeID = new SelectList(db.Trainees, "TraineeID", "TraineeName", courseDetail.TraineeID);
            ViewBag.TrainerID = new SelectList(db.Trainers, "TrainerID", "TrainerName", courseDetail.TrainerID);
            return View(courseDetail);
        }
        [HttpGet]
        public ActionResult Delete(string id)
        {

            CourseDetail courseDetail = db.CourseDetails.Find(id);

            db.CourseDetails.Remove(courseDetail);

            db.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}
