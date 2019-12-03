import { Component, OnInit } from '@angular/core';
import { Linija } from '../Models/linija';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Polazak, PolazakRequest } from '../Models/polazak';
import { AdminService } from '../admin.service';
import { Router } from '@angular/router';
import { LineService } from '../line.service';
import { RedVoznjeService } from '../red-voznje.service';
import { RedVoznjeBindingModel } from '../Models/RedVoznjeBindingModel';

@Component({
  selector: 'app-update-red-voznje',
  templateUrl: './update-red-voznje.component.html',
  styleUrls: ['./update-red-voznje.component.css']
})
export class UpdateRedVoznjeComponent implements OnInit {

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

    // this.adminService.izmeniRedVoznje(redVoznje).subscribe(res=>{

    // },error=>{console.log(error)});

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
