import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Linija, LineType } from '../Models/linija';
import { AdminService } from '../admin.service';
import { Router, ActivatedRoute } from '@angular/router';
import { LineService } from '../line.service';
import { Polazak, PolazakModel } from '../Models/polazak';

@Component({
  selector: 'app-update-polazak',
  templateUrl: './update-polazak.component.html',
  styleUrls: ['./update-polazak.component.css']
})
export class UpdatePolazakComponent implements OnInit {

  constructor(private adminService:AdminService,private router: Router,private lineService:LineService,private route:ActivatedRoute) { }
  public polazakForm:FormGroup
  public linije:Linija[]
  public validationMessage:string = ""
  public polazak:PolazakModel;

    ngOnInit() {
      this.polazakForm = new FormGroup({
        Vreme: new FormControl(null,[Validators.required,Validators.nullValidator]),
        TipDana:new FormControl(null,[Validators.required]),
        LinijaId: new FormControl(null,[Validators.required])
      });

      this.route.queryParams.subscribe((params)=>{
        this.polazak=JSON.parse(params["polazak"])

        this.polazakForm.patchValue({
          Vreme:this.polazak.Vreme,
          TipDana:this.polazak.TipDana,
          LinijaId:this.polazak.LinijaId
          
        })

      })
      this.lineService.subscriberToLineChanges().subscribe((data:Linija[]) => {this.linije = data;})
      this.lineService.refreshLines();
    }
    getLineTypeString(lineType: number) {
      switch (lineType) {
        case  LineType.Gradski : return 'Gradski';
        case  LineType.Prigradski: return 'Prigradski';
      }

    
    }
    onSubmit(){
      this.validationMessage="";
      if(!this.polazakForm.valid){
        this.validationMessage = "Morate popuniti sva polja!";
        return;
      }

      let polazak:PolazakModel = {
        Id:this.polazak.Id,
        Vreme:this.polazakForm.value.Vreme,
        TipDana:this.polazakForm.value.TipDana,
        LinijaId:this.polazakForm.value.LinijaId,
        Active:this.polazak.Active
      }
    
  
      this.adminService.izmeniPolazak(polazak).subscribe(res=>{
        this.router.navigate(['/management']);
      },error=>{console.log(error)});
    }

}
