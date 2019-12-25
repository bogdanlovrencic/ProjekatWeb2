import { Component, OnInit } from '@angular/core';
import { GetDataService } from '../get-data.service';
import { CenaStavke } from '../Models/cenaStavke';
import { Kontrolor } from '../Models/Kontrolor';
import { RedVoznjeBindingModel } from '../Models/RedVoznjeBindingModel';
import { RedVoznje } from '../Models/RedVoznje';
import { CenovnikPrikaz, Cenovnik } from '../Models/Cenovnik';
import { Stavka } from '../Models/Stavka';
import { Polazak, PolazakModel } from '../Models/polazak';
import { CenovnikStavka } from '../Models/CenovnikStavka';
import { forEach } from '@angular/router/src/utils/collection';
import { componentRefresh } from '@angular/core/src/render3/instructions';
import { Router, NavigationExtras } from '@angular/router';
import { AdminService } from '../admin.service';

@Component({
  selector: 'app-admin-view',
  templateUrl: './admin-view.component.html',
  styleUrls: ['./admin-view.component.css']
})
export class AdminViewComponent implements OnInit {

  constructor(private dataService:GetDataService,private router:Router,private adminService: AdminService) { }

  clicked="Cenovnici";
  selected = false;
  listaCenovnika:CenovnikPrikaz[];
  listaKontrolora:Kontrolor[];
  listaRedaVoznji:RedVoznje[];

  

  ngOnInit() {
    this.dataService.message.subscribe(msg =>{ this.clicked = msg;}); 
    this.dataService.cenovnici.subscribe(msg =>{ this.listaCenovnika = msg;}); 
    this.dataService.kontrolori.subscribe(msg => { this.listaKontrolora = msg;});
    this.dataService.timetable.subscribe(msg => { this.listaRedaVoznji = msg;});
    
  }


  onCenovnikUpdateClick(cenovnik:CenovnikPrikaz)
  {
    let navigationExtras: NavigationExtras = {
      queryParams: {
          "cenovnik": JSON.stringify(cenovnik)
      }
    };

    this.router.navigate(['CenovnikIzmena/cenovnik'],navigationExtras)
  
  }


  onKontrolorUpdateClick(kontrolor:Kontrolor)
  {
      let navigationExtras:NavigationExtras={
        queryParams:{
          "kontrolor": JSON.stringify(kontrolor)
        }
      }

      this.router.navigate(['KontrolorIzmena/kontrolor'],navigationExtras)
     
  }


  onRedVoznjeUpdateClick(redVoznje:RedVoznje)
  {
    let navigationExtras:NavigationExtras={
      queryParams:{
        "redVoznje": JSON.stringify(redVoznje)
      }
    }

    this.router.navigate(['RedVoznjeIzmena/redVoznje'],navigationExtras)
    
  
  }


  onCenovnikDeleteClick(id:number){
    this.dataService.obrisiCenovnik(id).subscribe(res =>{
      console.log("Data: ");
      console.log(res);
      if(res == 200){
        this.router.navigate(['/management']);
      }
      else{
        window.alert("Drugi admin je vec obrisao cenovnik, molimo Vas da refresujete stranicu!");
      }
    }, error=>{console.log(error)});
  }


  onKontrolorDeleteClick(email:string){
    this.dataService.obrisiKontrolora(email).subscribe(res =>{
      }, error=>{console.log(error)});
  }

  onRedVoznjeDeleteClick(id:number){
    this.dataService.obrisiRedVoznje(id).subscribe(res =>{
      console.log("Data: ");
        console.log(res);
        if(res == 200){
          this.router.navigate(['/management']);
        }
        else{
          window.alert("Drugi admin je vec obrisao red voznje, molimo Vas da refresujete stranicu!");
        }
    }, error=>{console.log(error)});
  }

}
