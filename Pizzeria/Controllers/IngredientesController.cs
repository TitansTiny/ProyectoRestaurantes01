using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AccesoADatos;

namespace Pizzeria.Controllers
{
    public class IngredientesController : Controller
    {
        private PizzeriaDBEntities1 db = new PizzeriaDBEntities1();

        // GET: Ingredientes
        public ActionResult Index()
        {
            return View(db.Ingredientes.ToList());
        }

        // GET: Ingredientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredientes ingredientes = db.Ingredientes.Find(id);
            if (ingredientes == null)
            {
                return HttpNotFound();
            }
            return View(ingredientes);
        }

        // GET: Ingredientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ingredientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IngredienteID,Nombre,Descripcion")] Ingredientes ingredientes)
        {
            if (ModelState.IsValid)
            {
                db.Ingredientes.Add(ingredientes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ingredientes);
        }

        // GET: Ingredientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredientes ingredientes = db.Ingredientes.Find(id);
            if (ingredientes == null)
            {
                return HttpNotFound();
            }
            return View(ingredientes);
        }

        // POST: Ingredientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IngredienteID,Nombre,Descripcion")] Ingredientes ingredientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ingredientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ingredientes);
        }

        // GET: Ingredientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredientes ingredientes = db.Ingredientes.Find(id);
            if (ingredientes == null)
            {
                return HttpNotFound();
            }
            return View(ingredientes);
        }

        // POST: Ingredientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ingredientes ingredientes = db.Ingredientes.Find(id);
            db.Ingredientes.Remove(ingredientes);
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
