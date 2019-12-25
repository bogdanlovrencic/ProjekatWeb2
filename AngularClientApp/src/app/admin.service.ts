import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { Linija } from './Models/linija';
import { RedVoznjeBindingModel } from './Models/RedVoznjeBindingModel';
import { Observable } from 'rxjs';
import { CenaStavke } from './Models/cenaStavke';
import { Cenovnik, CenovnikPrikaz, CenovnikUpdate } from './Models/Cenovnik';
import { Polazak, PolazakModel } from './Models/polazak';
import { Stanica } from './Models/stanica';
import { Stavka } from './Models/Stavka';
import { Kontrolor } from './Models/Kontrolor';
import { RedVoznje } from './Models/RedVoznje';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
 

  public linijaUrl='http://localhost:52295/api/Linijas';
  public redVoznjeUrl='http://localhost:52295/api/RedVoznjes';
  public stavkaUrl= 'http://localhost:52295/api/Stavkas';
  public polazakUrl='http://localhost:52295/api/Polazaks';

  constructor(private http:HttpClient) { }


  addCenovnik(cenovnik:Cenovnik,cenaVremenske:any,cenaDnevne:any,cenaMesecne:any,cenaGodisnje:any)
  {
     return this.http.post<any[]>(`http://localhost:52295/api/Cenovniks/DodajCenovnik?VaziOd=${cenovnik.VaziOd}&VaziDo=${cenovnik.VaziDo}&aktivan=${cenovnik.Aktivan}&cenaVremenske=${cenaVremenske}&cenaDnevne=${cenaDnevne}&cenaMesecne=${cenaMesecne}&cenaGodisnje=${cenaGodisnje}`,
      [cenovnik.VaziOd,cenovnik.VaziDo,cenovnik.Aktivan,cenaVremenske,cenaDnevne,cenaMesecne,cenaGodisnje]);
  }

  addLinija(linija:Linija)
  {
    return this.http.post(this.linijaUrl, linija);
  }

  addRedVoznje(redVoznje:RedVoznje)
  {
    return this.http.post(this.redVoznjeUrl,redVoznje);
  }

 

  izmeniCenovnik(cenovnik: CenovnikUpdate,cenaVremenske,cenaDnevne,cenaMesecne,cenaGodisnje):Observable<any>
  {
      return this.http.post<any[]>(`http://localhost:52295/api/Cenovniks/IzmeniCenovnik?id=${cenovnik.Id}&Vaziod=${cenovnik.VaziOd}&VaziDo=${cenovnik.VaziDo}&aktivan=${cenovnik.Aktivan}&version=${cenovnik.Version}&cenaVremenske=${cenaVremenske}&cenaDnevne=${cenaDnevne}&cenaMesecne=${cenaMesecne}&cenaGodisnje=${cenaGodisnje}`,
      [cenovnik.Id,cenovnik.VaziOd,cenovnik.VaziDo,cenovnik.Aktivan,cenovnik.Version,cenaVremenske,cenaDnevne,cenaMesecne,cenaGodisnje]);
  }

  
  izmeniKontrolora(kontrolor: Kontrolor) 
  {
      return this.http.put('http://localhost:52295/api/Korisniks?id='+kontrolor.Email,kontrolor);  
  }

  izmeniRedVoznje(redVoznje: RedVoznje):Observable<any>
  {
     return this.http.put('http://localhost:52295/api/RedVoznjes?id='+redVoznje.Id,redVoznje);
  }

  izmeniLiniju(linija:Linija):Observable<any>
  {
     return this.http.put('http://localhost:52295/api/Linijas?id='+linija.Id,linija)
  }


  removeLinija(linija: Linija):Observable<any> {
    return this.http.get('http://localhost:52295/api/Linijas/ObrisiLiniju?naziv='+linija.Naziv);
  }
  removeStanica(stanica: Stanica):Observable<any> {
    return this.http.get('http://localhost:52295/api/Stanicas/ObrisiStanicu?id='+ stanica.Id);
  }


}
