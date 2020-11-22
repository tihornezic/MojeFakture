using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using MojeFakture.Dtos;
using MojeFakture.Models;

namespace MojeFakture.Controllers.Api
{
    public class FaktureController : ApiController
    {
        private ApplicationDbContext _context;

        public FaktureController()
        {
            _context = new ApplicationDbContext();
        }
        // GET /api/fakture
        public IHttpActionResult GetFakturas()
        {
            var fakturaDto = _context.Fakturas
                .Include(f => f.Porez)
                .Include(f => f.Stavka)
                .ToList().Select(Mapper.Map<Faktura, FakturaDto>);

            return Ok(fakturaDto);
        }

        // GET /api/fakture/1
        public IHttpActionResult GetFaktura(int id)
        {
            var faktura = _context.Fakturas.SingleOrDefault(f => f.Id == id);

            if (faktura == null)
                return NotFound();

            return Ok(Mapper.Map<Faktura, FakturaDto>(faktura));
        }

        // POST /api/fakture
        [HttpPost]
        public IHttpActionResult CreateFaktura(FakturaDto fakturaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var faktura = Mapper.Map<FakturaDto, Faktura>(fakturaDto);
            _context.Fakturas.Add(faktura);
            _context.SaveChanges();

            fakturaDto.Id = faktura.Id;

            return Created(new Uri(Request.RequestUri + "/" + faktura.Id), fakturaDto);
        }

        // PUT /api/fakture/1
        [HttpPut]
        public void UpdateFaktura(int id, FakturaDto fakturaDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var fakturaInDb = _context.Fakturas.SingleOrDefault(f => f.Id == id);

            if(fakturaInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(fakturaDto, fakturaInDb);
            
            _context.SaveChanges();
        }

        // DELETE /api/fakture/1
        [HttpDelete]
        public void DeleteFaktura(int id)
        {
            var fakturaInDb = _context.Fakturas.SingleOrDefault(f => f.Id == id);

            if (fakturaInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Fakturas.Remove(fakturaInDb);
            _context.SaveChanges();
        }

    }
}
