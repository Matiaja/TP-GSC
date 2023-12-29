import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, switchMap } from 'rxjs/operators';
import { UsuarioService } from './usuario.service';
import { Persona } from '../models/persona';

@Injectable({
  providedIn: 'root',
})
export class AutenticacionService {

  private apiUrl = "https://localhost:7063/api/Personas";

  constructor(private http: HttpClient, private usuarioService: UsuarioService) {}

  private obtenerEncabezados(): HttpHeaders {
    const token = this.usuarioService.obtenerTokenAlmacenado();

    if (!token) {
      throw new Error('Token no disponible');
    }

    return new HttpHeaders({
      Authorization: `Bearer ${token}`,
    });
  }

  public obtenerPersonas(): Observable<Persona[]> {
    const headers = this.obtenerEncabezados();

    return this.http.get<Persona[]>(this.apiUrl, { headers }).pipe(
      catchError((error) => {
        console.error('Error al obtener personas:', error);
        return throwError('Error al obtener personas');
      })
    );
}
}

