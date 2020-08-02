using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SED.Models;

namespace SED.Controllers
{
    public class EscuelasController : Controller
    {
        private SEDEntities db = new SEDEntities();

        // GET: Escuelas
        public ActionResult Index()
        {
            return View(db.Escuela.ToList());
        }

        // GET: Escuelas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Escuela escuela = db.Escuela.Find(id);
            if (escuela == null)
            {
                return HttpNotFound();
            }
            return View(escuela);
        }

        // GET: Escuelas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Escuelas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_escuela,nombre,clave,descripcion,fecha_registro")] Escuela escuela)
        {
            if (ModelState.IsValid)
            {
                db.Escuela.Add(escuela);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(escuela);
        }

        // GET: Escuelas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Escuela escuela = db.Escuela.Find(id);
            if (escuela == null)
            {
                return HttpNotFound();
            }
            return View(escuela);
        }

        // POST: Escuelas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_escuela,nombre,clave,descripcion,fecha_registro")] Escuela escuela)
        {
            if (ModelState.IsValid)
            {
                db.Entry(escuela).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(escuela);
        }

        // GET: Escuelas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Escuela escuela = db.Escuela.Find(id);
            if (escuela == null)
            {
                return HttpNotFound();
            }
            return View(escuela);
        }

        // POST: Escuelas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Escuela escuela = db.Escuela.Find(id);
            db.Escuela.Remove(escuela);
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
