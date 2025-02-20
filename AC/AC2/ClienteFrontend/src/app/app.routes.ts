import { RouterModule, Routes } from "@angular/router";
import { ClientesComponent } from "./clientes/clientes.component";
import { NgModule } from "@angular/core";
import { CrearClienteComponent } from "./crear-cliente/crear-cliente.component";

// Definición de las rutas
export const routes: Routes = [
    { path: '', redirectTo: '/clientes', pathMatch: 'full' }, // Redirige a /clientes por defecto
    { path: 'clientes', component: ClientesComponent },
    { path: 'crear-cliente', component: CrearClienteComponent },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRouterModule {}