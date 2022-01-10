import { LoginBlockService } from './Services/guard/login-block.service';
import { GuardService } from './Services/guard/guard.service';
import { DashboardComponent } from './Pages/dashboard/dashboard.component';
import { LoginComponent } from './Pages/login/login.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes, CanActivate } from '@angular/router';

const routes: Routes = [
  {
    path: '', component: LoginComponent ,canActivate:[LoginBlockService]
  },
  {path:'DashBoard', component: DashboardComponent, canActivate: [GuardService]},

  {path:'**', component: DashboardComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
