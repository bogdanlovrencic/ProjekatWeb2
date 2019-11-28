using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JGSPNSWebApp.Models
{
    public class Putnik
    {
    
        public int Id { get; set; }

        public string TipPutnika { get; set; }

        public Korisnik Korisnik { get; set; }
    }
}