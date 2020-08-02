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
    public class Tipo_PreguntaController : Controller
    {
        private SEDEntities db = new SEDEntities();

        // GET: Tipo_Pregunta
        public ActionResult Index()
        {
            return View(db.Tipo_Pregunta.ToList());
        }

        // GET: Tipo_Pregunta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Pregunta tipo_Pregunta = db.Tipo_Pregunta.Find(id);
            if (tipo_Pregunta == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Pregunta);
        }

        // GET: Tipo_Pregunta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo_Pregunta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tipo_pregunta,nombre,descripcion")] Tipo_Pregunta tipo_Pregunta)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_Pregunta.Add(tipo_Pregunta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_Pregunta);
        }

        // GET: Tipo_Pregunta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Pregunta tipo_Pregunta = db.Tipo_Pregunta.Find(id);
            if (tipo_Pregunta == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Pregunta);
        }

        // POST: Tipo_Pregunta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tipo_pregunta,nombre,descripcion")] Tipo_Pregunta tipo_Pregunta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_Pregunta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_Pregunta);
        }

        // GET: Tipo_Pregunta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Pregunta tipo_Pregunta = db.Tipo_Pregunta.Find(id);
            if (tipo_Pregunta == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Pregunta);
        }

        // POST: Tipo_Pregunta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo_Pregunta tipo_Pregunta = db.Tipo_Pregunta.Find(id);
            db.Tipo_Pregunta.Remove(tipo_Pregunta);
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
