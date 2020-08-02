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
    public class Directores_EscuelasController : Controller
    {
        private SEDEntities db = new SEDEntities();

        // GET: Directores_Escuelas
        public ActionResult Index()
        {
            var directores_Escuelas = db.Directores_Escuelas.Include(d => d.Escuela);
            return View(db.Directores_Escuelas.ToList());
        }

        // GET: Directores_Escuelas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Directores_Escuelas directores_Escuelas = db.Directores_Escuelas.Find(id);
            if (directores_Escuelas == null)
            {
                return HttpNotFound();
            }
            return View(directores_Escuelas);
        }

        // GET: Directores_Escuelas/Create
        public ActionResult Create()
        {
            ViewBag.fk_id_escuela = new SelectList(db.Escuela, "id_escuela", "nombre");
            return View();
        }

        // POST: Directores_Escuelas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_director,codigo_empleado,nombre,fechaRegistro,correo_universitario,fk_id_escuela")] Directores_Escuelas directores_Escuelas)
        {
            if (ModelState.IsValid)
            {
                db.Directores_Escuelas.Add(directores_Escuelas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_id_escuela = new SelectList(db.Escuela, "id_escuela", "nombre", directores_Escuelas.fk_id_escuela);
            return View(directores_Escuelas);
        }

        // GET: Directores_Escuelas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Directores_Escuelas directores_Escuelas = db.Directores_Escuelas.Find(id);
            if (directores_Escuelas == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_id_escuela = new SelectList(db.Escuela, "id_escuela", "nombre", directores_Escuelas.fk_id_escuela);
            return View(directores_Escuelas);
        }

        // POST: Directores_Escuelas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_director,codigo_empleado,nombre,fechaRegistro,correo_universitario,fk_id_escuela")] Directores_Escuelas directores_Escuelas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(directores_Escuelas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_id_escuela = new SelectList(db.Escuela, "id_escuela", "nombre", directores_Escuelas.fk_id_escuela);
            return View(directores_Escuelas);
        }

        // GET: Directores_Escuelas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Directores_Escuelas directores_Escuelas = db.Directores_Escuelas.Find(id);
            if (directores_Escuelas == null)
            {
                return HttpNotFound();
            }
            return View(directores_Escuelas);
        }

        // POST: Directores_Escuelas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Directores_Escuelas directores_Escuelas = db.Directores_Escuelas.Find(id);
            db.Directores_Escuelas.Remove(directores_Escuelas);
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
