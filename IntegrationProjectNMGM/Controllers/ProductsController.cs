using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IntegrationProjectNMGM.Models;
using System.IO;

namespace IntegrationProjectNMGM.Controllers
{
    public class ProductsController : Controller
    {
        private ProductDbContext db = new ProductDbContext();

        // GET: Products
        public ActionResult Index()
        {
            return View(/*db.Products.ToList()*/);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            List<Review> reviews = new List<Review>();
            var r = db.Reviews.Where(s => s.ProductId == id);
            foreach (Review re in r)
            {
                reviews.Add(re);
            }
            List<Image> images = new List<Image>();
            var i = db.Images.Where(y => y.ProductId == id);
            foreach (Image im in i)
            {
                images.Add(im);
            }

            ProductDetails productDetails = new ProductDetails()
            {
                CurrentProduct = product,
                Reviews = reviews,
                Images = images
            };
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(productDetails);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }
            
        
        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Description,MSRP,CurrentPrice,Enabled")] Product product, HttpPostedFileBase file)
        {
            /********************************** IMAGE UPLOAD **********************************/
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/IntegrationProjectNMGM/Models/Images"),
                                                Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ViewBag.Messsage = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Error: " + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            /**********************************************************************************/
            if (ModelState.IsValid)
            {
                db.Products.Add(product);

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Create
        public ActionResult Review(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return View();
        }



        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,Description,MSRP,CurrentPrice,Enabled")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
    }
}
