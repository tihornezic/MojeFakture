using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MojeFakture.Models;

namespace MojeFakture.ViewModels
{
    public class StavkaFormViewModel
    {
        public Stavka Stavka { get; set; }

        public string Title
        {
            get
            {
                if (Stavka != null && Stavka.Id != 0)
                    return "Uredi Stavku";

                return "Nova stavka";
            }
        }
    }
}