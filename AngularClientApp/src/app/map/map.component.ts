import { Component, OnInit,Input,NgZone } from '@angular/core';
import { MarkerInfo } from './model/marker-info.model';
import { GeoLocation } from './model/geolocation';
import { Polyline } from './model/polyline';


@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css'],
  styles: ['agm-map {height: 500px; width: 700px;}']
})
export class MapComponent implements OnInit {

  markerInfo: MarkerInfo;
  public polyline: Polyline;
  public zoom: number;

  ngOnInit() {
    this.markerInfo = new MarkerInfo(new GeoLocation(45.264249, 19.82856), 
      "assets/MAS.png",
      "Međumesna autobuska stanica" , "" , "http://www.gspns.co.rs/");

      this.polyline = new Polyline([], 'blue', { url:"assets/busicon.png", scaledSize: {width: 50, height: 50}});
  }

  constructor(private ngZone: NgZone){
  }

  placeMarker($event){
    this.polyline.addLocation(new GeoLocation($event.coords.lat, $event.coords.lng))
    console.log(this.polyline)
  }

}
