import { Component, OnInit } from '@angular/core';
import { CenovnikService } from '../cenovnik.service';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';
import { Cenovnik } from '../cenovnik';

@Component({
  selector: 'app-cenovnik',
  templateUrl: './cenovnik.component.html',
  styleUrls: ['./cenovnik.component.css']
})
export class CenovnikComponent implements OnInit {
   
   Cenovnici  : Cenovnik[];

  constructor(private cenovnikService: CenovnikService) { 
     
  }

  ngOnInit() {
    this.PrikaziCenovnik();
  }

  PrikaziCenovnik():void
  {
     this.cenovnikService.PrikaziCene().subscribe(Cenovnici=> this.Cenovnici = Cenovnici);
  }
    
}
