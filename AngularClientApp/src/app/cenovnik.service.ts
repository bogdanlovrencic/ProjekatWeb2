import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';


const httpOptions = {
  headers: new HttpHeaders({ 'Content-type':'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class CenovnikService {

  private karteUrl='http://localhost:52295/api/karte/prikaziCenovnik';

  constructor(private http:HttpClient) { }

  PrikaziCene(tipKarte:string, tipPutnika:string): Observable<string>
  {
      return  this.http.post<string>(this.karteUrl,tipKarte+tipPutnika,httpOptions);
  }
}
