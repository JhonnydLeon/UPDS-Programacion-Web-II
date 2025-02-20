export interface ClienteInterface {
    id?: number; // Opcional porque el backend puede generar el ID automáticamente
    nombres: string;
    apellidos: string;
    direccion: string;
    telefono: string;
    genero: string;
    fechaNac: Date; // Asegúrate de usar el tipo Date para fechas
    numDoc: string;
    numCel: string;
    email: string;
  }