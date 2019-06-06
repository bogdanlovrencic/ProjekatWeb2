import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-type':'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class RedVoznjeService {

  private redVoznjeUrl='http://localhost:52295/api/RedVoznje/PrikaziRedVoznje';

  constructor(private http:HttpClient) { }

  Prikazi()
  {
    
  }
}
