import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { Linija } from './Models/linija';
import { RedVoznjeBindingModel } from './Models/RedVoznjeBindingModel';
import { Observable } from 'rxjs';
import { CenaStavke } from './Models/cenaStavke';
import { Cenovnik } from './Models/Cenovnik';
import { Polazak } from './Models/polazak';
import { Stanica } from './Models/stanica';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
 

  public cenovnikUrl='http://localhost:52295/api/Cenovniks';
  public linijaUrl='http://localhost:52295/api/Linijas';
  public redVoznjeUrl='http://localhost:52295/api/RedVoznjes';
  public stavkaUrl= 'http://localhost:52295/api/Stavkas';
  public polazakUrl='http://localhost:52295/api/Polazaks';

  constructor(private http:HttpClient) { }


  addCenovnik(cenovnik:Cenovnik)
  {
     return this.http.post(this.cenovnikUrl,cenovnik);
  }

  addStavka(data:NgForm)
  {  
    return this.http.post(this.stavkaUrl,data.value);
  }

  addLinija(linija:Linija)
  {
    return this.http.post(this.linijaUrl, linija);
  }

  addRedVoznje(redVoznje:RedVoznjeBindingModel)
  {
    return this.http.post(this.redVoznjeUrl,redVoznje);
  }

  addDeparture(polazak: Polazak) {
      return this.http.post(this.polazakUrl,polazak)
  }

  removeLinija(linija: Linija) {
    return this.http.get('http://localhost:52295/api/Linijas/ObrisiLiniju?naziv='+linija.Naziv);
  }
  removeStanica(stanica: Stanica) {
    return this.http.get('http://localhost:52295/api/Stanicas/ObrisiStanicu?id='+ stanica.Id);
  }


}
