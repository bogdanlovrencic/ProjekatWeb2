import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from 'src/app/login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { RedVoznjeComponent } from './red-voznje/red-voznje.component';
import { MrezaLinijaComponent } from './mreza-linija/mreza-linija.component';
import { TrenutnaLokacijaComponent } from './trenutna-lokacija/trenutna-lokacija.component';
import { CenovnikComponent } from './cenovnik/cenovnik.component';
import { KupiKartuComponent } from './kupi-kartu/kupi-kartu.component';
import { AdminManagementComponent } from './admin-management/admin-management.component';
import { ProfilKorisnikaComponent } from './profil-korisnika/profil-korisnika.component';
import { AddCenovnikComponent } from './add-cenovnik/add-cenovnik.component';
import { AddKontrolorComponent } from './add-kontrolor/add-kontrolor.component';
import { AddLinijaComponent } from './add-linija/add-linija.component';
import { AddRedVoznjeComponent } from './add-red-voznje/add-red-voznje.component';
import { AddStavkaComponent } from './add-stavka/add-stavka.component';
import { AddPolazakComponent } from './add-polazak/add-polazak.component';

const routes: Routes = [
  
  {
    path: '',
    redirectTo: '/redVoznje',
    pathMatch: 'full'   
  },

  {
    path: 'redVoznje',
    component: RedVoznjeComponent
  },

  {
    path: 'mrezaLinija',
    component: MrezaLinijaComponent
  },

  {
    path: 'trenutnaLokacija',
    component: TrenutnaLokacijaComponent
  },

  {
    path: 'cenovnik',
    component: CenovnikComponent
  },

  {
    path: 'kupiKartu',
    component:KupiKartuComponent
  },

  {
    path:'profil',
    component:ProfilKorisnikaComponent
  },

  {
    path:'management',
    component:AdminManagementComponent
  },

  {
    path: 'registracija',
    component: RegistrationComponent
  },

  {
    path: 'login',
    component: LoginComponent
  },

  {
    path: 'Cenovnik',
    component:AddCenovnikComponent,
   // canActivate: [AuthGuard]
  },

  {
    path:'Kontrolori',
    component:AddKontrolorComponent,
    //canActivate: [AuthGuard]
  },  

  {
    path:'Linije',
    component:AddLinijaComponent,
    //canActivate: [AuthGuard]
  },

  {
    path:'RedVoznje',
    component:AddRedVoznjeComponent,
    //canActivate: [AuthGuard]
  },

  {
    path:'Stavke',
    component:AddStavkaComponent,
  },

  {
    path:'Polazak',
    component:AddPolazakComponent,
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
