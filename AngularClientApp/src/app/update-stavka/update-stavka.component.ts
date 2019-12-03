import { Component, OnInit } from '@angular/core';
import { AdminService } from '../admin.service';
import { Stavka } from '../Models/Stavka';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-update-stavka',
  templateUrl: './update-stavka.component.html',
  styleUrls: ['./update-stavka.component.css']
})
export class UpdateStavkaComponent implements OnInit {

  public Stavka:Stavka
  public  stavkaForm:FormGroup
  public validationMessage=""

  constructor(private adminService:AdminService,private route:ActivatedRoute,private router:Router) { }

  ngOnInit() {

    this.stavkaForm=new FormGroup({
       Naziv:new FormControl(null,[Validators.required]),
       Cena: new FormControl(null,[Validators.required]),
       Aktivna: new FormControl(true,[Validators.required])
      
    })
  

    this.route.queryParams.subscribe((params)=>{
        this.Stavka=JSON.parse(params["stavka"])

        this.stavkaForm.patchValue({
            Naziv:this.Stavka.Naziv,
            Cena:this.Stavka.Cena,
            Aktivna:this.Stavka.Aktivna,
        })
        
    })
  }

  onSubmit()
  {

    if(!this.stavkaForm.valid)
    {
        this.validationMessage="Sva polja moraju biti popunjena!";
        return;
    }

    if(this.stavkaForm.value.Cena <= 0)
    {
        this.validationMessage="Cena ne sme biti manja ili jednaka 0!";
        return;
    }

    let stavka:Stavka={
      Id:this.Stavka.Id,
      Naziv:this.stavkaForm.value.Naziv,
      Cena:this.stavkaForm.value.Cena,
      Aktivna:this.stavkaForm.value.Aktivna
    }

    
    this.adminService.izmeniStavku(stavka).subscribe(
      res=>{
          this.router.navigate(['/management'])
      },error=>{console.log(error)});
  }

}
