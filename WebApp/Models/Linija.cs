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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Naziv { get; set; }

        public TipLinije TipLinije { get; set; }
  
        public List<Stanica> Stanice { get; set; }

        public bool Aktivna { get; set; }



    }
}