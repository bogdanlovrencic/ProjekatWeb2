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
        public CenovnikStavka()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Cenovnik")]
        public int IdCenovnika { get; set; }

        public Cenovnik Cenovnik { get; set; }

        [ForeignKey("Stavka")]
        public int IdStavke { get; set; }

        public Stavka Stavka { get; set; }

        public double Cena { get; set; }
    }
}