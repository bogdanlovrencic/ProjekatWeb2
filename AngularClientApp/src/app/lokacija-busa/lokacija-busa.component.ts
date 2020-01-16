import { Component, OnInit, ViewChild, NgZone } from '@angular/core';
import { AgmMap } from '@agm/core';
import { MarkerInfo } from '../map/model/marker-info.model';

import { GeoLocation } from '../Models/geolocation';

import { Stanica } from '../Models/stanica';

import { Linija } from '../Models/linija';
import { Polyline } from '../Models/polyline';
import { LokacijaBusaService } from '../lokacija-busa.service';
import { LinijeService } from '../linije.service';

@Component({
  selector: 'app-lokacija-busa',
  templateUrl: './lokacija-busa.component.html',
  styleUrls: ['./lokacija-busa.component.css']
})
export class LokacijaBusaComponent implements OnInit {
  
  

  constructor( private locationService: LokacijaBusaService, private linijaService: LinijeService) { }

  @ViewChild('AgmMap') agmMap: AgmMap;  
  
  tempNiz: any[] = [];
  lineStationsIds: any[] = [];
  lineStations: Stanica[] = [];
  lines: Linija[] = [];
  stations: Stanica[] = [];
  markerInfo: MarkerInfo;
  selLine: Polyline;
  selLineBus: Polyline;
  iconPath: any = { url:"assets/busicon.png", scaledSize: {width: 35, height: 35}};
  iconPathBus: any = { url:"assets/bus2.jpg", scaledSize: {width: 25, height: 25}};
  selectedLineId: any ;
  i: number;
  j: number;
  initBool: boolean = true;
  BusX: number;
  BusY: number;
  mapZoom = 14;
  isConnected: Boolean;

  ngOnInit() {
    // this.markerInfo = new MarkerInfo(new GeoLocation(45.232268, 19.842954),
    // "assets/busIcon.png",
    // "Jugodrvo", "", "http://ftn.uns.ac.rs/691618389/fakultet-tehnickih-nauka");
    this.selLine = new Polyline([], 'red', { url:"assets/busicon.png", scaledSize: {width: 50, height: 50}});
    this.selLineBus = new Polyline([], 'red', { url:"assets/bus2.jpg", scaledSize: {width: 60, height: 60}});
    
    
    this.checkConnection();
    this.registerForHello();  
    this.getLines();
  }

  private checkConnection(){
    this.locationService.startConnection().subscribe(
      e =>{
        this.isConnected = e;
      }
    );
  }

  private registerForHello(){
    this.locationService.registerForHello().subscribe(
      data=>{
        this.BusX = data[0];
        this.BusY = data[1];
        
        this.selLineBus = new Polyline([], 'red', { url:"assets/bus2.jpg", scaledSize: {width: 60, height: 60}});
        this.selLineBus.addLocation(new GeoLocation(this.BusX, this.BusY));
        
      }
    );
  }

  private hello(){
    this.locationService.hello(this.lineStations);
  }

  getLines(){
    this.linijaService.GetLinije().subscribe(
      response => {
        this.lines = response;
      });
    }

  getStations(){
    this.selLine = new Polyline([], 'red', { url:"assets/busicon.png", scaledSize: {width: 50, height: 50}});
    this.linijaService.GetLinije().subscribe(
      data=>{
            this.lines = data;
            for(this.i = 0; this.i < this.lines.length; this.i++){
              for(this.j = 0; this.j < this.lines[this.i].Stanice.length; this.j++){
                if(this.lines[this.i].Id == this.selectedLineId){
                  this.lineStations.push(this.lines[this.i].Stanice[this.j]);
                  this.selLine.addLocation(new GeoLocation(this.lines[this.i].Stanice[this.j].Lat,this.lines[this.i].Stanice[this.j].Lon));
                }
              }
            }
            console.log(this.lineStations.length);
            
            this.locationService.hello(this.lineStations);
          }
        );
  }
 
  
      
  onSelectLine(event: any){
    this.selectedLineId = event.target.value;
    this.lineStations = [];
    this.getStations();
    
  }

  temp(event: any){
    console.log(event);

  }

 

}
