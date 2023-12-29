import { Component } from '@angular/core';
import { Persona } from '../models/persona';

@Component({
  selector: 'app-personas',
  templateUrl: './personas.component.html',
  styleUrls: ['./personas.component.css']
})
export class PersonasComponent {

  personas: Persona[] = []

  ngOnInit(): void {
        this.datosHasheados();
  }

  datosHasheados() {
    this.personas = [
      new Persona(111222333, 'Juan Pérez', '555111111', 'juan.perez@gmail.com'),
      new Persona(444555666, 'María Rodríguez', '555222222', 'maria.rodriguez@gmail.com'),
      new Persona(777888999, 'Carlos Gómez', '555333333', 'carlos.gomez@gmail.com'),
    ];
  }
  

  borrarPersona(_t18: any) {
    throw new Error('Method not implemented.');
  }
  actualizarPersona(_t18: any) {
    throw new Error('Method not implemented.');
  }

  crearNuevaPersona() {
    throw new Error('Method not implemented.');
  }

}
