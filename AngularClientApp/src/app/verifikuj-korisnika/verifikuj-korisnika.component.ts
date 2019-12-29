import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { UserService } from '../user.service';
import { Korisnik } from '../Models/Korisnik';
import { KontrolorService } from '../kontrolor.service';

@Component({
  selector: 'app-verifikuj-korisnika',
  templateUrl: './verifikuj-korisnika.component.html',
  styleUrls: ['./verifikuj-korisnika.component.css']
})
export class VerifikujKorisnikaComponent implements OnInit {

  profileForm = this.fb.group({
    name: ['', Validators.required],
    surname: ['', Validators.required],
    address: ['', Validators.required],
    birthday: ['', Validators.required],
    email: ['', [Validators.required, Validators.email]],
    userType: ['', Validators.required],
  });

  users: Korisnik[] = [];
  selectedUserEmail: any;
  i: number;
  image: any = null;

  constructor(private fb: FormBuilder, private userService: UserService, private kontrolorService: KontrolorService) { }

  ngOnInit() {
    this.getNevalidniKorisnici();
  }

  getNevalidniKorisnici(){
    this.userService.getKorisniciZaValidaciju().subscribe(
      data =>{
        this.users = data;
        if(this.users.length > 0){
          this.selectedUserEmail = this.users[0].Email;
          this.populateForm();
          this.userService.downloadImage(this.selectedUserEmail).subscribe(
            response => {
              if(response.toString() != "204"){
                this.image = 'data:image/jpeg;base64,' + response;
              }
            }
          );
        }
      }
    );
  }

  onSelectUser(event: any){
    this.selectedUserEmail = event.target.value;
    this.populateForm();
    this.userService.downloadImage(this.selectedUserEmail).subscribe(
      response => {
        if(response.toString() != "204"){
        this.image = 'data:image/jpeg;base64,' + response;
      }
      }
    );
  }

  populateForm(){

    for(this.i = 0; this.i < this.users.length; this.i++){
      if(this.users[this.i].Email == this.selectedUserEmail){
        this.profileForm.controls.name.setValue(this.users[this.i].Name);
        this.profileForm.controls.surname.setValue(this.users[this.i].Surname);
        this.profileForm.controls.address.setValue(this.users[this.i].Address);
        this.profileForm.controls.birthday.setValue(this.users[this.i].DateOfBirth);
        this.profileForm.controls.email.setValue(this.users[this.i].Email);
        this.profileForm.controls.userType.setValue(this.users[this.i].UserType);
      }
    }

  }

  Validiraj(){
    this.kontrolorService.verifikujKorisnika(this.profileForm.controls.email.value, true).subscribe(
      data =>{
        this.profileForm.reset();
        this.getNevalidniKorisnici();
        this.image = null;
      }
    );
  }

  Odbij(){
    this.kontrolorService.verifikujKorisnika(this.profileForm.controls.email.value, false).subscribe(
      data =>{
        this.profileForm.reset();
        this.getNevalidniKorisnici();
        this.image = null;
      }
    );
  }

}
