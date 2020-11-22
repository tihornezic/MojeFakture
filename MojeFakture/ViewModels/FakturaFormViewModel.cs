using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MojeFakture.Models;

namespace MojeFakture.ViewModels
{
    public class FakturaFormViewModel
    {
        public IEnumerable<Stavka> Stavkas { get; set; }
        public IEnumerable<Porez> Porezs { get; set; }
        public Faktura Faktura { get; set; }

        public string Title
        {
            get
            {
                if (Faktura != null && Faktura.Id != 0)
                    return "Uredi fakturu";

                return "Nova faktura";
            }
        }
    }
}