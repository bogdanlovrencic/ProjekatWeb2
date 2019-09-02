using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JGSPNSWebApp.Models
{
    public class Korisnik
    {
        public string Ime { get; set; }

        public string Prezime { get; set; }

        [Key]
        public string Email { get; set; }

        public DateTime DatumRodjenja { get; set; }

        public string Adresa { get; set; }

        public string Lozinka { get; set; }

        public bool Verifikovan { get; set; } = false;
       
       // public List<Karta> KupljenjeKarte { get; set; }

        public string Uloga { get; set; }

        public string Status { get; set; }
        public string ImageUrl { get; set; }

        public bool Aktivan { get; set; }

        
    }
}