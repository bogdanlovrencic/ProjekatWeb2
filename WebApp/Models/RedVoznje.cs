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

        public DateTime Polazak { get; set; }

        public Linija IzabranaLinija { get; set; }

        public TipRedaVoznje IzabraniRedaVoznje { get; set; }

        public TipDana IzabranTipDana { get; set; }

        public bool Aktivan { get; set; }

    }
}