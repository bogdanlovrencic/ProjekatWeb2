import { Injectable, EventEmitter } from '@angular/core';
import { Stanica } from './Models/stanica';
import { Observable } from 'rxjs';

declare var $

@Injectable({
  providedIn: 'root'
})

export class LokacijaBusaService {
 
  private proxy:any
  private proxyName:string='LokacijaBusa'
  private connection:any
  public connectionExists:boolean
  public notificationReceived:EventEmitter<string>

  constructor() {
      this.notificationReceived= new EventEmitter<string>()
      this.connectionExists=false
      //create a hub connection
      this.connection= $.hubConnection('http://localhost:52295/')
      this.connection.qs={"token": "Bearer" + localStorage.jwt}
      //create new proxy with the given name
      this.proxy=this.connection.createHubProxy(this.proxyName)
   }

  hello(stanice:Stanica[]) {
      this.proxy.invoke('Hello',stanice)
  }
 
  startConnection():Observable<boolean> {
    return Observable.create((observer) => {
       
      this.connection.start()
      .done((data: any) => {  
          console.log('Now connected ' + data.transport.name + ', connection ID= ' + data.id)
          this.connectionExists = true;

          observer.next(true);
          observer.complete();
      })
      .fail((error: any) => {  
          console.log('Could not connect ' + error);
          this.connectionExists = false;

          observer.next(false);
          observer.complete(); 
      });  
    });
  }

  registerForHello():Observable<any> {
    return Observable.create((observer) => {

      this.proxy.on('hello', (data: any) => {  
          console.log('Stiglo sa servera');
          console.log(data);  
          observer.next(data);
      });  
    });
  }  
  
 
}
