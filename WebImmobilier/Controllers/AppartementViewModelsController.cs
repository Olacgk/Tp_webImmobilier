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
    public class AppartementViewModelsController : Controller
    {
        private bdImmobilierContext db = new bdImmobilierContext();

        // GET: AppartementViewModels
        public ActionResult Index()
        {
            var appartementViewModels = db.appartements.Include(a => a.Proprietaire);
            return View(appartementViewModels.ToList());
        }

        // GET: AppartementViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appartement appartementViewModel = db.appartements.Find(id);
            if (appartementViewModel == null)
            {
                return HttpNotFound();
            }
            return View(appartementViewModel);
        }

        // GET: AppartementViewModels/Create
        public ActionResult Create()
        {
            ViewBag.IdProprio = new SelectList(db.proprietaires, "IdUtilisateur", "NomUtilisateur");
            return View();
        }

        // POST: AppartementViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdBien,DescriptionBien,SuperficieBien,LocaliteBien,NbreSalleEau,NbreCuisine,NbreToilette,IdProprio,NbreSalle")] Appartement appartementViewModel)
        {
            if (ModelState.IsValid)
            {
                db.appartements.Add(appartementViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProprio = new SelectList(db.proprietaires, "IdUtilisateur", "NomUtilisateur", appartementViewModel.IdProprio);
            return View(appartementViewModel);
        }

        // GET: AppartementViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appartement appartementViewModel = db.appartements.Find(id);
            if (appartementViewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProprio = new SelectList(db.proprietaires, "IdUtilisateur", "NomUtilisateur", appartementViewModel.IdProprio);
            return View(appartementViewModel);
        }

        // POST: AppartementViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdBien,DescriptionBien,SuperficieBien,LocaliteBien,NbreSalleEau,NbreCuisine,NbreToilette,IdProprio,NbreSalle")] AppartementViewModel appartementViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appartementViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProprio = new SelectList(db.proprietaires, "IdUtilisateur", "NomUtilisateur", appartementViewModel.IdProprio);
            return View(appartementViewModel);
        }

        // GET: AppartementViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appartement appartementViewModel = db.appartements.Find(id);
            if (appartementViewModel == null)
            {
                return HttpNotFound();
            }
            return View(appartementViewModel);
        }

        // POST: AppartementViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Appartement appartementViewModel = db.appartements.Find(id);
            db.appartements.Remove(appartementViewModel);
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
