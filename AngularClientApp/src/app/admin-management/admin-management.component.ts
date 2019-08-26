import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-management',
  templateUrl: './admin-management.component.html',
  styleUrls: ['./admin-management.component.css']
})
export class AdminManagementComponent implements OnInit {

  message="";
  listPrices:PriceList[];
  listControllers:BusController[];
  listTimetables:BusTimetable[];

  constructor(private table:GetTableService, private router:Router) { }

  ngOnInit() {
    this.table.message.subscribe(msg => this.message = msg);
  }

}
