import { DataMapping } from './../../Modal/DataMapping';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatTableDataSource } from '@angular/material/table';
import { FormUserComponent } from 'src/app/Components/form-user/form-user.component';
import { UsuariosServiceService } from 'src/app/Services/HTTP/Usuarios/usuarios-service.service';

@Component({
  selector: 'app-datamapping',
  templateUrl: './datamapping.component.html',
  styleUrls : ['./datamapping.component.scss']
})
export class DatamappingComponent implements OnInit {
  
  private dialog: MatDialog;
  private request: UsuariosServiceService;
  displayedColumns: string[] = ['Empresa', 'Area', 'Responsavel', 'Edit'];
  dataSource!: MatTableDataSource<DataMapping>;
  private snackBar: MatSnackBar;
  constructor(dialog: MatDialog, request: UsuariosServiceService, _snackBar: MatSnackBar) {
    this.dialog = dialog;
    this.request = request;
    this.snackBar = _snackBar;
  }

  ngOnInit(): void {
    this.Lista();
  }

  public Criaruser() {
    this.dialog.open(FormUserComponent, {
      width: '250px',
      data: null
    }).afterClosed().subscribe(x => {
      if (x != undefined) {
        this.postUser(x);
      }
    });
  }


  public Atualizar(dataMapping: DataMapping) {
    this.dialog.open(FormUserComponent, {
      width: '250px',
      data: dataMapping
    }).afterClosed().subscribe(x => {
      if (x != undefined) {
        this.putUser(x);
      }
      this.ngOnInit();
    });
  }

  public Deletar(dataMapping: DataMapping) {
    // this.deleteUser(user);
    // this.ngOnInit();
  }




  public Lista() {
    this.request.ListaUser().subscribe(usarios => {

      // this.dataSource = new MatTableDataSource(usarios);
      // console.log(usarios);

    },
      erro => console.error(erro))
  }

  private postUser(dataMapping: DataMapping) {
    // this.request.SaveUser(user).subscribe(x => {
    //   this.snackBar.open("Cadastrado com Exito", "OK");
    // }, e => {
    //   this.snackBar.open(e.error.text, "OK");
    // })
  }

  private putUser(dataMapping: DataMapping) {
    // this.request.UpdateUser().subscribe(x => {
    //   this.snackBar.open("Atualizado com exito", "OK");
    // }, error => {
    //   this.snackBar.open(error.error.text, "OK");
    // });
  }

  private deleteUser(dataMapping: DataMapping) {
    // this.request.Delete(user.id).subscribe(x => {
    //   this.snackBar.open("Usuario deletado com exito", "OK")
    // }, error => {
    //   this.snackBar.open(error.error.text, "OK");
    // });
  }
}
