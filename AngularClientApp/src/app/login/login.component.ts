import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Validators } from '@angular/forms';
import { LoginService } from '../login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  private loginForm : FormGroup;

  constructor(private loginService: LoginService, private fb: FormBuilder) { 
      this.loginForm=this.fb.group({
        email:['',Validators.required],
        pass: ['',Validators.required]
      });
  }

  ngOnInit() {
  }

  Login():void
  {
     console.warn(this.loginForm.valid);
     
     let email=this.loginForm.value.email ;
     let password=this.loginForm.value.pass;
        
     this.loginService.Login(email,password).subscribe();
      
  }
  

}
