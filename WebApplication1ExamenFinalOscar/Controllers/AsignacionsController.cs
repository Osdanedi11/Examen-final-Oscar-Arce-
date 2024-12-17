using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1ExamenFinalOscar.Controllers
{
    public class AsignacionsController : Controller
    {
        private ExamenFinalOscarEntities db = new ExamenFinalOscarEntities();

        // GET: Asignacions
        public ActionResult Index()
        {
            var asignacion = db.Asignacion.Include(a => a.Empleado).Include(a => a.Proyecto);
            return View(asignacion.ToList());
        }

        // GET: Asignacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignacion asignacion = db.Asignacion.Find(id);
            if (asignacion == null)
            {
                return HttpNotFound();
            }
            return View(asignacion);
        }

        // GET: Asignacions/Create
        public ActionResult Create()
        {
            ViewBag.Carnet = new SelectList(db.Empleado, "Carnet", "NombreCompleto");
            ViewBag.CodigoProyecto = new SelectList(db.Proyecto, "CodigoProyecto", "NombreProyecto");
            return View();
        }

        // POST: Asignacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Carnet,CodigoProyecto,FechaAsignacion")] Asignacion asignacion)
        {
            if (ModelState.IsValid)
            {
                db.Asignacion.Add(asignacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Carnet = new SelectList(db.Empleado, "Carnet", "NombreCompleto", asignacion.Carnet);
            ViewBag.CodigoProyecto = new SelectList(db.Proyecto, "CodigoProyecto", "NombreProyecto", asignacion.CodigoProyecto);
            return View(asignacion);
        }

        // GET: Asignacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignacion asignacion = db.Asignacion.Find(id);
            if (asignacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.Carnet = new SelectList(db.Empleado, "Carnet", "NombreCompleto", asignacion.Carnet);
            ViewBag.CodigoProyecto = new SelectList(db.Proyecto, "CodigoProyecto", "NombreProyecto", asignacion.CodigoProyecto);
            return View(asignacion);
        }

        // POST: Asignacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Carnet,CodigoProyecto,FechaAsignacion")] Asignacion asignacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asignacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Carnet = new SelectList(db.Empleado, "Carnet", "NombreCompleto", asignacion.Carnet);
            ViewBag.CodigoProyecto = new SelectList(db.Proyecto, "CodigoProyecto", "NombreProyecto", asignacion.CodigoProyecto);
            return View(asignacion);
        }

        // GET: Asignacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignacion asignacion = db.Asignacion.Find(id);
            if (asignacion == null)
            {
                return HttpNotFound();
            }
            return View(asignacion);
        }

        // POST: Asignacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asignacion asignacion = db.Asignacion.Find(id);
            db.Asignacion.Remove(asignacion);
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
