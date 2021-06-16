import { HttpStatusCode } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { PageBase } from 'src/app/models/pageBase';
import { EventBaseResponse, OrderBy, TypeFilterEvent } from 'src/app/serviceApi/models';
import { EventService } from 'src/app/serviceApi/services';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-records-participant',
  templateUrl: './records-participant.component.html',
  styleUrls: ['./records-participant.component.css', '../../../app.component.css']
})
export class RecordsParticipantComponent implements OnInit , PageBase {

  constructor(
    private eventService: EventService
  ) { }
  errorMessage: string = '';
  loading: boolean = false;
  titlePage: string = 'MIS REGISTROS EN EVENTOS';
  public listEvents?: Array<EventBaseResponse>;
  
  private eventRequest = {
    Offset: 0,
    OrderBy: OrderBy.Asc,
    Limit: 100,
    TypeFilter: TypeFilterEvent.Participant,
  };
  loadEvents(): void {
    this.loading = true;
    this.eventService.apiEventsGet$Json$Response(this.eventRequest).subscribe(
      (res) => {
        if (res.status == HttpStatusCode.Ok) {
          this.listEvents = res.body.content?.listEvents!;
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
  ngOnInit(): void {
    this.loadEvents();
  }
}
