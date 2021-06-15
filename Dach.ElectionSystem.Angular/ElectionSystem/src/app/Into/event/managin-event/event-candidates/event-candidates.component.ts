import { HttpStatusCode } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { PageBase } from 'src/app/models/pageBase';
import { CandidateBaseResponse } from 'src/app/serviceApi/models';
import { CandidateService } from 'src/app/serviceApi/services';
import Swal from 'sweetalert2';
import { EventAdministratorModalComponent } from '../event-administrator-modal/event-administrator-modal.component';

@Component({
  selector: 'app-event-candidates',
  templateUrl: './event-candidates.component.html',
  styleUrls: [
    './event-candidates.component.css',
    '../../../../app.component.css',
  ],
})
export class EventCandidatesComponent implements OnInit, PageBase {
  loading: boolean = false;
  titlePage: string = '';
  errorMessage: string = '';
  idEvent?: number;
  public listCandidate?: Array<CandidateBaseResponse>;
  constructor(
    private candidateService: CandidateService,
    private activeRouter: ActivatedRoute,
    private modalService: NgbModal
  ) {}
  ngOnInit(): void {
    this.loading = true;
    this.activeRouter.parent?.params.subscribe((paramsMap) => {
      this.idEvent = Number(paramsMap.idEvent);
      this.candidateService
        .apiEventsIdEventCandidatesGet$Json$Response({ idEvent: this.idEvent })
        .subscribe(
          (res) => {
            if (res.status == HttpStatusCode.Ok) {
              this.listCandidate = res.body.content?.listCandidate!;
              this.loading = false;
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
  desactiveCandidate(idCandidate: number): void {
    this.candidateService
      .apiEventsIdEventCandidatesIdCandidateDelete$Json$Response({
        idCandidate: idCandidate,
        idEvent: this.idEvent!,
      })
      .subscribe(
        (res) => {
          if (res.status == HttpStatusCode.Ok) {
            this.loading = false;
            Swal.fire({
              icon: 'success',
              text: 'El Candidato ha sido: '+ (res.body.content?.isActive?'Activado':'Desactivado'),
              confirmButtonText: 'Continuar',
            }).then(() => {
              this.ngOnInit();
            });
          }
        },
        (err) => {
          this.loading = false;
          if (err.error.code == 131)
            this.errorMessage =
              'El usuario seleccionado ya es Participante en el evento';
          else this.errorMessage = err.error.message;
          Swal.fire({
            icon: 'error',
            text: this.errorMessage,
            confirmButtonColor: '#d33',
          });
        }
      );
  }

  openEventAdministratorModal(): void {
    let modal = this.modalService.open(EventAdministratorModalComponent, {
      size: 'lg',
      centered: true,
    });
    modal.componentInstance.titlePage = 'CANDIDATO';
    modal.componentInstance.idEvent = this.idEvent;
    modal.componentInstance.messageEvent.subscribe(() => {
      modal.close();
      this.ngOnInit();
    });
  }
}
