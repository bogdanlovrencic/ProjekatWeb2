import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Validators } from '@angular/forms';
import { HttpClient, HttpRequest } from '@angular/common/http';
import { RegistrationService } from '../registration.service';
import { Korisnik } from '../Korisnik';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
       
  private registrationForm : FormGroup;

  constructor(private fb: FormBuilder,private registerService: RegistrationService) {
    this.registrationForm = this.fb.group({
      firstName:['',Validators.required],
      lastName: [''],
      email: ['',Validators.required],
      password:['',Validators.required],
      confPassword:['',Validators.required],
      birthDate:[''],
      adresa : [''],
      tipKorisnika: []
    
    });
   }

  ngOnInit() {
  }

  onSubmit()
  {
     console.warn(this.registrationForm.valid);

      let korisnik=new Korisnik();
      korisnik.Ime= this.registrationForm.controls.firstName.value;
      korisnik.Prezime=this.registrationForm.controls.lastName.value;
      korisnik.Email=this.registrationForm.controls.email.value;
      korisnik.Lozinka=this.registrationForm.controls.password.value;
      korisnik.DatumRodjenja=this.registrationForm.controls.birthDate.value;
      korisnik.Adresa=this.registrationForm.controls.adresa.value;
      korisnik.TipKorisnika=this.registrationForm.controls.tipKorisnika.value;

      this.registerService.RegisterUser(korisnik).subscribe(
          (res)=> {        
            alert("Uspesno ste se registrovali."); 
            this.registrationForm.reset();
          },
         
          (err) =>{
              alert("Doslo je do greske pri registraciji.Pokusajte ponovo.")
          }
      );
      

  }

}
