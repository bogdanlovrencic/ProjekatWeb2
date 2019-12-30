import { Component, OnInit } from '@angular/core';
import { KupovinaKarteService } from '../kupovina-karte.service';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-validiraj-kartu',
  templateUrl: './validiraj-kartu.component.html',
  styleUrls: ['./validiraj-kartu.component.css']
})
export class ValidirajKartuComponent implements OnInit {

  constructor(private fb:FormBuilder,private kartaService:KupovinaKarteService) {

  }

  validirajKartuForm= this.fb.group({
    id:['',Validators.required],
  });

  validnaKarta:boolean
  show:boolean=false
  showError:boolean=false

  ngOnInit() {

  }

  ValidirajKartu()
  {
      this.kartaService.ValidirajKartu(this.validirajKartuForm.controls.id.value).subscribe(
        data=>{
          if(data == 200)
          {
            this.validnaKarta=true;
            this.showError=false;
          }
          else if(data == 202)
          {
            this.validnaKarta=false;
            this.showError=false;
          }
          else if(data == 204)
          {
            this.show=false;
            this.showError=true;
          }

      },(error)=>{
        console.log(error);
      })
  }

}
