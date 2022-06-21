import { MatButtonModule } from '@angular/material/button';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SneckbarComponent } from './sneckbar.component';
import {MatSnackBarModule} from '@angular/material/snack-bar';


@NgModule({
  declarations: [
    SneckbarComponent
  ],
  imports: [
    CommonModule,
    MatButtonModule,
    MatSnackBarModule
  ],
  exports:[
    SneckbarComponent
  ]
})
export class SneckbarModule { }
