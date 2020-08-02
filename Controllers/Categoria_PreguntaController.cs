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
    public class Categoria_PreguntaController : Controller
    {
        private SEDEntities db = new SEDEntities();

        // GET: Categoria_Pregunta
        public ActionResult Index()
        {
            return View(db.Categoria_Pregunta.ToList());
        }

        // GET: Categoria_Pregunta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria_Pregunta categoria_Pregunta = db.Categoria_Pregunta.Find(id);
            if (categoria_Pregunta == null)
            {
                return HttpNotFound();
            }
            return View(categoria_Pregunta);
        }

        // GET: Categoria_Pregunta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoria_Pregunta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_categoria_pregunta,nombre,descripcion,fecha_registro")] Categoria_Pregunta categoria_Pregunta)
        {
            if (ModelState.IsValid)
            {
                db.Categoria_Pregunta.Add(categoria_Pregunta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoria_Pregunta);
        }

        // GET: Categoria_Pregunta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria_Pregunta categoria_Pregunta = db.Categoria_Pregunta.Find(id);
            if (categoria_Pregunta == null)
            {
                return HttpNotFound();
            }
            return View(categoria_Pregunta);
        }

        // POST: Categoria_Pregunta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_categoria_pregunta,nombre,descripcion,fecha_registro")] Categoria_Pregunta categoria_Pregunta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoria_Pregunta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria_Pregunta);
        }

        // GET: Categoria_Pregunta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria_Pregunta categoria_Pregunta = db.Categoria_Pregunta.Find(id);
            if (categoria_Pregunta == null)
            {
                return HttpNotFound();
            }
            return View(categoria_Pregunta);
        }

        // POST: Categoria_Pregunta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Categoria_Pregunta categoria_Pregunta = db.Categoria_Pregunta.Find(id);
            db.Categoria_Pregunta.Remove(categoria_Pregunta);
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
