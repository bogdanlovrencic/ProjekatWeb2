import { Component, OnInit } from '@angular/core';
import { GetDataService } from '../get-data.service';
import { CenaStavke } from '../Models/cenaStavke';
import { Kontrolor } from '../Models/Kontrolor';
import { RedVoznje } from '../Models/RedVoznje';

@Component({
  selector: 'app-admin-view',
  templateUrl: './admin-view.component.html',
  styleUrls: ['./admin-view.component.css']
})
export class AdminViewComponent implements OnInit {

  clicked="Price";
  selected = false;
  listPrices:CenaStavke[];
  listControllers:Kontrolor[];
  listTimetables:RedVoznje[];

  constructor(private dataService:GetDataService) { }

  ngOnInit() {
    this.dataService.message.subscribe(msg =>{ this.clicked = msg;}); 
    this.dataService.prices.subscribe(msg =>{ this.listPrices = msg;}); 
    this.dataService.controller.subscribe(msg => {this.listControllers = msg;});
    this.dataService.timetable.subscribe(msg => {this.listTimetables = msg;});
  }

  onPriceDeleteClick(id){
    this.dataService.obrisiCenu(id).subscribe(res =>{
    }, error=>{console.log(error)});
  }

  onControllorDeleteClick(email){
    this.dataService.obrisiKontrolora(email).subscribe(res =>{
      }, error=>{console.log(error)});
  }

  onTimeTableDeleteClick(id){
    this.dataService.obrisiRedVoznje(id).subscribe(res =>{
    }, error=>{console.log(error)});
  }

}
