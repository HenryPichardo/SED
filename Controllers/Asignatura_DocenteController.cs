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
    public class Asignatura_DocenteController : Controller
    {
        private SEDEntities db = new SEDEntities();

        // GET: Asignatura_Docente
        public ActionResult Index()
        {
            var asignatura_Docente = db.Asignatura_Docente.Include(a => a.Asignatura).Include(a => a.Docentes);
            return View(asignatura_Docente.ToList());
        }

        // GET: Asignatura_Docente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignatura_Docente asignatura_Docente = db.Asignatura_Docente.Find(id);
            if (asignatura_Docente == null)
            {
                return HttpNotFound();
            }
            return View(asignatura_Docente);
        }

        // GET: Asignatura_Docente/Create
        public ActionResult Create()
        {
            ViewBag.fk_id_asignatura = new SelectList(db.Asignatura, "id_asignatura", "nombre");
            ViewBag.fk_id_docente = new SelectList(db.Docentes, "id_docente", "codigo_empleado");
            return View();
        }

        // POST: Asignatura_Docente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_asignatura_docente,fk_id_asignatura,fk_id_docente")] Asignatura_Docente asignatura_Docente)
        {
            if (ModelState.IsValid)
            {
                db.Asignatura_Docente.Add(asignatura_Docente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_id_asignatura = new SelectList(db.Asignatura, "id_asignatura", "nombre", asignatura_Docente.fk_id_asignatura);
            ViewBag.fk_id_docente = new SelectList(db.Docentes, "id_docente", "codigo_empleado", asignatura_Docente.fk_id_docente);
            return View(asignatura_Docente);
        }

        // GET: Asignatura_Docente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignatura_Docente asignatura_Docente = db.Asignatura_Docente.Find(id);
            if (asignatura_Docente == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_id_asignatura = new SelectList(db.Asignatura, "id_asignatura", "nombre", asignatura_Docente.fk_id_asignatura);
            ViewBag.fk_id_docente = new SelectList(db.Docentes, "id_docente", "codigo_empleado", asignatura_Docente.fk_id_docente);
            return View(asignatura_Docente);
        }

        // POST: Asignatura_Docente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_asignatura_docente,fk_id_asignatura,fk_id_docente")] Asignatura_Docente asignatura_Docente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asignatura_Docente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_id_asignatura = new SelectList(db.Asignatura, "id_asignatura", "nombre", asignatura_Docente.fk_id_asignatura);
            ViewBag.fk_id_docente = new SelectList(db.Docentes, "id_docente", "codigo_empleado", asignatura_Docente.fk_id_docente);
            return View(asignatura_Docente);
        }

        // GET: Asignatura_Docente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignatura_Docente asignatura_Docente = db.Asignatura_Docente.Find(id);
            if (asignatura_Docente == null)
            {
                return HttpNotFound();
            }
            return View(asignatura_Docente);
        }

        // POST: Asignatura_Docente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asignatura_Docente asignatura_Docente = db.Asignatura_Docente.Find(id);
            db.Asignatura_Docente.Remove(asignatura_Docente);
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
