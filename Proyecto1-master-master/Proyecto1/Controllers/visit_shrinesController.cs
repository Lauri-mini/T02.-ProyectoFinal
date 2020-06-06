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
    public class visit_shrinesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: visit_shrines
        public ActionResult Index()
        {
            var visit_shrine = db.visit_shrine.Include(v => v.santuario).Include(v => v.visita);
            return View(visit_shrine.ToList());
        }

        // GET: visit_shrines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            visit_shrine visit_shrine = db.visit_shrine.Find(id);
            if (visit_shrine == null)
            {
                return HttpNotFound();
            }
            return View(visit_shrine);
        }

        // GET: visit_shrines/Create
        public ActionResult Create()
        {
            ViewBag.SantuarioId = new SelectList(db.sanctuaries, "Id", "Nombre");
            ViewBag.VisitaId = new SelectList(db.visits, "Id", "Nombre");
            return View();
        }

        // POST: visit_shrines/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SantuarioId,VisitaId")] visit_shrine visit_shrine)
        {
            if (ModelState.IsValid)
            {
                db.visit_shrine.Add(visit_shrine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SantuarioId = new SelectList(db.sanctuaries, "Id", "Nombre", visit_shrine.SantuarioId);
            ViewBag.VisitaId = new SelectList(db.visits, "Id", "Nombre", visit_shrine.VisitaId);
            return View(visit_shrine);
        }

        // GET: visit_shrines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            visit_shrine visit_shrine = db.visit_shrine.Find(id);
            if (visit_shrine == null)
            {
                return HttpNotFound();
            }
            ViewBag.SantuarioId = new SelectList(db.sanctuaries, "Id", "Nombre", visit_shrine.SantuarioId);
            ViewBag.VisitaId = new SelectList(db.visits, "Id", "Nombre", visit_shrine.VisitaId);
            return View(visit_shrine);
        }

        // POST: visit_shrines/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SantuarioId,VisitaId")] visit_shrine visit_shrine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visit_shrine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SantuarioId = new SelectList(db.sanctuaries, "Id", "Nombre", visit_shrine.SantuarioId);
            ViewBag.VisitaId = new SelectList(db.visits, "Id", "Nombre", visit_shrine.VisitaId);
            return View(visit_shrine);
        }

        // GET: visit_shrines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            visit_shrine visit_shrine = db.visit_shrine.Find(id);
            if (visit_shrine == null)
            {
                return HttpNotFound();
            }
            return View(visit_shrine);
        }

        // POST: visit_shrines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            visit_shrine visit_shrine = db.visit_shrine.Find(id);
            db.visit_shrine.Remove(visit_shrine);
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
