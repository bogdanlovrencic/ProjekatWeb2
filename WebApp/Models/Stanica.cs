using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JGSPNSWebApp.Models
{
    public class Stanica
    {
        public Stanica()
        {
            Linije = new HashSet<Linija>();
        }

        [Key]
        public string Naziv { get; set; }

        public string Adresa { get; set; }

        public string KordinataX { get; set; }

        public string KordinataY { get; set; }

        public ICollection<Linija> Linije { get; set; }

    }
}