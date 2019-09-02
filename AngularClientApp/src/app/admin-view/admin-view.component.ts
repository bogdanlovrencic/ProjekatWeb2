import { Component, OnInit } from '@angular/core';
import { GetDataService } from '../get-data.service';
import { CenaStavke } from '../Models/cenaStavke';
import { Kontrolor } from '../Models/Kontrolor';
import { RedVoznjeBindingModel } from '../Models/RedVoznjeBindingModel';
import { RedVoznje } from '../Models/RedVoznje';
import { CenovnikPrikaz, Cenovnik } from '../Models/Cenovnik';
import { Stavka } from '../Models/Stavka';
import { Polazak, PolazakModel } from '../Models/polazak';

@Component({
  selector: 'app-admin-view',
  templateUrl: './admin-view.component.html',
  styleUrls: ['./admin-view.component.css']
})
export class AdminViewComponent implements OnInit {

  constructor(private dataService:GetDataService) { }

  clicked="Cenovnici";
  selected = false;
  listaCenovnika:CenovnikPrikaz[];
  listaKontrolora:Kontrolor[];
  listaPolazaka:PolazakModel[];
  listaRedaVoznji:RedVoznje[];
  listaStavki:Stavka[];

  

  ngOnInit() {
    this.dataService.message.subscribe(msg =>{ this.clicked = msg;}); 
    this.dataService.cenovnici.subscribe(msg =>{ this.listaCenovnika = msg;}); 
    this.dataService.stavke.subscribe(msg=>{ this.listaStavki = msg;});
    this.dataService.kontrolori.subscribe(msg => { this.listaKontrolora = msg;});
    this.dataService.polasci.subscribe(msg=>{ this.listaPolazaka=msg});
    this.dataService.timetable.subscribe(msg => { this.listaRedaVoznji = msg;});
  }

  

  onCenovnikUpdateClick(cenovnik:CenovnikPrikaz)
  {
    this.dataService.izmeniCenovnik(cenovnik).subscribe(
      res=>{

      },error=>{console.log(error)});
  }

  onStavkaUpdateClick(stavka:Stavka)
  {
      this.dataService.izmeniStavku(stavka).subscribe(
        res=>{

        },error=>{console.log(error)});
  }

  onKontrolorUpdateClick(kontrolor:Kontrolor)
  {
      this.dataService.izmeniKontrolora(kontrolor).subscribe(res=>{

      },error=>{console.log(error)});
  }

  onPolazakUpdateClick(polazak:PolazakModel)
  {
    this.dataService.izmeniPolazak(polazak).subscribe(res=>{

    },error=>{console.log(error)});
  }

  onRedVoznjeUpdateClick(redVoznje:RedVoznje)
  {
    this.dataService.izmeniRedVoznje(redVoznje).subscribe(res=>{

    },error=>{console.log(error)});
  }


  onCenovnikDeleteClick(id:number){
    this.dataService.obrisiCenovnik(id).subscribe(res =>{
         // this.dataService.refreshCenovnikList()
    }, error=>{console.log(error)});
  }

  onStavkaDeleteClick(id:number)
  {
      this.dataService.obrisiStavku(id).subscribe(res=>{

      },error=>{console.log(error)});
  }

  onPolazakDeleteClick(id:number){
      this.dataService.obrisiPolazak(id).subscribe(res=>{

      },error=> {console.log(error)});
  }

  onKontrolorDeleteClick(email:string){
    this.dataService.obrisiKontrolora(email).subscribe(res =>{
      }, error=>{console.log(error)});
  }

  onRedVoznjeDeleteClick(id:number){
    this.dataService.obrisiRedVoznje(id).subscribe(res =>{
    }, error=>{console.log(error)});
  }

}
