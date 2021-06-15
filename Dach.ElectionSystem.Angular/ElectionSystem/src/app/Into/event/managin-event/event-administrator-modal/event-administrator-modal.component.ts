import { HttpStatusCode } from '@angular/common/http';
import { ThisReceiver } from '@angular/compiler';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { PageBase } from 'src/app/models/pageBase';
import { UserBaseResponse } from 'src/app/serviceApi/models';
import { CandidateService, UserService, VoteService } from 'src/app/serviceApi/services';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-event-administrator-modal',
  templateUrl: './event-administrator-modal.component.html',
  styleUrls: [
    './event-administrator-modal.component.css',
    '../../../../app.component.css',
  ],
})
export class EventAdministratorModalComponent implements OnInit, PageBase {
  
  @Output() messageEvent = new EventEmitter<void>();
  constructor(
    private userService: UserService,
    private candidateService: CandidateService,
    private voteService: VoteService) {}
  loading: boolean = false;
  titlePage: string = '';
  errorMessage: string = '';
  idEvent? : number; 

  public listUser?: Array<UserBaseResponse>;


  ngOnInit(): void {
    this.loading = true;
    this.userService
      .apiUsersGetAll$Json$Response({
        Limit: 100,
        Offset: 0,
      })
      .subscribe(
        (res) => {
          if (res.status == HttpStatusCode.Ok) {
            this.listUser = res.body.content?.listUser!;
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

  assignUserEvent(idUser:number): void {
    this.loading=true
    switch (this.titlePage) {
      case 'CANDIDATO':
        {
            this.candidateService.apiEventsIdEventCandidatesPost$Json$Response(
              {
                idEvent: this.idEvent!,
                body: {idUser: idUser}
              }              
            ).subscribe(
              res=>{
                if (res.status == HttpStatusCode.Ok) {
                  this.loading = false;
                  Swal.fire({
                    icon: 'success',
                    text: 'El usuario ha sido registrado  como Candidato al evento.',
                    confirmButtonText: 'Continuar',
                  }).then(()=>{
                    this.messageEvent.emit();
                  });
                }
              },
              err=>{
                this.loading = false;
                if (err.error.code == 137)
                  this.errorMessage = 'El usuario seleccionado ya es candidato en el evento';
                else this.errorMessage = err.error.message;
                Swal.fire({
                  icon: 'error',
                  text: this.errorMessage,
                  confirmButtonColor: '#d33',
                });
              }
            )
        }
        break;
      case 'PARTICIPANTE':
        this.voteService.apiVotesEventsIdEventUsersIdUserPost$Json$Response(
          {
            idEvent: this.idEvent!,
            idUser: idUser
          }              
        ).subscribe(
          res=>{
            if (res.status == HttpStatusCode.Ok) {
              this.loading = false;
              Swal.fire({
                icon: 'success',
                text: 'El usuario ha sido registrado como Participante en evento.',
                confirmButtonText: 'Continuar',
              }).then(()=>{
                this.messageEvent.emit();
              });
            }
          },
          err=>{
            this.loading = false;
            if (err.error.code == 131)
              this.errorMessage = 'El usuario seleccionado ya es Participante en el evento';
            else this.errorMessage = err.error.message;
            Swal.fire({
              icon: 'error',
              text: this.errorMessage,
              confirmButtonColor: '#d33',
            });
          }
        )
        break;
    }
  }
}
