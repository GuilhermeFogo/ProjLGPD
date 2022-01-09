import { GuardService } from './Services/guard/guard.service';
import { DashboardComponent } from './Pages/dashboard/dashboard.component';
import { LoginComponent } from './Pages/login/login.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '', component: LoginComponent
  },
  {path:'DashBoard', component: DashboardComponent, canActivate: [GuardService]}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
