import { HttpStatusCode } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { StorageCache } from 'src/app/service/storageCache.service';
import {
  EventBaseResponse,
  OrderBy,
  TypeFilterEvent,
  UserBaseResponse,
} from 'src/app/serviceApi/models';
import { EventService } from 'src/app/serviceApi/services';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-event',
  templateUrl: './event.component.html',
  styleUrls: ['./event.component.css', '../../../app.component.css'],
})
export class EventComponent implements OnInit {
  public loading: boolean = false;
  public errorMessage: string = '';
  public listEvents: Array<EventBaseResponse> = [];
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
    private eventService: EventService
  ) {}
  loadEvents(): void {
    this.loading = true;
    this.eventService.apiEventsGet$Json$Response(this.eventRequest).subscribe(
      (res) => {
        if (res.status == HttpStatusCode.Ok) {
          this.listEvents = res.body.content?.listEvents!;
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
  desactiveEvent(idEvent: number): void {
    this.loading = true;
    this.eventService
      .apiEventsIdDelete$Json$Response({ id: idEvent })
      .subscribe(
        res => {
          if (res.status == HttpStatusCode.Ok) {
            this.loading = false;
            Swal.fire({
              icon: 'success',
              text: 'Evento ha sido Delete',
              confirmButtonText: 'Continuar',
            }).then((result) => {
              this.route.navigate(['/dashboard/event']);
            });
          }
        },
        err => {
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

  ngOnInit(): void {
    this.loadEvents();
  }
}
