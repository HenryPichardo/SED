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
    public class SecionsController : Controller
    {
        private SEDEntities db = new SEDEntities();

        // GET: Secions
        public ActionResult Index()
        {
            var secion = db.Secion.Include(s => s.Alumnos).Include(s => s.Asignatura).Include(s => s.Docentes);
            return View(secion.ToList());
        }

        // GET: Secions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Secion secion = db.Secion.Find(id);
            if (secion == null)
            {
                return HttpNotFound();
            }
            return View(secion);
        }

        // GET: Secions/Create
        public ActionResult Create()
        {
            ViewBag.fk_id_alumno = new SelectList(db.Alumnos, "id_alumno", "matricula");
            ViewBag.fk_id_asignatura = new SelectList(db.Asignatura, "id_asignatura", "nombre");
            ViewBag.fk_id_docente = new SelectList(db.Docentes, "id_docente", "codigo_empleado");
            return View();
        }

        // POST: Secions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_secion,fk_id_docente,fk_id_alumno,fk_id_asignatura,correo_universitario")] Secion secion)
        {
            if (ModelState.IsValid)
            {
                db.Secion.Add(secion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_id_alumno = new SelectList(db.Alumnos, "id_alumno", "matricula", secion.fk_id_alumno);
            ViewBag.fk_id_asignatura = new SelectList(db.Asignatura, "id_asignatura", "nombre", secion.fk_id_asignatura);
            ViewBag.fk_id_docente = new SelectList(db.Docentes, "id_docente", "codigo_empleado", secion.fk_id_docente);
            return View(secion);
        }

        // GET: Secions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Secion secion = db.Secion.Find(id);
            if (secion == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_id_alumno = new SelectList(db.Alumnos, "id_alumno", "matricula", secion.fk_id_alumno);
            ViewBag.fk_id_asignatura = new SelectList(db.Asignatura, "id_asignatura", "nombre", secion.fk_id_asignatura);
            ViewBag.fk_id_docente = new SelectList(db.Docentes, "id_docente", "codigo_empleado", secion.fk_id_docente);
            return View(secion);
        }

        // POST: Secions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_secion,fk_id_docente,fk_id_alumno,fk_id_asignatura,correo_universitario")] Secion secion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(secion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_id_alumno = new SelectList(db.Alumnos, "id_alumno", "matricula", secion.fk_id_alumno);
            ViewBag.fk_id_asignatura = new SelectList(db.Asignatura, "id_asignatura", "nombre", secion.fk_id_asignatura);
            ViewBag.fk_id_docente = new SelectList(db.Docentes, "id_docente", "codigo_empleado", secion.fk_id_docente);
            return View(secion);
        }

        // GET: Secions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Secion secion = db.Secion.Find(id);
            if (secion == null)
            {
                return HttpNotFound();
            }
            return View(secion);
        }

        // POST: Secions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Secion secion = db.Secion.Find(id);
            db.Secion.Remove(secion);
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
