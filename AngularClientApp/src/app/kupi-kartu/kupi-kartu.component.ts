import { Component, OnInit } from '@angular/core';
import { KupovinaKarteService } from 'src/app/kupovina-karte.service';
import { FormBuilder,FormGroup, Validators } from '@angular/forms';
import { Email } from 'src/app/Email';

@Component({
  selector: 'app-kupi-kartu',
  templateUrl: './kupi-kartu.component.html',
  styleUrls: ['./kupi-kartu.component.css']
})
export class KupiKartuComponent implements OnInit {

  private kupiKartuForm: FormGroup;

  constructor(private kartaService:KupovinaKarteService,private fb:FormBuilder) {
       this.kupiKartuForm=this.fb.group({
           email: ['',Validators.required]
       });
   }

  ngOnInit() {

  }
  KupiKartu():void
  {
       console.warn(this.kupiKartuForm.valid);
       let email  = this.kupiKartuForm.value.email;
      this.kartaService.dodajKartu(email).subscribe(
        (res)=>{
           alert(res); 
           this.kupiKartuForm.reset();
        },
        (err)=>{
          console.log(err);
        }
       
      );
     
  }

}
