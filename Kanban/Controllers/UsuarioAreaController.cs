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
    public class UsuarioAreaController : Controller
    {
        private KanbanContext db = new KanbanContext();

        // GET: UsuarioArea
        public ActionResult Index()
        {
            var usuarioArea = db.UsuarioArea.Include(u => u.Area).Include(u => u.Usuario).OrderBy(u => u.Area.Nome).ThenBy(u => u.Usuario.Nome);
            return View(usuarioArea.ToList());
        }

        // GET: UsuarioArea/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioArea usuarioArea = db.UsuarioArea.Find(id);
            if (usuarioArea == null)
            {
                return HttpNotFound();
            }
            return View(usuarioArea);
        }

        // GET: UsuarioArea/Create
        public ActionResult Create()
        {
            ViewBag.AreaID = new SelectList(db.Area, "ID", "Nome");
            ViewBag.UsuarioID = new SelectList(db.Usuario, "ID", "Nome");
            return View();
        }

        // POST: UsuarioArea/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UsuarioID,AreaID")] UsuarioArea usuarioArea)
        {
            if (ModelState.IsValid)
            {
                db.UsuarioArea.Add(usuarioArea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AreaID = new SelectList(db.Area, "ID", "Nome", usuarioArea.AreaID);
            ViewBag.UsuarioID = new SelectList(db.Usuario, "ID", "Nome", usuarioArea.UsuarioID);
            return View(usuarioArea);
        }

        // GET: UsuarioArea/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioArea usuarioArea = db.UsuarioArea.Find(id);
            if (usuarioArea == null)
            {
                return HttpNotFound();
            }
            ViewBag.AreaID = new SelectList(db.Area, "ID", "Nome", usuarioArea.AreaID);
            ViewBag.UsuarioID = new SelectList(db.Usuario, "ID", "Nome", usuarioArea.UsuarioID);
            return View(usuarioArea);
        }

        // POST: UsuarioArea/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UsuarioID,AreaID")] UsuarioArea usuarioArea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarioArea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AreaID = new SelectList(db.Area, "ID", "Nome", usuarioArea.AreaID);
            ViewBag.UsuarioID = new SelectList(db.Usuario, "ID", "Nome", usuarioArea.UsuarioID);
            return View(usuarioArea);
        }

        // GET: UsuarioArea/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioArea usuarioArea = db.UsuarioArea.Find(id);
            if (usuarioArea == null)
            {
                return HttpNotFound();
            }
            return View(usuarioArea);
        }

        // POST: UsuarioArea/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsuarioArea usuarioArea = db.UsuarioArea.Find(id);
            db.UsuarioArea.Remove(usuarioArea);
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
