import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaderResponse } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { CenaStavke } from './Models/cenaStavke';
import { Linija } from './Models/linija';
import { RedVoznjeBindingModel } from './Models/RedVoznjeBindingModel';
import { Kontrolor } from './Models/Kontrolor';
import { Stanica } from './Models/stanica';
import { Cenovnik, CenovnikPrikaz } from './Models/Cenovnik';
import { Stavka } from './Models/Stavka';
import { RedVoznje } from './Models/RedVoznje';
import { Polazak, PolazakModel } from './Models/polazak';
import { CenovnikStavka } from './Models/CenovnikStavka';

@Injectable({
  providedIn: 'root'
})
export class GetDataService {
  changeLinije(listaLinija: Linija[]) {
    return;
  }
 

  constructor(private http:HttpClient) { }

  private messageSource = new BehaviorSubject("default");
  message = this.messageSource.asObservable();

  private cenovnikSource = new BehaviorSubject(null);
  cenovnici = this.cenovnikSource.asObservable();

  private stavkaSource=new BehaviorSubject(null);
  stavke=this.stavkaSource.asObservable();

  private kontrolorSource = new BehaviorSubject(null);
  kontrolori = this.kontrolorSource.asObservable();

  private timetableSource = new BehaviorSubject(null);
  timetable = this.timetableSource.asObservable();

  private polazakSource = new BehaviorSubject(null);
  polasci = this.polazakSource.asObservable();

  changeCenovnici(cenovnici:CenovnikPrikaz[])
  {
     this.cenovnikSource.next(cenovnici);
  }

  changeStavke(stavke: Stavka[])
  {
    this.stavkaSource.next(stavke);
  }

  changeKontrolori(kontrolori:Kontrolor[])
  {
    this.kontrolorSource.next(kontrolori);
  }

  changePolasci(polasci:PolazakModel[])
  {
    this.polazakSource.next(polasci);
  }

  changeRedoviVoznje(redoviVoznje:RedVoznje[])
  {
    this.timetableSource.next(redoviVoznje);
  }

  changeMessage(msg:string){
    this.messageSource.next(msg);
  }

  //IZMENA

  

  //BRISANJE

  obrisiCenovnik(id:number){
    return this.http.get<any>('http://localhost:52295/api/Cenovniks/ObrisiCenovnik?id='+id);
  }

  obrisiStavku(id: number) {
    return this.http.get<any>('http://localhost:52295/api/Stavkas/ObrisiStavku?id='+id);
  }

  obrisiKontrolora(email:string){
    return this.http.get<any>('http://localhost:52295/api/Korisniks/ObrisiKontrolora?id='+email);
  }

  obrisiPolazak(id: number) {
    return this.http.get<any>('http://localhost:52295/api/Polazaks/ObrisiPolazak?id='+id);
  }

  obrisiRedVoznje(id:number){
    return this.http.get<any>('http://localhost:52295/api/RedVoznjes/ObrisiRedVoznje?id='+id);
  }
//


  getTableDataService(tableName:string):Observable<any>{

    if(tableName === 'Cenovnici'){
      return this.http.get<CenovnikPrikaz>('http://localhost:52295/api/Cenovniks/Cenovnici');
    }
    else if( tableName === 'Stavke')
    {
      return this.http.get<Stavka>('http://localhost:52295/api/Stavkas');
    }
    else if(tableName === 'Linije'){
      return this.http.get<Linija>('http://localhost:52295/api/Linijas');

    }
    else if(tableName === 'Stanica'){
      return this.http.get<Stanica>('http://localhost:52295/api/Stanicas');
    }

    else if(tableName === 'RedoviVoznje'){
      return this.http.get<RedVoznje>('http://localhost:52295/api/RedVoznjes');
    }
    else if(tableName === 'Kontrolori'){
      return this.http.get<Kontrolor>('http://localhost:52295/api/Korisniks');
    }

    else if(tableName == 'Polasci')
    {
      return this.http.get<PolazakModel>('http://localhost:52295/api/Polazaks');
    }
  }

  // refreshCenovnikList(){
  //   this.http.get('http://localhost:52295/api/Cenovniks').subscribe(
  //     (data: CenovnikPrikaz[])=> { this.priceListChanged.next(data);}
  //   )
  // }
}
