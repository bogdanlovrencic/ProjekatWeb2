import { Component, OnInit } from '@angular/core';
import { RedVoznjeService } from '../red-voznje.service';

import { HttpErrorResponse } from '@angular/common/http';
import { Linija } from '../Models/linija';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { RedVoznjeBindingModel } from '../Models/RedVoznjeBindingModel';
import { RedVoznje } from '../Models/RedVoznje';

@Component({
  selector: 'app-red-voznje',
  templateUrl: './red-voznje.component.html',
  styleUrls: ['./red-voznje.component.css']
})
export class RedVoznjeComponent implements OnInit {

  Linije : Linija[];
  private prikazRedaVoznjeForm:FormGroup
  public selectedRedVoznje:string
  public polasci:string[]
  buttonClicked=false
  public redVoznjeZaPrikaz:RedVoznje
  public validationMessage


  
  constructor(private redVoznjeService:RedVoznjeService,private fb:FormBuilder) { 
    this.prikazRedaVoznjeForm= this.fb.group({
      tipRedaVoznje:['',Validators.required],
      tipDana:['',Validators.required],
      izabranaLinija:['',Validators.required],
     
   })
  }

  ngOnInit() {
    
  }

  PrikaziRedVoznje()
  {
     
      this.validationMessage=""

      if(!this.prikazRedaVoznjeForm.valid)
      {
          this.validationMessage="Sva polja moraju biti popunjena!";
          return;
      }
      this.buttonClicked=true

      let redVoznje= new RedVoznjeBindingModel();

      redVoznje.TipRedaVoznje=this.prikazRedaVoznjeForm.controls.tipRedaVoznje.value
      redVoznje.TipDana=this.prikazRedaVoznjeForm.controls.tipDana.value
      redVoznje.LinijaId=this.prikazRedaVoznjeForm.controls.izabranaLinija.value

      this.redVoznjeService.prikaziRedVoznje(redVoznje).subscribe(res=>{
            this.redVoznjeZaPrikaz=res
            this.polasci= this.redVoznjeZaPrikaz.Polasci.split(',')
            console.log(res)
          
      }),error=>{console.log(error)}

  }
  

  onChange(event)
  {
    let redVoznjeTip:number;
     
    this.selectedRedVoznje=event.target.value
   
    if(this.selectedRedVoznje == 'Gradski')
       redVoznjeTip=0
    
    else
      redVoznjeTip=1

    this.redVoznjeService.getAllLinesForRedVoznje(redVoznjeTip).subscribe((data:Linija[])=>{
      this.Linije = data
   })
  }

}
