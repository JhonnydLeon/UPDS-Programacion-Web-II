// src/app/clientes/clientes.component.ts
import { Component, OnInit } from '@angular/core';
import { ClienteService } from '../cliente.service';
import { MatTableDataSource } from '@angular/material/table';
import { ClienteInterface } from '../interfaces/ClienteInterface';
import { MatTableModule } from '@angular/material/table'; // Importa MatTableModule
import { CommonModule } from '@angular/common'; // Importa CommonModule

@Component({
  selector: 'app-clientes',
  standalone: true,
  imports: [MatTableModule, CommonModule], // Agrega CommonModule aquí
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.css']
})
export class ClientesComponent implements OnInit {
  dataSource = new MatTableDataSource<ClienteInterface>();
  displayedColumns: string[] = [
    "nombres", "apellidos", "direccion", "telefono", "genero", "fechaNac", "numDoc", "numCel", "email"
  ];

  constructor(private service: ClienteService) {}

  ngOnInit(): void {
    this.service.getClientes().subscribe(
      (data: ClienteInterface[]) => {
        this.dataSource.data = data;
        console.log(data);
      },
      (error) => {
        console.error('Error al cargar clientes:', error);
      }
    );
  }
}