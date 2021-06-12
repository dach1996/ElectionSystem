import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { EventBaseResponse } from 'src/app/serviceApi/models';

@Component({
  selector: 'app-event-modal-select',
  templateUrl: './event-modal-select.component.html',
  styleUrls: ['./event-modal-select.component.css'],
})
export class EventModalSelectComponent implements OnInit {
  @Input() event: EventBaseResponse | undefined;

  constructor(public activeModal: NgbActiveModal) {}
  ngOnInit(): void {
  }
}
