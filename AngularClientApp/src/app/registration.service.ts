import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Korisnik } from './Korisnik';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-type':'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class RegistrationService {

  private registerUrl='http://localhost:52295/api/registracija/registrujSe';

  constructor(private http: HttpClient) { }

  RegisterUser(korisnik: Korisnik)
  {
      return this.http.post<Korisnik>(this.registerUrl,korisnik,httpOptions);
  }
}

