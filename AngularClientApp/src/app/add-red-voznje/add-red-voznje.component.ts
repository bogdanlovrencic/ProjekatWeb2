import { Component, OnInit } from '@angular/core';
import { RedVoznjeService } from '../red-voznje.service';
import { Linija } from '../Models/linija';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { RedVoznje } from '../Models/RedVoznje';
import { error } from 'util';
import { AdminService } from '../admin.service';

@Component({
  selector: 'app-add-red-voznje',
  templateUrl: './add-red-voznje.component.html',
  styleUrls: ['./add-red-voznje.component.css']
})
export class AddRedVoznjeComponent implements OnInit {

  Linije: Linija[];
  private addRedVoznjeForm : FormGroup;
  public validationMessage = ''

  constructor(private adminService: AdminService,private fb: FormBuilder, private router: Router) { 
      this.addRedVoznjeForm= this.fb.group({
         tipRedaVoznje:[],
         tipDana:[],
         izabranaLinija:[],
         polazak:['',Validators.required]
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

    redVoznje.TipRedaVoznje=this.addRedVoznjeForm.controls.tipRedaVoznje.value;
    redVoznje.TipDana=this.addRedVoznjeForm.controls.tipDana.value;
    redVoznje.Linija=this.addRedVoznjeForm.controls.izabranaLinija.value;
    redVoznje.Polazak=this.addRedVoznjeForm.controls.polazak.value;


    this.adminService.addRedVoznje(redVoznje).subscribe(res=>{


       }),error=>{console.log(error);}
    
  }

}
