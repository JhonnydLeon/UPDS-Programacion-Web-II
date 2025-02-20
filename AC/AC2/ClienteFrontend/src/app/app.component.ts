import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { FooterComponent } from './footer/footer.component';  // Importa FooterComponent
import { HeaderComponent } from './header/header.component';


@Component({
  selector: 'app-root',
  standalone: true,

  //importante importar aca los component como header, footer, etc
  imports: [RouterOutlet, HeaderComponent, FooterComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
  
})
export class AppComponent {
  title = 'ClienteFrontend';
}
