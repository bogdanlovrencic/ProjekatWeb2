using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JGSPNSWebApp.Models
{
    public class Polazak
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Vreme { get; set; }

        public string TipDana { get; set; }

        [ForeignKey("Linija")]
        public int LinijaId { get; set; }
        public Linija Linija { get; set; }

        public bool Active { get; set; } = true;
    }
}