import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Login } from '../models/login';
import { Observable, tap } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { JwtAuth } from '../models/jwtAuth';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  loginUrl = "Acounts/login"
  personaUrl = "Personas"


  public getToken(): string | null {
    return localStorage.getItem('jwtToken');
  }

  constructor(private http: HttpClient) { }

  public login(user: Login): Observable<any> {
    return this.http.post(`${environment.apiUrl}/${this.loginUrl}`, user, { responseType: 'text' });
  }

  public getPersonas(): Observable<any> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': 'Bearer ' + this.getToken(),
    });
  
    return this.http.get<any>(`${environment.apiUrl}/${this.personaUrl}`, { headers: headers });
  }
}
