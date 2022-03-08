import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import { User } from 'src/app/Modal/User';

@Component({
  selector: 'app-form-user',
  templateUrl: './form-user.component.html',
  styleUrls: ['./form-user.component.scss']
})
export class FormUserComponent implements OnInit {

  public formuser!: FormGroup;
  CreateEdit: string| undefined;
  private dialogRef: MatDialogRef<FormUserComponent>;
  constructor(private fb: FormBuilder, @Inject(MAT_DIALOG_DATA) public data: User, dialogRef: MatDialogRef<FormUserComponent>) {
    this.dialogRef = dialogRef;
    this.dialogRef.disableClose = true;
  }


  public f(campo: string){
    return this.formuser.get(campo);
  }

  ngOnInit(): void {
    if (!this.data) {
      this.CreateEdit = "Criando";
      this.formuser = this.fb.group({
        nome: ['', [Validators.required]],
        senha: ['', [Validators.required, Validators.minLength(6)]],
        id: [''],
        email:['',[Validators.required, Validators.email]],
        ativado:[true,[Validators.required]],
        roles: [1, [Validators.required]]
      });
    } else {
      this.CreateEdit = "Editando";
      this.formuser = this.fb.group({
        nome: [this.data.nome, [Validators.required]],
        senha: [this.data.senha, [Validators.required, Validators.minLength(6)]],
        email:[this.data.email,[Validators.required, Validators.email]],
        id: [this.data.id],
        roles: [this.data.role, [Validators.required]]
      });
    }
  }


  public Onsubmit() {
    this.dialogRef.close(this.MyUser());
  }

  public Close() {
    this.dialogRef.close(undefined);
  }

  private MyUser(): User {
    if (!this.data) {
      const newUser = new User({
        nome: this.f("nome")?.value,
        senha: this.f("senha")?.value,
        id: 0,
        email: this.f("email")?.value,
        role: this.f("roles")?.value,
      })
      console.log(newUser);
      
      return newUser;
    } else {
      const editUser = new User({
        nome: this.f("nome")?.value,
        senha: this.f("senha")?.value,
        id: this.f("id")?.value,
        email: this.f("email")?.value,
        role: this.f("roles")?.value,
      })
      return editUser;
    }
  }
}
