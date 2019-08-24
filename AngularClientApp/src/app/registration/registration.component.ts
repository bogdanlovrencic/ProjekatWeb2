import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { Validators } from '@angular/forms';
import { HttpClient, HttpRequest } from '@angular/common/http';
import { RegistrationService } from '../registration.service';
import { Korisnik } from '../Korisnik';
import { RouterLinkActive, Router } from '@angular/router';
import { DecodeJwtDataService } from '../decode-jwt-data.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
       
  private registrationForm : FormGroup;
  public validationMessage = ''
  selectedFile:File=null;
  rola;

  constructor(private fb: FormBuilder,private registerService: RegistrationService,private router: Router,private decoder: DecodeJwtDataService) {
    this.registrationForm = this.fb.group({
      firstName:['',Validators.required],
      lastName: ['',Validators.required],
      email: ['',Validators.required],
      password:['',Validators.required],
      confPassword:['',Validators.required],
      birthDate:['',Validators.required],
      adresa : ['',Validators.required],
      tipPutnika: []    
    });
   }

  ngOnInit() {
    this.rola=this.decoder.getRoleFromToken();
  }

  onSubmit()
  {
      this.validationMessage='';

      if(!this.registrationForm.valid)
      {
          this.validationMessage="Sva polja moraju biti popunjena!";
          return;
      }

      
      if(this.registrationForm.value.password !== this.registrationForm.value.confPassword)
      {
          this.validationMessage="Lozinke se moraju poklapati!";
          return;
      }

      let korisnik=new Korisnik();
      korisnik.Ime= this.registrationForm.controls.firstName.value;
      korisnik.Prezime=this.registrationForm.controls.lastName.value;
      korisnik.Email=this.registrationForm.controls.email.value;
      korisnik.Lozinka=this.registrationForm.controls.password.value;
      korisnik.DatumRodjenja=this.registrationForm.controls.birthDate.value;
      korisnik.Adresa=this.registrationForm.controls.adresa.value;
      korisnik.TipPutnika=this.registrationForm.controls.tipPutnika.value;

      this.registerService.RegisterUser(korisnik).subscribe(
          (res)=> {     
            if(this.selectedFile != null)
            {
                let imageData=new FormData();
                imageData.append('image',this.selectedFile,this.selectedFile.name);
                this.registerService.UploadImage(korisnik.Email,imageData)
            }   
            alert("Uspesno ste se registrovali."); 
            
            //this.router.navigate(['/login']);

            if(this.rola == 'Admin')
            {
                this.router.navigate(['/management']);
            }
            else
            {
                this.router.navigate(['/login']);
            }
          },
         
          (err) =>{
              alert("Doslo je do greske pri registraciji.Pokusajte ponovo.")
          }
      );
  }

  onFileSelected(event)
  {
     this.selectedFile=<File>event.target.files[0];
  }

}
