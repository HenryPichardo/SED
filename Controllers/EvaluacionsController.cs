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
    public class EvaluacionsController : Controller
    {
        private SEDEntities db = new SEDEntities();

        // GET: Evaluacions
        public ActionResult Index()
        {
            var evaluacion = db.Evaluacion.Include(e => e.Periodo).Include(e => e.Tipo_Evaluador);
            return View(evaluacion.ToList());
        }

        // GET: Evaluacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluacion evaluacion = db.Evaluacion.Find(id);
            if (evaluacion == null)
            {
                return HttpNotFound();
            }
            return View(evaluacion);
        }

        // GET: Evaluacions/Create
        public ActionResult Create()
        {
            ViewBag.fk_id_periodo = new SelectList(db.Periodo, "id_periodo", "periodo1");
            ViewBag.fk_id_tipo_evaluador = new SelectList(db.Tipo_Evaluador, "id_tipo_evaluador", "nombre");
            return View();
        }

        // POST: Evaluacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_evaluacion,fk_id_tipo_evaluador,fk_id_periodo,estado,fk_id_tipo_cuestionario,fecha_registro")] Evaluacion evaluacion)
        {
            if (ModelState.IsValid)
            {
                db.Evaluacion.Add(evaluacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_id_periodo = new SelectList(db.Periodo, "id_periodo", "periodo1", evaluacion.fk_id_periodo);
            ViewBag.fk_id_tipo_evaluador = new SelectList(db.Tipo_Evaluador, "id_tipo_evaluador", "nombre", evaluacion.fk_id_tipo_evaluador);
            return View(evaluacion);
        }

        // GET: Evaluacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluacion evaluacion = db.Evaluacion.Find(id);
            if (evaluacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_id_periodo = new SelectList(db.Periodo, "id_periodo", "periodo1", evaluacion.fk_id_periodo);
            ViewBag.fk_id_tipo_evaluador = new SelectList(db.Tipo_Evaluador, "id_tipo_evaluador", "nombre", evaluacion.fk_id_tipo_evaluador);
            return View(evaluacion);
        }

        // POST: Evaluacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_evaluacion,fk_id_tipo_evaluador,fk_id_periodo,estado,fk_id_tipo_cuestionario,fecha_registro")] Evaluacion evaluacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evaluacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_id_periodo = new SelectList(db.Periodo, "id_periodo", "periodo1", evaluacion.fk_id_periodo);
            ViewBag.fk_id_tipo_evaluador = new SelectList(db.Tipo_Evaluador, "id_tipo_evaluador", "nombre", evaluacion.fk_id_tipo_evaluador);
            return View(evaluacion);
        }

        // GET: Evaluacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluacion evaluacion = db.Evaluacion.Find(id);
            if (evaluacion == null)
            {
                return HttpNotFound();
            }
            return View(evaluacion);
        }

        // POST: Evaluacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Evaluacion evaluacion = db.Evaluacion.Find(id);
            db.Evaluacion.Remove(evaluacion);
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
