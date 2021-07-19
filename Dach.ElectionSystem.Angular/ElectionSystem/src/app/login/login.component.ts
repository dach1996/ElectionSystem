import { HttpStatusCode } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { LoginRequest } from '../serviceApi/models';
import { AuthService } from '../serviceApi/services';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css', '../app.component.css'],
})
export class LoginComponent implements OnInit {
  public loading: boolean = false;
  public errorMessage: string = '';
  public loginRequest: LoginRequest = {
    email: '',
    password: '',
  };

  constructor(private route: Router, private authService: AuthService) {}
  login(): void {
    this.loading = true;
    this.authService
      .apiAuthLoginPost$Json$Response({ body: this.loginRequest })
      .subscribe(
        (res) => {
          if (res.status == HttpStatusCode.Ok) {
            localStorage.setItem('token', 'Bearer ' + res.body.content?.token!);
            localStorage.setItem('userCurrent', JSON.stringify(res.body.content?.user!));
            this.loading = false;
            this.route.navigate(['/dashboard']);
          }
        },
        (err) => {
          this.loading = false;
          if (err.error.code == 150)
            this.errorMessage = 'Es necesario llenar todos los campos';
          else this.errorMessage = err.error.message;
          Swal.fire({
            icon: 'error',
            text: 'Error: ' + this.errorMessage,
            confirmButtonColor: '#d33',
          });
        }
      );
  }
  ngOnInit(): void {}

 

}

