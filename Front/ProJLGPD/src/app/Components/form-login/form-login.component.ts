import { UsuariosServiceService } from './../../Services/HTTP/Usuarios/usuarios-service.service';
import { AuthService } from './../../Services/HTTP/Auth/auth.service';
import { CookieService } from './../../Services/cookie/cookie.service';
import {FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import {User} from '../../Modal/User';
import { Router } from '@angular/router';

@Component({
  selector: 'app-form-login',
  templateUrl: './form-login.component.html',
  styleUrls: ['./form-login.component.scss']
})
export class FormLoginComponent implements OnInit {
 
  private fb: FormBuilder;
  form!: FormGroup;
  private route: Router;
  private cookie: CookieService;
  private Auth: AuthService;
  private teste: UsuariosServiceService;

  constructor(fb: FormBuilder, route: Router, CookieService: CookieService, Auth: AuthService, teste: UsuariosServiceService) {
    this.fb = fb;
    this.route = route;
    this.cookie = CookieService
    this.Auth = Auth;
    this.teste = teste;
  }

  
  public get f(): any{
    return this.form.controls;
  }
  

  ngOnInit(): void {
    this.form = this.fb.group({
      nameUser:["", Validators.required],
      pass: ["", Validators.required]
    });
  }

  public OnSubmit() {
    const user = new User({
      id: "0",
      nome: this.f.nameUser.value,
      senha: this.f.pass.value,
      role: ""
    });
    const expires =  this.cookie.Expires(0,0,2);
    
    this.Auth.Autenticar(user).subscribe(x=>{
      this.cookie.CreateCookie(x, expires);
      this.route.navigateByUrl("/DashBoard");
    },e => console.log(e));
  }


  public Teste(){
    this.teste.ListaUser().subscribe(a=>{
      console.log(a);
    });
  }
}
