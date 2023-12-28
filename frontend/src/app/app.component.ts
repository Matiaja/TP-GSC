import { Component } from '@angular/core';
import { Login } from './models/login';
import { JwtAuth } from './models/jwtAuth';
import { AuthenticationService } from './service/authentication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  loginDto = new Login();

  constructor(private authService: AuthenticationService) {}

  login(loginDto: Login) {
    this.authService.login(loginDto).subscribe((response) => {
      console.log('Token JWT:', response);
      localStorage.setItem('jwtToken', response);
    });
  }

  personas() {
    this.authService.getPersonas().subscribe((personasdata: any) => {
      console.log(personasdata);
    })
  }
}