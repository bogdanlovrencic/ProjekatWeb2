import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Linija, LineType } from '../Models/linija';
import { AdminService } from '../admin.service';
import { Router } from '@angular/router';
import { Polazak } from '../Models/polazak';
import { LineService } from '../line.service';


@Component({
  selector: 'app-add-polazak',
  templateUrl: './add-polazak.component.html',
  styleUrls: ['./add-polazak.component.css']
})
export class AddPolazakComponent implements OnInit {

  constructor(private adminService:AdminService,private router: Router,private lineService:LineService) { }
  public polazakForm:FormGroup
  public linije:Linija[]
  public validationMessage:string = ""

    ngOnInit() {
      this.polazakForm = new FormGroup({
        Vreme: new FormControl(null,[Validators.required,Validators.nullValidator]),
        TipDana:new FormControl(null,[Validators.required]),
        LinijaId: new FormControl(null,[Validators.required])
      });
      this.lineService.subscriberToLineChanges().subscribe((data:Linija[]) => {this.linije = data;})
      this.lineService.refreshLines();
    }
    getLineTypeString(lineType: number) {
      switch (lineType) {
        case  LineType.Gradska : return 'Gradska';
        case  LineType.Prigradska: return 'Prigradska';
      }
    }
    onSubmit(){
  
      if(!this.polazakForm.valid){
        this.validationMessage = "Morate popuniti sva polja!"
      }

      let departure:Polazak = {
        Vreme:this.polazakForm.value.Vreme,
        TipDana:this.polazakForm.value.TipDana,
        LinijaId:this.polazakForm.value.LinijaId
      }
    
      this.adminService.addDeparture(departure);
    }
  
  }


