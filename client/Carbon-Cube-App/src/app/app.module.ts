import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ICDDisplayComponent } from './components/icd-display/icd-display.component';
import { PatientInfoComponent } from './components/patient-info/patient-info.component';
import { AgGridModule } from 'ag-grid-angular';
import { HeaderComponent } from './components/header/header.component';
import { HttpClientModule } from '@angular/common/http';
import { WhoApiServiceService } from './services/who-api-service.service';

@NgModule({
  declarations: [
    AppComponent,
    ICDDisplayComponent,
    PatientInfoComponent,
    HeaderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    AgGridModule.withComponents([])
  ],
  providers: [WhoApiServiceService],
  bootstrap: [AppComponent]
})
export class AppModule { }
