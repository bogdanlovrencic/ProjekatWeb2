import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { Linija } from './Models/linija';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

   public cenaStavkeUrl='http://localhost:52295/api/CenaStavkes';
   public linijaUrl='http://localhost:52295/api/Linijas';

  constructor(private http:HttpClient) { }


  addCenaStavke(data:NgForm):any
  {
      this.http.post(this.cenaStavkeUrl,data.value)
  }

  addLinija(linija:Linija)
  {
    return this.http.post(this.linijaUrl, linija);
  }
}
