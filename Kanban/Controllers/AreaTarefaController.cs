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
    public class AreaTarefaController : Controller
    {
        private KanbanContext db = new KanbanContext();

        // GET: AreaTarefa
        public ActionResult Index()
        {
            var areaTarefa = db.AreaTarefa.Include(a => a.Area).Include(a => a.Tarefa);
            return View(areaTarefa.ToList());
        }

        // GET: AreaTarefa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaTarefa areaTarefa = db.AreaTarefa.Find(id);
            if (areaTarefa == null)
            {
                return HttpNotFound();
            }
            return View(areaTarefa);
        }

        // GET: AreaTarefa/Create
        public ActionResult Create()
        {
            ViewBag.AreaID = new SelectList(db.Area, "ID", "Nome");
            ViewBag.TarefaID = new SelectList(db.Tarefa, "ID", "Descricao");
            return View();
        }

        // POST: AreaTarefa/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AreaID,TarefaID")] AreaTarefa areaTarefa)
        {
            if (ModelState.IsValid)
            {
                db.AreaTarefa.Add(areaTarefa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AreaID = new SelectList(db.Area, "ID", "Nome", areaTarefa.AreaID);
            ViewBag.TarefaID = new SelectList(db.Tarefa, "ID", "Descricao", areaTarefa.TarefaID);
            return View(areaTarefa);
        }

        // GET: AreaTarefa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaTarefa areaTarefa = db.AreaTarefa.Find(id);
            if (areaTarefa == null)
            {
                return HttpNotFound();
            }
            ViewBag.AreaID = new SelectList(db.Area, "ID", "Nome", areaTarefa.AreaID);
            ViewBag.TarefaID = new SelectList(db.Tarefa, "ID", "Descricao", areaTarefa.TarefaID);
            return View(areaTarefa);
        }

        // POST: AreaTarefa/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AreaID,TarefaID")] AreaTarefa areaTarefa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(areaTarefa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AreaID = new SelectList(db.Area, "ID", "Nome", areaTarefa.AreaID);
            ViewBag.TarefaID = new SelectList(db.Tarefa, "ID", "Descricao", areaTarefa.TarefaID);
            return View(areaTarefa);
        }

        // GET: AreaTarefa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaTarefa areaTarefa = db.AreaTarefa.Find(id);
            if (areaTarefa == null)
            {
                return HttpNotFound();
            }
            return View(areaTarefa);
        }

        // POST: AreaTarefa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AreaTarefa areaTarefa = db.AreaTarefa.Find(id);
            db.AreaTarefa.Remove(areaTarefa);
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
