
import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { AppComponent } from "./app.component";
import { ClientesComponent } from "./clientes/clientes.component";
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';


import { AppRouterModule } from "./app-router.module";
import { ClienteService } from "./cliente.service";
import { provideHttpClient } from '@angular/common/http'; // Importa provideHttpClient

//imports de angular material
import {MatButtonModule} from '@angular/material/button';
import {MatTableModule} from '@angular/material/table';
import { CrearClienteComponent } from "./crear-cliente/crear-cliente.component";
import { ReactiveFormsModule } from "@angular/forms";
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from "@angular/material/card";
import {MatToolbarModule } from "@angular/material/toolbar"

//nuevos
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';



@NgModule({
    declarations: [
        AppComponent,
        ClientesComponent,
        HeaderComponent,
        FooterComponent,
        CrearClienteComponent
        
    ],

    imports:[
        BrowserModule,
        BrowserAnimationsModule,
        AppRouterModule,
        MatTableModule,
        MatButtonModule,
        ReactiveFormsModule,
        MatInputModule,
        MatCardModule,
        MatToolbarModule
      
    ],

    providers:[
        ClienteService,
        provideHttpClient() // Usa provideHttpClient sin paréntesis
    ],

    bootstrap:[ AppComponent]
})
export class AppModule{}