using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JGSPNSWebApp.Models
{
    public class Stanica
    {
     
        public int Id { get; set; }

        public string Naziv { get; set; }

        public string Adresa { get; set; }

        public double Lat { get; set; }

        public double Lon { get; set; }

        public List<Linija> Linije { get; set; }

        public bool Aktivna { get; set; }

        public long Version { get; set; }

        public override bool Equals(System.Object obj)
        {
            if (obj == null)
                return false;

            Stanica s = obj as Stanica;
            if ((System.Object)s == null)
                return false;

            return (Id == s.Id) && (Naziv == s.Naziv) && (Adresa==s.Adresa) && (Lat == s.Lat) && (Lon == s.Lon);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ Naziv.GetHashCode() ^ Adresa.GetHashCode() ^ Lat.GetHashCode() ^ Lon.GetHashCode();
        }

    }
}