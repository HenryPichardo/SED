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
    public class Preguntas_CuestionarioController : Controller
    {
        private SEDEntities db = new SEDEntities();

        // GET: Preguntas_Cuestionario
        public ActionResult Index()
        {
            var preguntas_Cuestionario = db.Preguntas_Cuestionario.Include(p => p.Pregunta);
            return View(preguntas_Cuestionario.ToList());
        }

        // GET: Preguntas_Cuestionario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Preguntas_Cuestionario preguntas_Cuestionario = db.Preguntas_Cuestionario.Find(id);
            if (preguntas_Cuestionario == null)
            {
                return HttpNotFound();
            }
            return View(preguntas_Cuestionario);
        }

        // GET: Preguntas_Cuestionario/Create
        public ActionResult Create()
        {
            ViewBag.fk_id_pregunta = new SelectList(db.Pregunta, "id_pregunta", "nombre_pregunta");
            return View();
        }

        // POST: Preguntas_Cuestionario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_cuestionario,fk_id_pregunta")] Preguntas_Cuestionario preguntas_Cuestionario)
        {
            if (ModelState.IsValid)
            {
                db.Preguntas_Cuestionario.Add(preguntas_Cuestionario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_id_pregunta = new SelectList(db.Pregunta, "id_pregunta", "nombre_pregunta", preguntas_Cuestionario.fk_id_pregunta);
            return View(preguntas_Cuestionario);
        }

        // GET: Preguntas_Cuestionario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Preguntas_Cuestionario preguntas_Cuestionario = db.Preguntas_Cuestionario.Find(id);
            if (preguntas_Cuestionario == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_id_pregunta = new SelectList(db.Pregunta, "id_pregunta", "nombre_pregunta", preguntas_Cuestionario.fk_id_pregunta);
            return View(preguntas_Cuestionario);
        }

        // POST: Preguntas_Cuestionario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_cuestionario,fk_id_pregunta")] Preguntas_Cuestionario preguntas_Cuestionario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(preguntas_Cuestionario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_id_pregunta = new SelectList(db.Pregunta, "id_pregunta", "nombre_pregunta", preguntas_Cuestionario.fk_id_pregunta);
            return View(preguntas_Cuestionario);
        }

        // GET: Preguntas_Cuestionario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Preguntas_Cuestionario preguntas_Cuestionario = db.Preguntas_Cuestionario.Find(id);
            if (preguntas_Cuestionario == null)
            {
                return HttpNotFound();
            }
            return View(preguntas_Cuestionario);
        }

        // POST: Preguntas_Cuestionario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Preguntas_Cuestionario preguntas_Cuestionario = db.Preguntas_Cuestionario.Find(id);
            db.Preguntas_Cuestionario.Remove(preguntas_Cuestionario);
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
