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
  nuevaPersona: Persona = new Persona(); 
  personaSeleccionada: Persona | null = null;

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

  editarPersona(persona: Persona) {
    
    this.personaSeleccionada = { ...persona };
  }

  guardarCambios() {
    if (this.personaSeleccionada) {
      this.personasService.actualizarPersona(this.personaSeleccionada).subscribe(
        () => {
          console.log('Persona actualizada correctamente');
          this.obtenerPersonas();
          this.personaSeleccionada = null;
        },
        (error) => {
          console.error('Error al actualizar persona:', error);
        }
      );
    }
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

  camposCompletos(): boolean {
    return !!this.nuevaPersona.dni && !!this.nuevaPersona.nombre &&
           !!this.nuevaPersona.telefono && !!this.nuevaPersona.email;
  }

  camposCompletosUpdate(): boolean {
    return !!this.personaSeleccionada?.dni &&
           !!this.personaSeleccionada.nombre &&
           !!this.personaSeleccionada.telefono &&
           !!this.personaSeleccionada.email;
  }
  

  crearNuevaPersona() {
    this.personasService.crearPersona(this.nuevaPersona).subscribe(
      () => {
        console.log('Nueva persona creada correctamente');
        this.obtenerPersonas();

        this.nuevaPersona = new Persona();
      },
      (error) => {
        console.error('Error al crear nueva persona:', error);
      }
    );
  }
}

