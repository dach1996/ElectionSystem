import { HttpStatusCode } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PageBase } from 'src/app/models/pageBase';
import { CandidateBaseResponse } from 'src/app/serviceApi/models';
import { CandidateService } from 'src/app/serviceApi/services';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-event-candidates',
  templateUrl: './event-candidates.component.html',
  styleUrls: ['./event-candidates.component.css'],
})
export class EventCandidatesComponent implements OnInit, PageBase {
  loading: boolean = false;
  titlePage: string = '';
  errorMessage: string = '';
  public listCandidate?: Array<CandidateBaseResponse>;
  constructor(
    private candidateService: CandidateService,
    private activeRouter: ActivatedRoute
  ) {}
  ngOnInit(): void {
    this.loading = true;
    this.activeRouter.parent?.params.subscribe((paramsMap) => {
      let idEvent = Number(paramsMap.idEvent);
      this.candidateService
        .apiEventsIdEventCandidatesGet$Json$Response({ idEvent: idEvent })
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
}
