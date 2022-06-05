import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { FormUserModule } from './../../Components/form-user/form-user.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GerenciaUserComponent } from './gerencia-user.component';
import { MenuModule } from 'src/app/Components/menu/menu.module';
import {MatTableModule} from '@angular/material/table';



@NgModule({
  declarations: [GerenciaUserComponent],
  imports: [
    CommonModule,
    FormUserModule,
    MenuModule,
    MatDialogModule, 
    MatButtonModule,
    MatIconModule,
    MatTableModule
  ], exports:[GerenciaUserComponent]
})
export class GerenciaUserModule { }
