using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JGSPNSWebApp.Models
{
    public class RedVoznje
    {
        public RedVoznje()
        {

        }
        [Key]
        public int Id { get; set; }
        public TipDana DanUNedelji { get; set; }

        public bool Aktivan { get; set; }
    }
}