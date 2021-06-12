import { HttpStatusCode } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import {
  ChangePasswordRequest,
  UserBaseResponse,
  UserUpdateRequest,
} from 'src/app/serviceApi/models';
import { UserService } from 'src/app/serviceApi/services';
import Swal from 'sweetalert2';
import { StorageCache } from 'src/app/service/storageCache.service';
import { PageBase } from 'src/app/models/pageBase';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css', '../../../app.component.css'],
})
export class EditUserComponent implements OnInit, PageBase {
  titlePage: string='EDITAR MI USUARIO';
  public loading: boolean = false;
  public errorMessage: string = '';
  public user: UserBaseResponse | undefined;
  public userRequest: UserUpdateRequest | undefined;
  public passwordRequest: ChangePasswordRequest = {
    newPassword: '',
  };

  constructor(
    private route: Router,
    private userService: UserService,
    private routeActive: ActivatedRoute,
    private storage: StorageCache
  ) {}
  
  ngOnInit(): void {
    this.loading = true;
    this.userService.apiUsersGetMine$Json$Response().subscribe(
      (res) => {
        if (res.status == HttpStatusCode.Ok) {
          this.loading = false;
          if (
            res.body.content?.listUser !== null &&
            res.body.content?.listUser !== undefined
          )
            this.user = res.body.content?.listUser[0];
        }
      },
      (err) => {
        this.loading = false;

        if (err.error.code == 150)
          this.errorMessage = 'Es necesario llenar todos los campos';
        else this.errorMessage = err.error.message;
        Swal.fire({
          icon: 'error',
          text: this.errorMessage,
          confirmButtonColor: '#d33',
        });
      }
    );
  }
  changePassword(): void {
    if (this.passwordRequest === undefined) {
      Swal.fire({
        icon: 'error',
        text: 'Debe ingresar una contraseña',
        confirmButtonColor: '#d33',
      });
      return;
    }
    this.loading = true;
    this.userService
      .apiUsersChangepasswordPost$Json$Response({
        body: this.passwordRequest,
      })
      .subscribe((res) => {
        if (res.status == HttpStatusCode.Ok) {
          this.loading = false;
          Swal.fire({
            icon: 'success',
            text: 'Processo Correcto, Por tu seguridad te pidimos que vuelvas a ingresar para actualizar los datos.',
            confirmButtonText: 'Continuar',
          }).then(()=>{
            this.route.navigate(['/login']);
          });
        }
      });
  }
  updateUser(): void {
    this.loading = true;
    this.userRequest = {
      birthDate: new Date(this.user?.birthDate!),
      dni : this.user?.dni!,
      firstLastName : this.user?.firstLastName!,
      firstName : this.user?.firstName!,
      userName : this.user?.userName!,
      secondLastName : this.user?.secondLastName!,
      secondName : this.user?.secondName!,
    };

    this.userService
      .apiUsersPut$Json$Response({ body: this.userRequest })
      .subscribe(
        (res) => {
          if (res.status == HttpStatusCode.Ok) {
            this.loading = false;
            Swal.fire({
              icon: 'success',
              text: 'Processo Correcto, Por tu seguridad te pidimos que vuelvas a ingresar para actualizar los datos.',
              confirmButtonText: 'Continuar',
            }).then(()=>{
              this.route.navigate(['/login']);
            });
          }
        },
        (err) => {
          this.loading = false;
          if (err.error.code == 150)
            this.errorMessage = 'Es necesario llenar todos los campos';
          else this.errorMessage = err.error.message;
          Swal.fire({
            icon: 'error',
            text: this.errorMessage,
            confirmButtonColor: '#d33',
          });
        }
      );
  }
}
