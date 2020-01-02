import { Component, OnInit } from '@angular/core';
import { Karta } from '../Models/karta';
import { KupovinaKarteService } from '../kupovina-karte.service';
import { DecodeJwtDataService } from '../decode-jwt-data.service';

@Component({
  selector: 'app-kupljene-karte',
  templateUrl: './kupljene-karte.component.html',
  styleUrls: ['./kupljene-karte.component.css']
})
export class KupljeneKarteComponent implements OnInit {

  constructor(private kartaService:KupovinaKarteService,private decoderService:DecodeJwtDataService) { }

  public Karte: Karta[]
  public message=""

  ngOnInit() {
      this.prikaziKupljenKarte()
  }

  prikaziKupljenKarte()
  {
      this.kartaService.getKupljeneKarte(this.decoderService.getEmailFromToken()).subscribe(res=>{
          this.Karte=res;
        
          if(this.Karte == null)
              this.message="Trenutno nije kupljena nijedna karta"
      },error=>{console.log(error)}
      )
  }

}
