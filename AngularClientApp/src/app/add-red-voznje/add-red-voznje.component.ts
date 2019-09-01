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

@Component({
  selector: 'app-add-red-voznje',
  templateUrl: './add-red-voznje.component.html',
  styleUrls: ['./add-red-voznje.component.css']
})
export class AddRedVoznjeComponent implements OnInit {

  Linije: Linija[];
  private addRedVoznjeForm : FormGroup;
  public validationMessage = ''
  public selected=false;
  polasci:Polazak[];


  constructor(private adminService: AdminService,private fb: FormBuilder, private router: Router,private lineService:LineService,private redVoznjeService:RedVoznjeService) { 
      this.addRedVoznjeForm= this.fb.group({
         tipRedaVoznje:[Validators.required],
         tipDana:[Validators.required],
         izabranaLinija:[Validators.required],
         polazak:[]
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

    let redVoznje=new RedVoznjeBindingModel();

    redVoznje.TipRedaVoznje=this.addRedVoznjeForm.controls.tipRedaVoznje.value;
    redVoznje.TipDana=this.addRedVoznjeForm.controls.tipDana.value;
    redVoznje.LinijaId=this.addRedVoznjeForm.controls.izabranaLinija.value;
    // redVoznje.Polasci= this.polasci;


    this.adminService.addRedVoznje(redVoznje).subscribe(res=>{
          this.addRedVoznjeForm.reset();
          this.router.navigate(['/management'])

       }),error=>{console.log(error);}
    
  }

  onSelect()
  {
    let redVoznjeTip = this.addRedVoznjeForm.value.tipRedaVoznje
    this.redVoznjeService.getAllLinesForRedVoznje(redVoznjeTip).subscribe((data:Linija[])=>{
      this.Linije = data
    })
    this.selected = false
  }

  onSelectClicked()
  {
      let polazakRequest: PolazakRequest={
        TipDana:this.addRedVoznjeForm.value.tipDana,
        LinijaId: this.addRedVoznjeForm.value.izabranaLinija
      }

      this.redVoznjeService.getPolasci(polazakRequest).subscribe((data:Polazak[])=>{
        this.polasci = data
      })
    //  this.selected = true
      
  }

}
