import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from 'src/app/login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { RedVoznjeComponent } from './red-voznje/red-voznje.component';
import { MrezaLinijaComponent } from './mreza-linija/mreza-linija.component';
import { CenovnikComponent } from './cenovnik/cenovnik.component';
import { KupiKartuComponent } from './kupi-kartu/kupi-kartu.component';
import { AdminManagementComponent } from './admin-management/admin-management.component';
import { ProfilKorisnikaComponent } from './profil-korisnika/profil-korisnika.component';
import { AddCenovnikComponent } from './add-cenovnik/add-cenovnik.component';
import { AddLinijaComponent } from './add-linija/add-linija.component';
import { AddRedVoznjeComponent } from './add-red-voznje/add-red-voznje.component';
import { AdminViewComponent } from './admin-view/admin-view.component';
import { UpdateCenovnikComponent } from './update-cenovnik/update-cenovnik.component';
import { UpdateRedVoznjeComponent } from './update-red-voznje/update-red-voznje.component';
import { UpdateLinijaComponent } from './update-linija/update-linija.component';
import { ValidirajKartuComponent } from './validiraj-kartu/validiraj-kartu.component';
import { VerifikujKorisnikaComponent } from './verifikuj-korisnika/verifikuj-korisnika.component';
import { KupljeneKarteComponent } from './kupljene-karte/kupljene-karte.component';
import { LokacijaBusaComponent } from './lokacija-busa/lokacija-busa.component';
import { HomePageComponent } from './home-page/home-page.component';

const routes: Routes = [
  
  {
    path: '',
    redirectTo: '/home',
    pathMatch: 'full'   
  },

  {
    path:'home',
    component:HomePageComponent
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
    path: 'lokacijaBusa',
    component: LokacijaBusaComponent
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
    path:'AdminView',
    component:AdminViewComponent,
  },

  {
    path:'CenovnikIzmena/cenovnik',
    component:UpdateCenovnikComponent,
  },

 
  // {
  //   path:'KontrolorIzmena/kontrolor',
  //   component:UpdateKontrolorComponent,
  // },

  {
    path:'RedVoznjeIzmena/redVoznje',
    component:UpdateRedVoznjeComponent,
  },

  {
    path:'LinijaIzmena/linija',
    component:UpdateLinijaComponent,
  },

  {
    path:'validacijaKarti',
    component:ValidirajKartuComponent
  },

  {
    path:'verifikacijaKorisnika',
    component:VerifikujKorisnikaComponent
  },

  {
    path:'kupljeneKarte',
    component:KupljeneKarteComponent
  }


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
