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
import { CenovnikComponent } from './cenovnik/cenovnik.component';
import { ReactiveFormsModule } from '@angular/forms';
import { KupiKartuComponent } from './kupi-kartu/kupi-kartu.component';
import { NavigationBarComponent } from './navigation-bar/navigation-bar.component';
import { RouterModule } from '@angular/router';
import { AdminManagementComponent } from './admin-management/admin-management.component';
import { ProfilKorisnikaComponent } from './profil-korisnika/profil-korisnika.component';
import { TokenInterceptor } from './token.interceptor';
import { AdminViewComponent } from './admin-view/admin-view.component';
import { AddCenovnikComponent } from './add-cenovnik/add-cenovnik.component';
import { AddLinijaComponent } from './add-linija/add-linija.component';
import { AddRedVoznjeComponent } from './add-red-voznje/add-red-voznje.component';
import { UpdateCenovnikComponent } from './update-cenovnik/update-cenovnik.component';
import { UpdateLinijaComponent } from './update-linija/update-linija.component';
import { UpdateRedVoznjeComponent } from './update-red-voznje/update-red-voznje.component';
import { ValidirajKartuComponent } from './validiraj-kartu/validiraj-kartu.component';
import { VerifikujKorisnikaComponent } from './verifikuj-korisnika/verifikuj-korisnika.component';
import { KupljeneKarteComponent } from './kupljene-karte/kupljene-karte.component';
import { LokacijaBusaComponent } from './lokacija-busa/lokacija-busa.component';
import { NgxPayPalModule } from 'ngx-paypal';
import { HomePageComponent } from './home-page/home-page.component';


@NgModule({
  declarations: [
    AppComponent,
    RegistrationComponent,
    NavigationBarComponent,
    LoginComponent,
    RedVoznjeComponent,
    MrezaLinijaComponent,
    CenovnikComponent,
    KupiKartuComponent,
    AdminManagementComponent,
    ProfilKorisnikaComponent,
    AdminViewComponent,
    AddCenovnikComponent,
    AddLinijaComponent,
    AddRedVoznjeComponent,
    UpdateCenovnikComponent,
    UpdateLinijaComponent,
    UpdateRedVoznjeComponent,
    ValidirajKartuComponent,
    VerifikujKorisnikaComponent,
    KupljeneKarteComponent,
    LokacijaBusaComponent,
    HomePageComponent,
 
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    NgxPayPalModule,
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
