import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  standalone: false,
  
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit{

  registerForm: FormGroup

  constructor(private fb: FormBuilder,
              private service: AuthService,
              private router: Router){

    this.registerForm = this.fb.group({
      userName: ['', Validators.required],
      password: ['', Validators.compose([
        Validators.required,
        Validators.minLength(6),
        Validators.maxLength(30)
      ])]

    });
  }

  onSubmit(){
    this.service.register(this.registerForm.value).subscribe((data: any)=>{
      localStorage.setItem('userName', data.result.userName);
      localStorage.setItem('token_value',data.result.token);
      alert(data.displayMessage);
      this.router.navigate(['/clientes']);
    })

  }

  ngOnInit(): void {
    
  }

}

