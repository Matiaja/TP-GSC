import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { UsuarioService } from '../service/usuario.service';
import { Router } from '@angular/router';
import { Usuario } from '../models/usuario';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  constructor(
    private fb: FormBuilder,
    private us: UsuarioService,
    private router: Router
  ) {}

  formularioLogin = this.fb.group({
    usuario: ['', Validators.required],
    clave: ['', Validators.required],
  });

  submit() {
    if (!this.formularioLogin.invalid) {
      const usuario = new Usuario(
        this.formularioLogin.get('usuario')!.value!,
        this.formularioLogin.get('clave')!.value!
      );

      const observer = {
        next: (token: string) => {
          localStorage.setItem('token', token);
          this.router.navigate(['/personas']);
        },
        error: (error: any) => {
          this.router.navigate(['/personas-error']);
        },
      };

      this.us.getToken(usuario).subscribe(observer);
    }
  }
}

