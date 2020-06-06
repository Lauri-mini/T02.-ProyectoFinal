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
    public class biodiversitiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: biodiversities
        public ActionResult Index()
        {
            var biodiversities = db.biodiversities.Include(b => b.santuario);
            return View(biodiversities.ToList());
        }

        // GET: biodiversities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            biodiversity biodiversity = db.biodiversities.Find(id);
            if (biodiversity == null)
            {
                return HttpNotFound();
            }
            return View(biodiversity);
        }
        [Authorize]
        // GET: biodiversities/Create
        public ActionResult Create()
        {
            ViewBag.SantuarioId = new SelectList(db.sanctuaries, "Id", "Nombre");
            return View();
        }

        // POST: biodiversities/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(biodiversity biodiversity, HttpPostedFileBase hpb)
        {
            if (ModelState.IsValid)
            {
                if (hpb != null)
                {
                    var foto = System.IO.Path.GetFileName(hpb.FileName);
                    var direccion = "~/Content/img/" + biodiversity.Nombre + "_" + foto;
                    hpb.SaveAs(Server.MapPath(direccion));
                    biodiversity.ImgUrl = biodiversity.Nombre + "_" + foto;
                }

                db.biodiversities.Add(biodiversity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SantuarioId = new SelectList(db.sanctuaries, "Id", "Nombre", biodiversity.SantuarioId);
            return View(biodiversity);
        }
        [Authorize]
        // GET: biodiversities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            biodiversity biodiversity = db.biodiversities.Find(id);
            if (biodiversity == null)
            {
                return HttpNotFound();
            }
            ViewBag.SantuarioId = new SelectList(db.sanctuaries, "Id", "Nombre", biodiversity.SantuarioId);
            return View(biodiversity);
        }

        // POST: biodiversities/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Tipo,Descripcion,Especie,ImgUrl,SantuarioId")] biodiversity biodiversity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(biodiversity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SantuarioId = new SelectList(db.sanctuaries, "Id", "Nombre", biodiversity.SantuarioId);
            return View(biodiversity);
        }
        [Authorize]
        // GET: biodiversities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            biodiversity biodiversity = db.biodiversities.Find(id);
            if (biodiversity == null)
            {
                return HttpNotFound();
            }
            return View(biodiversity);
        }

        // POST: biodiversities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            biodiversity biodiversity = db.biodiversities.Find(id);
            db.biodiversities.Remove(biodiversity);
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
