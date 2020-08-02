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
    public class RespuestasController : Controller
    {
        private SEDEntities db = new SEDEntities();

        // GET: Respuestas
        public ActionResult Index()
        {
            return View(db.Respuestas.ToList());
        }

        // GET: Respuestas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Respuestas respuestas = db.Respuestas.Find(id);
            if (respuestas == null)
            {
                return HttpNotFound();
            }
            return View(respuestas);
        }

        // GET: Respuestas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Respuestas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_respuesta,nombre,fecha_registro")] Respuestas respuestas)
        {
            if (ModelState.IsValid)
            {
                db.Respuestas.Add(respuestas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(respuestas);
        }

        // GET: Respuestas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Respuestas respuestas = db.Respuestas.Find(id);
            if (respuestas == null)
            {
                return HttpNotFound();
            }
            return View(respuestas);
        }

        // POST: Respuestas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_respuesta,nombre,fecha_registro")] Respuestas respuestas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(respuestas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(respuestas);
        }

        // GET: Respuestas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Respuestas respuestas = db.Respuestas.Find(id);
            if (respuestas == null)
            {
                return HttpNotFound();
            }
            return View(respuestas);
        }

        // POST: Respuestas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Respuestas respuestas = db.Respuestas.Find(id);
            db.Respuestas.Remove(respuestas);
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
