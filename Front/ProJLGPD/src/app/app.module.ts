import { DatamappingModule } from './Pages/datamapping/datamapping.module';
import { ErrorModule } from './Pages/error/error.module';
import { DashboardModule } from './Pages/dashboard/dashboard.module';
import { LoginModule } from './Pages/login/login.module';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { GerenciaUserModule } from './Pages/gerencia-user/gerencia-user.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    LoginModule,
    BrowserAnimationsModule,
    DashboardModule,
    ErrorModule,
    GerenciaUserModule,
    DatamappingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
