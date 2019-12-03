import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { Linija } from './Models/linija';
import { RedVoznjeBindingModel } from './Models/RedVoznjeBindingModel';
import { Observable } from 'rxjs';
import { CenaStavke } from './Models/cenaStavke';
import { Cenovnik, CenovnikPrikaz } from './Models/Cenovnik';
import { Polazak, PolazakModel } from './Models/polazak';
import { Stanica } from './Models/stanica';
import { Stavka } from './Models/Stavka';
import { Kontrolor } from './Models/Kontrolor';
import { RedVoznje } from './Models/RedVoznje';

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

  addRedVoznje(redVoznje:RedVoznje)
  {
    return this.http.post(this.redVoznjeUrl,redVoznje);
  }

  // addPolazak(polazak: Polazak) {
  //     return this.http.post(this.polazakUrl,polazak)
  // }

  izmeniCenovnik(cenovnik: CenovnikPrikaz)
  {
      return this.http.put('http://localhost:52295/api/Cenovniks?id='+cenovnik.Id,cenovnik);
  }

  izmeniStavku(stavka:Stavka)
  {
      return this.http.put('http://localhost:52295/api/Stavkas?id='+stavka.Id,stavka);
  }

  izmeniKontrolora(kontrolor: Kontrolor) 
  {
      return this.http.put('http://localhost:52295/api/Korisniks?id='+kontrolor.Email,kontrolor);  
  }

  // izmeniPolazak(polazak: PolazakModel)
  // {
  //     return this.http.put('http://localhost:52295/api/Polazaks?id='+polazak.Id,polazak);  
  // }

  izmeniRedVoznje(redVoznje: RedVoznje)
  {
     return this.http.put('http://localhost:52295/api/RedVoznjes?id='+redVoznje.Id,redVoznje);
  }

  izmeniLiniju(linija:Linija)
  {
     return this.http.put('http://localhost:52295/api/Linijas?id='+linija.Id,linija)
  }

  removeLinija(linija: Linija) {
    return this.http.get('http://localhost:52295/api/Linijas/ObrisiLiniju?naziv='+linija.Naziv);
  }
  removeStanica(stanica: Stanica) {
    return this.http.get('http://localhost:52295/api/Stanicas/ObrisiStanicu?id='+ stanica.Id);
  }


}
