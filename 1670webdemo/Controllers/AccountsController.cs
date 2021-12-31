using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using _1670webdemo.Models;

namespace _1670webdemo.Controllers
{
    public class AccountsController : Controller
    {
        private hrContext db = new hrContext();
        public static string GetMD5(string str)
        {
            if (string.IsNullOrEmpty(str))
                return null;
            else
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] fromData = Encoding.UTF8.GetBytes(str);
                byte[] targetData = md5.ComputeHash(fromData);
                string byte2String = null;

                for (int i = 0; i < targetData.Length; i++)
                {
                    byte2String += targetData[i].ToString("x2");

                }
                return byte2String;
            }
        }
        public ActionResult Index()
        {
            return View(db.Accounts.Where(g => g.AccountType != "Admin").ToList());
        }
        public ActionResult Create()
        {
            ViewBag.AccountType = new SelectList(db.Accounts, "AccountType", "AccountType");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Username,Password,State,AccountType")] Account account)
        {
            if (ModelState.IsValid)
            {
                var isUsernameAlreadyExists = db.Accounts.Any(x => x.Username == account.Username);
                if (isUsernameAlreadyExists)
                {
                    return View(account);
                }
                ViewBag.AccountType = new SelectList(db.Accounts, "AccountType", "AccountType",account.AccountType);
                account.Password = GetMD5(account.Password);
                db.Configuration.ValidateOnSaveEnabled = false;
                db.Accounts.Add(account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(account);
        }

        public ActionResult Edit(string id)
        {
            Account account = db.Accounts.Find(id);
            return View(account);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Username,Password,State,AccountType")] Account account)
        {
            if (ModelState.IsValid)
            {
                
                account.Password = GetMD5(account.Password);
                db.Configuration.ValidateOnSaveEnabled = false;
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(account);
        }
        [HttpGet]
        public ActionResult Delete(string id)
        {
            Account account = db.Accounts.FirstOrDefault(t => t.Username == id);
            foreach (var item in account.Staffs.ToList())
            {
               db.Staffs.Remove(item);
            }
            foreach (var item in account.Trainers.ToList())
            {
                db.Trainers.Remove(item);
            }
            foreach (var item in account.Trainees.ToList())
            {
                db.Trainees.Remove(item);
            }
            db.Accounts.Remove(account);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        public ActionResult Login([Bind(Include = "UserName,Password,AccountType")] Account account)
        {
            Account acc = new Account();
            account.Password = GetMD5(account.Password);
            db.Configuration.ValidateOnSaveEnabled = false;
            acc = db.Accounts.Where(a => a.Username == account.Username && a.Password == account.Password).FirstOrDefault();
            if (acc != null)
            {
                Session["Username"] = acc.Username;
                Session["AccountType"] = acc.AccountType;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login", "Accounts");
            }
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }
        
    }
}
