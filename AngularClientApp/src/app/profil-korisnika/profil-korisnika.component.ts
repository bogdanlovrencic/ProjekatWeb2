import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Korisnik } from '../Models/Korisnik';
import { DecodeJwtDataService } from '../decode-jwt-data.service';
import { decode } from 'punycode';
import { UserService } from '../user.service';

@Component({
  selector: 'app-profil-korisnika',
  templateUrl: './profil-korisnika.component.html',
  styleUrls: ['./profil-korisnika.component.css']
})
export class ProfilKorisnikaComponent implements OnInit {

  constructor(private userService:UserService, private decoder:DecodeJwtDataService) { }

  user=new Korisnik();
  email;
  selectedFile:File;
  still="";
  NewPassword="";
  ConfirmPassword="";

  ngOnInit() {
    this.email=this.decoder.getEmailFromToken();
    this.getUserData();
  }

  getUserData(){
    this.userService.getUserData(this.email).subscribe(
      res=>{
          this.user=res;

          switch(this.user.Status)
          {
            case 'Potvrdjen':
              this.still='green';
              break;

            case 'Odbijen':
              this.still='red';
              break;

            case 'Ocekuje_se_verifikacija':
              this.still='orange';
              break;     
          }

          let datum=new Date(res.DateOfBirth);
          let mesec= datum.getMonth() + 1;
          let mesecFormat = mesec.toLocaleString().length < 2 ? '0' : '';
          let danFormat= datum.getDate().toLocaleString().length < 2 ? '0' : '';

          this.user.DateOfBirth= datum.getFullYear()+'-' + mesecFormat + mesec +'-'+danFormat+ datum.getDate();
          
      },
      error=>{
        console.log('error:'+error);
      });
  }

  SaveChanges(f:NgForm)
  {
      this.userService.saveUserChanges(this.user).subscribe(
        result=>{
          if(this.selectedFile != null)
          {
            let userImageData=new FormData();
            userImageData.append('image',this.selectedFile,this.selectedFile.name);
            userImageData.append('email',this.decoder.getEmailFromToken());
            this.userService.UploadImage(userImageData).subscribe(res=>
              {
                  this.getUserData();
              })
          }

          this.userService.changePassword(f).subscribe(res=>{
            if(res == 200)
            {
              console.log(res);
               window.alert("Uspesno ste promenili loziniku.")
               f.controls.OldPassword.setValue('')
               f.controls.NewPassword.setValue('')
               f.controls.confirmPassword.setValue('')
            }
            
          },error=>{ 
              console.log(error)
              window.alert("Dogodila se greska prilikom promene lozinke, pokusajte ponovo!")
            });
        });
  }
 

  onFileSelected(event)
  {
      this.selectedFile = <File>event.target.files[0];
  }
}
