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
    public class ComentarioController : Controller
    {
        private KanbanContext db = new KanbanContext();

        // GET: Comentario
        public ActionResult Index()
        {
            var comentario = db.Comentario.Include(c => c.Tarefa).Include(c => c.Usuario);
            return View(comentario.ToList());
        }

        // GET: Comentario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = db.Comentario.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            return View(comentario);
        }

        // GET: Comentario/Create
        public ActionResult Create()
        {
            ViewBag.TarefaID = new SelectList(db.Tarefa, "ID", "Descricao");
            ViewBag.UsuarioID = new SelectList(db.Usuario, "ID", "Nome");
            return View();
        }

        // POST: Comentario/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UsuarioID,TarefaID,Texto")] Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                db.Comentario.Add(comentario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TarefaID = new SelectList(db.Tarefa, "ID", "Descricao", comentario.TarefaID);
            ViewBag.UsuarioID = new SelectList(db.Usuario, "ID", "Nome", comentario.UsuarioID);
            return View(comentario);
        }

        // GET: Comentario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = db.Comentario.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            ViewBag.TarefaID = new SelectList(db.Tarefa, "ID", "Descricao", comentario.TarefaID);
            ViewBag.UsuarioID = new SelectList(db.Usuario, "ID", "Nome", comentario.UsuarioID);
            return View(comentario);
        }

        // POST: Comentario/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UsuarioID,TarefaID,Texto")] Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comentario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TarefaID = new SelectList(db.Tarefa, "ID", "Descricao", comentario.TarefaID);
            ViewBag.UsuarioID = new SelectList(db.Usuario, "ID", "Nome", comentario.UsuarioID);
            return View(comentario);
        }

        // GET: Comentario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = db.Comentario.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            return View(comentario);
        }

        // POST: Comentario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comentario comentario = db.Comentario.Find(id);
            db.Comentario.Remove(comentario);
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
