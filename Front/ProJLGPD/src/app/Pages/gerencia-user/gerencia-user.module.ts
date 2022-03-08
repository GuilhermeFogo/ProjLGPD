import { MatDialogModule } from '@angular/material/dialog';
import { FormUserModule } from './../../Components/form-user/form-user.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GerenciaUserComponent } from './gerencia-user.component';
import { MenuModule } from 'src/app/Components/menu/menu.module';



@NgModule({
  declarations: [GerenciaUserComponent],
  imports: [
    CommonModule,
    FormUserModule,
    MenuModule,
    MatDialogModule
  ], exports:[GerenciaUserComponent]
})
export class GerenciaUserModule { }
