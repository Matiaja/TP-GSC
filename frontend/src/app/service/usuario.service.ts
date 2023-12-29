import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { Usuario } from '../models/usuario';

@Injectable({
  providedIn: 'root',
})
export class UsuarioService {

  constructor(private http: HttpClient) { }

  private apiUrl = "https://localhost:7063/api/Acounts/login";
  private token: string | null = null;

  public getToken(usuario: Usuario): Observable<string> {
    const credentials = { nombreUsuario: usuario.nombreUsuario, clave: usuario.clave };
    return this.http.post(this.apiUrl, credentials, { responseType: 'text' }).pipe(
      tap(token => this.token = token)
    );
  }
  public obtenerTokenAlmacenado(): string | null {
      return this.token;
  }
  
}
