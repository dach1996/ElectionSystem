import { HttpStatusCode } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { PageBase } from 'src/app/models/pageBase';
import { EventBaseResponse } from 'src/app/serviceApi/models';
import { EventService } from 'src/app/serviceApi/services';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-event-details',
  templateUrl: './event-details.component.html',
  styleUrls: ['./event-details.component.css', '../../../../app.component.css'],
})
export class EventDetailsComponent implements OnInit, PageBase {
  public event?: EventBaseResponse;
  constructor(
    private activeRouter: ActivatedRoute,
    private eventService: EventService
  ) {}
  public loading: boolean = false;
  public titlePage: string = '';
  public errorMessage: string = '';

  ngOnInit(): void {
    this.loading = true;
    this.activeRouter.parent?.params.subscribe((paramsMap) => {
      let idEvent = Number(paramsMap.idEvent);

      this.eventService.apiEventsIdGet$Json$Response({ id: idEvent }).subscribe(
        (res) => {
          if (res.status == HttpStatusCode.Ok) {
            this.loading = false;
            this.event = <EventBaseResponse>res.body?.content?.listEvents?.[0];
            if (res.body.content?.listEvents?.length == 0)
              Swal.fire({
                icon: 'error',
                text: 'Existió un error, no se encontró el evento.',
                confirmButtonColor: '#d33',
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
    });
  }
  startStopEvent() {
    this.loading = true;
    this.eventService
      .apiStartStopPost$Json$Response({
        body:{
          daysAllow:5
        },
        idEvent: this.event?.id!,
      })
      .subscribe(
        (res) => {
          if (res.status == HttpStatusCode.Ok) {
            this.loading = false;
            Swal.fire({
              icon: 'success',
              text: 'Evento: ' + this.event?.name + ' ha sido Actualizado',
              confirmButtonText: 'Continuar',
            }).then(()=>{
                this.ngOnInit();
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
