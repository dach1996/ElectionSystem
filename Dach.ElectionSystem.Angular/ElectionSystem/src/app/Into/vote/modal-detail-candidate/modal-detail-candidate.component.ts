import { DatePipe } from '@angular/common';
import { HttpStatusCode } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { PageBase } from 'src/app/models/pageBase';
import { StorageCache } from 'src/app/service/storageCache.service';
import {
  CandidateBaseResponse,
  EventBaseResponse,
} from 'src/app/serviceApi/models';
import { AdditionalInformationCandidate } from 'src/app/serviceApi/models/candidate-information-additional';
import { VoteService } from 'src/app/serviceApi/services';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-modal-detail-candidate',
  templateUrl: './modal-detail-candidate.component.html',
  styleUrls: ['./modal-detail-candidate.component.css'],
})
export class ModalDetailCandidateComponent implements OnInit, PageBase {
  errorMessage: string = '';
  loading: boolean = false;
  titlePage: string = '';
  candidate: CandidateBaseResponse | undefined;
  event?: EventBaseResponse;
  hasVote: boolean = false;

  public hasRelationShip?: boolean;
  constructor(
    public activeModal: NgbActiveModal,
    private storage: StorageCache,
    public datepipe: DatePipe,
    private voteService: VoteService
  ) {}

  ngOnInit(): void {
    const tag = document.createElement('script');
    tag.src = 'https://www.youtube.com/iframe_api';
    document.body.appendChild(tag);
    this.loading = true;
    this.voteService
      .apiVotesEventsIdEventGet$Json$Response({
        Limit: 100,
        idEvent: this.event?.id!,
      })
      .subscribe(
        (res) => {
          if (res.status == HttpStatusCode.Ok) {
            let voteUserCurrent = res.body.content?.listVotes?.find(
              (v) => v.idUser == this.storage.UserCurrent?.id
            );
            if (this.candidate?.additionalInformation!)
              this.candidate.information = <AdditionalInformationCandidate>(
                JSON.parse(this.candidate.additionalInformation)
              );
            if (voteUserCurrent !== null && voteUserCurrent !== undefined)
              this.hasVote = voteUserCurrent?.hasVote!;
          }
        },
        (err) => {
          if (err.error.code == 150)
            this.errorMessage = 'Es necesario llenar todos los campos';
          else this.errorMessage = err.error.message;
          Swal.fire({
            icon: 'error',
            text: 'Error: ' + 'No se encontró Registros',
            confirmButtonColor: '#d33',
          });
        },
        () => (this.loading = false)
      );
  }
  voteCandidate(): void {
    this.loading = true;
    this.voteService
      .apiVotesEventsIdEventCandidatesIdCandidatePut$Json$Response({
        idCandidate: this.candidate?.id!,
        idEvent: this.event?.id!,
      })
      .subscribe(
        (res) => {
          if (res.status == HttpStatusCode.Ok) {
            Swal.fire({
              icon: 'success',
              text: 'Evento: ' + this.event?.name + ' ha sido Actualizado',
              confirmButtonText: 'Continuar',
            });
          }
        },
        (err) => {
          this.errorMessage = err.error.message;
          Swal.fire({
            icon: 'error',
            text: 'Error: ' + this.errorMessage,
            confirmButtonColor: '#d33',
          });
        },
        () => (this.loading = false)
      );
  }

  extratIdFromVideo(url: string): string {
    let results = url.match('v=([a-zA-Z0-9]+)&?');
    if (results !== null) return results[1];
    else return '';
  }
}
