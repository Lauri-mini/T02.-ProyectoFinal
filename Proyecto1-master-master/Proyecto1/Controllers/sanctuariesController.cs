using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto1.Models;

namespace Proyecto1.Controllers
{
    public class sanctuariesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: sanctuaries
        public ActionResult Index()
        {
            return View(db.sanctuaries.ToList());
        }

        // GET: sanctuaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sanctuary sanctuary = db.sanctuaries.Find(id);
            if (sanctuary == null)
            {
                return HttpNotFound();
            }
            return View(sanctuary);
        }
        [Authorize]
        // GET: sanctuaries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: sanctuaries/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Ubicacion,Descripcion")] sanctuary sanctuary)
        {
            if (ModelState.IsValid)
            {
                db.sanctuaries.Add(sanctuary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sanctuary);
        }
        [Authorize]
        // GET: sanctuaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sanctuary sanctuary = db.sanctuaries.Find(id);
            if (sanctuary == null)
            {
                return HttpNotFound();
            }
            return View(sanctuary);
        }

        // POST: sanctuaries/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Ubicacion,Descripcion")] sanctuary sanctuary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanctuary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sanctuary);
        }

        // GET: sanctuaries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sanctuary sanctuary = db.sanctuaries.Find(id);
            if (sanctuary == null)
            {
                return HttpNotFound();
            }
            return View(sanctuary);
        }
        [Authorize]
        // POST: sanctuaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sanctuary sanctuary = db.sanctuaries.Find(id);
            db.sanctuaries.Remove(sanctuary);
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
