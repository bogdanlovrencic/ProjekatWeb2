import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map ,} from 'rxjs/operators';
import { Email } from 'src/app/Email';


const httpOptions = {
  headers: new HttpHeaders({ 'Content-type':'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class KupovinaKarteService {

    private karteUrl='http://localhost:52295/api/Kartas/kupiKartu';

  constructor(private http:HttpClient) { }

 

  dodajKartu (email:string): Observable<string>
  {
      return this.http.post<string>(this.karteUrl, email);
  }

  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      return of(result as T);
    };
  }
  
}
