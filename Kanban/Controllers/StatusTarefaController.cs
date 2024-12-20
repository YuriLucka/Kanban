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
    public class StatusTarefaController : Controller
    {
        private KanbanContext db = new KanbanContext();

        // GET: StatusTarefa
        public ActionResult Index()
        {
            return View(db.StatusTarefa.ToList());
        }

        // GET: StatusTarefa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusTarefa statusTarefa = db.StatusTarefa.Find(id);
            if (statusTarefa == null)
            {
                return HttpNotFound();
            }
            return View(statusTarefa);
        }

        // GET: StatusTarefa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatusTarefa/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome")] StatusTarefa statusTarefa)
        {
            if (ModelState.IsValid)
            {
                db.StatusTarefa.Add(statusTarefa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(statusTarefa);
        }

        // GET: StatusTarefa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusTarefa statusTarefa = db.StatusTarefa.Find(id);
            if (statusTarefa == null)
            {
                return HttpNotFound();
            }
            return View(statusTarefa);
        }

        // POST: StatusTarefa/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome")] StatusTarefa statusTarefa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statusTarefa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(statusTarefa);
        }

        // GET: StatusTarefa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusTarefa statusTarefa = db.StatusTarefa.Find(id);
            if (statusTarefa == null)
            {
                return HttpNotFound();
            }
            return View(statusTarefa);
        }

        // POST: StatusTarefa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StatusTarefa statusTarefa = db.StatusTarefa.Find(id);
            db.StatusTarefa.Remove(statusTarefa);
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
