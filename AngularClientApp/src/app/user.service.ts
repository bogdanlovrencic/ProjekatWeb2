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

  private getUserUrl='http://localhost:52295/api/Account/GetUser?email=';
  private urlSaveChanges='http://localhost:52295/api/Account/IzmeniKorisnika';
  private uploadImageUrl='http://localhost:52295/api/Account/UploadImage';
  private changePassUrl='http://localhost:52295/api/Account/ChangePassword';

  getUserData(email:string):Observable<Korisnik>
  {
      return this.http.get<Korisnik>(this.getUserUrl+email);
  }

  saveUserChanges(user:Korisnik):any
  {
      return this.http.post(this.urlSaveChanges,user);
  }

  UploadImage(imageData: FormData):any {
    return this.http.post(this.uploadImageUrl,imageData);
  }

  changePassword(data: NgForm):any {
      return this.http.post(this.changePassUrl,data.value);
  }

  downloadImage(email: string):Observable<any[]> 
  {
    return this.http.get<any[]>('http://localhost:52295/api/Account/DownloadImage?email='+email)
  }
  getKorisniciZaValidaciju():Observable<Korisnik[]> 
  {
    return this.http.get<Korisnik[]>('http://localhost:52295/api/Account/GetNevalidiraniKorisnici')
  }

}
