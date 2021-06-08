import { HttpStatusCode } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {  OrderBy, TypeFilterEvent } from 'src/app/serviceApi/models';
import { EventGetViewModel } from 'src/app/serviceApi/models/ViewModels/EventGetViewModel';
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
  public listEvents: Array<EventGetViewModel> = [];
  public eventRequest = {
    Offset: 0,
    OrderBy: OrderBy.Asc,
    Limit: 10,
    Name: '',
    Category: '',
    TypeFilter: TypeFilterEvent.All,
    id: null,
  };
  constructor(private route: Router, private eventService: EventService) {}
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
