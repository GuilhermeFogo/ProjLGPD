import { Component, OnInit } from '@angular/core';
import { UsuariosServiceService } from "../../Services/HTTP/Usuarios/usuarios-service.service";
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  constructor() {
  }

  ngOnInit(): void {
  }

}
