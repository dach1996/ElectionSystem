/* tslint:disable */
/* eslint-disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { BaseService } from '../base-service';
import { ApiConfiguration } from '../api-configuration';
import { StrictHttpResponse } from '../strict-http-response';
import { RequestBuilder } from '../request-builder';
import { Observable } from 'rxjs';
import { map, filter } from 'rxjs/operators';

import { Candidate } from '../models/candidate';
import { CandidateCreateRequest } from '../models/candidate-create-request';
import { CandidateCreateResponse } from '../models/candidate-create-response';
import { CandidateDesactiveResponse } from '../models/candidate-desactive-response';
import { CandidateGetResponse } from '../models/candidate-get-response';
import { CandidateUpdateRequest } from '../models/candidate-update-request';
import { CandidateUpdateResponse } from '../models/candidate-update-response';
import { EventAdministrator } from '../models/event-administrator';
import { EventNumber } from '../models/event-number';
import { OrderBy } from '../models/order-by';
import { UnitGenericResponse } from '../models/unit-generic-response';
import { ResponseGeneric } from '../models/generic-response';

@Injectable({
  providedIn: 'root',
})
export class CandidateService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation apiEventsIdEventCandidatesGet
   */
  static readonly ApiEventsIdEventCandidatesGetPath = '/api/events/{idEvent}/candidates';

  /**
   * Consultar Candidatos de evento.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiEventsIdEventCandidatesGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEventsIdEventCandidatesGet$Json$Response(params: {
    idEvent: number;
  }): Observable<StrictHttpResponse<ResponseGeneric<CandidateGetResponse>>> {

    const rb = new RequestBuilder(this.rootUrl, CandidateService.ApiEventsIdEventCandidatesGetPath, 'get');
    if (params) {
      rb.query('Offset', 0, {});
      rb.query('OrderBy', 'Desc', {});
      rb.query('Limit', 100, {});
      rb.path('idEvent', params.idEvent, {});
    }
    rb.header('Authorization', localStorage.getItem('token')!);
    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<ResponseGeneric<CandidateGetResponse>>;
      })
    );
  }

  /**
   * Path part for operation apiEventsIdEventCandidatesPost
   */
  static readonly ApiEventsIdEventCandidatesPostPath = '/api/events/{idEvent}/candidates';

  /**
   * Crear Candidato.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiEventsIdEventCandidatesPost$Json()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiEventsIdEventCandidatesPost$Json$Response(params: {
    idEvent: number;
    body?: CandidateCreateRequest
  }): Observable<StrictHttpResponse<CandidateCreateResponse>> {

    const rb = new RequestBuilder(this.rootUrl, CandidateService.ApiEventsIdEventCandidatesPostPath, 'post');
    if (params) {
      rb.path('idEvent', params.idEvent, {});
      rb.body(params.body, 'application/*+json');
    }
    rb.header('Authorization', localStorage.getItem('token')!);
    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<CandidateCreateResponse>;
      })
    );
  }


  /**
   * Path part for operation apiEventsIdEventCandidatesIdCandidateGet
   */
  static readonly ApiEventsIdEventCandidatesIdCandidateGetPath = '/api/events/{idEvent}/candidates/{idCandidate}';


  /**
   * Consultar candidato de evento por Id.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiEventsIdEventCandidatesIdCandidateGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEventsIdEventCandidatesIdCandidateGet$Json$Response(params: {

    /**
     * Paginación
     */
    Offset: number;

    /**
     * Orden de Consulta
     */
    OrderBy: OrderBy;

    /**
     * Cantidad de Registros
     */
    Limit: number;

    /**
     * Total de candidatos en el evento
     */
    TotalCandidates?: number;
    idEvent: number;
    idCandidate: number;
  }): Observable<StrictHttpResponse<CandidateGetResponse>> {

    const rb = new RequestBuilder(this.rootUrl, CandidateService.ApiEventsIdEventCandidatesIdCandidateGetPath, 'get');
    if (params) {
      rb.query('Offset', params.Offset, {});
      rb.query('OrderBy', params.OrderBy, {});
      rb.query('Limit', params.Limit, {});
      rb.query('TotalCandidates', params.TotalCandidates, {});
      rb.path('idEvent', params.idEvent, {});
      rb.path('idCandidate', params.idCandidate, {});
    }
    rb.header('Authorization', localStorage.getItem('token')!);
    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<CandidateGetResponse>;
      })
    );
  }

  /**
   * Path part for operation apiEventsIdEventCandidatesIdCandidatePut
   */
  static readonly ApiEventsIdEventCandidatesIdCandidatePutPath = '/api/events/{idEvent}/candidates/{idCandidate}';



  /**
   * Actualizar Candidato.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiEventsIdEventCandidatesIdCandidatePut$Json()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiEventsIdEventCandidatesIdCandidatePut$Json$Response(params: {
    idEvent: number;
    idCandidate: number;
    body?: CandidateUpdateRequest
  }): Observable<StrictHttpResponse<CandidateUpdateResponse>> {

    const rb = new RequestBuilder(this.rootUrl, CandidateService.ApiEventsIdEventCandidatesIdCandidatePutPath, 'put');
    if (params) {
      rb.path('idEvent', params.idEvent, {});
      rb.path('idCandidate', params.idCandidate, {});
      rb.body(params.body, 'application/*+json');
    }
    rb.header('Authorization', localStorage.getItem('token')!);
    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<CandidateUpdateResponse>;
      })
    );
  }


  /**
   * Path part for operation apiEventsIdEventCandidatesIdCandidateDelete
   */
  static readonly ApiEventsIdEventCandidatesIdCandidateDeletePath = '/api/events/{idEvent}/candidates/{idCandidate}';

 

  /**
   * Activar / Desactivar Candidato.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiEventsIdEventCandidatesIdCandidateDelete$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEventsIdEventCandidatesIdCandidateDelete$Json$Response(params: {
    idEvent: number;
    idCandidate: number;
  }): Observable<StrictHttpResponse<CandidateDesactiveResponse>> {

    const rb = new RequestBuilder(this.rootUrl, CandidateService.ApiEventsIdEventCandidatesIdCandidateDeletePath, 'delete');
    if (params) {
      rb.path('idEvent', params.idEvent, {});
      rb.path('idCandidate', params.idCandidate, {});
    }
    rb.header('Authorization', localStorage.getItem('token')!);
    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<CandidateDesactiveResponse>;
      })
    );
  }

 

  /**
   * Path part for operation apiEventsIdEventCandidatesImagePost
   */
  static readonly ApiEventsIdEventCandidatesImagePostPath = '/api/events/{idEvent}/candidates/image';


  /**
   * Subir Imagen.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiEventsIdEventCandidatesImagePost$Json()` instead.
   *
   * This method sends `multipart/form-data` and handles request body of type `multipart/form-data`.
   */
  apiEventsIdEventCandidatesImagePost$Json$Response(params: {
    idEvent: number;
    body?: { 'Image': Blob, 'IdEvent'?: number, 'TokenModel.Username'?: string, 'TokenModel.Email'?: string, 'TokenModel.Id'?: string, 'UserContext.Id'?: number, 'UserContext.DNI'?: string, 'UserContext.UserName'?: string, 'UserContext.Password'?: string, 'UserContext.TemPassword'?: string, 'UserContext.FirstName'?: string, 'UserContext.SecondName'?: string, 'UserContext.FirstLastName'?: string, 'UserContext.SecondLastName'?: string, 'UserContext.BirthDate'?: string, 'UserContext.Email'?: string, 'UserContext.IsActive'?: boolean, 'UserContext.IsAdministrator'?: boolean, 'UserContext.ListEventAdministrator'?: Array<EventAdministrator>, 'UserContext.ListCandidate'?: Array<Candidate>, 'UserContext.EventNumber.Id'?: number, 'UserContext.EventNumber.IdUser'?: number, 'UserContext.EventNumber.NumberMaxEvent'?: number, 'UserContext.EventNumber.User.Id'?: number, 'UserContext.EventNumber.User.DNI'?: string, 'UserContext.EventNumber.User.UserName'?: string, 'UserContext.EventNumber.User.Password'?: string, 'UserContext.EventNumber.User.TemPassword'?: string, 'UserContext.EventNumber.User.FirstName'?: string, 'UserContext.EventNumber.User.SecondName'?: string, 'UserContext.EventNumber.User.FirstLastName'?: string, 'UserContext.EventNumber.User.SecondLastName'?: string, 'UserContext.EventNumber.User.BirthDate'?: string, 'UserContext.EventNumber.User.Email'?: string, 'UserContext.EventNumber.User.IsActive'?: boolean, 'UserContext.EventNumber.User.IsAdministrator'?: boolean, 'UserContext.EventNumber.User.ListEventAdministrator'?: Array<EventAdministrator>, 'UserContext.EventNumber.User.ListCandidate'?: Array<Candidate>, 'UserContext.EventNumber.User.EventNumber'?: EventNumber, 'PathRoot'?: string }
  }): Observable<StrictHttpResponse<UnitGenericResponse>> {

    const rb = new RequestBuilder(this.rootUrl, CandidateService.ApiEventsIdEventCandidatesImagePostPath, 'post');
    if (params) {
      rb.path('idEvent', params.idEvent, {});
      rb.body(params.body, 'multipart/form-data');
    }
    rb.header('Authorization', localStorage.getItem('token')!);
    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<UnitGenericResponse>;
      })
    );
  }



  /**
   * Path part for operation apiEventsIdEventCandidatesImageDelete
   */
  static readonly ApiEventsIdEventCandidatesImageDeletePath = '/api/events/{idEvent}/candidates/image';


  /**
   * Borrar Imagen.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiEventsIdEventCandidatesImageDelete$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEventsIdEventCandidatesImageDelete$Json$Response(params: {

    /**
     * Nombre de imagen a Borrar
     */
    NameResoruce: string;
    idEvent: number;
  }): Observable<StrictHttpResponse<UnitGenericResponse>> {

    const rb = new RequestBuilder(this.rootUrl, CandidateService.ApiEventsIdEventCandidatesImageDeletePath, 'delete');
    if (params) {
      rb.query('NameResoruce', params.NameResoruce, {});
      rb.path('idEvent', params.idEvent, {});
    }
    rb.header('Authorization', localStorage.getItem('token')!);
    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<UnitGenericResponse>;
      })
    );
  }



}
