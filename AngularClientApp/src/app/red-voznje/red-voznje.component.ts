import { Component, OnInit } from '@angular/core';
import { RedVoznjeService } from '../red-voznje.service';
import { Linija } from '../linija';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-red-voznje',
  templateUrl: './red-voznje.component.html',
  styleUrls: ['./red-voznje.component.css']
})
export class RedVoznjeComponent implements OnInit {

  Linije : Linija[];

  selected=null;
  
  constructor(private redVoznjeService:RedVoznjeService) { }

  ngOnInit() {
     this.PrikaziLinije();
  }

  // PrikaziRedVoznje():void
  // {
      
  // }
  
  PrikaziLinije():void
  {
      this.redVoznjeService.GetLinije().subscribe(
      data=>{
          this.Linije= data as Linija[];
      },
      (err:HttpErrorResponse)=>{
        console.log(err.message);
      }
      );
  }

}
