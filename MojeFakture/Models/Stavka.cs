using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MojeFakture.Models
{
    public class Stavka
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Naziv { get; set; }
        [Required]
        [Display(Name = "Jedinična cijena")]
        public float JedinicnaCijena { get; set; }
    }
}