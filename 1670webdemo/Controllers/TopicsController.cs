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
    public class TopicsController : Controller
    {
        private hrContext db = new hrContext();

        // GET: Topics
        public ActionResult Index()
        {
            var topics = db.Topics.Include(t => t.Course);
            return View(topics.ToList());
        }
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TopicID,TopicName,TopicDesc,CourseID")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                db.Topics.Add(topic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseName", "CourseName", topic.CourseID);
            return View(topic);
        }

        // GET: Topics/Edit/5
        public ActionResult Edit(string id)
        {
            Topic topic = db.Topics.Find(id);
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", topic.CourseID);
            return View(topic);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TopicID,TopicName,TopicDesc,CourseID")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(topic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", topic.CourseID);
            return View(topic);
        }

        public ActionResult Delete(string id)
        {
            Topic topic = db.Topics.Find(id);

            db.Topics.Remove(topic);

            db.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}
