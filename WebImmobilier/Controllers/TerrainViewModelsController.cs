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
    public class TerrainViewModelsController : Controller
    {
        private bdImmobilierContext db = new bdImmobilierContext();

        private List<TerrainViewModel> GetTerrainViewModels()
        {
            List<TerrainViewModel> liste = new List<TerrainViewModel>();
            var listeTerrain = db.terrains.ToList();
            var listeBien = db.biens.ToList();
            foreach (var item in listeTerrain)
            {
                var leBien = listeBien.Where(a => a.IdBien == item.IdBien).FirstOrDefault();
                TerrainViewModel m = new TerrainViewModel();
                m.IdBien = item.IdBien;
                m.SuperficieBien = leBien.SuperficieBien;
                m.DescriptionBien = leBien.DescriptionBien;
                m.LocaliteBien = item.LocaliteBien;
                m.IdProprio = leBien.IdProprio;
                m.NbreSalleEau = item.NbreSalleEau;
                m.NbreCuisine = item.NbreCuisine;
                m.NbreToilette = item.NbreToilette;
                m.TypeTerrain = item.TypeTerrain;
                liste.Add(m);
            }

            return liste;
        }   

        // GET: TerrainViewModels
        public ActionResult Index()
        {
            var terrainViewModels = GetTerrainViewModels();
            return View(terrainViewModels.ToList());
        }

        // GET: TerrainViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Terrain terrainViewModel = db.terrains.Find(id);
            if (terrainViewModel == null)
            {
                return HttpNotFound();
            }
            return View(terrainViewModel);
        }

        // GET: TerrainViewModels/Create
        public ActionResult Create()
        {
            ViewBag.IdProprio = new SelectList(db.proprietaires, "IdUtilisateur", "NomUtilisateur");
            return View();
        }

        // POST: TerrainViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdBien,DescriptionBien,SuperficieBien,LocaliteBien,NbreSalleEau,NbreCuisine,NbreToilette,IdProprio,TypeTerrain")] TerrainViewModel terrainViewModel)
        {
            if (ModelState.IsValid)
            {
                //db.TerrainViewModels.Add(terrainViewModel);
                Terrain t = new Terrain();
                t.IdBien = terrainViewModel.IdBien;
                t.TypeTerrain = terrainViewModel.TypeTerrain;
                t.LocaliteBien = terrainViewModel.LocaliteBien;
                t.IdProprio = terrainViewModel.IdProprio;
                t.SuperficieBien = terrainViewModel.SuperficieBien;
                t.DescriptionBien = terrainViewModel.DescriptionBien;
                t.NbreSalleEau = 0;
                t.NbreCuisine = 0;
                t.NbreToilette = 0;
                db.biens.Add(t);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProprio = new SelectList(db.proprietaires, "IdUtilisateur", "NomUtilisateur", terrainViewModel.IdProprio);
            return View(terrainViewModel);
        }

        // GET: TerrainViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Terrain terrainViewModel = db.terrains.Find(id);
            if (terrainViewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProprio = new SelectList(db.proprietaires, "IdUtilisateur", "NomUtilisateur", terrainViewModel.IdProprio);
            return View(terrainViewModel);
        }

        // POST: TerrainViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdBien,DescriptionBien,SuperficieBien,LocaliteBien,NbreSalleEau,NbreCuisine,NbreToilette,IdProprio,TypeTerrain")] Terrain terrainViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(terrainViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProprio = new SelectList(db.proprietaires, "IdUtilisateur", "NomUtilisateur", terrainViewModel.IdProprio);
            return View(terrainViewModel);
        }

        // GET: TerrainViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Terrain terrainViewModel = db.terrains.Find(id);
            if (terrainViewModel == null)
            {
                return HttpNotFound();
            }
            return View(terrainViewModel);
        }

        // POST: TerrainViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Terrain terrainViewModel = db.terrains.Find(id);
            db.terrains.Remove(terrainViewModel);
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
