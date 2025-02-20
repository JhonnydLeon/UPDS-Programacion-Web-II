import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

export interface Cliente {
  id?: number; // Opcional porque el backend puede generar el ID automáticamente
  nombres: string;
  apellidos: string;
  direccion: string;
  telefono: string;
  genero: string;
  fechaNac: Date; // Usa el tipo Date para fechas
  numDoc: string;
  numCel: string;
  email: string;
}

@Injectable({
  providedIn: 'root' // Esto hace que el servicio esté disponible globalmente
})
export class ClienteService {
  baseUrl: string = "https://localhost:7226/api/Clientes";

  constructor(private http: HttpClient) {}

  getClientes(): Observable<Cliente[]> {
    return this.http.get<Cliente[]>(this.baseUrl).pipe(
      catchError(this.handleError)
    );
  }

  crearCliente(cliente: Cliente): Observable<Cliente> {
    return this.http.post<Cliente>(this.baseUrl, cliente).pipe(
      catchError(this.handleError)
    );
  }

  private handleError(error: any): Observable<never> {
    console.error('Ocurrió un error:', error);
    return throwError(() => new Error('Error en la solicitud HTTP. Por favor, inténtalo de nuevo más tarde.'));
  }
}