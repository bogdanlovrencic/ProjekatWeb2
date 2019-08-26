using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JGSPNSWebApp.Models
{
    public class Putnik
    {
        [Key]
        public int Id { get; set; }

        public TipPutnika TipPutnika { get; set; }

        public Korisnik Korisnik { get; set; }
    }
}