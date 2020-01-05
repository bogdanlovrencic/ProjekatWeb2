import { Component, OnInit } from '@angular/core';
import { KupovinaKarteService } from 'src/app/kupovina-karte.service';
import { FormBuilder,FormGroup, Validators } from '@angular/forms';
import { UserService } from '../user.service';
import { TipPutnika } from '../Models/TipPutnika';
import { DecodeJwtDataService } from '../decode-jwt-data.service';
import { Korisnik } from '../Models/Korisnik';
import { IPayPalConfig, ICreateOrderRequest } from 'ngx-paypal';

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

  public payPalConfig?: IPayPalConfig;
  showSuccess: boolean;

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
    this.initConfig();
  
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
        this.userProfileType = this.userData.UserType;
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

  //PayPal
  private initConfig(): void {

    this.payPalConfig = {
      currency: 'EUR',
      clientId: 'ATniFSIBK8rHNVLG_PetS-skYOy0lfhJw1m7IlrlHhqLzAC7_HaD1fNQPX_y8nDiTvtfyn7uyQEyofp6',
      

      createOrderOnClient: (data) => <ICreateOrderRequest> {
          intent: 'CAPTURE',
          purchase_units: [{
              amount: {
                  currency_code: 'EUR',
                  value: this.priceEUR.toPrecision(2),
                  breakdown: {
                      item_total: {
                          currency_code: 'EUR',
                          value: this.priceEUR.toPrecision(2)
                      }
                  }
              },
              items: [{
                  name: 'Enterprise Subscription',
                  quantity: '1',
                  category: 'DIGITAL_GOODS',
                  unit_amount: {
                      currency_code: 'EUR',
                      value: this.priceEUR.toPrecision(2),
                  },
              }]
          }]
      },
      advanced: {
          commit: 'true'
          
      },
      style: {
        label: 'paypal',
        layout: 'horizontal'
        
      },

      onApprove: (data, actions) => {
          console.log('onApprove - transaction was approved, but not authorized', data, actions);
         
      },
      onClientAuthorization: (data) => {
          console.log('onClientAuthorization - you should probably inform your server about completed transaction at this point', data);
          if(!this.isLoggedIn){
             this.userProfileType = 0;           
          }
          this.kartaService.KupiKartuPrekoPayPal(this.isLoggedIn, this.emailForm.controls.email.value, data.id, data.payer.email_address, data.payer.payer_id, this.cena, this.selectedTicketType, this.userProfileType).subscribe();
           
      },
      onCancel: (data, actions) => {
          console.log('OnCancel', data, actions);

      },
      onError: err => {
        window.alert("Something went wrong!");
          console.log('OnError', err);
      },
      onClick: (data, actions) => {
          console.log('onClick', data, actions);
      },
    };
  }

}
