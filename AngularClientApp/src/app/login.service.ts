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

  private loginUrl='http://localhost:52295/oauth/token';

  constructor(private http: HttpClient) { }


  Login(username:string,password:string):Observable<any>
  {    
      var data="username="+username+"&password="+password+"&grant_type=password";    
      return this.http.post(this.loginUrl,data);
  }
  
}
