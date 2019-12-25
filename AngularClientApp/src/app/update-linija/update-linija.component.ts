import { Component, OnInit } from '@angular/core';
import { Stanica } from '../Models/stanica';
import { AdminService } from '../admin.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Linija, LineType } from '../Models/linija';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-update-linija',
  templateUrl: './update-linija.component.html',
  styleUrls: ['./update-linija.component.css']
})
export class UpdateLinijaComponent implements OnInit {

  markerInfo: Stanica;
  public polyline: Linija;
  public zoom: number;
  stationIcon:any;
  imeLinije:string;
  selektovanaStanica:Stanica;
  izabraniTipLinije:LineType;
  public editLinijaForm:FormGroup
  private validationMessage='';
  public Linija:Linija
  private tipLinije=""

  constructor(private adminSrv:AdminService, private router:Router,private route:ActivatedRoute) { }
  inputName= false;
  rola = "";

  ngOnInit() {
     
      this.stationIcon = { url:"assets/busicon.png", scaledSize: {width: 50, height: 50}};
      console.log(this.rola)

      this.editLinijaForm = new FormGroup({
        imeLinije:new FormControl(null,[Validators.required]),
        izabraniTipLinije: new FormControl(null,[Validators.required]),    
      
      })


      this.route.queryParams.subscribe((params)=>{
        this.Linija=JSON.parse(params["linija"])
        
        
        this.polyline = new Linija(this.Linija.Naziv, this.Linija.Stanice);

        if(this.Linija.TipLinije == 0)
        {
            this.tipLinije="Gradski"
        }
        else{
            this.tipLinije="Prigradski"
        }

        this.editLinijaForm.patchValue({
            imeLinije:this.Linija.Naziv,
            izabraniTipLinije:this.tipLinije,
            
        })
        
    })
  }

  placeMarker($event){
    this.polyline.addLocation(new Stanica($event.coords.lat, $event.coords.lng))
    console.log(this.polyline)
  
  }

  onSaveClicked(){
    if(!this.editLinijaForm.valid)
    {
      this.validationMessage="Sva polja moraju biti popunjena!";
      return;
    }
    this.polyline.Id=this.Linija.Id;
    this.polyline.Naziv = this.editLinijaForm.value.imeLinije;
    this.polyline.TipLinije=this.editLinijaForm.value.izabraniTipLinije;
    this.polyline.Aktivna=this.Linija.Aktivna;
    this.polyline.Version=this.Linija.Version;

    this.adminSrv.izmeniLiniju(this.polyline).subscribe(data=>{
      console.log("Data: ");
      console.log(data);
      if(data == 200){
        this.router.navigate(['/management']);
      }
      else{
        window.alert("Drugi admin je vec izmenio liniju, molimo Vas da refresujete stranicu!");
      }
    },(error)=>{console.log(error)})

  }

  onStationClicked(stanica){
    this.inputName = true;
    this.selektovanaStanica=stanica;
  
  }

}
