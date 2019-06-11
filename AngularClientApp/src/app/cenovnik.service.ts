import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { Cenovnik } from './cenovnik';
import { catchError } from 'rxjs/operators';


const httpOptions = {
  headers: new HttpHeaders({ 'Content-type':'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class CenovnikService {

  private ceneUrl='http://localhost:52295/api/cenovnik/prikaziCene';

  constructor(private http:HttpClient) { }

  PrikaziCene(): Observable<Cenovnik[]>
  {   
      return this.http.get<Cenovnik[]>(this.ceneUrl).pipe(
        catchError(this.handleError<Cenovnik[]>('PrikaziCene', [])));

     
  }

  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      return of(result as T);
    };
  }
}
