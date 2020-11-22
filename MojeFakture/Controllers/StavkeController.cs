using MojeFakture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MojeFakture.ViewModels;

namespace MojeFakture.Controllers
{
    public class StavkeController : Controller
    {
        private ApplicationDbContext _context;

        public StavkeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult New()
        {
            var viewModel = new StavkaFormViewModel
            {
                Stavka = new Stavka()
            };
            

            return View("StavkaForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Stavka stavka)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new StavkaFormViewModel
                {
                    Stavka = stavka
                };

                return View("StavkaForm", viewModel);
            }

            if (stavka.Id == 0)
                _context.Stavkas.Add(stavka);
            else
            {
                var stavkaInDb = _context.Stavkas.Single(s => s.Id == stavka.Id);

                stavkaInDb.Naziv = stavka.Naziv;
                stavkaInDb.JedinicnaCijena = stavka.JedinicnaCijena;
            }
            
            _context.SaveChanges();

            return RedirectToAction("Index", "Stavke");
        }

        // GET: Stavke
        public ActionResult Index()
        {

            /*var stavke = _context.Stavkas.ToList();*/

            return View();
        }

        public ActionResult Edit(int id)
        {
            var stavka = _context.Stavkas.SingleOrDefault(s => s.Id == id);
            var viewModel = new StavkaFormViewModel
            {
                Stavka = stavka
            };
            
            return View("StavkaForm", viewModel);
        }

    }
}