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
    public class CuestionariosController : Controller
    {
        private SEDEntities db = new SEDEntities();

        // GET: Cuestionarios
        public ActionResult Index()
        {
            var cuestionario = db.Cuestionario.Include(c => c.Periodo).Include(c => c.Tipo_Cuestionario);
            return View(cuestionario.ToList());
        }

        // GET: Cuestionarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuestionario cuestionario = db.Cuestionario.Find(id);
            if (cuestionario == null)
            {
                return HttpNotFound();
            }
            return View(cuestionario);
        }

        // GET: Cuestionarios/Create
        public ActionResult Create()
        {
            ViewBag.fk_id_periodo = new SelectList(db.Periodo, "id_periodo", "periodo1");
            ViewBag.fk_id_tipo_cuestionario = new SelectList(db.Tipo_Cuestionario, "id_tipo_cuestionario", "nombre");
            return View();
        }

        // POST: Cuestionarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_cuestionario,fk_id_periodo,fk_id_tipo_cuestionario,cantidad_categoria,fecha_registro")] Cuestionario cuestionario)
        {
            if (ModelState.IsValid)
            {
                db.Cuestionario.Add(cuestionario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_id_periodo = new SelectList(db.Periodo, "id_periodo", "periodo1", cuestionario.fk_id_periodo);
            ViewBag.fk_id_tipo_cuestionario = new SelectList(db.Tipo_Cuestionario, "id_tipo_cuestionario", "nombre", cuestionario.fk_id_tipo_cuestionario);
            return View(cuestionario);
        }

        // GET: Cuestionarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuestionario cuestionario = db.Cuestionario.Find(id);
            if (cuestionario == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_id_periodo = new SelectList(db.Periodo, "id_periodo", "periodo1", cuestionario.fk_id_periodo);
            ViewBag.fk_id_tipo_cuestionario = new SelectList(db.Tipo_Cuestionario, "id_tipo_cuestionario", "nombre", cuestionario.fk_id_tipo_cuestionario);
            return View(cuestionario);
        }

        // POST: Cuestionarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_cuestionario,fk_id_periodo,fk_id_tipo_cuestionario,cantidad_categoria,fecha_registro")] Cuestionario cuestionario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cuestionario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_id_periodo = new SelectList(db.Periodo, "id_periodo", "periodo1", cuestionario.fk_id_periodo);
            ViewBag.fk_id_tipo_cuestionario = new SelectList(db.Tipo_Cuestionario, "id_tipo_cuestionario", "nombre", cuestionario.fk_id_tipo_cuestionario);
            return View(cuestionario);
        }

        // GET: Cuestionarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuestionario cuestionario = db.Cuestionario.Find(id);
            if (cuestionario == null)
            {
                return HttpNotFound();
            }
            return View(cuestionario);
        }

        // POST: Cuestionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cuestionario cuestionario = db.Cuestionario.Find(id);
            db.Cuestionario.Remove(cuestionario);
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
