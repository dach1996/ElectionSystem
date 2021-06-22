import { HttpStatusCode } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { PageBase } from 'src/app/models/pageBase';
import {
  EventBaseResponse,
  EventUpdateRequest,
} from 'src/app/serviceApi/models';
import { EventService } from 'src/app/serviceApi/services';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-event-edit',
  templateUrl: './event-edit.component.html',
  styleUrls: ['./event-edit.component.css', '../../../app.component.css'],
})
export class EventEditComponent implements OnInit, PageBase {
  public loading: boolean = false;
  public errorMessage: string = '';
  public idEvent: number | undefined;
  public event: EventBaseResponse | undefined;
  public imageFile: File | undefined;
  constructor(
    private route: Router,
    private eventService: EventService,
    private routeActive: ActivatedRoute
  ) {}
  titlePage: string = 'EDITAR EVENTO';
  ngOnInit(): void {
    this.loading = true;
    this.routeActive.paramMap.subscribe((paramsMap: ParamMap) => {
      this.idEvent = Number(paramsMap.get('idEvent')!);
      this.eventService
        .apiEventsIdGet$Json$Response({ id: this.idEvent })
        .subscribe(
          (res) => {
            if (res.status == HttpStatusCode.Ok) {
              this.loading = false;
              this.event = res.body?.content?.listEvents?.[0];
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
  updateEvent(): void {
    this.loading = true;
    let eventUpdate: EventUpdateRequest = {
      category: this.event?.category!,
      dateMaxRegisterParticipants: new Date(
        this.event?.dateMaxRegisterParticipants!
      ),
      description: this.event?.description!,
      maxPeople: this.event?.maxPeople!,
      numberMaxCandidate: this.event?.numberMaxCandidate!,
      name: this.event?.name!,
      numberMaxPeople: this.event?.numberMaxPeople!,
    };

    this.eventService
      .apiEventsIdPut$Json$Response({ id: this.event?.id!, body: eventUpdate })
      .subscribe(
        (res) => {
          if (res.status == HttpStatusCode.Ok) {
            this.loading = false;
            Swal.fire({
              icon: 'success',
              text: 'Evento: ' + this.event?.name + ' ha sido Actualizado',
              confirmButtonText: 'Continuar',
            }).then((result) => {
              this.route.navigate(['/dashboard/event']);
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
  changeImage(event: any) {
    this.imageFile = event.target.files[0];
  }
  updateImage(): void {
    if (this.imageFile === undefined) return;
    this.loading = true;
    this.eventService
      .apiEventsIdEventImagePost$Json$Response({
        idEvent: this.idEvent!,
        Image: this.imageFile,
      })
      .subscribe(
        (res) => {
          if (res.code == HttpStatusCode.Ok) {
            this.loading = false;
            Swal.fire({
              icon: 'success',
              text: 'Imagen cargada exitosamente',
              confirmButtonText: 'Continuar',
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
