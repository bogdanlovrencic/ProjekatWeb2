import { Component, OnInit } from '@angular/core';
import { KupovinaKarteService } from 'src/app/kupovina-karte.service';
import { FormBuilder,FormGroup, Validators } from '@angular/forms';
import { Email } from 'src/app/Email';
import { UserService } from '../user.service';
import { TipPutnika } from '../Models/TipPutnika';

@Component({
  selector: 'app-kupi-kartu',
  templateUrl: './kupi-kartu.component.html',
  styleUrls: ['./kupi-kartu.component.css']
})
export class KupiKartuComponent implements OnInit {

  private emailForm: FormGroup;

  loggedIn = undefined;
  userData : any;
  userProfileActivated: any;
  userProfileType: any;
  selectedTicketType: any;
  cena: number;
  addTicket: any;
  temp: any;
  isLoggedIn: boolean;
  priceEUR: number;
  tempPrice: number;

  // public payPalConfig?: IPayPalConfig;
  // showSuccess: boolean;

  constructor(private userService: UserService, private kartaService: KupovinaKarteService, private fb: FormBuilder) {
      this.emailForm=this.fb.group({
        email: ['', Validators.required],
        
      });
   }

  ngOnInit() {
    this.loggedIn = localStorage['role'];
    this.selectedTicketType = "Vremenska karta";
    this.getUser();
    //this.initConfig();
    this.temp = localStorage['name'];
    if(this.temp){
      this.isLoggedIn = true;
    }
    else{
      this.isLoggedIn = false;
    }
    
  }

  onSelectTipKarte(event : any){
    this.selectedTicketType = event.target.value;
    this.getUser();
  }

  getUser(){
      if(localStorage.getItem('name'))
      {
        this.userService.getUserData(localStorage.getItem('name')).subscribe( data =>{
        this.userData = data;
        this.userProfileActivated = this.userData.Status;
        this.userProfileType = this.userData.TipPutnika;
        //this.email = this.userData.Email;
        this.emailForm.controls.email.setValue(this.userData.Email);
        
        if(this.userProfileActivated != "Potvrdjen")
        {
          this.userProfileType = 0;
        }
        this.kartaService.getCena(this.selectedTicketType, this.userProfileType).subscribe( data =>
          {
            this.cena = data;
            this.priceEUR = data*0.0085;
          } 
          );
      });
      }
      else
      {     
        this.emailForm.controls.email.setValue(null);
        this.kartaService.getCena(this.selectedTicketType, TipPutnika.Regularni.toString()).subscribe( data =>
          {
            this.cena = data;
            this.priceEUR = data*0.0085;
          } 
          );
      }
  }

  KupiKartu():void
  {
    this.kartaService.dodajKartu(this.cena, this.selectedTicketType, localStorage.getItem('name'), this.emailForm.controls.email.value).subscribe( data =>{
      window.alert("Kupili ste kartu!")
      this.emailForm.reset()
    } );     
  }

}
