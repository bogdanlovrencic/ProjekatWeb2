import { Component, OnInit } from '@angular/core';
import { Stanica } from '../Models/stanica';

import { AdminService } from '../admin.service';
import { Router } from '@angular/router';
import { Polyline } from '../Models/polyline';
import { GeoLocation } from '../map/model/geolocation';
import { MarkerInfo } from '../map/model/marker-info.model';
import { Linija, LineType } from '../Models/linija';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';

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
  imeLinije:string;
  selektovanaStanica:Stanica;
  izabraniTipLinije:LineType;
  public addLinijaForm:FormGroup
  private validationMessage='';

  constructor(private adminSrv:AdminService, private router:Router) { }
  inputName= false;
  rola = "";

  ngOnInit() {
      this.polyline = new Linija(this.imeLinije, []);
      this.stationIcon = { url:"assets/busicon.png", scaledSize: {width: 50, height: 50}};
      console.log(this.rola)

      this.addLinijaForm = new FormGroup({
        imeLinije:new FormControl(null,[Validators.required]),
        izabraniTipLinije: new FormControl(null,[Validators.required]),    
      
      })
  }

  placeMarker($event){
    this.polyline.addLocation(new Stanica($event.coords.lat, $event.coords.lng))
    console.log(this.polyline)
  
  }

  onSaveClicked(){
    if(!this.addLinijaForm.valid)
    {
      this.validationMessage="Sva polja moraju biti popunjena!";
      return;
    }

    this.polyline.Naziv = this.addLinijaForm.value.imeLinije;
    this.polyline.TipLinije=this.addLinijaForm.value.izabraniTipLinije;

    this.adminSrv.addLinija(this.polyline).subscribe(res=>{
      this.router.navigate(['/management']);
    },(error)=>{ alert("Linija vec postoji!")})

  }

  onStationClicked(stanica){
    this.inputName = true;
    this.selektovanaStanica=stanica;
  
  }

  

}
