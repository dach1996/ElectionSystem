import { HttpStatusCode } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { PageBase } from 'src/app/models/pageBase';
import { CandidateBaseResponse, OrderBy } from 'src/app/serviceApi/models';
import { CandidateService } from 'src/app/serviceApi/services';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-edit-candidate',
  templateUrl: './edit-candidate.component.html',
  styleUrls: ['./edit-candidate.component.css','../../../app.component.css']
})
export class EditCandidateComponent implements OnInit, PageBase {

  constructor(
    private candidateService: CandidateService,
    private activeRouter: ActivatedRoute
  ) { }
  loading: boolean=false;
  titlePage: string='EDITAR MI INFORMACIÓN DE CANDIDATO';
  errorMessage: string='';
  candidate? : CandidateBaseResponse;

  ngOnInit(): void {
    this.loading = true;
    this.activeRouter.paramMap.subscribe((paramsMap: ParamMap) => {
      let idEvent =  Number(paramsMap.get('idEvent')!);
      let idUser = Number(paramsMap.get('idUser')!);
      this.candidateService
        .apiEventsIdEventCandidatesIdCandidateGet$Json$Response({ 
          Limit:100,
          Offset:0,
          OrderBy:OrderBy.Desc,
          idUser : idUser,
          idEvent : idEvent 
        })
        .subscribe(
          (res) => {
            if (res.status == HttpStatusCode.Ok) {
              this.loading = false;
              this.candidate = res.body?.content?.listCandidate?.[0];
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
