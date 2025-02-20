import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';


import { AppComponent } from './app.component';
import { ClientesComponent } from './clientes/clientes.component';
import { FooterComponent } from './footer/footer.component';
import { HeaderComponent } from './header/header.component';
//import
import { ClienteService } from './cliente.service';
import { AppRouterModule } from './app-router.module';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatButtonModule} from '@angular/material/button';
import {MatTableModule} from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { CrearClienteComponent } from './crear-cliente/crear-cliente.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MatInputModule} from '@angular/material/input';
import { MatCardModule} from '@angular/material/card';
import { MatSelectModule } from '@angular/material/select';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatDialogModule} from '@angular/material/dialog';
import { ActualizarClienteComponent } from './actualizar-cliente/actualizar-cliente.component';
import { DeleteClienteComponent } from './delete-cliente/delete-cliente.component';
import { MatListModule } from '@angular/material/list';
import { AuthService } from './auth.service';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { FormsModule } from '@angular/forms';
import { MatPaginatorModule } from '@angular/material/paginator';

@NgModule({
  declarations: [
    AppComponent,
    ClientesComponent,
    FooterComponent,
    HeaderComponent,
    CrearClienteComponent,
    ActualizarClienteComponent,
    DeleteClienteComponent,
    RegisterComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule, AppRouterModule,HttpClientModule,BrowserAnimationsModule,MatButtonModule,
    MatTableModule,MatIconModule, ReactiveFormsModule ,MatInputModule,MatCardModule,MatSelectModule,
    MatToolbarModule,MatDialogModule,MatListModule,FormsModule ,MatPaginatorModule

    
  ],
  providers: [ClienteService, AuthService],
  bootstrap: [AppComponent]
})
export class AppModule { }
