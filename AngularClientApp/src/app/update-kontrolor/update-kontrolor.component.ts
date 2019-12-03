import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { RegistrationService } from '../registration.service';
import { Router, ActivatedRoute } from '@angular/router';
import { DecodeJwtDataService } from '../decode-jwt-data.service';
import { AdminService } from '../admin.service';
import { Kontrolor } from '../Models/Kontrolor';


@Component({
  selector: 'app-update-kontrolor',
  templateUrl: './update-kontrolor.component.html',
  styleUrls: ['./update-kontrolor.component.css']
})
export class UpdateKontrolorComponent implements OnInit {

  private editForm : FormGroup;
  public validationMessage = ''
  selectedFile:File=null;
  rola: string;
  public kontrolor:Kontrolor

  constructor(private fb: FormBuilder, private registerService: RegistrationService, private router: Router, private decoder: DecodeJwtDataService,private adminService:AdminService,private route:ActivatedRoute) {
    this.editForm = this.fb.group({
      Ime:['',Validators.required],
      Prezime: ['',Validators.required],
      Email: [''],
      Lozinka:['',Validators.required],
     // confPassword:['',Validators.required],
      DatumRodjenja:['',Validators.required],
      Adresa : ['',Validators.required],
     // tipPutnika: []   
      
    });
   }

  ngOnInit() {
    this.rola=this.decoder.getRoleFromToken();

    this.route.queryParams.subscribe((params)=>{
      this.kontrolor=JSON.parse(params["kontrolor"])

  
          
   
      this.editForm.patchValue({
          Ime:this.kontrolor.Ime,
          Prezime:this.kontrolor.Prezime,
          Email:this.kontrolor.Email,
          Lozinka:this.kontrolor.Lozinka,
          DatumRodjenja:this.kontrolor.DatumRodjenja,
          Adresa:this.kontrolor.Adresa
          
      })
    })

  }

  onSubmit()
  {
      this.validationMessage='';

      if(!this.editForm.valid)
      {
          this.validationMessage="Sva polja moraju biti popunjena!";
          return;
      }

      
      if(this.editForm.value.password !== this.editForm.value.confPassword)
      {
          this.validationMessage="Lozinke se moraju poklapati!";
          return;
      }

      let korisnik=new Kontrolor();
      korisnik.Ime= this.editForm.controls.Ime.value;
      korisnik.Prezime=this.editForm.controls.Prezime.value;
      korisnik.Email=this.editForm.controls.Email.value;
      korisnik.Lozinka=this.editForm.controls.Lozinka.value;
      korisnik.DatumRodjenja=this.editForm.controls.DatumRodjenja.value;
      korisnik.Adresa=this.editForm.controls.Adresa.value;
      korisnik.Uloga=this.kontrolor.Uloga;
      korisnik.Status=this.kontrolor.Status;
      korisnik.Verifikovan=this.kontrolor.Verifikovan;
      korisnik.ImageUrl=this.kontrolor.ImageUrl;
      korisnik.Aktivan=this.kontrolor.Aktivan;


      this.adminService.izmeniKontrolora(korisnik).subscribe(res=>{

       },error=>{console.log(error)});
      
  }

  onFileSelected(event)
  {
     this.selectedFile=<File>event.target.files[0];
  }
 }

