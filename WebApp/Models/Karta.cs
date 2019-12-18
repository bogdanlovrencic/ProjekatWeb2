using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JGSPNSWebApp.Models
{
    public class Karta
    {  
        public int Id { get; set; }      

        public DateTime VremeVazenja { get; set; }

        [ForeignKey("CenovnikStavka")]
        public int IdCenovnikStavka { get; set; }
        public CenovnikStavka CenovnikStavka { get; set; }

        [ForeignKey("Korisnik")]
        public string IdKorisnika { get; set; }
        public Korisnik Korisnik { get; set; }

        public double Cena { get; set; }

        public bool Validna { get; set; }
      
        
    }
}