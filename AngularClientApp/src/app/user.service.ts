import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { NgForm } from '@angular/forms';
import { Korisnik } from './Models/Korisnik';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  
 
  constructor(private http:HttpClient) { }

  private url='http://localhost:52295/api/Korisniks?id=';
  private urlSaveChanges='http://localhost:52295/api/Korisniks?id=';
  private uploadImageUrl='http://localhost:52295/api/account/UploadImage?email=';
  private changePassUrl='http://localhost:52295/api/Account/ChangePassword?id=';

  getUserData(email:string):Observable<Korisnik>
  {
      return this.http.get<Korisnik>(this.url+email);
  }

  saveUserChanges(user:Korisnik):any
  {
      return this.http.put(this.urlSaveChanges+user.Email,user);
  }

  UploadImage(email: string, imageData: FormData):any {
    return this.http.post(this.uploadImageUrl+email,imageData);
  }

  changePassword(data: NgForm):any {
      return this.http.post(this.changePassUrl+data.value.Email,data.value);
  }

}
