import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ClienteInterface } from './interfaces/ClienteInterface';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  baseUrl: string = 'https://localhost:7176/api/Clientes'; // URL base del backend

  constructor(private http: HttpClient) {}

  // Obtener todos los "clientes" (clientes)
  getClientes(): Observable<ClienteInterface[]> {
    const headers = this.getAuthHeaders();
    return this.http.get<ClienteInterface[]>(`${this.baseUrl}`, { headers });
  }

  // Obtener un "cliente" (cliente) por ID
  getCliente(id: number): Observable<ClienteInterface> {
    const headers = this.getAuthHeaders();
    return this.http.get<ClienteInterface>(`${this.baseUrl}/${id}`, { headers });
  }

  // Crear un nuevo "cliente" (cliente)
  crearCliente(cliente: ClienteInterface): Observable<ClienteInterface> {
    const headers = this.getAuthHeaders();
    return this.http.post<ClienteInterface>(this.baseUrl, cliente, { headers });
  }

  // Actualizar un "cliente" (cliente) existente
  actualizarCliente(id: number, cliente: ClienteInterface): Observable<ClienteInterface> {
    const headers = this.getAuthHeaders();
    return this.http.put<ClienteInterface>(`${this.baseUrl}/${id}`, cliente, { headers });
  }

  // Eliminar un "cliente" (cliente) por ID
  deleteCliente(id: number): Observable<void> {
    const headers = this.getAuthHeaders();
    return this.http.delete<void>(`${this.baseUrl}/${id}`, { headers });
  }

  // Método auxiliar para obtener los encabezados de autenticación
  private getAuthHeaders(): HttpHeaders {
    const auth_token = localStorage.getItem('token_value');
    if (!auth_token) {
      throw new Error('No se encontró el token en localStorage.');
    }
    return new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: `Bearer ${auth_token}`
    });
  }
}