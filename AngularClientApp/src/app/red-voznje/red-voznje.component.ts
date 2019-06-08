import { Component, OnInit } from '@angular/core';
import { RedVoznjeService } from '../red-voznje.service';

@Component({
  selector: 'app-red-voznje',
  templateUrl: './red-voznje.component.html',
  styleUrls: ['./red-voznje.component.css']
})
export class RedVoznjeComponent implements OnInit {

  constructor(private redVoznjeService:RedVoznjeService) { }

  ngOnInit() {
  }

  PrikaziRedVoznje():void
  {
      
  }
  

}
