using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JGSPNSWebApp.Models
{
    public class Linija
    {      
        [Key]     
        public string Id { get; set; }

        public string RedniBroj { get; set; }

        public List<Stanica> Stanice { get; set; }



    }
}