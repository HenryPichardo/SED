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
    public class Asignatura_AlumnoController : Controller
    {
        private SEDEntities db = new SEDEntities();

        // GET: Asignatura_Alumno
        public ActionResult Index()
        {
            var asignatura_Alumno = db.Asignatura_Alumno.Include(a => a.Alumnos).Include(a => a.Asignatura);
            return View(asignatura_Alumno.ToList());
        }

        // GET: Asignatura_Alumno/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignatura_Alumno asignatura_Alumno = db.Asignatura_Alumno.Find(id);
            if (asignatura_Alumno == null)
            {
                return HttpNotFound();
            }
            return View(asignatura_Alumno);
        }

        // GET: Asignatura_Alumno/Create
        public ActionResult Create()
        {
            ViewBag.fk_id_alumno = new SelectList(db.Alumnos, "id_alumno", "matricula");
            ViewBag.fk_id_asignatura = new SelectList(db.Asignatura, "id_asignatura", "nombre");
            return View();
        }

        // POST: Asignatura_Alumno/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "fk_id_asignatura,fk_id_alumno,id_asignaturo_alumno")] Asignatura_Alumno asignatura_Alumno)
        {
            if (ModelState.IsValid)
            {
                db.Asignatura_Alumno.Add(asignatura_Alumno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_id_alumno = new SelectList(db.Alumnos, "id_alumno", "matricula", asignatura_Alumno.fk_id_alumno);
            ViewBag.fk_id_asignatura = new SelectList(db.Asignatura, "id_asignatura", "nombre", asignatura_Alumno.fk_id_asignatura);
            return View(asignatura_Alumno);
        }

        // GET: Asignatura_Alumno/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignatura_Alumno asignatura_Alumno = db.Asignatura_Alumno.Find(id);
            if (asignatura_Alumno == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_id_alumno = new SelectList(db.Alumnos, "id_alumno", "matricula", asignatura_Alumno.fk_id_alumno);
            ViewBag.fk_id_asignatura = new SelectList(db.Asignatura, "id_asignatura", "nombre", asignatura_Alumno.fk_id_asignatura);
            return View(asignatura_Alumno);
        }

        // POST: Asignatura_Alumno/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "fk_id_asignatura,fk_id_alumno,id_asignaturo_alumno")] Asignatura_Alumno asignatura_Alumno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asignatura_Alumno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_id_alumno = new SelectList(db.Alumnos, "id_alumno", "matricula", asignatura_Alumno.fk_id_alumno);
            ViewBag.fk_id_asignatura = new SelectList(db.Asignatura, "id_asignatura", "nombre", asignatura_Alumno.fk_id_asignatura);
            return View(asignatura_Alumno);
        }

        // GET: Asignatura_Alumno/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignatura_Alumno asignatura_Alumno = db.Asignatura_Alumno.Find(id);
            if (asignatura_Alumno == null)
            {
                return HttpNotFound();
            }
            return View(asignatura_Alumno);
        }

        // POST: Asignatura_Alumno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asignatura_Alumno asignatura_Alumno = db.Asignatura_Alumno.Find(id);
            db.Asignatura_Alumno.Remove(asignatura_Alumno);
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
