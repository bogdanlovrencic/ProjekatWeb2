using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JGSPNSWebApp.Models
{
    public class Cenovnik1
    {
        public int Id  { get; set; }
        public string TipKarte { get; set; }     
        public double Cena { get; set; }

        public Cenovnik1()
        {

        }

        public Cenovnik1(int id,string tipKarte,double cena)
        {
            Id = id;
            TipKarte = tipKarte;
            Cena = cena;
        }
    }
}