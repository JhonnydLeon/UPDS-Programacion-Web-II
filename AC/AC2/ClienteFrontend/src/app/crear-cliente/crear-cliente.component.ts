import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ClienteService, Cliente } from '../cliente.service';

// Importa los módulos de Angular Material necesarios
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-crear-cliente',
  standalone: true,
  imports: [
    ReactiveFormsModule, // Para formularios reactivos
    MatCardModule,       // Para mat-card
    MatFormFieldModule,  // Para mat-form-field
    MatInputModule,      // Para matInput
    MatButtonModule     // Para botones de Angular Material
  ],
  templateUrl: './crear-cliente.component.html',
  styleUrls: ['./crear-cliente.component.css']
})
export class CrearClienteComponent {
  clienteForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private service: ClienteService,
    private router: Router
  ) {
    // Inicializa el formulario reactivo con validaciones
    this.clienteForm = this.fb.group({
      nombres: ['', Validators.required],
      apellidos: ['', Validators.required],
      direccion: ['', Validators.required],
      telefono: ['', Validators.required]
    });
  }

  onSubmit() {
    if (this.clienteForm.valid) {
      const cliente: Cliente = this.clienteForm.value as Cliente; // Convierte los valores del formulario a tipo Cliente

      this.service.crearCliente(cliente).subscribe(
        (response) => {
          console.log('Cliente creado:', response);
          alert('Cliente creado exitosamente');
          this.router.navigate(['/']); // Redirige a la página principal o a la lista de clientes
        },
        (error) => {
          console.error('Error al crear cliente:', error);
          alert('Hubo un error al crear el cliente. Por favor, inténtalo de nuevo.');
        }
      );
    } else {
      console.log('Formulario inválido');
      alert('Por favor, completa todos los campos requeridos');
    }
  }
}