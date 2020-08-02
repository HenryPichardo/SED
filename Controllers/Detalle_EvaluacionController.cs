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
    public class Detalle_EvaluacionController : Controller
    {
        private SEDEntities db = new SEDEntities();

        // GET: Detalle_Evaluacion
        public ActionResult Index()
        {
            var detalle_Evaluacion = db.Detalle_Evaluacion.Include(d => d.Evaluacion).Include(d => d.Pregunta);
            return View(detalle_Evaluacion.ToList());
        }

        // GET: Detalle_Evaluacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Evaluacion detalle_Evaluacion = db.Detalle_Evaluacion.Find(id);
            if (detalle_Evaluacion == null)
            {
                return HttpNotFound();
            }
            return View(detalle_Evaluacion);
        }

        // GET: Detalle_Evaluacion/Create
        public ActionResult Create()
        {
            ViewBag.fk_id_evaluacion = new SelectList(db.Evaluacion, "id_evaluacion", "estado");
            ViewBag.fk_id_pregunta = new SelectList(db.Pregunta, "id_pregunta", "nombre_pregunta");
            return View();
        }

        // POST: Detalle_Evaluacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_detalle_evaluacion,fk_id_evaluacion,fk_id_pregunta,fk_id_respuesta")] Detalle_Evaluacion detalle_Evaluacion)
        {
            if (ModelState.IsValid)
            {
                db.Detalle_Evaluacion.Add(detalle_Evaluacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_id_evaluacion = new SelectList(db.Evaluacion, "id_evaluacion", "estado", detalle_Evaluacion.fk_id_evaluacion);
            ViewBag.fk_id_pregunta = new SelectList(db.Pregunta, "id_pregunta", "nombre_pregunta", detalle_Evaluacion.fk_id_pregunta);
            return View(detalle_Evaluacion);
        }

        // GET: Detalle_Evaluacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Evaluacion detalle_Evaluacion = db.Detalle_Evaluacion.Find(id);
            if (detalle_Evaluacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_id_evaluacion = new SelectList(db.Evaluacion, "id_evaluacion", "estado", detalle_Evaluacion.fk_id_evaluacion);
            ViewBag.fk_id_pregunta = new SelectList(db.Pregunta, "id_pregunta", "nombre_pregunta", detalle_Evaluacion.fk_id_pregunta);
            return View(detalle_Evaluacion);
        }

        // POST: Detalle_Evaluacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_detalle_evaluacion,fk_id_evaluacion,fk_id_pregunta,fk_id_respuesta")] Detalle_Evaluacion detalle_Evaluacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalle_Evaluacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_id_evaluacion = new SelectList(db.Evaluacion, "id_evaluacion", "estado", detalle_Evaluacion.fk_id_evaluacion);
            ViewBag.fk_id_pregunta = new SelectList(db.Pregunta, "id_pregunta", "nombre_pregunta", detalle_Evaluacion.fk_id_pregunta);
            return View(detalle_Evaluacion);
        }

        // GET: Detalle_Evaluacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Evaluacion detalle_Evaluacion = db.Detalle_Evaluacion.Find(id);
            if (detalle_Evaluacion == null)
            {
                return HttpNotFound();
            }
            return View(detalle_Evaluacion);
        }

        // POST: Detalle_Evaluacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Detalle_Evaluacion detalle_Evaluacion = db.Detalle_Evaluacion.Find(id);
            db.Detalle_Evaluacion.Remove(detalle_Evaluacion);
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
