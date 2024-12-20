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
    public class TarefaController : Controller
    {
        private KanbanContext db = new KanbanContext();

        // GET: Tarefa
        public ActionResult Index()
        {
            var tarefa = db.Tarefa.Include(t => t.Prioridade).Include(t => t.Status).Include(t => t.Usuario);
            return View(tarefa.ToList());
        }

        // GET: Tarefa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarefa tarefa = db.Tarefa.Find(id);
            if (tarefa == null)
            {
                return HttpNotFound();
            }
            return View(tarefa);
        }

        // GET: Tarefa/Create
        public ActionResult Create()
        {
            ViewBag.PrioridadeID = new SelectList(db.Prioridade, "ID", "Nome");
            ViewBag.StatusTarefaID = new SelectList(db.StatusTarefa, "ID", "Nome");
            ViewBag.UsuarioID = new SelectList(db.Usuario, "ID", "Nome");
            return View();
        }

        // POST: Tarefa/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UsuarioID,StatusTarefaID,PrioridadeID,Titulo,Descricao,DataCriacao,DataConclusao")] Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                db.Tarefa.Add(tarefa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PrioridadeID = new SelectList(db.Prioridade, "ID", "Nome", tarefa.PrioridadeID);
            ViewBag.StatusTarefaID = new SelectList(db.StatusTarefa, "ID", "Nome", tarefa.StatusTarefaID);
            ViewBag.UsuarioID = new SelectList(db.Usuario, "ID", "Nome", tarefa.UsuarioID);
            return View(tarefa);
        }

        // GET: Tarefa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarefa tarefa = db.Tarefa.Find(id);
            if (tarefa == null)
            {
                return HttpNotFound();
            }
            ViewBag.PrioridadeID = new SelectList(db.Prioridade, "ID", "Nome", tarefa.PrioridadeID);
            ViewBag.StatusTarefaID = new SelectList(db.StatusTarefa, "ID", "Nome", tarefa.StatusTarefaID);
            ViewBag.UsuarioID = new SelectList(db.Usuario, "ID", "Nome", tarefa.UsuarioID);
            return View(tarefa);
        }

        // POST: Tarefa/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UsuarioID,StatusTarefaID,PrioridadeID,Titulo,Descricao,DataCriacao,DataConclusao")] Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarefa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PrioridadeID = new SelectList(db.Prioridade, "ID", "Nome", tarefa.PrioridadeID);
            ViewBag.StatusTarefaID = new SelectList(db.StatusTarefa, "ID", "Nome", tarefa.StatusTarefaID);
            ViewBag.UsuarioID = new SelectList(db.Usuario, "ID", "Nome", tarefa.UsuarioID);
            return View(tarefa);
        }

        // GET: Tarefa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarefa tarefa = db.Tarefa.Find(id);
            if (tarefa == null)
            {
                return HttpNotFound();
            }
            return View(tarefa);
        }

        // POST: Tarefa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tarefa tarefa = db.Tarefa.Find(id);
            db.Tarefa.Remove(tarefa);
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
