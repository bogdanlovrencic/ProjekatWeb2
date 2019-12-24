import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Validators } from '@angular/forms';
import { LoginService } from '../login.service';
import { Router } from '@angular/router';
import { DecodeJwtDataService } from '../decode-jwt-data.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  private loginForm : FormGroup;
  

  constructor(private loginService: LoginService, private fb: FormBuilder,private router:Router,private decodeService:DecodeJwtDataService) { 
      this.loginForm=this.fb.group({
        username:['',Validators.required],
        pass: ['',Validators.required]
      });
  }

  ngOnInit() {
  }

  Login():void
  {
     console.warn(this.loginForm.valid);
     
     let username=this.loginForm.value.username ;
     let password=this.loginForm.value.pass;
     let rola=""
        
     this.loginService.Login(username,password).subscribe(
      res=>{
        var accessToken=res.access_token;
        localStorage.setItem('token',accessToken);
        rola=this.decodeService.getRoleFromToken()
      
       if(rola == 'Admin' || rola == 'Controller')
       {
          this.router.navigate(['/profil']);
       }
       else{
         this.router.navigate(['/redVoznje']);
       }
          

      },
        (err) =>{
            alert("Doslo je do greske pri logovanju. Pokusajte ponovo.")
        }
     );
  }
  

}
