import { HttpStatusCode } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PageBase } from 'src/app/models/pageBase';
import { EventCreateRequest } from 'src/app/serviceApi/models';
import { EventService } from 'src/app/serviceApi/services';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-create-edit-event',
  templateUrl: './create-event.component.html',
  styleUrls: ['./create-event.component.css', '../../../app.component.css'],
})

export class EventCreateComponent implements OnInit, PageBase {
  
  public loading: boolean = false;
  public errorMessage: string = '';
  public titlePage: string = 'CREAR NUEVO EVENTO';
  public eventCreateRequest: EventCreateRequest = {
    category: 'Elección de candidato',
    dateMaxRegisterParticipants: new Date(),
    description: '',
    maxPeople: false,
    name: '',
    numberMaxCandidate: 0,
    numberMaxPeople: 0,
  };

  constructor(private route: Router, private eventService: EventService) {}

  ngOnInit(): void {}
  createEvent(): void {
    this.loading = true;
    this.eventService
      .apiEventsPost$Json$Response({ body: this.eventCreateRequest })
      .subscribe(
        (res) => {
          if (res.status == HttpStatusCode.Ok) {
            this.loading = false;
            Swal.fire({
              icon: 'success',
              text:
                'Evento: ' + this.eventCreateRequest.name + ' ha sido Creado',
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
 
  


}
