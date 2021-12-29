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
    public class StaffsController : Controller
    {
        private hrContext db = new hrContext();

        // GET: Staffs
        public ActionResult Index()
        {
            var staffs = db.Staffs.Include(s => s.Account);
            return View(staffs.ToList());
        }

        // GET: Staffs/Create
        public ActionResult Create()
        {
            ViewBag.Username = new SelectList(db.Accounts,"Username" , "Username");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StaffID,StaffName,StaffEmail,StaffAge,StaffAddr,Username")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                db.Staffs.Add(staff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Username = new SelectList(db.Accounts, "Username", "Password", staff.Username);
            return View(staff);
        }
        public ActionResult Edit(string id)
        {
            Staff staff = db.Staffs.Find(id);
            ViewBag.Username = new SelectList(db.Accounts, "Username", "Password", staff.Username);
            return View(staff);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StaffID,StaffName,StaffEmail,StaffAge,StaffAddr,Username")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Username = new SelectList(db.Accounts, "Username", "Password", staff.Username);
            return View(staff);
        }
        [HttpGet]
        public ActionResult Delete(string id)
        {
            Staff staff = db.Staffs.Find(id);

            db.Staffs.Remove(staff);

            db.SaveChanges();

            return RedirectToAction("Index");

        }

    }
}
