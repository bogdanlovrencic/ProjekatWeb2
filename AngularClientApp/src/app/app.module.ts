import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule} from '@angular/forms';
import { AgmCoreModule } from '@agm/core';
import { HttpClientModule, HTTP_INTERCEPTORS }    from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegistrationComponent } from './registration/registration.component';
import { LoginComponent } from './login/login.component';
import { RedVoznjeComponent } from './red-voznje/red-voznje.component';
import { MrezaLinijaComponent } from './mreza-linija/mreza-linija.component';
import { TrenutnaLokacijaComponent } from './trenutna-lokacija/trenutna-lokacija.component';
import { CenovnikComponent } from './cenovnik/cenovnik.component';
import { ReactiveFormsModule } from '@angular/forms';
import { KupiKartuComponent } from './kupi-kartu/kupi-kartu.component';
import { MapComponent } from './map/map.component';
import { NavigationBarComponent } from './navigation-bar/navigation-bar.component';
import { RouterModule } from '@angular/router';
import { AdminManagementComponent } from './admin-management/admin-management.component';
import { ProfilKorisnikaComponent } from './profil-korisnika/profil-korisnika.component';
//import { KupovinaKarteService } from './kupovina-karte.service';
import { TokenInterceptor } from './token.interceptor';
import { AdminViewComponent } from './admin-view/admin-view.component';
import { AddCenovnikComponent } from './add-cenovnik/add-cenovnik.component';
import { AddLinijaComponent } from './add-linija/add-linija.component';
import { AddRedVoznjeComponent } from './add-red-voznje/add-red-voznje.component';
import { UpdateCenovnikComponent } from './update-cenovnik/update-cenovnik.component';
import { UpdateKontrolorComponent } from './update-kontrolor/update-kontrolor.component';
import { UpdateLinijaComponent } from './update-linija/update-linija.component';
import { UpdateRedVoznjeComponent } from './update-red-voznje/update-red-voznje.component';
import { ValidirajKartuComponent } from './validiraj-kartu/validiraj-kartu.component';
import { VerifikujKorisnikaComponent } from './verifikuj-korisnika/verifikuj-korisnika.component';

@NgModule({
  declarations: [
    AppComponent,
    RegistrationComponent,
    NavigationBarComponent,
    LoginComponent,
    RedVoznjeComponent,
    MrezaLinijaComponent,
    TrenutnaLokacijaComponent,
    CenovnikComponent,
    KupiKartuComponent,
    MapComponent,
    AdminManagementComponent,
    ProfilKorisnikaComponent,
    AdminViewComponent,
    AddCenovnikComponent,
    AddLinijaComponent,
    AddRedVoznjeComponent,
    UpdateCenovnikComponent,
    UpdateKontrolorComponent,
    UpdateLinijaComponent,
    UpdateRedVoznjeComponent,
    ValidirajKartuComponent,
    VerifikujKorisnikaComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    AgmCoreModule.forRoot({apiKey: 'AIzaSyDnihJyw_34z5S1KZXp90pfTGAqhFszNJk'})
  
  ],
  providers: [
    { 
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    }
    
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
