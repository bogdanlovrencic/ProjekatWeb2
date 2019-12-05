using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JGSPNSWebApp.Models
{
    public class CenovnikStavka
    {
     
        public int Id { get; set; }

        [ForeignKey("Cenovnik")]
        public int Cenovnik_Id { get; set; }
        public Cenovnik Cenovnik { get; set; }

        [ForeignKey("Stavka")]
        public int Stavka_Id { get; set; }
        public Stavka Stavka { get; set; }

        public double Cena { get; set; }
    }
    
}