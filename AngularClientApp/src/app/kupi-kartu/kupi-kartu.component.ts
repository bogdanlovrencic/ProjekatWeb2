import { Component, OnInit } from '@angular/core';
import { KupovinaKarteService } from 'src/app/kupovina-karte.service';
import { FormBuilder,FormGroup, Validators } from '@angular/forms';
import { Email } from 'src/app/Email';
import { UserService } from '../user.service';
import { TipPutnika } from '../Models/TipPutnika';
import { DecodeJwtDataService } from '../decode-jwt-data.service';
import { Korisnik } from '../Models/Korisnik';

@Component({
  selector: 'app-kupi-kartu',
  templateUrl: './kupi-kartu.component.html',
  styleUrls: ['./kupi-kartu.component.css']
})
export class KupiKartuComponent implements OnInit {

  private emailForm: FormGroup;

  rola = "";
  userData : Korisnik;
  userProfileActivated: any;
  userProfileType: any;
  selectedTicketType: any;
  cena: number;
  addTicket: any;
  temp: any;
  isLoggedIn: boolean;
  priceEUR: number;
  tempPrice: number;
  userEmail:string

  // public payPalConfig?: IPayPalConfig;
  // showSuccess: boolean;

  constructor(private userService: UserService, private kartaService: KupovinaKarteService, private fb: FormBuilder,private decodedJwtService:DecodeJwtDataService) {
      this.emailForm=this.fb.group({
        email: ['', Validators.required],
        
      });
   }

  ngOnInit() {
    this.rola = this.decodedJwtService.getRoleFromToken();
    this.userEmail=this.decodedJwtService.getEmailFromToken();
    this.selectedTicketType = "Vremenska karta";
    this.getUser(this.userEmail);
    //this.initConfig();
  
    if(this.rola !=""){
      this.isLoggedIn = true;
    }
    else{
      this.isLoggedIn = false;
    }
    
  }

  onSelectTipKarte(event : any){
    this.selectedTicketType = event.target.value;
    this.getUser(this.userEmail);
  }

  getUser(email:string){
   

      if(email!="")
      {
        this.userService.getUserData(email).subscribe( data =>{
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
    this.kartaService.dodajKartu(this.cena, this.selectedTicketType,this.userData.Email, this.emailForm.controls.email.value).subscribe( data =>{
      window.alert("Kupili ste kartu!")
      this.emailForm.reset()
    } );     
  }

}
