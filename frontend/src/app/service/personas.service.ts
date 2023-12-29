import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Persona } from '../models/persona';
import { AutenticacionService } from './authentication.service';
import { UsuarioService } from './usuario.service';

@Injectable({
  providedIn: 'root'
})
export class PersonasService {
  private apiUrl = "https://localhost:7063/api/Personas";

  constructor(private http: HttpClient, private usuarioService: UsuarioService) {}

  private getHeaders(): HttpHeaders {
    const token = this.usuarioService.obtenerTokenAlmacenado();
    return new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
  }

  getPersonas(): Observable<Persona[]> {
    return this.http.get<Persona[]>(this.apiUrl, { headers: this.getHeaders() }).pipe(
      catchError(this.handleError)
    );
  }

  crearPersona(persona: Persona): Observable<Persona> {
    return this.http.post<Persona>(this.apiUrl, persona, { headers: this.getHeaders() }).pipe(
      catchError(this.handleError)
    );
  }

  actualizarPersona(persona: Persona): Observable<void> {
    return this.http.put<void>(this.apiUrl, persona, { headers: this.getHeaders() }).pipe(
      catchError(this.handleError)
    );
  }

  eliminarPersona(id: number): Observable<void> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.delete<void>(url, { headers: this.getHeaders() }).pipe(
      catchError(this.handleError)
    );
  }

  private handleError(error: any) {
    console.error('Error:', error);
    return throwError('Error en la solicitud al servidor');
  }
}
