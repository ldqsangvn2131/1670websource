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
    public class TraineesController : Controller
    {
        private hrContext db = new hrContext();

        public ActionResult Index()
        {
            var trainees = db.Trainees.Include(t => t.Account);
            return View(trainees.ToList());
        }
        public ActionResult Profiles()
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Login", "Accounts");
            }
            string Username = Session["Username"].ToString();
            Trainee trainee = new Trainee();
            trainee = db.Trainees.Where(a => a.Username == Username).FirstOrDefault();
            return View(trainee);
        }
        public ActionResult Create()
        {
            ViewBag.Username = new SelectList(db.Accounts.Where(g => g.AccountType == "Trainee"), "Username", "Username");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TraineeID,TraineeName,TraineeEmail,TraineeAge,TraineeDoB,TraineeEdu,Username")] Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                db.Trainees.Add(trainee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Username = new SelectList(db.Accounts.Where(g => g.AccountType == "Trainee"), trainee.Username);
            return View(trainee);
        }
        public ActionResult Edit(string id)
        {
            Trainee trainee = db.Trainees.Find(id);
            ViewBag.Username = new SelectList(db.Accounts, "Username", "Username", trainee.Username);
            return View(trainee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TraineeID,TraineeName,TraineeEmail,TraineeAge,TraineeDoB,TraineeEdu,Username")] Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Username = new SelectList(db.Accounts, "Username", "Password", trainee.Username);
            return View(trainee);
        }
        [HttpGet]
        public ActionResult Delete(string id)
        {

            Trainee trainee = db.Trainees.Find(id);

            db.Trainees.Remove(trainee);

            db.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}
