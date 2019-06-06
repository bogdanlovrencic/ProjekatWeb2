import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map ,} from 'rxjs/operators';
import { Email } from 'src/app/Email';
//import { Karta} from 'src/app/karta'

const httpOptions = {
  headers: new HttpHeaders({ 'Content-type':'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class KupovinaKarteService {

    private karteUrl='http://localhost:52295/api/karte/kupi';

  constructor(private http:HttpClient) { }

 

  dodajKartu (email:Email): Observable<string>
  {
      return this.http.post<string>(this.karteUrl, email, httpOptions);
  }

  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      return of(result as T);
    };
  }
  
}
