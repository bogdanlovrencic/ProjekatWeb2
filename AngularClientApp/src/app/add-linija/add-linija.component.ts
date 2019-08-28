import { Component, OnInit } from '@angular/core';
import { Stanica } from '../Models/stanica';
import { Linija } from '../Models/linija';
import { AdminService } from '../admin.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-linija',
  templateUrl: './add-linija.component.html',
  styleUrls: ['./add-linija.component.css']
})
export class AddLinijaComponent implements OnInit {

  markerInfo: Stanica;
  public polyline: Linija;
  public zoom: number;
  stationIcon:any;
  imeLinije;
  selektovanaStanica:Stanica;

  constructor(private adminService:AdminService, private router:Router) { }
  inputName= false;
  rola = "";

  ngOnInit() {
      this.polyline = new Linija(null, []);
      this.stationIcon = { url:"assets/busicon.png", scaledSize: {width: 50, height: 50}};
      console.log(this.rola)
  }

  placeMarker($event){
    this.polyline.addLocation(new Stanica($event.coords.lat , $event.coords.lng))
    console.log(this.polyline)
  }

  onSaveClicked(){
    this.polyline.RedniBroj = this.imeLinije;
    this.adminService.addLinija(this.polyline).subscribe(res=>{
      this.router.navigate(['/management'])
    },error=>{console.log(error)})
  }

  onStationClicked(stanica){
    this.inputName = true;
    this.selektovanaStanica=stanica;
  }

}
