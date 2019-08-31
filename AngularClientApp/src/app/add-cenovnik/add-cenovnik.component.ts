import { Component, OnInit } from '@angular/core';
import { NgForm, FormGroup, FormControl, Validators } from '@angular/forms';
import { AdminService } from '../admin.service';
import { Router } from '@angular/router';
import { error } from '@angular/compiler/src/util';
import { Stavka } from '../Models/Stavka';
import { StavkaService } from '../stavka.service';
import { Cenovnik } from '../Models/Cenovnik';

@Component({
  selector: 'app-add-cena-stavke',
  templateUrl: './add-cenovnik.component.html',
  styleUrls: ['./add-cenovnik.component.css']
})
export class AddCenovnikComponent implements OnInit {

  private validationMessage='';
  public hourItems :Stavka[]
  public dayItems :Stavka[]
  public monthItems :Stavka[]
  public yearItems :Stavka[]
  public cenovnikForm:FormGroup
  constructor(private adminService: AdminService,private router: Router,private priceListItemService:StavkaService) { }

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
  }

  onSubmit()
  {
    if(!this.cenovnikForm.valid)
    {
      this.validationMessage="Sva polja moraju biti popunjena!";
      return;
    }

    let cenovnik:Cenovnik ={
      VaziOd: this.cenovnikForm.value.VaziOd,
      VaziDo:this.cenovnikForm.value.VaziDo,
      Aktivan:true,
      Stavke:[this.cenovnikForm.value.HourId,this.cenovnikForm.value.DayId,this.cenovnikForm.value.MonthId,this.cenovnikForm.value.YearId],
    };
      this.adminService.addCenovnik(cenovnik).subscribe(res=>{
        this.router.navigate(['/management']);
      },
      error=>{
        console.log(error);
      });
  }

}
