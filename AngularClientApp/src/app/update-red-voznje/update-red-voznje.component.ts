import { Component, OnInit } from '@angular/core';
import { Linija } from '../Models/linija';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Polazak, PolazakRequest } from '../Models/polazak';
import { AdminService } from '../admin.service';
import { Router, ActivatedRoute } from '@angular/router';
import { LineService } from '../line.service';
import { RedVoznjeService } from '../red-voznje.service';
import { RedVoznjeBindingModel } from '../Models/RedVoznjeBindingModel';
import { RedVoznje } from '../Models/RedVoznje';

@Component({
  selector: 'app-update-red-voznje',
  templateUrl: './update-red-voznje.component.html',
  styleUrls: ['./update-red-voznje.component.css']
})
export class UpdateRedVoznjeComponent implements OnInit {

  Linije: Linija[];
  private editRedVoznjeForm : FormGroup;
  public validationMessage = ''
  public selected=false;
  public RedVoznje:RedVoznje
  public selectedRedVoznje:string


  constructor(private adminService: AdminService,private fb: FormBuilder, private router: Router,private lineService:LineService,private redVoznjeService:RedVoznjeService,private route:ActivatedRoute) { 
      this.editRedVoznjeForm= this.fb.group({
         tipRedaVoznje:[Validators.required],
         tipDana:[Validators.required],
         izabranaLinija:[Validators.required],
         polasci:[]
      })

  }

  ngOnInit() {
    this.route.queryParams.subscribe((params)=>{
       this.RedVoznje=JSON.parse(params["redVoznje"])

     
       this.editRedVoznjeForm.patchValue({
         tipRedaVoznje:this.RedVoznje.IzabraniRedVoznje,
         tipDana:this.RedVoznje.IzabranTipDana,
         izabranaLinija:this.RedVoznje.LinijaId,
         polasci:this.RedVoznje.Polasci
       })
    })

    let redVoznjeTip;
    if(this.editRedVoznjeForm.value.tipRedaVoznje == 'Gradski')
    {
        redVoznjeTip=0
    }
    else
    {
        redVoznjeTip=1
    }
    this.redVoznjeService.getAllLinesForRedVoznje(redVoznjeTip).subscribe((data:Linija[])=>{
      this.Linije = data
    })
    this.selected = false

  }

  onSubmit()
  {
    this.validationMessage='';

    if(!this.editRedVoznjeForm.valid)
    {
        this.validationMessage="Sva polja moraju biti popunjena!";
        return;
    }

    let redVoznje=new RedVoznje();

    redVoznje.Id=this.RedVoznje.Id;
    redVoznje.IzabraniRedVoznje=this.editRedVoznjeForm.controls.tipRedaVoznje.value;
    redVoznje.IzabranTipDana=this.editRedVoznjeForm.controls.tipDana.value;
    redVoznje.LinijaId=this.editRedVoznjeForm.controls.izabranaLinija.value;
    redVoznje.Polasci= this.editRedVoznjeForm.controls.polasci.value;
    redVoznje.Aktivan=this.RedVoznje.Aktivan
    redVoznje.Version=this.RedVoznje.Version
  
    this.adminService.izmeniRedVoznje(redVoznje).subscribe(data=>{
      console.log("Data: ");
      console.log(data);
      if(data == 200){
        this.router.navigate(['/management']);
      }
      else if(data == 202)
      {
        window.alert("Drugi admin je obrisao red voznje, molimo Vas da refresujete stranicu!");
      }
      else{
        window.alert("Drugi admin je vec izmenio red voznje, molimo Vas da refresujete stranicu!");
      }

       },error=>{console.log(error)})
    
  }

  // onSelect()
  // {
  //   let redVoznjeTip;
  //   if(this.editRedVoznjeForm.value.tipRedaVoznje == 'Gradski')
  //   {
  //       redVoznjeTip=0
  //   }
  //   else
  //   {
  //       redVoznjeTip=1
  //   }
  //   this.redVoznjeService.getAllLinesForRedVoznje(redVoznjeTip).subscribe((data:Linija[])=>{
  //     this.Linije = data
  //   })
  //   this.selected = false
  // }

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
