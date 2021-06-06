import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginRequest } from '../serviceApi/models';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  public loginRequest: LoginRequest ={
    email:'',
    password:''
  }
  constructor(private route: Router) {}
  login() {
    this.route.navigate(['/dashboard']);
  }
  ngOnInit(): void {}
}
