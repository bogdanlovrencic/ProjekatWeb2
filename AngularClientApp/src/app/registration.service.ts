import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs';
import { Korisnik } from './Models/Korisnik';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-type':'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class RegistrationService {

  private registerUrl='http://localhost:52295/api/account/register';

  private uploadImageUrl='http://localhost:52295/api/account/UploadImage?email=';

  constructor(private http: HttpClient) { }

  RegisterUser(korisnik: Korisnik): Observable<any>
  {
      return this.http.post(this.registerUrl,korisnik);
  }

  UploadImage(email:string,data:FormData)
  {
     return this.http.post(this.uploadImageUrl+email,data).subscribe((val)=>
     {
       console.log(val);
     });
  }
}

