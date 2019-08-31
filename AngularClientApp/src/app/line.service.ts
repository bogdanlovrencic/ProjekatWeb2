import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Subject } from 'rxjs';
import { Linija } from './Models/linija';

@Injectable({
  providedIn: 'root'
})
export class LineService {

  constructor(private http:HttpClient,private router:Router) { }

  private lineChanged = new Subject<Linija[]>()

  subscriberToLineChanges() : Subject<Linija[]>{
    this.refreshLines()
    return this.lineChanged;
  }
  
  refreshLines(){
  this.http.get('http://localhost:52295/api/Linijas').subscribe((data:Linija[]) =>{
    this.lineChanged.next(data)
  })
  }
}
