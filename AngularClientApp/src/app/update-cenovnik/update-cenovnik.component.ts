import { Component, OnInit } from '@angular/core';
import { Stavka } from '../Models/Stavka';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AdminService } from '../admin.service';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { StavkaService } from '../stavka.service';
import { CenovnikPrikaz, Cenovnik } from '../Models/Cenovnik';

@Component({
  selector: 'app-update-cenovnik',
  templateUrl: './update-cenovnik.component.html',
  styleUrls: ['./update-cenovnik.component.css']
})
export class UpdateCenovnikComponent implements OnInit {

  

  private validationMessage='';
  public hourItems :Stavka[]
  public dayItems :Stavka[]
  public monthItems :Stavka[]
  public yearItems :Stavka[]
  public cenovnikForm:FormGroup
  public Cenovnik:CenovnikPrikaz

  constructor(private adminService: AdminService,private router: Router,private priceListItemService:StavkaService,  private route:ActivatedRoute) { }

  
  ngOnInit() {
    this.cenovnikForm = new FormGroup({
      VaziOd:new FormControl(null,[Validators.required]),
      VaziDo: new FormControl(null,[Validators.required]),
      HourId: new FormControl(null,[Validators.required]),
      DayId:new FormControl(null,[Validators.required]),
      MonthId: new FormControl(null,[Validators.required]),
      YearId: new FormControl(null,[Validators.required])
    })
    
    this.priceListItemService.subscribeToHourItemsChanged().subscribe((data:Stavka[])=>{
      this.hourItems = data
    })
   this.priceListItemService.subscribeToDayItemsChanged().subscribe((data:Stavka[])=>
    {this.dayItems = data})
   this.priceListItemService.subscribeToMonthItemsChanged().subscribe((data:Stavka[])=>{
     this.monthItems = data
   })
   this.priceListItemService.subscribeToYeartemsChanged().subscribe((data:Stavka[])=>
   { this.yearItems = data})

   this.route.queryParams.subscribe((params)=>{
        this.Cenovnik=JSON.parse(params["cenovnik"]); 
        
        this.cenovnikForm.patchValue({
          VaziOd:this.Cenovnik.VaziOd.getUTCDate,
          VaziDo:this.Cenovnik.VaziDo.toDateString,
          HourId:this.Cenovnik.Stavke[0].Id,
          DayId:this.Cenovnik.Stavke[1].Id,
          MonthId:this.Cenovnik.Stavke[2].Id,
          YearId:this.Cenovnik.Stavke[3].Id

        
  
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
    let cenovnik:CenovnikPrikaz ={
      Id: this.Cenovnik.Id,
      VaziOd: this.cenovnikForm.value.VaziOd,
      VaziDo:this.cenovnikForm.value.VaziDo,
      Aktivan:true,
      Stavke:[this.cenovnikForm.value.HourId,this.cenovnikForm.value.DayId,this.cenovnikForm.value.MonthId,this.cenovnikForm.value.YearId],
    };
     this.adminService.izmeniCenovnik(cenovnik).subscribe(res=>{
        this.router.navigate(['/management']);
      },
      error=>{
        console.log(error);
      });
  }

}
