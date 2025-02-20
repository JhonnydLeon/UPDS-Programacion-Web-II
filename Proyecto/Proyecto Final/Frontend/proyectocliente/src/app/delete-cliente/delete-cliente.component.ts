import { Component, OnInit } from '@angular/core';
import { ClienteService } from '../cliente.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-delete-cliente',
  standalone: false,
  
  templateUrl: './delete-cliente.component.html',
  styleUrls: ['./delete-cliente.component.css']
})
export class DeleteClienteComponent implements OnInit{

  id: any;

  cliente = {
    nombres:'',
    apellidos:'',
    //direccion:'',
    //telefono:'',
    genero:'',
    fecha_Nac:'',
    num_Doc:'',
    num_Cel:'',
    email:''
  }

  constructor(private service:ClienteService,
              private route: ActivatedRoute,
              private router: Router){}

  ngOnInit(): void {

    this.id = this.route.snapshot.paramMap.get('id');
    this.service.getCliente(this.id).subscribe((data: any)=> {
      console.log(data);
      this.cliente.nombres = data.result.nombres;
      this.cliente.apellidos = data.result.apellidos;
      //this.cliente.direccion = data.result.direccion;
      //this.cliente.telefono = data.result.telefono;
      this.cliente.genero = data.result.genero;
      this.cliente.fecha_Nac = data.result.fecha_Nac;
      this.cliente.num_Doc = data.result.num_Doc;
      this.cliente.num_Cel = data.result.num_Cel;
      this.cliente.email = data.result.email;
    })
    
  }
  cancel(){
    this.router.navigate(['/']);
  }
    
  confirmar(){
    this.service.deleteCliente(this.id).subscribe((data: any) =>{
      this.router.navigate(['/']);
    })
  }

}
