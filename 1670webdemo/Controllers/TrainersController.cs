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
    public class TrainersController : Controller
    {
        private hrContext db = new hrContext();

        // GET: Trainers
        public ActionResult Index()
        {
            var trainers = db.Trainers.Include(t => t.Account);
            return View(trainers.ToList());
        }

        // GET: Trainers/Create
        public ActionResult Create()
        {
            ViewBag.Username = new SelectList(db.Accounts, "Username", "Username");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrainerID,TrainerName,TrainerEmail,TrainerSpec,TrainerAge,TrainerAddr,Username")] Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                db.Trainers.Add(trainer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Username = new SelectList(db.Accounts, "Username", "Password", trainer.Username);
            return View(trainer);
        }
        public ActionResult Edit(string id)
        {
            Trainer trainer = db.Trainers.Find(id);
            ViewBag.Username = new SelectList(db.Accounts, "Username", "Password", trainer.Username);
            return View(trainer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrainerID,TrainerName,TrainerEmail,TrainerSpec,TrainerAge,TrainerAddr,Username")] Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Username = new SelectList(db.Accounts, "Username", "Password", trainer.Username);
            return View(trainer);
        }
        [HttpGet]
        public ActionResult Delete(string id)
        {

            Trainer trainer = db.Trainers.Find(id);

            db.Trainers.Remove(trainer);

            db.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}
