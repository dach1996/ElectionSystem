/* tslint:disable */
/* eslint-disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
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
import { AdditionalInformation, AdditionalInformationCandidate } from '../models/candidate-information-additional';

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
  static readonly ApiEventsIdEventCandidatesIdCandidateGetPath = '/api/events/{idEvent}/candidates/{idUser}';


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

    idEvent: number;
    idUser: number;
  }): Observable<StrictHttpResponse<ResponseGeneric<CandidateGetResponse>>> {

    const rb = new RequestBuilder(this.rootUrl, CandidateService.ApiEventsIdEventCandidatesIdCandidateGetPath, 'get');
    if (params) {
      rb.query('Offset', params.Offset, {});
      rb.query('OrderBy', params.OrderBy, {});
      rb.query('Limit', params.Limit, {});
      rb.path('idEvent', params.idEvent, {});
      rb.path('idUser', params.idUser, {});
    }
    rb.header('Authorization', localStorage.getItem('token')!);
    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<ResponseGeneric<CandidateGetResponse>>
      })
    );
  }

  /**
   * Path part for operation apiEventsIdEventCandidatesIdCandidatePut
   */
  static readonly ApiEventsIdEventCandidatesIdCandidatePutPath = '/api/events/{idEvent}/candidates';



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
    body?: AdditionalInformationCandidate
  }): Observable<StrictHttpResponse<ResponseGeneric<CandidateUpdateResponse>>> {

    let additionalInformation: AdditionalInformation ={
      additionalInformation: params?.body
    }
    const rb = new RequestBuilder(this.rootUrl, CandidateService.ApiEventsIdEventCandidatesIdCandidatePutPath, 'put');
    if (params) {
      rb.path('idEvent', params.idEvent, {});
      rb.body(additionalInformation, 'application/*+json');
    }
    rb.header('Authorization', localStorage.getItem('token')!);
    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<ResponseGeneric<CandidateUpdateResponse>>;
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
  }): Observable<StrictHttpResponse<ResponseGeneric<CandidateDesactiveResponse>>> {

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
        return r as StrictHttpResponse<ResponseGeneric<CandidateDesactiveResponse>>;
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
  apiUploadImage$Json$Response(params: {
    idEvent: number;
    Image: File;
  }): Observable<any> {
    const formData = new FormData();
    var url =
      this.rootUrl +
      CandidateService.ApiEventsIdEventCandidatesImagePostPath.replace(
        '{idEvent}',
        params.idEvent.toString()
      );
    // Store form name as "file" with file data
    formData.append('Image', params.Image);

    // Make http post request over api
    // with formData as req

    let headers = new HttpHeaders();
    headers = headers.append(
      'Authorization',
      `${localStorage.getItem('token')!}`
    );
    return this.http.post(url, formData, { headers: headers });
  
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
  }): Observable<StrictHttpResponse<ResponseGeneric<UnitGenericResponse>>> {

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
        return r as StrictHttpResponse<ResponseGeneric<UnitGenericResponse>>
      })
    );
  }



}
