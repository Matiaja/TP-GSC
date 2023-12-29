import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, switchMap, throwError} from 'rxjs';
import { UsuarioService } from './usuario.service';
import { Persona } from '../models/persona';

@Injectable({
  providedIn: 'root'
})
export class AutenticacionService {

  constructor(private http: HttpClient, private us: UsuarioService) {}

  private apiUrl = "https://localhost:7063/api/personas"

  public getPersonas(): Observable<Persona[]> {
    const token = localStorage.getItem('token');

    if (!token) {
      return throwError(() => 'Token no disponible');
    }

    const headers = new HttpHeaders({
      Authorization: `Bearer ${token}`,
    });

    return this.http.get<Persona[]>(this.apiUrl, { headers });
}
}
