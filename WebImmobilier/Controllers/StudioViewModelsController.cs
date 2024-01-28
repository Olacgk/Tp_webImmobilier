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
    public class StudioViewModelsController : Controller
    {
        private bdImmobilierContext db = new bdImmobilierContext();

        private List<StudioViewModel> GetStudioViewModels()
        {
            List<StudioViewModel> liste = new List<StudioViewModel>();
            var listeStudio = db.studios.ToList();
            var listeBien = db.biens.ToList();
            foreach (var item in listeStudio)
            {
                var leBien = listeBien.Where(a => a.IdBien == item.IdBien).FirstOrDefault();
                StudioViewModel m = new StudioViewModel();
                m.IdBien = item.IdBien;
                m.SuperficieBien = leBien.SuperficieBien;
                m.DescriptionBien = leBien.DescriptionBien;
                m.LocaliteBien = item.LocaliteBien;
                m.IdProprio = leBien.IdProprio;
                m.NbreSalleEau = item.NbreSalleEau;
                m.NbreCuisine = item.NbreCuisine;
                m.NbreToilette = item.NbreToilette;
                m.NbrePiece = item.NbrePiece;
                liste.Add(m);
            }

            return liste;
        }

        // GET: StudioViewModels
        public ActionResult Index()
        {
            var studioViewModels = GetStudioViewModels();
            return View(studioViewModels.ToList());
        }

        // GET: StudioViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studio studioViewModel = db.studios.Find(id);
            if (studioViewModel == null)
            {
                return HttpNotFound();
            }
            return View(studioViewModel);
        }

        // GET: StudioViewModels/Create
        public ActionResult Create()
        {
            ViewBag.IdProprio = new SelectList(db.proprietaires, "IdUtilisateur", "NomUtilisateur");
            return View();
        }

        // POST: StudioViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdBien,DescriptionBien,SuperficieBien,LocaliteBien,NbreSalleEau,NbreCuisine,NbreToilette,IdProprio,NbrePiece")] StudioViewModel studioViewModel)
        {
            if (ModelState.IsValid)
            {
                //db.studios.Add(studioViewModel);
                Studio s = new Studio();
                s.IdBien = studioViewModel.IdBien;
                s.NbrePiece = studioViewModel.NbrePiece;
                s.NbreSalleEau = studioViewModel.NbreSalleEau;
                s.NbreCuisine = studioViewModel.NbreCuisine;
                s.NbreToilette = studioViewModel.NbreToilette;
                s.LocaliteBien = studioViewModel.LocaliteBien;
                s.IdProprio = studioViewModel.IdProprio;
                s.DescriptionBien = studioViewModel.DescriptionBien;
                s.SuperficieBien = studioViewModel.SuperficieBien;
                db.biens.Add(s);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProprio = new SelectList(db.proprietaires, "IdUtilisateur", "NomUtilisateur", studioViewModel.IdProprio);
            return View(studioViewModel);
        }

        // GET: StudioViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studio studioViewModel = db.studios.Find(id);
            if (studioViewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProprio = new SelectList(db.proprietaires, "IdUtilisateur", "NomUtilisateur", studioViewModel.IdProprio);
            return View(studioViewModel);
        }

        // POST: StudioViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdBien,DescriptionBien,SuperficieBien,LocaliteBien,NbreSalleEau,NbreCuisine,NbreToilette,IdProprio,NbrePiece")] Studio studioViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studioViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProprio = new SelectList(db.proprietaires, "IdUtilisateur", "NomUtilisateur", studioViewModel.IdProprio);
            return View(studioViewModel);
        }

        // GET: StudioViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studio studioViewModel = db.studios.Find(id);
            if (studioViewModel == null)
            {
                return HttpNotFound();
            }
            return View(studioViewModel);
        }

        // POST: StudioViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Studio studioViewModel = db.studios.Find(id);
            db.studios.Remove(studioViewModel);
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
