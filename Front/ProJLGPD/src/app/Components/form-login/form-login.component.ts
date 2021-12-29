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

  constructor(fb: FormBuilder, route: Router) {
    this.fb = fb;
    this.route = route;
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
    console.log(user);
    
    this.route.navigateByUrl("/teste");
    
  }
}
