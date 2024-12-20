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
    public class RegistroController : Controller
    {
        private KanbanContext db = new KanbanContext();

        // GET: Registro
        public ActionResult Index()
        {
            var registro = db.Registro.Include(r => r.Tarefa).Include(r => r.Usuario);
            return View(registro.ToList());
        }

        // GET: Registro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro registro = db.Registro.Find(id);
            if (registro == null)
            {
                return HttpNotFound();
            }
            return View(registro);
        }

        // GET: Registro/Create
        public ActionResult Create()
        {
            ViewBag.TarefaID = new SelectList(db.Tarefa, "ID", "Titulo");
            ViewBag.UsuarioID = new SelectList(db.Usuario, "ID", "Nome");
            return View();
        }

        // POST: Registro/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UsuarioID,TarefaID,Descricao,Data,HoraInicial,HoraFinal")] Registro registro)
        {
            if (ModelState.IsValid)
            {
                db.Registro.Add(registro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TarefaID = new SelectList(db.Tarefa, "ID", "Titulo", registro.TarefaID);
            ViewBag.UsuarioID = new SelectList(db.Usuario, "ID", "Nome", registro.UsuarioID);
            return View(registro);
        }

        // GET: Registro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro registro = db.Registro.Find(id);
            if (registro == null)
            {
                return HttpNotFound();
            }
            ViewBag.TarefaID = new SelectList(db.Tarefa, "ID", "Titulo", registro.TarefaID);
            ViewBag.UsuarioID = new SelectList(db.Usuario, "ID", "Nome", registro.UsuarioID);
            return View(registro);
        }

        // POST: Registro/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UsuarioID,TarefaID,Descricao,Data,HoraInicial,HoraFinal")] Registro registro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TarefaID = new SelectList(db.Tarefa, "ID", "Titulo", registro.TarefaID);
            ViewBag.UsuarioID = new SelectList(db.Usuario, "ID", "Nome", registro.UsuarioID);
            return View(registro);
        }

        // GET: Registro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro registro = db.Registro.Find(id);
            if (registro == null)
            {
                return HttpNotFound();
            }
            return View(registro);
        }

        // POST: Registro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registro registro = db.Registro.Find(id);
            db.Registro.Remove(registro);
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
