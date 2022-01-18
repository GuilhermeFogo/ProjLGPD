import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from '../dashboard/dashboard.component';
import { BtnSairModule } from 'src/app/Components/btn-sair/btn-sair.module';



@NgModule({
  declarations: [
    DashboardComponent
  ],
  imports: [
    CommonModule,
    BtnSairModule
  ], exports:[DashboardComponent]
})
export class DashboardModule { }
