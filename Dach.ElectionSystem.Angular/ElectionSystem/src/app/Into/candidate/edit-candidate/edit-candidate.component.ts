import { HttpStatusCode } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { PageBase } from 'src/app/models/pageBase';
import { CandidateBaseResponse, OrderBy } from 'src/app/serviceApi/models';
import { AdditionalInformationCandidate } from 'src/app/serviceApi/models/candidate-information-additional';
import { CandidateService } from 'src/app/serviceApi/services';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-edit-candidate',
  templateUrl: './edit-candidate.component.html',
  styleUrls: ['./edit-candidate.component.css', '../../../app.component.css'],
})
export class EditCandidateComponent implements OnInit, PageBase {
  constructor(
    private candidateService: CandidateService,
    private activeRouter: ActivatedRoute
  ) {}
  loading: boolean = false;
  titlePage: string = 'EDITAR MI INFORMACIÓN DE CANDIDATO';
  errorMessage: string = '';
  candidate?: CandidateBaseResponse;
  information?: AdditionalInformationCandidate = {
    goals: '',
    likes: '',
    pastime: '',
    sports: '',
    urlVideo: '',
    alias: '',
  };
  idEvent?: number;
  imageFile: File | undefined;

  ngOnInit(): void {
    this.loading = true;
    this.activeRouter.paramMap.subscribe((paramsMap: ParamMap) => {
      let idEvent = Number(paramsMap.get('idEvent')!);
      let idUser = Number(paramsMap.get('idUser')!);
      this.idEvent = idEvent;
      this.candidateService
        .apiEventsIdEventCandidatesIdCandidateGet$Json$Response({
          Limit: 100,
          Offset: 0,
          OrderBy: OrderBy.Desc,
          idUser: idUser,
          idEvent: idEvent,
        })
        .subscribe(
          (res) => {
            if (res.status == HttpStatusCode.Ok) {
              this.loading = false;
              this.candidate = res.body?.content?.listCandidate?.[0];
              if (this.candidate?.additionalInformation!)
                this.information = <AdditionalInformationCandidate>(
                  JSON.parse(this.candidate.additionalInformation)
                );
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
  updateCandidate() {
    this.loading = true;
    let updateCandidate: AdditionalInformationCandidate = {
      goals: this.information?.goals!,
      likes: this.information?.likes!,
      pastime: this.information?.pastime!,
      sports: this.information?.sports!,
      urlVideo: this.information?.urlVideo!,
      alias: this.information?.alias,
    };
    this.candidateService
      .apiEventsIdEventCandidatesIdCandidatePut$Json$Response({
        idEvent: this.idEvent!,
        body: updateCandidate,
      })
      .subscribe(
        (res) => {
          if (res.status == HttpStatusCode.Ok) {
            this.loading = false;
            Swal.fire({
              icon: 'success',
              text: 'Sus  datos han sido actualizados con éxito',
              confirmButtonText: 'Continuar',
            }).then(() => {
              this.ngOnInit();
            });
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
  }
  changeImage(event: any) {
    this.imageFile = event.target.files[0];
  }
  updateImage() {
    if (this.imageFile === undefined) return;
    this.loading = true;
    this.candidateService
      .apiUploadImage$Json$Response({
        idEvent: this.idEvent!,
        Image: this.imageFile,
      })
      .subscribe(
        (res) => {
          if (res.code == HttpStatusCode.Ok) {
            this.loading = false;
            Swal.fire({
              icon: 'success',
              text: 'Imagen cargada exitosamente',
              confirmButtonText: 'Continuar',
            }).then(() => {
              this.ngOnInit();
            });
          }
        },
        (err) => {
          this.loading = false;
          if (err.error.code == 150)
            this.errorMessage = 'Es necesario llenar todos los campos';
          if (err.error.code == 141)
            this.errorMessage =
              'Número Máximo de imágenes de candidato alcanzado.';
          else this.errorMessage = err.error.message;
          Swal.fire({
            icon: 'error',
            text: this.errorMessage,
            confirmButtonColor: '#d33',
          });
        }
      );
  }

  deleteImage(image: string) {
    this.loading=true;
    let parts = image.split('/');
    let resoucer = parts[parts.length-1];
    if (resoucer === undefined) return;
    this.loading = true;
    this.candidateService
      .apiEventsIdEventCandidatesImageDelete$Json$Response({
        idEvent: this.idEvent!,
        NameResoruce: resoucer,
      })
      .subscribe(
        (res) => {
          if (res.body.code == HttpStatusCode.Ok) {
            this.loading = false;
            Swal.fire({
              icon: 'success',
              text: 'Imagen Borrada Exitosamente',
              confirmButtonText: 'Continuar',
            }).then(() => {
              this.ngOnInit();
            });
          }
        },
        (err) => {
          this.loading = false;
          if (err.error.code == 150)
            this.errorMessage = 'Es necesario llenar todos los campos';
          if (err.error.code == 141)
            this.errorMessage =
              'Error al intentar borrar la imágen';
          else this.errorMessage = err.error.message;
          Swal.fire({
            icon: 'error',
            text: this.errorMessage,
            confirmButtonColor: '#d33',
          });
        }
      );
  }
}
