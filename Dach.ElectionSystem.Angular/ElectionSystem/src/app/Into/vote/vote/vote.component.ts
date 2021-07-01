import { HttpStatusCode } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { PageBase } from 'src/app/models/pageBase';
import {
  CandidateBaseResponse,
  EventBaseResponse,
  OrderBy,
  TypeFilterEvent,
} from 'src/app/serviceApi/models';
import { CandidateService, EventService } from 'src/app/serviceApi/services';
import Swal from 'sweetalert2';
import { ModalDetailCandidateComponent } from '../modal-detail-candidate/modal-detail-candidate.component';

@Component({
  selector: 'app-vote',
  templateUrl: './vote.component.html',
  styleUrls: ['./vote.component.css', '../../../app.component.css'],
})
export class VoteComponent implements OnInit, PageBase {
  event?: EventBaseResponse;
  listEvents?: Array<EventBaseResponse>;
  listCandidates?: Array<CandidateBaseResponse>
  constructor(
    private eventService: EventService,
    private candidateService: CandidateService,
    private modalService: NgbModal
  ) {}
  loading: boolean = false;
  titlePage: string = 'PARTICIPAR EN EVENTO';
  errorMessage: string = '';
  private eventRequest = {
    Offset: 0,
    OrderBy: OrderBy.Asc,
    Limit: 100,
    TypeFilter: TypeFilterEvent.Participant,
  };
  ngOnInit(): void {
    this.loadEvents();
  }
  loadCandidates() {
    if (this.event?.id === null) return;
    this.loading = true;
    this.candidateService
      .apiEventsIdEventCandidatesGet$Json$Response({ idEvent: this.event?.id! })
      .subscribe(
        (res) => {
          if (res.status == HttpStatusCode.Ok) {
            this.listCandidates = res.body.content?.listCandidate!;
            if (this.listCandidates === null)
              Swal.fire({
                icon: 'error',
                text:
                  'Error: ' +
                  'No se encontraron candidatas registradas en el evento',
                confirmButtonColor: '#d33',
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
        },
        () => (this.loading = false)
      );
  }
  loadEvents(): void {
    this.loading = true;
    this.eventService.apiEventsGet$Json$Response(this.eventRequest).subscribe(
      (res) => {
        if (res.status == HttpStatusCode.Ok) {
          this.listEvents = res.body.content?.listEvents!;
          if (this.listEvents === null)
            Swal.fire({
              icon: 'error',
              text:
                'Error: ' +
                'No se encontraron envento en los que puedas participar',
              confirmButtonColor: '#d33',
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
      },
      () => (this.loading = false)
    );
  }
  openCandidateDetailModal(candidate: CandidateBaseResponse): void {
    let modal = this.modalService.open(ModalDetailCandidateComponent, {
      size: 'md',
      centered: true,
    });
    modal.componentInstance.titlePage = 'DETALLES DE CANDIDATO';
    modal.componentInstance.candidate = candidate;
    modal.componentInstance.event = this.event;
  }
}
