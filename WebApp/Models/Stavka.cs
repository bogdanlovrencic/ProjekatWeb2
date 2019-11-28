using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JGSPNSWebApp.Models
{
    public class Stavka
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        public double Cena { get; set; }

        public bool Aktivna { get; set; }
    }
}