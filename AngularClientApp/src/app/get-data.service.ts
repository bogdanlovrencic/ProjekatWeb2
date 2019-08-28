import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { CenaStavke } from './Models/cenaStavke';
import { Linija } from './Models/linija';
import { RedVoznje } from './Models/RedVoznje';
import { Kontrolor } from './Models/Kontrolor';
import { Stanica } from './Models/stanica';

@Injectable({
  providedIn: 'root'
})
export class GetDataService {

  constructor(private http:HttpClient) { }

  private messageSource = new BehaviorSubject("default");
  message = this.messageSource.asObservable();

  private pricesSource = new BehaviorSubject(null);
  prices = this.pricesSource.asObservable();

  private controllerSource = new BehaviorSubject(null);
  controller = this.controllerSource.asObservable();

  private timetableSource = new BehaviorSubject(null);
  timetable = this.timetableSource.asObservable();

  izmenaCena(cene:CenaStavke[])
  {
    this.pricesSource.next(cene);
  }

  izmenaKontrolora(kontrolori:Kontrolor[])
  {
    this.controllerSource.next(kontrolori);
  }

  izmenaRedaVoznje(redoviVoznje:RedVoznje[])
  {
    this.timetableSource.next(redoviVoznje);
  }

  changeMessage(msg:string){
    this.messageSource.next(msg);
  }

  obrisiCenu(id){
    return this.http.delete('http://localhost:52295/api/CenaStavkes?id='+id);
  }

  obrisiKontrolora(email){
    return this.http.delete('http://localhost:52295/api/Korisniks?id='+email);
  }

  obrisiRedVoznje(id){
    return this.http.delete('http://localhost:52295/api/RedVoznjes?id='+id);
  }

  getTableDataService(tableName:string):Observable<any>{

    if(tableName === 'Cena'){
      return this.http.get<CenaStavke>('http://localhost:52295/api/CenaStavkes')
    }
    else if(tableName === 'Linija'){
      return this.http.get<Linija>('http://localhost:52295/api/Linijas')

    }
    else if(tableName === 'Stanica'){
      return this.http.get<Stanica>('http://localhost:52295/api/Stanicas')
    }
    else if(tableName === 'RedVoznje'){
      return this.http.get<RedVoznje>('http://localhost:52295/RedVoznjes/AllRedoviVoznje')

    }
    else if(tableName === 'Kontrolor'){
      return this.http.get<Kontrolor>('http://localhost:52295/api/Korisniks')

    }
  }
}
