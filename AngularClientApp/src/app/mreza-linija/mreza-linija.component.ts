import { Component, OnInit } from '@angular/core';
import { Linija } from '../Models/linija';
import { Stanica } from '../Models/stanica';
import { DecodeJwtDataService } from '../decode-jwt-data.service';
import { AdminService } from '../admin.service';
import { RedVoznjeService } from '../red-voznje.service';
import { LinijeService } from '../linije.service';
import { Router, NavigationExtras } from '@angular/router';
import { componentRefresh, refreshDescendantViews } from '@angular/core/src/render3/instructions';

@Component({
  selector: 'app-mreza-linija',
  templateUrl: './mreza-linija.component.html',
  styleUrls: ['./mreza-linija.component.css']
})
export class MrezaLinijaComponent implements OnInit {

  constructor(private linijeService: LinijeService,  private jwt:DecodeJwtDataService, private adminSrv: AdminService,private router:Router) { }
  linija:Linija;
  stationIcon:any;
  linSelected:number;
  rola = "";
  selektovanaStanica : Stanica;
  selektovanaLinija:Linija;
  sveLinije: Linija[];
  buttonDisabled: boolean
  buttonPrikaziDisabled:boolean


  ngOnInit() {
    this.linija = new Linija(null, []);
    this.stationIcon = { url:"assets/busicon.png", scaledSize: {width: 50, height: 50}};
    this.linijeService.GetLinije().subscribe(res => {
      this.sveLinije = res;    
    }); 
    this.rola = this.jwt.getRoleFromToken();
  
  }  

  onClickPrikazi(naziv:string)
  {
  
    this.linijeService.getLinija(naziv).subscribe(res => {
        console.log(res);
        this.linija = new Linija(res.Naziv, res.Stanice);
       
    },
    error=>{console.log(error)}
    )
  }

  onUpdateLinijaClicked(naziv)
  {

    this.linijeService.getLinija(naziv).subscribe(res => {
      console.log(res);
      this.linija = res; 

      let navigationExtras:NavigationExtras={
        queryParams:{
          "linija": JSON.stringify(this.linija)
        }
      }

      this.router.navigate(['LinijaIzmena/linija'],navigationExtras)
    },
      error=>{console.log(error)})    
  }

  OnDeleteClicked(){
    if(this.selektovanaStanica != null){
      this.adminSrv.removeStanica(this.selektovanaStanica).subscribe(res => {
        console.log("Data: ");
        console.log(res);
        if(res == 200){
          this.router.navigate(['/management']);
        }
        else{
          window.alert("Drugi admin je vec obrisao  stanicu sa  linije, molimo Vas da refresujete stranicu!");
        }
      },
      (error)=>{ alert("Stanica ne postoji!")});
    }
      

    if(this.selektovanaLinija != null){
      this.adminSrv.removeLinija(this.selektovanaLinija).subscribe(res=>{
        console.log("Data: ");
        console.log(res);
        if(res == 200){
          this.router.navigate(['/management']);
        }
        else{
          window.alert("Drugi admin je vec obrisao ovu liniju, molimo Vas da refresujete stranicu!");
        }
        }),
        (error)=>{console.log(error)}
    }
      
  }

  onStationClicked(stanica){
    this.selektovanaStanica=stanica;
  }

  onLineClick(linija){
    this.selektovanaLinija = linija;
    console.log(this.selektovanaLinija);
  }

  onChange(event){
    this.buttonDisabled = true
    this.buttonPrikaziDisabled=true
  }

}
