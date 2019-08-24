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
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
