import { UsuariosServiceService } from './../../Services/HTTP/Usuarios/usuarios-service.service';
import { User } from 'src/app/Modal/User';
import { MatDialog } from '@angular/material/dialog';
import { Component, OnInit } from '@angular/core';
import { FormUserComponent } from 'src/app/Components/form-user/form-user.component';
import { MatTableDataSource } from '@angular/material/table';
@Component({
  selector: 'app-gerencia-user',
  templateUrl: './gerencia-user.component.html',
  styleUrls: ['./gerencia-user.component.scss']
})
export class GerenciaUserComponent implements OnInit {

  private dialog: MatDialog;
  private request: UsuariosServiceService;
  displayedColumns: string[] = ['nome','role','email','ativo','Edit'];
  dataSource!: MatTableDataSource<User>;
  constructor(dialog: MatDialog, request: UsuariosServiceService) {
    this.dialog = dialog;
    this.request = request;
   }

  ngOnInit(): void {
    this.Lista();
  }

  public Criaruser(){
    this.dialog.open(FormUserComponent, {
      width:'250px',
      data: null
    }).afterClosed().subscribe(x=>{
      if(x != undefined){
        this.postUser(x);
        console.log(x);
        
      }
    });
  }


  public Atualizar(user:User){
    this.dialog.open(FormUserComponent, {
      width:'250px',
      data: user
    }).afterClosed().subscribe(x=>{
      if(x != undefined){
        this.putUser(x);
        console.log(x);
      }
    });
  }

  public Deletar(user:User){
    this.deleteUser(user);
  }




  public Lista(){
    this.request.ListaUser().subscribe(usarios=>{
      
      this.dataSource = new MatTableDataSource(usarios);
      console.log(usarios);
      
    }, 
    erro=> console.error(erro))
  }

  private postUser(user: User) {
    this.request.SaveUser(user).subscribe(x=>{
      console.log("Cadastro com exito");
      console.log(x);
    })
  }

  private putUser(user: User) {
    this.request.UpdateUser(user).subscribe(x => {
      console.log("Atualizado com exito");
    }, error => console.log(error))
  }

  private deleteUser(user: User) {
    this.request.Delete(user.id).subscribe(x => {
      console.log("Deletado com exito");
    }, error => console.log(error))
  }

}