import { Injectable } from '@angular/core';

import { Stavka } from './Models/Stavka';
import { Subject } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class StavkaService {

  private priceLsitItems = new Subject<Stavka[]>()
  private HourItemChanged = new  Subject<Stavka[]>()
  private DayItemChanged = new  Subject<Stavka[]>()
  private MothItemChanged = new  Subject<Stavka[]>()
  private YearItemChanged = new  Subject<Stavka[]>()
  constructor(private http:HttpClient) { }


  subscribeToHourItemsChanged():Subject<Stavka[]>{
    this.refreshHourItems()
    return this.HourItemChanged;
  }
  subscribeToDayItemsChanged():Subject<Stavka[]>{
    this.refreshDayItems()
    return this.DayItemChanged;
  }
  subscribeToMonthItemsChanged():Subject<Stavka[]>{
    this.refreshMonthItems()
    return this.MothItemChanged;
  }
  subscribeToYeartemsChanged():Subject<Stavka[]>{
    this.refreshYearItems()
    return this.YearItemChanged;
  }
  refreshHourItems(){
    this.http.get('http://localhost:52295/api/Stavkas/Stavke?naziv='+'Vremenska karta').subscribe((data:Stavka[])=>{this.HourItemChanged.next(data)})    
  }
  refreshDayItems(){
    this.http.get('http://localhost:52295/api/Stavkas/Stavke?naziv='+'Dnevna karta').subscribe((data:Stavka[])=>{this.DayItemChanged.next(data)})    
  }
  refreshMonthItems(){
    this.http.get('http://localhost:52295/api/Stavkas/Stavke?naziv='+'Mesecna karta').subscribe((data:Stavka[])=>{this.MothItemChanged.next(data)})    
  }
  refreshYearItems(){
    this.http.get('http://localhost:52295/api/Stavkas/Stavke?naziv='+'Godisnja karta').subscribe((data:Stavka[])=>{this.YearItemChanged.next(data)})    
  }
}
