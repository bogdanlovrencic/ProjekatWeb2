import { Component, OnInit } from '@angular/core';
import { GetDataService } from '../get-data.service';
import { CenaStavke } from '../Models/cenaStavke';
import { Kontrolor } from '../Models/Kontrolor';
import { RedVoznjeBindingModel } from '../Models/RedVoznjeBindingModel';
import { RedVoznje } from '../Models/RedVoznje';
import { CenovnikPrikaz } from '../Models/Cenovnik';

@Component({
  selector: 'app-admin-view',
  templateUrl: './admin-view.component.html',
  styleUrls: ['./admin-view.component.css']
})
export class AdminViewComponent implements OnInit {

  clicked="";
  selected = false;
  public listaCenovnika:CenovnikPrikaz[];
  listControllers:Kontrolor[];
  listTimetables:RedVoznje[];

  constructor(private dataService:GetDataService) { }

  ngOnInit() {
    this.dataService.message.subscribe(msg =>{ this.clicked = msg;}); 
    this.dataService.cenovnici.subscribe(msg =>{ this.listaCenovnika = msg;}); 
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
