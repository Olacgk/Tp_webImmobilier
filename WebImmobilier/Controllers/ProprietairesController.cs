using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebImmobilier.Models;

namespace WebImmobilier.Controllers
{
    public class ProprietairesController : Controller
    {
        private bdImmobilierContext db = new bdImmobilierContext();

        // GET: Proprietaires
        public ActionResult Index()
        {
            return View(db.proprietaires.ToList());
        }

        // GET: Proprietaires/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proprietaire proprietaire = (Proprietaire)db.utilisateurs.Find(id);
            if (proprietaire == null)
            {
                return HttpNotFound();
            }
            return View(proprietaire);
        }

        // GET: Proprietaires/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proprietaires/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUtilisateur,NomUtilisateur,PrenomUtilisateur,LoginUtilisateur,TelephoneProprio")] Proprietaire proprietaire)
        {
            if (ModelState.IsValid)
            {
                db.utilisateurs.Add(proprietaire);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(proprietaire);
        }

        // GET: Proprietaires/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proprietaire proprietaire = (Proprietaire)db.utilisateurs.Find(id);
            if (proprietaire == null)
            {
                return HttpNotFound();
            }
            return View(proprietaire);
        }

        // POST: Proprietaires/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUtilisateur,NomUtilisateur,PrenomUtilisateur,LoginUtilisateur,TelephoneProprio")] Proprietaire proprietaire)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proprietaire).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proprietaire);
        }

        // GET: Proprietaires/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proprietaire proprietaire = (Proprietaire)db.utilisateurs.Find(id);
            if (proprietaire == null)
            {
                return HttpNotFound();
            }
            return View(proprietaire);
        }

        // POST: Proprietaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proprietaire proprietaire = (Proprietaire)db.utilisateurs.Find(id);
            db.utilisateurs.Remove(proprietaire);
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
