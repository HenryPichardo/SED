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
    public class Tipo_CuestionarioController : Controller
    {
        private SEDEntities db = new SEDEntities();

        // GET: Tipo_Cuestionario
        public ActionResult Index()
        {
            return View(db.Tipo_Cuestionario.ToList());
        }

        // GET: Tipo_Cuestionario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Cuestionario tipo_Cuestionario = db.Tipo_Cuestionario.Find(id);
            if (tipo_Cuestionario == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Cuestionario);
        }

        // GET: Tipo_Cuestionario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo_Cuestionario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tipo_cuestionario,nombre,fecha_registro")] Tipo_Cuestionario tipo_Cuestionario)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_Cuestionario.Add(tipo_Cuestionario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_Cuestionario);
        }

        // GET: Tipo_Cuestionario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Cuestionario tipo_Cuestionario = db.Tipo_Cuestionario.Find(id);
            if (tipo_Cuestionario == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Cuestionario);
        }

        // POST: Tipo_Cuestionario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tipo_cuestionario,nombre,fecha_registro")] Tipo_Cuestionario tipo_Cuestionario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_Cuestionario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_Cuestionario);
        }

        // GET: Tipo_Cuestionario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Cuestionario tipo_Cuestionario = db.Tipo_Cuestionario.Find(id);
            if (tipo_Cuestionario == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Cuestionario);
        }

        // POST: Tipo_Cuestionario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo_Cuestionario tipo_Cuestionario = db.Tipo_Cuestionario.Find(id);
            db.Tipo_Cuestionario.Remove(tipo_Cuestionario);
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
