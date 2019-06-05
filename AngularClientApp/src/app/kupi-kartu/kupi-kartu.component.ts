import { Component, OnInit } from '@angular/core';
import { KupovinaKarteService } from 'src/app/kupovina-karte.service';

@Component({
  selector: 'app-kupi-kartu',
  templateUrl: './kupi-kartu.component.html',
  styleUrls: ['./kupi-kartu.component.css']
})
export class KupiKartuComponent implements OnInit {

  constructor(private kartaService:KupovinaKarteService) { }

  ngOnInit() {

  }

  KupiKartu(email:string):void
  {
      this.kartaService.dodajKartu(email).subscribe();
  }

}
