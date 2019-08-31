using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JGSPNSWebApp.Models
{
    public class Cenovnik
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime VaziOd { get; set; }

        public DateTime VaziDo { get; set; }

        public bool  Aktivan { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public List<Stavka> Stavke { get; set;}


    }
}