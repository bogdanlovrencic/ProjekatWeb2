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
  // public hourItems :Stavka[]
  // public dayItems :Stavka[]
  // public monthItems :Stavka[]
  // public yearItems :Stavka[]
  public cenovnikForm:FormGroup
  constructor(private adminService: AdminService,private router: Router,private priceListItemService:StavkaService) { }

  ngOnInit() {
    this.cenovnikForm = new FormGroup({
      VaziOd:new FormControl(null,[Validators.required]),
      VaziDo: new FormControl(null,[Validators.required]),
      HourTicket: new FormControl(null,[Validators.required]),
      DayTicket:new FormControl(null,[Validators.required]),
      MonthTicket: new FormControl(null,[Validators.required]),
      YearTicket: new FormControl(null,[Validators.required])
    })
    
  //   this.priceListItemService.subscribeToHourItemsChanged().subscribe((data:Stavka[])=>{
  //     this.hourItems = data
  //   })
  //  this.priceListItemService.subscribeToDayItemsChanged().subscribe((data:Stavka[])=>
  //   {this.dayItems = data})
  //  this.priceListItemService.subscribeToMonthItemsChanged().subscribe((data:Stavka[])=>{
  //    this.monthItems = data
  //  })
  //  this.priceListItemService.subscribeToYeartemsChanged().subscribe((data:Stavka[])=>
  //  { this.yearItems = data})
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
    let cenovnik:Cenovnik ={
      VaziOd: this.cenovnikForm.value.VaziOd,
      VaziDo:this.cenovnikForm.value.VaziDo,
      Aktivan:true
    };

    let vremenska=this.cenovnikForm.value.HourTicket
    let dnevna=this.cenovnikForm.value.DayTicket
    let mesecna=this.cenovnikForm.value.MonthTicket 
    let godisnja=this.cenovnikForm.value.YearTicket 

  
      this.adminService.addCenovnik(cenovnik,vremenska,dnevna,mesecna,godisnja).subscribe(res=>{
        this.router.navigate(['/management']);
      },
      error=>{
        console.log(error);
      });
  }

}
