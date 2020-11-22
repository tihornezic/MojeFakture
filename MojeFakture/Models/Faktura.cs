using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MojeFakture.Models
{
    public class Faktura
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Opis { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Datum stvaranja")]
        public string DatumStvaranja { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Datum dospijeća")]
        public string DatumDospijeca { get; set; }

        [Display(Name = "Datum dospijeća")]
        public string NazivPrimatelja { get; set; }

        [Required]
        [Display(Name = "Količina")]
        public int Kolicina { get; set; }
        public float UkupnaCijena { get; set; }


        public Porez Porez { get; set; }
        public int PorezId { get; set; }

        public Stavka Stavka { get; set; }
        public int StavkaId { get; set; }
    }
}