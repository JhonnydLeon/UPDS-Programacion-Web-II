export interface ClienteInterface {
    id: number;           // ID del cliente
    nombres: string;      // Nombres del cliente
    apellidos: string;    // Apellidos del cliente
    genero: string;       // Género del cliente
    fecha_Nac: string;    // Fecha de nacimiento (como string en formato ISO, ej.: 'YYYY-MM-DD')
    num_Doc: string;      // Número de documento
    num_Cel: string;      // Número de celular
    email: string;        // Correo electrónico
}