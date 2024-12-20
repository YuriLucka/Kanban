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
    public class ResponsabilidadeController : Controller
    {
        private KanbanContext db = new KanbanContext();

        // GET: Responsabilidade
        public ActionResult Index()
        {
            return View(db.Responsabilidade.ToList());
        }

        // GET: Responsabilidade/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Responsabilidade responsabilidade = db.Responsabilidade.Find(id);
            if (responsabilidade == null)
            {
                return HttpNotFound();
            }
            return View(responsabilidade);
        }

        // GET: Responsabilidade/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Responsabilidade/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Descricao")] Responsabilidade responsabilidade)
        {
            if (ModelState.IsValid)
            {
                db.Responsabilidade.Add(responsabilidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(responsabilidade);
        }

        // GET: Responsabilidade/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Responsabilidade responsabilidade = db.Responsabilidade.Find(id);
            if (responsabilidade == null)
            {
                return HttpNotFound();
            }
            return View(responsabilidade);
        }

        // POST: Responsabilidade/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Descricao")] Responsabilidade responsabilidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(responsabilidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(responsabilidade);
        }

        // GET: Responsabilidade/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Responsabilidade responsabilidade = db.Responsabilidade.Find(id);
            if (responsabilidade == null)
            {
                return HttpNotFound();
            }
            return View(responsabilidade);
        }

        // POST: Responsabilidade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Responsabilidade responsabilidade = db.Responsabilidade.Find(id);
            db.Responsabilidade.Remove(responsabilidade);
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
