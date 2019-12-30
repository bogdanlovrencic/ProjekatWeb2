import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map ,} from 'rxjs/operators';
import { Email } from 'src/app/Email';
import { Korisnik } from './Models/Korisnik';


const httpOptions = {
  headers: new HttpHeaders({ 'Content-type':'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class KupovinaKarteService {
 
  

  constructor(private http:HttpClient) { }

 

  dodajKartu (cenaKarte: any, izabraniTipKarte: any, userEmail: any, email: any): Observable<any>
  {
      return this.http.post<any>(`http://localhost:52295/api/Kartas/kupiKartu?cena=${cenaKarte}&tipKarte=${izabraniTipKarte}&korisnikEmail=${userEmail}&email=${email}`,[cenaKarte,izabraniTipKarte,userEmail,email]);
  }

  getCena(selectedTicketType: string, userType: string):Observable<number> {
      return this.http.get<number>(`http://localhost:52295/api/Kartas/IzracunajCenu?tipKarte=${selectedTicketType}&tipPutnika=${userType}`);
  }

  ValidirajKartu(id: any):Observable<any> {
      return this.http.get<any>('http://localhost:52295/api/Kartas/ValidacijaKarte?id='+id)
  }


 
  
}
