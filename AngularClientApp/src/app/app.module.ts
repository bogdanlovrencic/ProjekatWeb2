import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule} from '@angular/forms';
import { AgmCoreModule } from '@agm/core';
import { HttpClientModule }    from '@angular/common/http';

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
//import { KupovinaKarteService } from './kupovina-karte.service';

@NgModule({
  declarations: [
    AppComponent,
    RegistrationComponent,
    LoginComponent,
    RedVoznjeComponent,
    MrezaLinijaComponent,
    TrenutnaLokacijaComponent,
    CenovnikComponent,
    KupiKartuComponent,
    MapComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AgmCoreModule.forRoot({apiKey: 'AIzaSyDnihJyw_34z5S1KZXp90pfTGAqhFszNJk'})
  
  ],
  providers: [
    // KupovinaKarteService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
