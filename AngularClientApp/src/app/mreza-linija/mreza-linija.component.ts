import { Component, OnInit } from '@angular/core';
import { Linija } from '../Models/linija';
import { Stanica } from '../Models/stanica';
import { DecodeJwtDataService } from '../decode-jwt-data.service';
import { AdminService } from '../admin.service';
import { RedVoznjeService } from '../red-voznje.service';
import { LinijeService } from '../linije.service';

@Component({
  selector: 'app-mreza-linija',
  templateUrl: './mreza-linija.component.html',
  styleUrls: ['./mreza-linija.component.css']
})
export class MrezaLinijaComponent implements OnInit {

  constructor(private linijeService: LinijeService,  private jwt:DecodeJwtDataService, private adminSrv: AdminService) { }
  linija:Linija;
  stationIcon:any;
  linSelected:string;
  rola = "";
  selektovanaStanica : Stanica;
  selektovanaLinija:Linija;
  sveLinije: Linija[];


  ngOnInit() {
    this.linija = new Linija(null, []);
    this.stationIcon = { url:"assets/busicon.png", scaledSize: {width: 50, height: 50}};
    this.linijeService.GetLinije().subscribe(res => {
      this.sveLinije = res;    
    }); 
    this.rola = this.jwt.getRoleFromToken();
  }  

  onClickPrikazi(naziv)
  {
    this.linijeService.getLinija(naziv).subscribe(res => {
        console.log(res);
        this.linija = new Linija(res.Naziv, res.Stanice);
       
    },
    error=>{console.log(error)}
    )
  }

  OnDeleteClicked(){
    if(this.selektovanaStanica != null){
      this.adminSrv.removeStanica(this.selektovanaStanica).subscribe(res => {},(error)=>{ alert("Stanica ne postoji!")});
    }
      

    if(this.selektovanaLinija != null){
      this.adminSrv.removeLinija(this.selektovanaLinija).subscribe(res=>{});
    }
      
  }

  onStationClicked(stanica){
    this.selektovanaStanica=stanica;
  }

  onLineClick(linija){
    this.selektovanaLinija = linija;
    console.log(this.selektovanaLinija);
  }

}
