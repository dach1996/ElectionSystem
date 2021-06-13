import { HttpStatusCode } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { PageBase } from 'src/app/models/pageBase';
import { StorageCache } from 'src/app/service/storageCache.service';
import { EventBaseResponse } from 'src/app/serviceApi/models';
import { EventService } from 'src/app/serviceApi/services';
import { DatePipe } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-event-modal-select',
  templateUrl: './event-modal-select.component.html',
  styleUrls: ['./event-modal-select.component.css'],
})
export class EventModalSelectComponent implements OnInit, PageBase {
  @Input() event: EventBaseResponse | undefined;
  public hasRelationShip?: boolean;
  constructor(
    public activeModal: NgbActiveModal,
    private eventService: EventService,
    private storage: StorageCache,
    public datepipe: DatePipe,
    private route : Router
  ) {

    
  }
  errorMessage: string='';
  loading: boolean = false;
  titlePage: string = '';
  ngOnInit(): void {
    
    this.loading = true;
    this.eventService
      .apiEventsVerifyRelationShip$Json$Response({
        body: {
          idEvent: this.event?.id!,
          idUserComapare: this.storage.UserCurrent?.id!,
        },
      })
      .subscribe(
        (res) => {
          if (res.status == HttpStatusCode.Ok) {
            this.loading = false;
            this.hasRelationShip = true;
            this.datepipe.transform(this.event?.user?.birthDate, 'dd/MM/yyyy');
          }
        },
        (err) => {
          this.loading = false;
          this.hasRelationShip = false;
        }
      );
  }
  administratorEvent(idEvent:number):void{
    this.activeModal.close();
    this.route.navigate(['/dashboard/event/administrator/'+idEvent]);
  }
}
