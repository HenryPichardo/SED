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
    public class Docente_EvaluacionController : Controller
    {
        private SEDEntities db = new SEDEntities();

        // GET: Docente_Evaluacion
        public ActionResult Index()
        {
            var docente_Evaluacion = db.Docente_Evaluacion.Include(d => d.Docentes).Include(d => d.Evaluacion);
            return View(docente_Evaluacion.ToList());
        }

        // GET: Docente_Evaluacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Docente_Evaluacion docente_Evaluacion = db.Docente_Evaluacion.Find(id);
            if (docente_Evaluacion == null)
            {
                return HttpNotFound();
            }
            return View(docente_Evaluacion);
        }

        // GET: Docente_Evaluacion/Create
        public ActionResult Create()
        {
            ViewBag.fk_id_docente = new SelectList(db.Docentes, "id_docente", "codigo_empleado");
            ViewBag.fk_id_evaluacion = new SelectList(db.Evaluacion, "id_evaluacion", "estado");
            return View();
        }

        // POST: Docente_Evaluacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "fk_id_docente,fk_id_evaluacion,id_docente_evaluacion")] Docente_Evaluacion docente_Evaluacion)
        {
            if (ModelState.IsValid)
            {
                db.Docente_Evaluacion.Add(docente_Evaluacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_id_docente = new SelectList(db.Docentes, "id_docente", "codigo_empleado", docente_Evaluacion.fk_id_docente);
            ViewBag.fk_id_evaluacion = new SelectList(db.Evaluacion, "id_evaluacion", "estado", docente_Evaluacion.fk_id_evaluacion);
            return View(docente_Evaluacion);
        }

        // GET: Docente_Evaluacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Docente_Evaluacion docente_Evaluacion = db.Docente_Evaluacion.Find(id);
            if (docente_Evaluacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_id_docente = new SelectList(db.Docentes, "id_docente", "codigo_empleado", docente_Evaluacion.fk_id_docente);
            ViewBag.fk_id_evaluacion = new SelectList(db.Evaluacion, "id_evaluacion", "estado", docente_Evaluacion.fk_id_evaluacion);
            return View(docente_Evaluacion);
        }

        // POST: Docente_Evaluacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "fk_id_docente,fk_id_evaluacion,id_docente_evaluacion")] Docente_Evaluacion docente_Evaluacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(docente_Evaluacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_id_docente = new SelectList(db.Docentes, "id_docente", "codigo_empleado", docente_Evaluacion.fk_id_docente);
            ViewBag.fk_id_evaluacion = new SelectList(db.Evaluacion, "id_evaluacion", "estado", docente_Evaluacion.fk_id_evaluacion);
            return View(docente_Evaluacion);
        }

        // GET: Docente_Evaluacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Docente_Evaluacion docente_Evaluacion = db.Docente_Evaluacion.Find(id);
            if (docente_Evaluacion == null)
            {
                return HttpNotFound();
            }
            return View(docente_Evaluacion);
        }

        // POST: Docente_Evaluacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Docente_Evaluacion docente_Evaluacion = db.Docente_Evaluacion.Find(id);
            db.Docente_Evaluacion.Remove(docente_Evaluacion);
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
