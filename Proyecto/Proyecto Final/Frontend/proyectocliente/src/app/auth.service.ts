import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserInterface } from './interfaces/UserInterface';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baserUrl: string = 'https://localhost:7176/api/Users/';

  constructor(private http: HttpClient,
              private router: Router) { }

  register(user: UserInterface){
   
    return this.http.post(this.baserUrl+'Register', user);

  }

  login(user: UserInterface){
    return this.http.post(this.baserUrl+'Login', user);
  }

  get getUsername(){
    return localStorage.getItem('userName');
  }

  get isAutenticado(){
    return !!localStorage.getItem('token_value');
  }
  logout(){
    localStorage.removeItem('UserName');
    localStorage.removeItem('token_value');
    this.router.navigate(['/clientes']);
    window.location.reload();
  }

}
