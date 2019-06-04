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
        public Polazak()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_polaska { get; set; }
        public string VremePolaska { get; set; }

        [ForeignKey("Linija")]
        public int LinijaId { get; set; }

        public Linija Linija { get; set; }



    }
}