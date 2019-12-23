import { Component, OnInit } from '@angular/core';
import { CenovnikService } from '../cenovnik.service';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';
import { KupovinaKarteService } from '../kupovina-karte.service';
// import { CenaStavke } from '../Models/cenaStavke';

@Component({
  selector: 'app-cenovnik',
  templateUrl: './cenovnik.component.html',
  styleUrls: ['./cenovnik.component.css']
})
export class CenovnikComponent implements OnInit {
   
  selectedTipKarte:any='Vremenska karta'
  selectedTipPutnika:any='Regularni'
  cena:number


  constructor(private kartaSevice: KupovinaKarteService) { 
     
  }

  ngOnInit() {
   
    this.kartaSevice.getCena(this.selectedTipKarte, this.selectedTipPutnika).subscribe(tempCena => this.cena = tempCena);
    
  }

  onSelectTipKarte(event : any){
    this.selectedTipKarte = event.target.value;
    this.kartaSevice.getCena(this.selectedTipKarte, this.selectedTipPutnika).subscribe(tempCena => this.cena = tempCena);
  }

  onSelectTipPutnika(event : any){
    this.selectedTipPutnika = event.target.value;
    this.kartaSevice.getCena(this.selectedTipKarte, this.selectedTipPutnika).subscribe(tempCena => this.cena = tempCena);
  }
    
}
