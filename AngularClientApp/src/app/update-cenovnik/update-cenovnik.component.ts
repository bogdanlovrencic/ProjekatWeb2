import { Component, OnInit } from '@angular/core';
import { Stavka } from '../Models/Stavka';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AdminService } from '../admin.service';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { StavkaService } from '../stavka.service';
import { CenovnikPrikaz, Cenovnik, CenovnikUpdate } from '../Models/Cenovnik';

@Component({
  selector: 'app-update-cenovnik',
  templateUrl: './update-cenovnik.component.html',
  styleUrls: ['./update-cenovnik.component.css']
})
export class UpdateCenovnikComponent implements OnInit {

  private validationMessage='';
  public cenovnikForm:FormGroup
  public Cenovnik:CenovnikPrikaz
 
  constructor(private adminService: AdminService,private router: Router,private priceListItemService:StavkaService,  private route:ActivatedRoute) { }

  
  ngOnInit() {
    this.cenovnikForm = new FormGroup({
      VaziOd:new FormControl(null,[Validators.required]),
      VaziDo: new FormControl(null,[Validators.required]),
      HourTicket: new FormControl(null,[Validators.required]),
      DayTicket:new FormControl(null,[Validators.required]),
      MonthTicket: new FormControl(null,[Validators.required]),
      YearTicket: new FormControl(null,[Validators.required])
    })
    

   this.route.queryParams.subscribe((params)=>{
        this.Cenovnik=JSON.parse(params["cenovnik"]); 
        
       
        this.cenovnikForm.patchValue({
          VaziOd:this.Cenovnik.VaziOd,
          VaziDo:this.Cenovnik.VaziDo,
          HourTicket:this.Cenovnik.Stavke[0].Cena,
          DayTicket:this.Cenovnik.Stavke[1].Cena,
          MonthTicket:this.Cenovnik.Stavke[2].Cena,
          YearTicket:this.Cenovnik.Stavke[3].Cena

     })
   })

  
  }

  onSubmit()
  {
    if(!this.cenovnikForm.valid)
    {
      this.validationMessage="Sva polja moraju biti popunjena!";
      return;
    }

    if(this.cenovnikForm.value.VaziDo < this.cenovnikForm.value.VaziOd)
    {
      this.validationMessage="Datum pocetka vazenja cenovnika mora biti manji od datuma kraja vazenja!";
      return;
    }

    if(this.cenovnikForm.value.HourTicket < 0 || this.cenovnikForm.value.DayTicket < 0 || this.cenovnikForm.value.MonthTicket < 0 || this.cenovnikForm.value.YearTicket < 0)
    {
      this.validationMessage="Cena ne sme biti negativna!";
      return
    }

    let cenovnik:CenovnikUpdate ={
      Id: this.Cenovnik.Id,
      VaziOd: this.cenovnikForm.value.VaziOd,
      VaziDo:this.cenovnikForm.value.VaziDo,
      Aktivan:true,
      Version:this.Cenovnik.Version
    };

    let vremenska=this.cenovnikForm.value.HourTicket
    let dnevna=this.cenovnikForm.value.DayTicket
    let mesecna=this.cenovnikForm.value.MonthTicket 
    let godisnja=this.cenovnikForm.value.YearTicket 

     this.adminService.izmeniCenovnik(cenovnik,vremenska,dnevna,mesecna,godisnja).subscribe(data=>{
        console.log("Data: ");
        console.log(data);
        if(data == 200){
          this.router.navigate(['/management']);
        }
        else{
          window.alert("Drugi admin je vec izmenio cenovnik, molimo Vas da refresujete stranicu!");
        }
       
      },
      error=>{
        console.log(error);
      });
  }

}
