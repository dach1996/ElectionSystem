import { HttpStatusCode } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { PageBase } from 'src/app/models/pageBase';
import { StorageCache } from 'src/app/service/storageCache.service';
import {
  EventBaseResponse,
  OrderBy,
  TypeFilterEvent,
  UserBaseResponse,
} from 'src/app/serviceApi/models';
import { EventService, UserService } from 'src/app/serviceApi/services';
import Swal from 'sweetalert2';
 
@Component({
  selector: 'app-list-user',
  templateUrl: './list-user.component.html',
  styleUrls: ['./list-user.component.css', '../../../app.component.css']
})
export class ListUserComponent implements OnInit, PageBase {
  public loading: boolean = false;
  public errorMessage: string = '';
  public listUser: Array<UserBaseResponse> = [];
  public userCurrent: UserBaseResponse | undefined;
  public eventRequest = {
    Offset: 0,
    OrderBy: OrderBy.Asc,
    Limit: 10,
    Name: '',
    Category: '',
    TypeFilter: TypeFilterEvent.All,
    id: null,
  };
  constructor(
    private route: Router,
    private storage: StorageCache,
    private userService: UserService,
    private modalService: NgbModal
  ) {}
  titlePage: string = 'LISTA DE USUARIOS';
  loadEvents(): void {
    this.loading = true;
    this.userService.apiUsersGetAll$Json$Response({
Limit:100,
Offset:0
    }).subscribe(
      (res) => {
        if (res.status == HttpStatusCode.Ok) {
          this.listUser = res.body.content?.listUser!;
          this.userCurrent = this.storage.UserCurrent;
        }
      },
      (err) => {
        if (err.error.code == 150)
          this.errorMessage = 'Es necesario llenar todos los campos';
        else this.errorMessage = err.error.message;
        Swal.fire({
          icon: 'error',
          text: 'Error: ' + this.errorMessage,
          confirmButtonColor: '#d33',
        });
      },
      () => (this.loading = false)
    );
  }
 /* desactiveEvent(idEvent: number): void {
    this.loading = true;
    this.eventService
      .apiEventsIdDelete$Json$Response({ id: idEvent })
      .subscribe(
        (res) => {
          if (res.status == HttpStatusCode.Ok) {
            this.loading = false;
            Swal.fire({
              icon: 'success',
              text: 'Evento ha sido Eliminado con éxito',
              confirmButtonText: 'Continuar',
            }).then((result) => {
              this.ngOnInit();
            });
          }
        },
        (err) => {
          if (err.error.code == 150)
            this.errorMessage = 'Es necesario llenar todos los campos';
          else this.errorMessage = err.error.message;
          Swal.fire({
            icon: 'error',
            text: 'Error: ' + this.errorMessage,
            confirmButtonColor: '#d33',
          });
          this.loading = false;
        }
      );
  }
  openEventModalSelected(event:EventBaseResponse) {
    //const modalEvent = this.modalService.open( );
   //modalEvent.componentInstance.event = event;
  }*/
  ngOnInit(): void {
    this.loadEvents();
  }
}
