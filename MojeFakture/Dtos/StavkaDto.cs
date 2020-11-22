using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MojeFakture.Dtos
{
    public class StavkaDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Naziv { get; set; }
        [Required]
        public float JedinicnaCijena { get; set; }
    }
}