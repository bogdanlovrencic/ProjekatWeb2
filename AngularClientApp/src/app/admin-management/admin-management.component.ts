import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CenaStavke } from '../Models/cenaStavke';
import { Kontrolor } from '../Models/Kontrolor';
import { RedVoznjeBindingModel } from '../Models/RedVoznjeBindingModel';
import { GetDataService } from '../get-data.service';
import { Stavka } from '../Models/Stavka';
import { Linija } from '../Models/linija';
import { Polazak, PolazakModel } from '../Models/polazak';
import { RedVoznje } from '../Models/RedVoznje';
import { CenovnikPrikaz } from '../Models/Cenovnik';

@Component({
  selector: 'app-admin-management',
  templateUrl: './admin-management.component.html',
  styleUrls: ['./admin-management.component.css']
})
export class AdminManagementComponent implements OnInit {

  message="";
  listaCenovnika:CenovnikPrikaz[];
  listaKontrolora:Kontrolor[];
  listaRedaVoznji:RedVoznje[];
  listaStavki:Stavka[];
  listaLinija: Linija[];
  listaPolazaka:PolazakModel[];

 
  constructor(private tableData:GetDataService, private router:Router) { }

  ngOnInit() {
    this.tableData.message.subscribe(msg => this.message = msg);
  }


  getTable(tableName:string){
    this.tableData.getTableDataService(tableName).subscribe(res =>{ 
      //let info = JSON.parse(JSON.stringify(res));
      if(tableName ==="Cenovnici")
      {
        //let info = JSON.parse(JSON.stringify(res));
        this.listaCenovnika = res;   
        this.tableData.changeCenovnici(this.listaCenovnika);
      }
      else if(tableName ==='Stavke')
      {
          //let info=JSON.parse(JSON.stringify(res));
          this.listaStavki=res;
          this.tableData.changeStavke(this.listaStavki);

      }
      else if(tableName === "Linije")
      {
          let info=JSON.parse(JSON.stringify(res));
          this.listaLinija=info;
          this.tableData.changeLinije(this.listaLinija);
      }
      else if(tableName ==="Kontrolori")
      {
        //let info = JSON.parse(JSON.stringify(res));
        this.listaKontrolora = res;
        this.tableData.changeKontrolori(this.listaKontrolora);
      }
      else if(tableName ==="RedoviVoznje")
      {
        let info = JSON.parse(JSON.stringify(res));
        this.listaRedaVoznji = info;
        this.tableData.changeRedoviVoznje(this.listaRedaVoznji);
      }
      else if(tableName === "Polasci")
      {
        let info = JSON.parse(JSON.stringify(res));
        this.listaPolazaka = info;
        this.tableData.changePolasci(this.listaPolazaka);
      }
    });
    console.log('admin');
    this.tableData.changeMessage(tableName);
    console.log(this.message);
    }

  onAddClick(table){
    switch(table){
      case 'Cenovnik':
        this.router.navigate(['/Cenovnik'])
      break;
      case 'Stavka':
        this.router.navigate(['/Stavke'])
        break;
      case 'Kontrolor':
        this.router.navigate(['/Kontrolori'])
      break;
      case 'Linija':
        this.router.navigate(['/Linije'])
        break;
      case 'RedVoznje':
        this.router.navigate(['/RedVoznje'])
        break;
      case 'Polazak':
        this.router.navigate(['/Polazak'])
        break;
    }
  }
}
