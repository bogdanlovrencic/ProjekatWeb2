import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';

import { catchError } from 'rxjs/operators';
import { Linija } from './Models/linija';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-type':'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class RedVoznjeService {

  //private redVoznjeUrl='http://localhost:52295/api/RedVoznje/PrikaziRedVoznje';

  private linijeUrl='http://localhost:52295/api/RedVoznje/ucitajLinije';
  
  constructor(private http:HttpClient) { }

  PrikaziRedVoznje()
  {
      //return this.http.get<Linija[]>().subscribe();
  }

  GetLinije():Observable<Linija[]>
  {
      return this.http.get<Linija[]>(this.linijeUrl) .pipe(
        catchError(this.handleError<Linija[]>('GetLinije', []))
      );
  }
 
  
  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      return of(result as T);
    };
  }
}
