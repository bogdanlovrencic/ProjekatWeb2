import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CenaStavke } from '../Models/cenaStavke';
import { Kontrolor } from '../Models/Kontrolor';
import { RedVoznje } from '../Models/RedVoznje';
import { GetDataService } from '../get-data.service';

@Component({
  selector: 'app-admin-management',
  templateUrl: './admin-management.component.html',
  styleUrls: ['./admin-management.component.css']
})
export class AdminManagementComponent implements OnInit {

  message="";
  listaCena:CenaStavke[];
  listaKontrolora:Kontrolor[];
  listaRedovaVoznje:RedVoznje[];

 
  constructor(private tableData:GetDataService, private router:Router) { }

  ngOnInit() {
    this.tableData.message.subscribe(msg => this.message = msg);
  }


  getTable(tableName:string){
    this.tableData.getTableDataService(tableName).subscribe(res =>{ 
      //let info = JSON.parse(JSON.stringify(res));
      if(tableName==="Cene")
      {
        this.listaCena = res;
        this.tableData.izmenaCena(this.listaCena);
      }
      else if(tableName==="Kontrolori")
      {
        //console.log(res);
        let info = JSON.parse(JSON.stringify(res));
        this.listaKontrolora = info;
        this.tableData.izmenaKontrolora(this.listaKontrolora);
      }
      else if(tableName==="RedoviVoznje")
      {
        let info = JSON.parse(JSON.stringify(res));
        this.listaRedovaVoznje = info;
        this.tableData.izmenaRedaVoznje(this.listaRedovaVoznje);
      }
    });
    console.log('admin');
    this.tableData.changeMessage(tableName);
    console.log(this.message);
    }

  onAddClick(table){
    switch(table){
      case 'Cena':
        this.router.navigate(['/CenaStavke'])
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
    }
  }
}
