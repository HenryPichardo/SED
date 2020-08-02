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
    public class PreguntasController : Controller
    {
        private SEDEntities db = new SEDEntities();

        // GET: Preguntas
        public ActionResult Index()
        {
            var pregunta = db.Pregunta.Include(p => p.Categoria_Pregunta).Include(p => p.Tipo_Pregunta);
            return View(pregunta.ToList());
        }

        // GET: Preguntas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pregunta pregunta = db.Pregunta.Find(id);
            if (pregunta == null)
            {
                return HttpNotFound();
            }
            return View(pregunta);
        }

        // GET: Preguntas/Create
        public ActionResult Create()
        {
            ViewBag.fk_id_categoria_pregunta = new SelectList(db.Categoria_Pregunta, "id_categoria_pregunta", "nombre");
            ViewBag.fk_id_tipo_pregunta = new SelectList(db.Tipo_Pregunta, "id_tipo_pregunta", "nombre");
            return View();
        }

        // POST: Preguntas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_pregunta,fk_id_categoria_pregunta,fk_id_tipo_pregunta,nombre_pregunta,pregunta1,fecha_registro")] Pregunta pregunta)
        {
            if (ModelState.IsValid)
            {
                db.Pregunta.Add(pregunta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_id_categoria_pregunta = new SelectList(db.Categoria_Pregunta, "id_categoria_pregunta", "nombre", pregunta.fk_id_categoria_pregunta);
            ViewBag.fk_id_tipo_pregunta = new SelectList(db.Tipo_Pregunta, "id_tipo_pregunta", "nombre", pregunta.fk_id_tipo_pregunta);
            return View(pregunta);
        }

        // GET: Preguntas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pregunta pregunta = db.Pregunta.Find(id);
            if (pregunta == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_id_categoria_pregunta = new SelectList(db.Categoria_Pregunta, "id_categoria_pregunta", "nombre", pregunta.fk_id_categoria_pregunta);
            ViewBag.fk_id_tipo_pregunta = new SelectList(db.Tipo_Pregunta, "id_tipo_pregunta", "nombre", pregunta.fk_id_tipo_pregunta);
            return View(pregunta);
        }

        // POST: Preguntas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_pregunta,fk_id_categoria_pregunta,fk_id_tipo_pregunta,nombre_pregunta,pregunta1,fecha_registro")] Pregunta pregunta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pregunta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_id_categoria_pregunta = new SelectList(db.Categoria_Pregunta, "id_categoria_pregunta", "nombre", pregunta.fk_id_categoria_pregunta);
            ViewBag.fk_id_tipo_pregunta = new SelectList(db.Tipo_Pregunta, "id_tipo_pregunta", "nombre", pregunta.fk_id_tipo_pregunta);
            return View(pregunta);
        }

        // GET: Preguntas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pregunta pregunta = db.Pregunta.Find(id);
            if (pregunta == null)
            {
                return HttpNotFound();
            }
            return View(pregunta);
        }

        // POST: Preguntas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pregunta pregunta = db.Pregunta.Find(id);
            db.Pregunta.Remove(pregunta);
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
