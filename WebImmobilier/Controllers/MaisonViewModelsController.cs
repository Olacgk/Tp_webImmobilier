using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebImmobilier.Models;
using PagedList.Mvc;
using PagedList;

namespace WebImmobilier.Controllers
{
    public class MaisonViewModelsController : Controller
    {
        private bdImmobilierContext db = new bdImmobilierContext();
        int pageSized = 1;

        private List<MaisonViewModel> GetMaisonViewModels()
        {
            List<MaisonViewModel> liste = new List<MaisonViewModel>();
            var listeMaison = db.maisons.ToList();
            var listeBien = db.biens.ToList();
            foreach (var item in listeMaison)
            {
                var leBien = listeBien.Where(a => a.IdBien == item.IdBien).FirstOrDefault();
                MaisonViewModel m = new MaisonViewModel();
                m.IdBien = item.IdBien;
                m.SuperficieBien = leBien.SuperficieBien;
                m.DescriptionBien = leBien.DescriptionBien;
                m.LocaliteBien = item.LocaliteBien;
                m.IdProprio = leBien.IdProprio;
                m.NbreChambre = item.NbreChambre;
                m.NbreSalleEau = item.NbreSalleEau;
                m.NbreCuisine = item.NbreCuisine;
                m.NbreToilette = item.NbreToilette;
                liste.Add(m);
            }

            return liste;
        }

        // GET: MaisonViewModels
        public ActionResult Index(int? page)
        {
            page = page.HasValue ? page : 1;
            var maisonViewModels = GetMaisonViewModels();
            var list = maisonViewModels.ToList();
            return View(list.ToPagedList((int)page, pageSized));
        }

        // GET: MaisonViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maison maisonViewModel = db.maisons.Find(id);
            if (maisonViewModel == null)
            {
                return HttpNotFound();
            }
            return View(maisonViewModel);
        }

        // GET: MaisonViewModels/Create
        public ActionResult Create()
        {
            ViewBag.IdProprio = new SelectList(db.proprietaires, "IdUtilisateur", "NomUtilisateur");
            return View();
        }

        // POST: MaisonViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdBien,DescriptionBien,SuperficieBien,LocaliteBien,IdProprio,NbreChambre,NbreSalleEau,NbreCuisine,NbreToilette")] MaisonViewModel maisonViewModel)
        {
            if (ModelState.IsValid)
            {
                //db.MaisonViewModels.Add(maisonViewModel);
                Maison b = new Maison();
                b.DescriptionBien = maisonViewModel.DescriptionBien;
                b.LocaliteBien = maisonViewModel.LocaliteBien;
                b.SuperficieBien = maisonViewModel.SuperficieBien;
                b.NbreSalleEau = maisonViewModel.NbreSalleEau;
                b.NbreChambre = maisonViewModel.NbreChambre;
                b.NbreCuisine = maisonViewModel.NbreCuisine;
                b.NbreToilette = maisonViewModel.NbreToilette;
                b.IdProprio = maisonViewModel.IdProprio;
                db.biens.Add(b);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProprio = new SelectList(db.proprietaires, "IdUtilisateur", "NomUtilisateur", maisonViewModel.IdProprio);
            return View(maisonViewModel);
        }

        // GET: MaisonViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maison maisonViewModel = db.maisons.Find(id);
            if (maisonViewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProprio = new SelectList(db.proprietaires, "IdUtilisateur", "NomUtilisateur", maisonViewModel.IdProprio);
            return View(maisonViewModel);
        }

        // POST: MaisonViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdBien,DescriptionBien,SuperficieBien,LocaliteBien,IdProprio,NbreChambre,NbreSalleEau,NbreCuisine,NbreToilette")] Maison maisonViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maisonViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProprio = new SelectList(db.proprietaires, "IdUtilisateur", "NomUtilisateur", maisonViewModel.IdProprio);
            return View(maisonViewModel);
        }

        // GET: MaisonViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maison maisonViewModel = db.maisons.Find(id);
            if (maisonViewModel == null)
            {
                return HttpNotFound();
            }
            return View(maisonViewModel);
        }

        // POST: MaisonViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Maison maisonViewModel = db.maisons.Find(id);
            db.maisons.Remove(maisonViewModel);
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
