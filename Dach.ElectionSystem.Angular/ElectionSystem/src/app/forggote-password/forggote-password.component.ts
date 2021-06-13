import { HttpStatusCode } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { ForggotenPasswordRequest } from '../serviceApi/models';
import { AuthService } from '../serviceApi/services';

@Component({
  selector: 'app-forggote-password',
  templateUrl: './forggote-password.component.html',
  styleUrls: ['./forggote-password.component.css', '../app.component.css'],
})
export class ForggotePasswordComponent implements OnInit {
  public loading: boolean = false;
  public errorMessage: string = '';
  public recoveryRequest: ForggotenPasswordRequest = {
    email: '',
  };
  constructor(private route: Router, private authService: AuthService) {}
  recoveryPassworrd(): void {
    this.loading = true;
    this.authService
      .apiAuthForgottenpasswordPost$Json$Response({
        body: this.recoveryRequest,
      })
      .subscribe(
        (res) => {
          if (res.status == HttpStatusCode.Ok) {
            this.loading = false;
            Swal.fire({
              icon: 'success',
              text: 'Ha sido enviado a tu correo una contraseña temporal',
              confirmButtonText: 'Continuar',
            }).then(()=>
            this.route.navigate(['/login']));
          }
        },
        (err) => {
          this.loading = false;
          if (err.error.code == 110) this.errorMessage = 'El correo no existe registrado';
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
