import { Component, OnInit } from '@angular/core';
import { CenovnikService } from '../cenovnik.service';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-cenovnik',
  templateUrl: './cenovnik.component.html',
  styleUrls: ['./cenovnik.component.css']
})
export class CenovnikComponent implements OnInit {
   
  private cenovnikForm: FormGroup;

  constructor(private cenovnikService: CenovnikService) { 
   
  }

  ngOnInit() {
  }

  PrikaziCenovnik():void
  {
     let tipKarte : string;
      let tipPutnika: string;

    tipKarte = this.cenovnikForm.value.tipKarte;
    tipPutnika= this.cenovnikForm.value.tipPutnika;

   this.cenovnikService.PrikaziCene(tipKarte,tipPutnika).subscribe(
     (res)=>{
        alert(res); 
      
     },
     (err)=>{
       console.log(err);
     }
   );
  }

}
