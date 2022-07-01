import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DatamappingComponent } from '../datamapping/datamapping.component';
import { MenuModule } from 'src/app/Components/menu/menu.module';
import {MatTableModule} from '@angular/material/table';


@NgModule({
  declarations: [
    DatamappingComponent
  ],
  imports: [
    CommonModule,
    MenuModule,
    MatTableModule,
    MatButtonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatIconModule
  ], exports:[DatamappingComponent]
})
export class DatamappingModule { }
