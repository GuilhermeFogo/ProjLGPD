import { User } from './../../../Modal/User';
import { environment } from './../../../../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private http: HttpClient;
  private url: string;
  constructor(http: HttpClient) {
    this.http = http;
    this.url = environment.Local + "/api/Autenticacao/"
  }

  public Autenticar(user: User) {
    return this.http.post(this.url, user);
  }
}
