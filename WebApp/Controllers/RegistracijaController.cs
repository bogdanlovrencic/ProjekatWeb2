﻿using JGSPNSWebApp.Models;
using JGSPNSWebApp.Persistence;
using JGSPNSWebApp.Persistence.UnitOfWork;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JGSPNSWebApp.Controllers
{
    [RoutePrefix("api/registracija")]
    public class RegistracijaController : ApiController
    {
        private static ApplicationDbContext context = new ApplicationDbContext();

        IUnitOfWork unitOfWork = new DemoUnitOfWork(context);

        public RegistracijaController()
        {

        }

        [HttpPost,Route("registrujSe")]
        public IHttpActionResult PostRegistracija([FromBody]KorisnikRegistracijaBindingModel korisnik)
        {
            string uloga;

            if (User.IsInRole("Admin"))
            {
                uloga = "Kontrolor";
                korisnik.TipPutnika = "Regularni";
            }

            else
                uloga = "Putnik";


            ApplicationUser user = new ApplicationUser()
            {
                Ime = korisnik.Ime,
                Prezime = korisnik.Prezime,
                Email = korisnik.Email,
                Lozinka = korisnik.Lozinka,
                DatumRodjenja = korisnik.DatumRodjenja,
                Adresa = korisnik.Adresa,
                TipPutnika = korisnik.TipPutnika,
                Id = korisnik.Ime,
                UserName = korisnik.Email,
                PasswordHash = ApplicationUser.HashPassword(korisnik.Lozinka),
                Verifikovan= korisnik.TipPutnika.Equals("Regularni"),
                Uloga=context.Uloge.Find(uloga)
                         
            };

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);


            userManager.Create(user);                     
            userManager.AddToRole(user.Id, "AppUser");


            return Ok();


        }
    }
}
