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
        public Karta()
        {

        }

        public Karta(string id,DateTime vremeOd,DateTime vremeDo)
        {
            Id = id;
            VremeOd = vremeOd;
            VremeDo = vremeDo;
        }

        public string Id { get; set; }      

        public DateTime VremeOd { get; set; }

        public DateTime VremeDo { get; set; }  

      
        
    }
}