import { RouterModule, Routes } from "@angular/router";
import { ClientesComponent } from "./clientes/clientes.component";
import { NgModule } from "@angular/core";
import { CrearClienteComponent } from "./crear-cliente/crear-cliente.component";
import { DeleteClienteComponent } from "./delete-cliente/delete-cliente.component";
import { RegisterComponent } from "./register/register.component";
import { LoginComponent } from "./login/login.component";


// route

const routes:Routes = [
    {path:'',component: ClientesComponent},
    {path:'clientes', component: ClientesComponent},
    {path:'crear-cliente', component: CrearClienteComponent},
    {path:'delete-cliente/:id', component: DeleteClienteComponent},
    {path:'register', component: RegisterComponent},
    {path:'login',component: LoginComponent},

    {path:'clientes/delete-cliente/:id', component: DeleteClienteComponent}

]

@NgModule ({
    imports : [RouterModule.forRoot(routes)],
    exports:[RouterModule]
})

export class AppRouterModule{}

