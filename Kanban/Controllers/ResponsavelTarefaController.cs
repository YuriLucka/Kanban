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
    public class ResponsavelTarefaController : Controller
    {
        private KanbanContext db = new KanbanContext();

        // GET: ResponsavelTarefa
        public ActionResult Index()
        {
            var responsavelTarefa = db.ResponsavelTarefa.Include(r => r.Responsabilidade).Include(r => r.Tarefa).Include(r => r.Usuario);
            return View(responsavelTarefa.ToList());
        }

        // GET: ResponsavelTarefa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResponsavelTarefa responsavelTarefa = db.ResponsavelTarefa.Find(id);
            if (responsavelTarefa == null)
            {
                return HttpNotFound();
            }
            return View(responsavelTarefa);
        }

        // GET: ResponsavelTarefa/Create
        public ActionResult Create()
        {
            ViewBag.ResponsabilidadeID = new SelectList(db.Responsabilidade, "ID", "Nome");
            ViewBag.TarefaID = new SelectList(db.Tarefa, "ID", "Descricao");
            ViewBag.UsuarioID = new SelectList(db.Usuario, "ID", "Nome");
            return View();
        }

        // POST: ResponsavelTarefa/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UsuarioID,TarefaID,ResponsabilidadeID")] ResponsavelTarefa responsavelTarefa)
        {
            if (ModelState.IsValid)
            {
                db.ResponsavelTarefa.Add(responsavelTarefa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ResponsabilidadeID = new SelectList(db.Responsabilidade, "ID", "Nome", responsavelTarefa.ResponsabilidadeID);
            ViewBag.TarefaID = new SelectList(db.Tarefa, "ID", "Descricao", responsavelTarefa.TarefaID);
            ViewBag.UsuarioID = new SelectList(db.Usuario, "ID", "Nome", responsavelTarefa.UsuarioID);
            return View(responsavelTarefa);
        }

        // GET: ResponsavelTarefa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResponsavelTarefa responsavelTarefa = db.ResponsavelTarefa.Find(id);
            if (responsavelTarefa == null)
            {
                return HttpNotFound();
            }
            ViewBag.ResponsabilidadeID = new SelectList(db.Responsabilidade, "ID", "Nome", responsavelTarefa.ResponsabilidadeID);
            ViewBag.TarefaID = new SelectList(db.Tarefa, "ID", "Descricao", responsavelTarefa.TarefaID);
            ViewBag.UsuarioID = new SelectList(db.Usuario, "ID", "Nome", responsavelTarefa.UsuarioID);
            return View(responsavelTarefa);
        }

        // POST: ResponsavelTarefa/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UsuarioID,TarefaID,ResponsabilidadeID")] ResponsavelTarefa responsavelTarefa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(responsavelTarefa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ResponsabilidadeID = new SelectList(db.Responsabilidade, "ID", "Nome", responsavelTarefa.ResponsabilidadeID);
            ViewBag.TarefaID = new SelectList(db.Tarefa, "ID", "Descricao", responsavelTarefa.TarefaID);
            ViewBag.UsuarioID = new SelectList(db.Usuario, "ID", "Nome", responsavelTarefa.UsuarioID);
            return View(responsavelTarefa);
        }

        // GET: ResponsavelTarefa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResponsavelTarefa responsavelTarefa = db.ResponsavelTarefa.Find(id);
            if (responsavelTarefa == null)
            {
                return HttpNotFound();
            }
            return View(responsavelTarefa);
        }

        // POST: ResponsavelTarefa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResponsavelTarefa responsavelTarefa = db.ResponsavelTarefa.Find(id);
            db.ResponsavelTarefa.Remove(responsavelTarefa);
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
