import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ClienteService } from '../cliente.service';
import { ClienteInterface } from '../interfaces/ClienteInterface';
import { Router } from '@angular/router';

@Component({
  selector: 'app-crear-cliente',
  standalone: false,
  
  templateUrl: './crear-cliente.component.html',
  styleUrl: './crear-cliente.component.css'
})
export class CrearClienteComponent  {

  constructor(private service: ClienteService,
              private router: Router){}

  clienteForm = new FormGroup({
    nombres: new FormControl('', Validators.required),
    apellidos: new FormControl('', Validators.required),
    //direccion: new FormControl('', Validators.required),
    //telefono: new FormControl('', Validators.required),
    genero: new FormControl('', Validators.required),
    fecha_Nac: new FormControl('', Validators.required),
    num_Doc: new FormControl('', Validators.required),
    num_Cel: new FormControl('', Validators.required),
    email: new FormControl('', Validators.required),
  })

  onSubmit() {
    if (this.clienteForm.valid) {
      const cliente: ClienteInterface = this.clienteForm.value as ClienteInterface;

      this.service.crearCliente(cliente).subscribe((data: any) => {
        alert('cliente Creado');
        this.router.navigate(['/clientes']);
      });
    }
  }
  
}
