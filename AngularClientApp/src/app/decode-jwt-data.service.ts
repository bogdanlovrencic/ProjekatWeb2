import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DecodeJwtDataService {

  constructor() { }

  getRoleFromToken():string
  {
      let jwt=localStorage.getItem('token');
      let role="";

      if(jwt != null)
      {
          let jwtData=jwt.split('.')[1];
          let decodedJwtJsonData=window.atob(jwtData);
          let decodedJwtData= JSON.parse(decodedJwtJsonData);

          role=decodedJwtData.role;
      }

      return role;
  }

  getEmailFromToken():string
  {
      let jwt=localStorage.getItem('token');
      let email="";

      if(jwt != null)
      {
          let jwtData=jwt.split('.')[1];
          let decodedJwtJsonData=window.atob(jwtData);
          let decodedJwtData= JSON.parse(decodedJwtJsonData);

          email=decodedJwtData.unique_name;
      }

      return email;
  }
}


