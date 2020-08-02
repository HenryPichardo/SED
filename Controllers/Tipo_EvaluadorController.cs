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
    public class Tipo_EvaluadorController : Controller
    {
        private SEDEntities db = new SEDEntities();

        // GET: Tipo_Evaluador
        public ActionResult Index()
        {
            return View(db.Tipo_Evaluador.ToList());
        }

        // GET: Tipo_Evaluador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Evaluador tipo_Evaluador = db.Tipo_Evaluador.Find(id);
            if (tipo_Evaluador == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Evaluador);
        }

        // GET: Tipo_Evaluador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo_Evaluador/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tipo_evaluador,nombre,fecha_registro")] Tipo_Evaluador tipo_Evaluador)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_Evaluador.Add(tipo_Evaluador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_Evaluador);
        }

        // GET: Tipo_Evaluador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Evaluador tipo_Evaluador = db.Tipo_Evaluador.Find(id);
            if (tipo_Evaluador == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Evaluador);
        }

        // POST: Tipo_Evaluador/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tipo_evaluador,nombre,fecha_registro")] Tipo_Evaluador tipo_Evaluador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_Evaluador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_Evaluador);
        }

        // GET: Tipo_Evaluador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Evaluador tipo_Evaluador = db.Tipo_Evaluador.Find(id);
            if (tipo_Evaluador == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Evaluador);
        }

        // POST: Tipo_Evaluador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo_Evaluador tipo_Evaluador = db.Tipo_Evaluador.Find(id);
            db.Tipo_Evaluador.Remove(tipo_Evaluador);
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
