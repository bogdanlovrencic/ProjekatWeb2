import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Validators } from '@angular/forms';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
       
  private registrationForm : FormGroup;

  constructor(private fb: FormBuilder) {
    this.registrationForm = this.fb.group({
      firstName:['',Validators.required],
      lastName: [''],
      email: ['',Validators.required],
      password:[''],
      confPassword:[''],
      bithDate:[''],
      address: this.fb.group({           
        city: [''],
        street: [''],         
        zip: ['']
      })
    });
   }

  ngOnInit() {
  }

  onSubmit()
  {
    console.warn(this.registrationForm.valid);
  }

}
