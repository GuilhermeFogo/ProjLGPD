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
  constructor(http: HttpClient, cookie: CookieService) {
    super(cookie);
    this.http = http;
    this.url = environment.Local + "/api/Usuario/";
  }

  public ListaUser() {
    const cookies =  this.Ajudarequest();

    const header = new HttpHeaders().append("Authorization", cookies);
    return this.http.get(this.url,{
      headers: header
    });
  }
}
