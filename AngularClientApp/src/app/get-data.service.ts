import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { CenaStavke } from './Models/cenaStavke';
import { Linija } from './Models/linija';
import { RedVoznje } from './Models/RedVoznje';
import { Kontrolor } from './Models/Kontrolor';
import { Stanica } from './Models/stanica';
import { Cenovnik } from './Models/Cenovnik';
import { Stavka } from './Models/Stavka';

@Injectable({
  providedIn: 'root'
})
export class GetDataService {

  constructor(private http:HttpClient) { }

  private messageSource = new BehaviorSubject("default");
  message = this.messageSource.asObservable();

  private pricesSource = new BehaviorSubject(null);
  prices = this.pricesSource.asObservable();

  private stavkaSource=new BehaviorSubject(null);
  stavka=this.messageSource.asObservable();

  private controllerSource = new BehaviorSubject(null);
  controller = this.controllerSource.asObservable();

  private timetableSource = new BehaviorSubject(null);
  timetable = this.timetableSource.asObservable();

  izmenaCena(cene:CenaStavke[])
  {
    this.pricesSource.next(cene);
  }

  updateStavka(stavke:Stavka[])
  {
    this.stavkaSource.next(stavke);
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

    if(tableName === 'Cenovnici'){
      return this.http.get<Cenovnik>('http://localhost:52295/api/Cenovniks')
    }
    else if( tableName === 'Stavke')
    {
      return this.http.get<Stavka>('http://localhost://52295/api/Stavkas')
    }
    else if(tableName === 'Linije'){
      return this.http.get<Linija>('http://localhost:52295/api/Linijas')

    }
    else if(tableName === 'Stanica'){
      return this.http.get<Stanica>('http://localhost:52295/api/Stanicas')
    }
    else if(tableName === 'RedoviVoznje'){
      return this.http.get<RedVoznje>('http://localhost:52295/RedVoznjes/AllRedoviVoznje')

    }
    else if(tableName === 'Kontrolori'){
      return this.http.get<Kontrolor>('http://localhost:52295/api/Korisniks')

    }
  }
}
