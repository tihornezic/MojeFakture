using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using MojeFakture.Dtos;
using MojeFakture.Models;

namespace MojeFakture.Controllers.Api
{
    public class StavkeController : ApiController
    {
        private ApplicationDbContext _context;

        public StavkeController()
        {
            _context = new ApplicationDbContext();
        }
        // GET /api/stavke
        public IEnumerable<StavkaDto> GetStavkas()
        {
            return _context.Stavkas.ToList().Select(Mapper.Map<Stavka, StavkaDto>);
        }

        // GET /api/stavke/1
        public IHttpActionResult GetStavka(int id)
        {
            var stavka = _context.Stavkas.SingleOrDefault(s => s.Id == id);

            if (stavka == null)
                return NotFound();

            return Ok(Mapper.Map<Stavka, StavkaDto>(stavka));
        }

        // POST /api/stavke
        [HttpPost]
        public IHttpActionResult CreateStavka(StavkaDto stavkaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var stavka = Mapper.Map<StavkaDto, Stavka>(stavkaDto);
            _context.Stavkas.Add(stavka);
            _context.SaveChanges();

            stavkaDto.Id = stavka.Id;

            return Created(new Uri(Request.RequestUri + "/" + stavka.Id), stavkaDto);
        }

        // PUT api/stavke/1
        [HttpPut]
        public void UpdateStavka(int id, StavkaDto stavkaDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var stavkaInDb = _context.Stavkas.SingleOrDefault(s => s.Id == id);

            if(stavkaInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);


            Mapper.Map(stavkaDto, stavkaInDb);
            

            _context.SaveChanges();

        }

        // DELETE /api/stavke/1
        [HttpDelete]
        public void DeleteStavka(int id)
        {
            var stavkaInDb = _context.Stavkas.SingleOrDefault(s => s.Id == id);

            if (stavkaInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Stavkas.Remove(stavkaInDb);
            _context.SaveChanges();
        }
    }
}
