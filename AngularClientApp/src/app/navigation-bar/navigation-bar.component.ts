import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DecodeJwtDataService } from '../decode-jwt-data.service';


@Component({
  selector: 'app-navigation-bar',
  templateUrl: './navigation-bar.component.html',
  styleUrls: ['./navigation-bar.component.css']
})
export class NavigationBarComponent implements OnInit {
   

  constructor( private router:Router,private decodeService:DecodeJwtDataService)  {
   
  }
  isLoggedIn=false;
  isAdmin= false;

  ngOnInit() {
    this.rola=this.decodeService.getRoleFromToken();

    if(this.rola != "")
    {
        this.isLoggedIn=true;
    }

    if(this.rola == "Admin")
    {
        this.isAdmin=true;
    }    
  }

  LogOut(){
    this.isLoggedIn = false;
    this.isAdmin = false;
    this.rola="";
    localStorage.removeItem('token');   
    this.router.navigate(['/login']); 
  }

  rola = "";
  

}
