using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kanban.DAL;
using Kanban.Models;

namespace Kanban.Controllers
{
    public class PrioridadeController : Controller
    {
        private KanbanContext db = new KanbanContext();

        // GET: Prioridade
        public ActionResult Index()
        {
            return View(db.Prioridade.ToList());
        }

        // GET: Prioridade/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prioridade prioridade = db.Prioridade.Find(id);
            if (prioridade == null)
            {
                return HttpNotFound();
            }
            return View(prioridade);
        }

        // GET: Prioridade/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prioridade/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome")] Prioridade prioridade)
        {
            if (ModelState.IsValid)
            {
                db.Prioridade.Add(prioridade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prioridade);
        }

        // GET: Prioridade/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prioridade prioridade = db.Prioridade.Find(id);
            if (prioridade == null)
            {
                return HttpNotFound();
            }
            return View(prioridade);
        }

        // POST: Prioridade/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome")] Prioridade prioridade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prioridade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prioridade);
        }

        // GET: Prioridade/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prioridade prioridade = db.Prioridade.Find(id);
            if (prioridade == null)
            {
                return HttpNotFound();
            }
            return View(prioridade);
        }

        // POST: Prioridade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prioridade prioridade = db.Prioridade.Find(id);
            db.Prioridade.Remove(prioridade);
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
