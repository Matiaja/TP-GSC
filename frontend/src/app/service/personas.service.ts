import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Persona } from '../models/persona';

@Injectable({
  providedIn: 'root'
})
export class PersonasService {
  private apiUrl = "https://localhost:7063/api/Personas";

  constructor(private http: HttpClient) {}


  getPersonas(): Observable<Persona[]> {
    return this.http.get<Persona[]>(this.apiUrl).pipe(
      catchError(this.handleError)
    );
  }


  crearPersona(persona: Persona): Observable<Persona> {
    return this.http.post<Persona>(this.apiUrl, persona).pipe(
      catchError(this.handleError)
    );
  }


  actualizarPersona(persona: Persona): Observable<void> {
    return this.http.put<void>(this.apiUrl, persona).pipe(
      catchError(this.handleError)
    );
  }

  eliminarPersona(id: number): Observable<void> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.delete<void>(url).pipe(
      catchError(this.handleError)
    );
  }

  private handleError(error: any) {
    console.error('Error:', error);
    return throwError('Error en la solicitud al servidor');
  }
}
