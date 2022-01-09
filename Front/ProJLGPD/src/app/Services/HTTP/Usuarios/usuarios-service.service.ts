import { CookieService } from './../../cookie/cookie.service';
import { environment } from './../../../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsuariosServiceService {
  private http: HttpClient;
  private url: string;
  private cookie: CookieService;
  constructor(http: HttpClient, cookie: CookieService) {
    this.http = http;
    this.cookie = cookie;
    this.url = environment.Local + "/api/Usuario/";
  }

  public ListaUser() {
    const cookies = this.cookie.getValueCookie("Session");

    const header = new HttpHeaders().append("Authorization", cookies);
    return this.http.get(this.url,{
      headers: header
    });
  }
}
