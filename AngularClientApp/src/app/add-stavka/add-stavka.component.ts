import { Component, OnInit } from '@angular/core';
import { AdminService } from '../admin.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-add-stavka',
  templateUrl: './add-stavka.component.html',
  styleUrls: ['./add-stavka.component.css']
})
export class AddStavkaComponent implements OnInit {

  validationMessage="";

  constructor(private adminService:AdminService,private router: Router) { }

  ngOnInit() {
  }

  onSubmit(f:NgForm)
  {
    if(!f.valid)
    {
        this.validationMessage="Sva polja moraju biti popunjena!";
        return;
    }

    this.adminService.addStavka(f).subscribe(res=>{
      this.router.navigate(['/management']);
    },
    error=>{
      console.log(error);
    });
  }

}
