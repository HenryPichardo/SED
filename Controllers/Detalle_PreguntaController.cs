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
    public class Detalle_PreguntaController : Controller
    {
        private SEDEntities db = new SEDEntities();

        // GET: Detalle_Pregunta
        public ActionResult Index()
        {
            var detalle_Pregunta = db.Detalle_Pregunta.Include(d => d.Pregunta);
            return View(detalle_Pregunta.ToList());
        }

        // GET: Detalle_Pregunta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Pregunta detalle_Pregunta = db.Detalle_Pregunta.Find(id);
            if (detalle_Pregunta == null)
            {
                return HttpNotFound();
            }
            return View(detalle_Pregunta);
        }

        // GET: Detalle_Pregunta/Create
        public ActionResult Create()
        {
            ViewBag.fk_id_pregunta = new SelectList(db.Pregunta, "id_pregunta", "nombre_pregunta");
            return View();
        }

        // POST: Detalle_Pregunta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "fk_id_pregunta,opcion")] Detalle_Pregunta detalle_Pregunta)
        {
            if (ModelState.IsValid)
            {
                db.Detalle_Pregunta.Add(detalle_Pregunta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_id_pregunta = new SelectList(db.Pregunta, "id_pregunta", "nombre_pregunta", detalle_Pregunta.fk_id_pregunta);
            return View(detalle_Pregunta);
        }

        // GET: Detalle_Pregunta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Pregunta detalle_Pregunta = db.Detalle_Pregunta.Find(id);
            if (detalle_Pregunta == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_id_pregunta = new SelectList(db.Pregunta, "id_pregunta", "nombre_pregunta", detalle_Pregunta.fk_id_pregunta);
            return View(detalle_Pregunta);
        }

        // POST: Detalle_Pregunta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "fk_id_pregunta,opcion")] Detalle_Pregunta detalle_Pregunta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalle_Pregunta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_id_pregunta = new SelectList(db.Pregunta, "id_pregunta", "nombre_pregunta", detalle_Pregunta.fk_id_pregunta);
            return View(detalle_Pregunta);
        }

        // GET: Detalle_Pregunta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Pregunta detalle_Pregunta = db.Detalle_Pregunta.Find(id);
            if (detalle_Pregunta == null)
            {
                return HttpNotFound();
            }
            return View(detalle_Pregunta);
        }

        // POST: Detalle_Pregunta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Detalle_Pregunta detalle_Pregunta = db.Detalle_Pregunta.Find(id);
            db.Detalle_Pregunta.Remove(detalle_Pregunta);
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
