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
    public class CategoriaLaboralsController : Controller
    {
        private ExamenFinalOscarEntities db = new ExamenFinalOscarEntities();

        // GET: CategoriaLaborals
        public ActionResult Index()
        {
            return View(db.CategoriaLaboral.ToList());
        }

        // GET: CategoriaLaborals/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaLaboral categoriaLaboral = db.CategoriaLaboral.Find(id);
            if (categoriaLaboral == null)
            {
                return HttpNotFound();
            }
            return View(categoriaLaboral);
        }

        // GET: CategoriaLaborals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaLaborals/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Categoria,Descripcion")] CategoriaLaboral categoriaLaboral)
        {
            if (ModelState.IsValid)
            {
                db.CategoriaLaboral.Add(categoriaLaboral);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoriaLaboral);
        }

        // GET: CategoriaLaborals/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaLaboral categoriaLaboral = db.CategoriaLaboral.Find(id);
            if (categoriaLaboral == null)
            {
                return HttpNotFound();
            }
            return View(categoriaLaboral);
        }

        // POST: CategoriaLaborals/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Categoria,Descripcion")] CategoriaLaboral categoriaLaboral)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoriaLaboral).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoriaLaboral);
        }

        // GET: CategoriaLaborals/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaLaboral categoriaLaboral = db.CategoriaLaboral.Find(id);
            if (categoriaLaboral == null)
            {
                return HttpNotFound();
            }
            return View(categoriaLaboral);
        }

        // POST: CategoriaLaborals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CategoriaLaboral categoriaLaboral = db.CategoriaLaboral.Find(id);
            db.CategoriaLaboral.Remove(categoriaLaboral);
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
