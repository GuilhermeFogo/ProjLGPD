import { Observable } from 'rxjs';
import { User } from './../../../Modal/User';
import { CookieService } from './../../cookie/cookie.service';
import { environment } from './../../../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HelperRequests } from 'src/app/Helper/helper-requests';

@Injectable({
  providedIn: 'root'
})
export class UsuariosServiceService extends HelperRequests {
  private http: HttpClient;
  private url: string;
  private cookies: string;
  constructor(http: HttpClient, cookie: CookieService) {
    super(cookie);
    this.http = http;
    this.url = environment.Local + "/api/Usuario";
    this.cookies =  this.Ajudarequest();
  }

  public ListaUser() {

    const header = new HttpHeaders().append("Authorization", this.cookies);
    return this.http.get(this.url,{
      headers: header
    });
  }

  public SaveUser(usuario: User) {
    const header = new HttpHeaders().append("Authorization", this.cookies);
    console.log(usuario);
    return this.http.post(this.url, usuario,{
      headers: header
    });
  }

  public UpdateUser(User:User) {
    const header = new HttpHeaders().append("Authorization", this.cookies);
    return this.http.put(this.url, User,{
      headers: header
    });
  }

  public Delete(id: number){
    const header = new HttpHeaders().append("Authorization", this.cookies);
    return this.http.delete(this.url,{
      headers: header,
      body: id
    })
  }
}
