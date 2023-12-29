import { Component, OnInit } from '@angular/core';
import { Persona } from '../models/persona';
import { PersonasService } from '../service/personas.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-personas',
  templateUrl: './personas.component.html',
  styleUrls: ['./personas.component.css']
})
export class PersonasComponent implements OnInit {
  personas: Persona[] = [];
  nuevaPersona: Persona = new Persona(); // Objeto para la nueva persona

  constructor(private personasService: PersonasService) {}

  ngOnInit(): void {
    this.obtenerPersonas();
  }

  obtenerPersonas() {
    this.personasService.getPersonas().subscribe(
      (data) => {
        this.personas = data;
      },
      (error) => {
        console.error('Error al obtener personas:', error);
      }
    );
  }

  borrarPersona(id: number) {
    this.personasService.eliminarPersona(id).subscribe(
      () => {
        console.log('Persona eliminada correctamente');
        this.obtenerPersonas(); 
      },
      (error) => {
        console.error('Error al eliminar persona:', error);
      }
    );
  }

  actualizarPersona(persona: Persona) {
    this.personasService.actualizarPersona(persona).subscribe(
      () => {
        console.log('Persona actualizada correctamente');
      },
      (error) => {
        console.error('Error al actualizar persona:', error);
      }
    );
  }

  crearNuevaPersona() {
    this.personasService.crearPersona(this.nuevaPersona).subscribe(
      () => {
        console.log('Nueva persona creada correctamente');
        this.obtenerPersonas();
        // Limpiar los campos del formulario después de la creación
        this.nuevaPersona = new Persona();
      },
      (error) => {
        console.error('Error al crear nueva persona:', error);
      }
    );
  }
}

