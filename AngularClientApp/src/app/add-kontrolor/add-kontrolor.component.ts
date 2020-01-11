import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DecodeJwtDataService } from '../decode-jwt-data.service';
import { Korisnik } from '../Models/Korisnik';
import { RegistrationService } from '../registration.service';

@Component({
  selector: 'app-add-kontrolor',
  templateUrl: './add-kontrolor.component.html',
  styleUrls: ['./add-kontrolor.component.css']
})
export class AddKontrolorComponent implements OnInit {



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
      tipPutnika: ['Regularni']    
    });
   }

  ngOnInit() {
   
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
      korisnik.Name= this.registrationForm.controls.firstName.value;
      korisnik.Surname=this.registrationForm.controls.lastName.value;
      korisnik.Email=this.registrationForm.controls.email.value;
      korisnik.Password=this.registrationForm.controls.password.value;
      korisnik.DateOfBirth=this.registrationForm.controls.birthDate.value;
      korisnik.Address=this.registrationForm.controls.adresa.value;
      korisnik.UserType=this.registrationForm.controls.tipPutnika.value;
      korisnik.ConfirmPassword=this.registrationForm.controls.confPassword.value;

      this.registerService.RegisterUser(korisnik).subscribe(
          (data)=> {  
            if(!data)
            {
              window.alert('Korisnik sa email-om: ' + this.registrationForm.controls.email.value + ' je vec registrovan!')
            
            }
            else if (data.toString() == 200) 
            {   
              if(this.selectedFile != null)
              {
                  let userImageData=new FormData();
                  userImageData.append('image',this.selectedFile,this.selectedFile.name);
                  userImageData.append('email',this.registrationForm.value.email);
              
                  this.registerService.UploadImage(userImageData).subscribe()
              }   

               this.router.navigate(['/management']);
           
            
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
