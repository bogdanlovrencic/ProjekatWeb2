import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class KontrolorService {

  constructor(private http:HttpClient) { }

  verifikujKorisnika(email: any, valid: boolean):Observable<any> {
      return this.http.post<any>(`http://localhost:52295/api/Account/VerifkujKorisnika?email=${email}&validan=${valid}`,[email,valid])
  }
}
