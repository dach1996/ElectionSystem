import { HttpStatusCode } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { VoteBaseResponse } from 'src/app/serviceApi/models';
import { VoteService } from 'src/app/serviceApi/services';
import Swal from 'sweetalert2';
import { EventAdministratorModalComponent } from '../event-administrator-modal/event-administrator-modal.component';

@Component({
  selector: 'app-event-participants',
  templateUrl: './event-participants.component.html',
  styleUrls: ['./event-participants.component.css',
  '../../../../app.component.css']
})
export class EventParticipantsComponent implements OnInit {

  loading: boolean = false;
  titlePage: string = '';
  errorMessage: string = '';
  idEvent?: number;
  public listParticipants?: Array<VoteBaseResponse>;
  constructor(
    private voteService: VoteService,
    private activeRouter: ActivatedRoute,
    private modalService: NgbModal
  ) {}
  ngOnInit(): void {
    this.loading = true;
    this.activeRouter.parent?.params.subscribe((paramsMap) => {
      this.idEvent = Number(paramsMap.idEvent);
      this.voteService
        .apiVotesEventsIdEventGet$Json$Response({ idEvent: this.idEvent, Limit: 100})
        .subscribe(
          (res) => {
            if (res.status == HttpStatusCode.Ok) {
              this.listParticipants = res.body.content?.listVotes!;
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

  desactiveParticipant(idParticipant: number): void {
    this.voteService
      .apiVotesEventsIdEventUsersIdUserDelete$Json$Response({
        idUser: idParticipant,
        idEvent: this.idEvent!,
      })
      .subscribe(
        (res) => {
          if (res.status == HttpStatusCode.Ok) {
            this.loading = false;
            Swal.fire({
              icon: 'success',
              text: 'El Participante ha sido: '+ (res.body.content?.isActive?'Activado':'Desactivado'),
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
    modal.componentInstance.titlePage = 'PARTICIPANTE';
    modal.componentInstance.idEvent = this.idEvent;
    modal.componentInstance.messageEvent.subscribe(() => {
      modal.close();
      this.ngOnInit();
    });
  }
}
