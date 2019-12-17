import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of, Subject } from 'rxjs';

import { catchError } from 'rxjs/operators';
import { Linija } from './Models/linija';
import { RedVoznjeBindingModel } from './Models/RedVoznjeBindingModel';
import { PolazakRequest, Polazak } from './Models/polazak';
import { RedVoznje } from './Models/RedVoznje';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-type':'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class RedVoznjeService {
 
 

  private linijeUrl='http://localhost:52295/api/RedVoznjes/ucitajLinije';
  public polasci = new  Subject<Polazak[]>()
  private lineChanged = new Subject<Linija[]>()

  constructor(private http:HttpClient) { }

 
  prikaziRedVoznje(redVoznjePrikaz:RedVoznjeBindingModel):Observable<any> {
    
    return this.http.get(`http://localhost:52295/api/RedVoznjes/getRedVoznje?tipRedaVoznje=${redVoznjePrikaz.TipRedaVoznje}&tipDana=${redVoznjePrikaz.TipDana}&linijaId=${redVoznjePrikaz.LinijaId}`)
  }
  
  getAllLinesForRedVoznje(tipRedaVoznje:number): Subject<Linija[]>
  {
      this.http.get('http://localhost:52295/api/RedVoznjes/getLinije?tipLinije='+tipRedaVoznje).subscribe((data:Linija[])=>{
        this.lineChanged.next(data)
      })

      return this.lineChanged;
  }

  getPolasci(polazakRequest: PolazakRequest) {
    this.http.post('http://localhost:52295/api/RedVoznjes/getPolasci',polazakRequest).subscribe(
      ok => this.polasci.next(<Polazak[]>ok),
      error => console.log(error));

      return this.polasci;
  }
 
  
  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      return of(result as T);
    };
  }
}
