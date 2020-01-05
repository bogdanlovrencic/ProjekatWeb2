using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JGSPNSWebApp.Models
{
    public class PayPal
    {
        public int Id { get; set; }
        public string TransactionId { get; set; }
        public string PayerId { get; set; }
        public string PayerEmail { get; set; }

        [ForeignKey("Karta")]
        public int IdKarte { get; set; }
        public Karta Karta { get; set; }
    }
}