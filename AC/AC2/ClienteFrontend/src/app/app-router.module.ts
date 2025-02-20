import { RouterModule, Routes } from "@angular/router";
import { NgModule } from "@angular/core";
import { ClientesComponent } from "./clientes/clientes.component";
import { CrearClienteComponent } from "./crear-cliente/crear-cliente.component"; // Importa el componente

// Definición de las rutas
const routes: Routes = [
    { path: '', redirectTo: '/clientes', pathMatch: 'full' }, // Redirige a /clientes por defecto
    { path: 'clientes', component: ClientesComponent },
    { path: 'crear-cliente', component: CrearClienteComponent }, // Agrega esta línea
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRouterModule {}