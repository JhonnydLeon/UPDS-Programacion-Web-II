import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ClienteService } from '../cliente.service';

@Component({
  selector: 'app-actualizar-cliente',
  standalone: false,
  
  templateUrl: './actualizar-cliente.component.html',
  styleUrl: './actualizar-cliente.component.css'
})
export class ActualizarClienteComponent implements OnInit{

  form: FormGroup;
  id: number;

  constructor(private fb: FormBuilder,
              private dialogRef: MatDialogRef<ActualizarClienteComponent>,
              @Inject(MAT_DIALOG_DATA) private data: {nombres: string, apellidos: string, genero: string, fecha_Nac: string, num_Doc:string, num_Cel: string, email: string,id: number}
              , private service: ClienteService,
                private router: Router) {

                this.id = data.id;
                this.form = fb.group({
                  nombres: [data.nombres, Validators.required],
                  apellidos: [data.apellidos, Validators.required],
                  genero: [data.genero, Validators.required],
                  fecha_Nac: [data.fecha_Nac, Validators.required],
                  num_Doc: [data.num_Doc, Validators.required],
                  num_Cel: [data.num_Cel, Validators.required],
                  email: [data.email, Validators.required]
                })
             }

            cerrar(){
              this.dialogRef.close();
            }
            guardar(){
              this.form.value.id = this.id;
              this.service.actualizarCliente(this.id, this.form.value).subscribe((data)=>{
                this.router.navigate(['/clientes']);
                window.location.reload();
              });
              this.dialogRef.close();
            }

  ngOnInit(): void {
    
  }

}
