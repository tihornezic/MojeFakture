using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MojeFakture.Models;

namespace MojeFakture.Dtos
{
    public class FakturaDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Opis { get; set; }

        [Required]
        [StringLength(255)]
        public string DatumStvaranja { get; set; }

        [Required]
        [StringLength(255)]
        public string DatumDospijeca { get; set; }

        public string NazivPrimatelja { get; set; }

        [Required]
        public int Kolicina { get; set; }
        public float UkupnaCijena { get; set; }


        public int PorezId { get; set; }
        public PorezDto Porez { get; set; }

        public int StavkaId { get; set; }
        public StavkaDtoDto Stavka { get; set; }
    }
}