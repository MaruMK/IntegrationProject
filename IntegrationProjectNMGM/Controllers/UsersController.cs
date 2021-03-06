﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IntegrationProjectNMGM.Models;

namespace IntegrationProjectNMGM.Controllers
{
    public class UsersController : Controller
    {
        private ProductDbContext db = new ProductDbContext();

        // GET: Users
        public ActionResult Index()
        {
            if(!String.IsNullOrEmpty((String) Session["username"])){
                if((bool)Session["manager"])
                    return View(db.Users.ToList());
                else
                    return RedirectToAction("Index", "Home");
            }
            else
                return RedirectToAction("Login");
        }

        // GET: Users/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(int.Parse(id));
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,Username,FName,LName,Password,Email")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(int.Parse(id));
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Username,FName,LName,Password,Email")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //=========================================================================================================
        // GET: Users/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Users/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Username,Password")] User user)
        {
            string userName = user.Username;
            string passWord = user.Password;

            var query = from User in db.Users
                        where User.Username == userName
                        select User;

            if (query.Count() > 0 && query.First().Password == user.Password)
            {
                Session["id"] = query.First().UserID;
                Session["userName"] = userName;
                Session["manager"] = query.First().Manager;
                return RedirectToAction("Index", "Home");            
            }
            else
            {
                Response.Write("<script>alert('Username or Password incorrect');</script>");
                return View(user);
            }

        }
        //=========================================================================================================

        //=========================================================================================================
        // GET: Users/Logoff
        public ActionResult Logoff()
        {
            Session.Abandon();
            return View();
        }
        //=========================================================================================================

        //=========================================================================================================
        // GET: Users/Login
        public ActionResult Forgot()
        {
            return View();
        }

        // POST: Users/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Forgot([Bind(Include = "Email,LName")] User user)
        {
            string email = user.Email;
            string lname = user.LName;

            var query = from User in db.Users
                        where User.Email == email
                        select User;

            if (query.Count() > 0 && query.First().LName == lname)
            {
                Response.Write("<script>alert('Password is: "+query.First().Password+"');</script>");
                return View();
            }
            else
            {
                Response.Write("<script>alert('Account doesn't exist or last name doesn't correspond');</script>");
                return View();
            }

        }
        //=========================================================================================================

    }
}
