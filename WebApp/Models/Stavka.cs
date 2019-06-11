using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JGSPNSWebApp.Models
{
    public class Stavka
    {
        public Stavka()
        {
           

        }

       
        public int Id { get; set; }

        public VrstaKarte VrstaKarte { get; set; }


    }
}