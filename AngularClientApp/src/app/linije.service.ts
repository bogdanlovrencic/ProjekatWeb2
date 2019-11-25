import { Injectable } from '@angular/core';

import { Observable, of } from 'rxjs';
import { Linija } from './Models/linija';
import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class LinijeService {


  constructor(private http:HttpClient) { }

  private linijeUrl='http://localhost:52295/api/Linijas';

  getLinija(naziv: string):Observable<Linija> {
    return this.http.get<Linija>('http://localhost:52295/api/Linijas?naziv='+naziv);
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
