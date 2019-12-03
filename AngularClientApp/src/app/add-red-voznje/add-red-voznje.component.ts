import { Component, OnInit } from '@angular/core';
import { RedVoznjeService } from '../red-voznje.service';
import { Linija } from '../Models/linija';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { error } from 'util';
import { AdminService } from '../admin.service';
import { LineService } from '../line.service';
import { Polazak, PolazakRequest } from '../Models/polazak';
import { RedVoznje } from '../Models/RedVoznje';
import { RedVoznjeBindingModel } from '../Models/RedVoznjeBindingModel';
import { $ } from 'protractor';
import { runInThisContext } from 'vm';

@Component({
  selector: 'app-add-red-voznje',
  templateUrl: './add-red-voznje.component.html',
  styleUrls: ['./add-red-voznje.component.css']
})
export class AddRedVoznjeComponent implements OnInit {

  Linije: Linija[];
  private addRedVoznjeForm : FormGroup;
  public validationMessage = ''
  polasci:Polazak[];
  public selectedRedVoznje:string


  constructor(private adminService: AdminService,private fb: FormBuilder, private router: Router,private lineService:LineService,private redVoznjeService:RedVoznjeService) { 
      this.addRedVoznjeForm= this.fb.group({
         tipRedaVoznje:[Validators.required],
         tipDana:[Validators.required],
         izabranaLinija:[Validators.required],
         polasci:[]
      })

  }

  ngOnInit() {
   
  }

  onSubmit()
  {
    this.validationMessage='';

    if(!this.addRedVoznjeForm.valid)
    {
        this.validationMessage="Sva polja moraju biti popunjena!";
        return;
    }

    let redVoznje=new RedVoznje();

    redVoznje.IzabraniRedVoznje=this.addRedVoznjeForm.controls.tipRedaVoznje.value;
    redVoznje.IzabranTipDana=this.addRedVoznjeForm.controls.tipDana.value;
    redVoznje.LinijaId=this.addRedVoznjeForm.controls.izabranaLinija.value;
    redVoznje.Polasci= this.addRedVoznjeForm.controls.polasci.value;


    this.adminService.addRedVoznje(redVoznje).subscribe(res=>{
          this.addRedVoznjeForm.reset();
          this.router.navigate(['/management'])

       }),error=>{console.log(error);}
    
  }



  onChange(event)
  {
    let redVoznjeTip:number;
     
    this.selectedRedVoznje=event.target.value
   
    if(this.selectedRedVoznje == 'Gradski')
       redVoznjeTip=0
    
    else
      redVoznjeTip=1

    this.redVoznjeService.getAllLinesForRedVoznje(redVoznjeTip).subscribe((data:Linija[])=>{
      this.Linije = data
   })
  }

  
}
