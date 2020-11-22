using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MojeFakture.Models;
using MojeFakture.ViewModels;

namespace MojeFakture.Controllers
{
    public class FaktureController : Controller
    {
        private ApplicationDbContext _context;

        public FaktureController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var Stavke = _context.Stavkas.ToList();
            var Porezi = _context.Porezes.ToList();
            var viewModel = new FakturaFormViewModel
            {
                Faktura = new Faktura(),
                Stavkas = Stavke,
                Porezs = Porezi
            };

            return View("FakturaForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Faktura faktura)
        {
            if (!ModelState.IsValid)
            {
                var Stavke = _context.Stavkas.ToList();
                var Porezi = _context.Porezes.ToList();
                var viewModel = new FakturaFormViewModel
                {
                    Stavkas = Stavke,
                    Porezs = Porezi
                };

                return View("FakturaForm", viewModel);
            }


            if (faktura.Id == 0)
                _context.Fakturas.Add(faktura);
            else
            {
                var fakturaInDb = _context.Fakturas.Single(f => f.Id == faktura.Id);

                //TryUpdateModel(fakturaInDb);
                //Mapper.Map(faktura, fakturaInDb);

                fakturaInDb.Opis = faktura.Opis;
                fakturaInDb.DatumStvaranja = faktura.DatumStvaranja;
                fakturaInDb.DatumDospijeca = faktura.DatumDospijeca;
                fakturaInDb.PorezId = faktura.PorezId;
                fakturaInDb.StavkaId = faktura.StavkaId;
                fakturaInDb.Kolicina = faktura.Kolicina;
                fakturaInDb.NazivPrimatelja = faktura.NazivPrimatelja;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Fakture");
        }

        // fakture
        public ActionResult Index()
        {

            /*var fakture = _context.Fakturas.ToList();*/

            return View();
        }

        // fakture/detalji
        public ActionResult Detalji(int id)
        {

            var faktura = _context.Fakturas.Include(p => p.Porez).Include(s => s.Stavka).SingleOrDefault(c => c.Id == id);

            return View(faktura);
        }

        public ActionResult Edit(int id)
        {
            var faktura = _context.Fakturas.SingleOrDefault(f => f.Id == id);
            var Porezi = _context.Porezes.ToList();
            var Stavke = _context.Stavkas.ToList();

            var viewModel = new FakturaFormViewModel
            {
                Faktura = faktura,
                Porezs = _context.Porezes.ToList(),
                Stavkas = _context.Stavkas.ToList()
            };
            return View("FakturaForm", viewModel);
        }

    }

}