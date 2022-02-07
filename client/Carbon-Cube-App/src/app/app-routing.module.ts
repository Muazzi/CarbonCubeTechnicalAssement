import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ICDDisplayComponent } from './components/icd-display/icd-display.component';
import { PatientInfoComponent } from './components/patient-info/patient-info.component';

const routes: Routes = [
  { path: 'icd', component: ICDDisplayComponent },
  { path: 'patient', component: PatientInfoComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
