using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JGSPNSWebApp.Models
{
    public class RedVoznje
    {

        public int Id { get; set; }

        [ForeignKey("Linija")]
        public int LinijaId { get; set; }
        public Linija Linija { get; set; }

        public string IzabraniRedVoznje { get; set; }

        public string IzabranTipDana { get; set; }

        public bool Aktivan { get; set; }

    }
}