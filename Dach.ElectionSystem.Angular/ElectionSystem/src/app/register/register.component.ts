import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserCreateRequest } from '../serviceApi/models';
import { UserService } from '../serviceApi/services';
import { HttpStatusCode } from '@angular/common/http';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css', '../app.component.css'],
})
export class RegisterComponent implements OnInit {
  public loading: boolean = false;
  public errorMessage: string = '';
  public userCreateRequest: UserCreateRequest = {
    birthDate: new Date(),
    dni: '',
    email: '',
    firstLastName: '',
    firstName: '',
    password: '',
    userName: '',
    secondLastName: '',
    secondName: '',
  };
  constructor(private route: Router, private userService: UserService) {}
  createUser(): void {
    this.loading = true;
    this.userService
      .apiUsersPost$Json$Response({ body: this.userCreateRequest })
      .subscribe(
        (res) => {
          if (res.status == HttpStatusCode.Ok) {
            Swal.fire({
              icon: 'success',
              text: 'Usuario Creado',
              confirmButtonText: 'Continuar',
            }).then((result) => {
              this.route.navigate(['/login']);
            });
            this.loading = false;
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
