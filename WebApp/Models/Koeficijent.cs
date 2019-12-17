using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JGSPNSWebApp.Models
{
    public class Koeficijent
    {
        public int Id { get; set; }

        public TipPutnika TipPutnika { get; set; }

        public double Koef { get; set; }
    }
}