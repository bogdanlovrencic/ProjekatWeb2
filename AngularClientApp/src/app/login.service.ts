import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';
import { HttpHeaders, HttpClient } from '@angular/common/http';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-type':'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private loginUrl='http://localhost:52295/api/login/Login';

  constructor(private http: HttpClient) { }


  Login(email:string,password:string):Observable<string>
  {
      return this.http.post<string>(this.loginUrl,email+" "+password,httpOptions);
  }
  
}
