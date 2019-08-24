using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JGSPNSWebApp.Models
{
    public class StatusRegistracije
    {
        [Key]
        public string Email { get; set; }
        public string ImgUrl { get; set; }
        public string Status { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }




  
    }
}