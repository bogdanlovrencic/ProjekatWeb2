import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  private loginForm : FormGroup;

  constructor(private fb: FormBuilder) { 
      this.loginForm=this.fb.group({
        email:['',Validators.required],
        pass: ['',Validators.required]
      });
  }

  ngOnInit() {
  }

  onSubmit()
  {
    console.warn(this.loginForm.valid);
  }
  

}
