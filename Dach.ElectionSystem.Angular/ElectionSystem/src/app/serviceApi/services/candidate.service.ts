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
   * To access only the response body, use `apiEventsIdEventCandidatesGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEventsIdEventCandidatesGet$Plain$Response(params: {

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
  }): Observable<StrictHttpResponse<CandidateGetResponse>> {

    const rb = new RequestBuilder(this.rootUrl, CandidateService.ApiEventsIdEventCandidatesGetPath, 'get');
    if (params) {
      rb.query('Offset', params.Offset, {});
      rb.query('OrderBy', params.OrderBy, {});
      rb.query('Limit', params.Limit, {});
      rb.query('TotalCandidates', params.TotalCandidates, {});
      rb.path('idEvent', params.idEvent, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<CandidateGetResponse>;
      })
    );
  }

  /**
   * Consultar Candidatos de evento.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiEventsIdEventCandidatesGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEventsIdEventCandidatesGet$Plain(params: {

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
  }): Observable<CandidateGetResponse> {

    return this.apiEventsIdEventCandidatesGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<CandidateGetResponse>) => r.body as CandidateGetResponse)
    );
  }

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
  }): Observable<StrictHttpResponse<CandidateGetResponse>> {

    const rb = new RequestBuilder(this.rootUrl, CandidateService.ApiEventsIdEventCandidatesGetPath, 'get');
    if (params) {
      rb.query('Offset', params.Offset, {});
      rb.query('OrderBy', params.OrderBy, {});
      rb.query('Limit', params.Limit, {});
      rb.query('TotalCandidates', params.TotalCandidates, {});
      rb.path('idEvent', params.idEvent, {});
    }

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
   * Consultar Candidatos de evento.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiEventsIdEventCandidatesGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEventsIdEventCandidatesGet$Json(params: {

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
  }): Observable<CandidateGetResponse> {

    return this.apiEventsIdEventCandidatesGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<CandidateGetResponse>) => r.body as CandidateGetResponse)
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
   * To access only the response body, use `apiEventsIdEventCandidatesPost$Plain()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiEventsIdEventCandidatesPost$Plain$Response(params: {
    idEvent: number;
    body?: CandidateCreateRequest
  }): Observable<StrictHttpResponse<CandidateCreateResponse>> {

    const rb = new RequestBuilder(this.rootUrl, CandidateService.ApiEventsIdEventCandidatesPostPath, 'post');
    if (params) {
      rb.path('idEvent', params.idEvent, {});
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<CandidateCreateResponse>;
      })
    );
  }

  /**
   * Crear Candidato.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiEventsIdEventCandidatesPost$Plain$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiEventsIdEventCandidatesPost$Plain(params: {
    idEvent: number;
    body?: CandidateCreateRequest
  }): Observable<CandidateCreateResponse> {

    return this.apiEventsIdEventCandidatesPost$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<CandidateCreateResponse>) => r.body as CandidateCreateResponse)
    );
  }

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
   * Crear Candidato.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiEventsIdEventCandidatesPost$Json$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiEventsIdEventCandidatesPost$Json(params: {
    idEvent: number;
    body?: CandidateCreateRequest
  }): Observable<CandidateCreateResponse> {

    return this.apiEventsIdEventCandidatesPost$Json$Response(params).pipe(
      map((r: StrictHttpResponse<CandidateCreateResponse>) => r.body as CandidateCreateResponse)
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
   * To access only the response body, use `apiEventsIdEventCandidatesIdCandidateGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEventsIdEventCandidatesIdCandidateGet$Plain$Response(params: {

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

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<CandidateGetResponse>;
      })
    );
  }

  /**
   * Consultar candidato de evento por Id.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiEventsIdEventCandidatesIdCandidateGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEventsIdEventCandidatesIdCandidateGet$Plain(params: {

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
  }): Observable<CandidateGetResponse> {

    return this.apiEventsIdEventCandidatesIdCandidateGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<CandidateGetResponse>) => r.body as CandidateGetResponse)
    );
  }

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
   * Consultar candidato de evento por Id.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiEventsIdEventCandidatesIdCandidateGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEventsIdEventCandidatesIdCandidateGet$Json(params: {

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
  }): Observable<CandidateGetResponse> {

    return this.apiEventsIdEventCandidatesIdCandidateGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<CandidateGetResponse>) => r.body as CandidateGetResponse)
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
   * To access only the response body, use `apiEventsIdEventCandidatesIdCandidatePut$Plain()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiEventsIdEventCandidatesIdCandidatePut$Plain$Response(params: {
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

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<CandidateUpdateResponse>;
      })
    );
  }

  /**
   * Actualizar Candidato.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiEventsIdEventCandidatesIdCandidatePut$Plain$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiEventsIdEventCandidatesIdCandidatePut$Plain(params: {
    idEvent: number;
    idCandidate: number;
    body?: CandidateUpdateRequest
  }): Observable<CandidateUpdateResponse> {

    return this.apiEventsIdEventCandidatesIdCandidatePut$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<CandidateUpdateResponse>) => r.body as CandidateUpdateResponse)
    );
  }

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
   * Actualizar Candidato.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiEventsIdEventCandidatesIdCandidatePut$Json$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiEventsIdEventCandidatesIdCandidatePut$Json(params: {
    idEvent: number;
    idCandidate: number;
    body?: CandidateUpdateRequest
  }): Observable<CandidateUpdateResponse> {

    return this.apiEventsIdEventCandidatesIdCandidatePut$Json$Response(params).pipe(
      map((r: StrictHttpResponse<CandidateUpdateResponse>) => r.body as CandidateUpdateResponse)
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
   * To access only the response body, use `apiEventsIdEventCandidatesIdCandidateDelete$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEventsIdEventCandidatesIdCandidateDelete$Plain$Response(params: {
    idEvent: number;
    idCandidate: number;
  }): Observable<StrictHttpResponse<CandidateDesactiveResponse>> {

    const rb = new RequestBuilder(this.rootUrl, CandidateService.ApiEventsIdEventCandidatesIdCandidateDeletePath, 'delete');
    if (params) {
      rb.path('idEvent', params.idEvent, {});
      rb.path('idCandidate', params.idCandidate, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<CandidateDesactiveResponse>;
      })
    );
  }

  /**
   * Activar / Desactivar Candidato.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiEventsIdEventCandidatesIdCandidateDelete$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEventsIdEventCandidatesIdCandidateDelete$Plain(params: {
    idEvent: number;
    idCandidate: number;
  }): Observable<CandidateDesactiveResponse> {

    return this.apiEventsIdEventCandidatesIdCandidateDelete$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<CandidateDesactiveResponse>) => r.body as CandidateDesactiveResponse)
    );
  }

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
   * Activar / Desactivar Candidato.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiEventsIdEventCandidatesIdCandidateDelete$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEventsIdEventCandidatesIdCandidateDelete$Json(params: {
    idEvent: number;
    idCandidate: number;
  }): Observable<CandidateDesactiveResponse> {

    return this.apiEventsIdEventCandidatesIdCandidateDelete$Json$Response(params).pipe(
      map((r: StrictHttpResponse<CandidateDesactiveResponse>) => r.body as CandidateDesactiveResponse)
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
   * To access only the response body, use `apiEventsIdEventCandidatesImagePost$Plain()` instead.
   *
   * This method sends `multipart/form-data` and handles request body of type `multipart/form-data`.
   */
  apiEventsIdEventCandidatesImagePost$Plain$Response(params: {
    idEvent: number;
    body?: { 'Image': Blob, 'IdEvent'?: number, 'TokenModel.Username'?: string, 'TokenModel.Email'?: string, 'TokenModel.Id'?: string, 'UserContext.Id'?: number, 'UserContext.DNI'?: string, 'UserContext.UserName'?: string, 'UserContext.Password'?: string, 'UserContext.TemPassword'?: string, 'UserContext.FirstName'?: string, 'UserContext.SecondName'?: string, 'UserContext.FirstLastName'?: string, 'UserContext.SecondLastName'?: string, 'UserContext.BirthDate'?: string, 'UserContext.Email'?: string, 'UserContext.IsActive'?: boolean, 'UserContext.IsAdministrator'?: boolean, 'UserContext.ListEventAdministrator'?: Array<EventAdministrator>, 'UserContext.ListCandidate'?: Array<Candidate>, 'UserContext.EventNumber.Id'?: number, 'UserContext.EventNumber.IdUser'?: number, 'UserContext.EventNumber.NumberMaxEvent'?: number, 'UserContext.EventNumber.User.Id'?: number, 'UserContext.EventNumber.User.DNI'?: string, 'UserContext.EventNumber.User.UserName'?: string, 'UserContext.EventNumber.User.Password'?: string, 'UserContext.EventNumber.User.TemPassword'?: string, 'UserContext.EventNumber.User.FirstName'?: string, 'UserContext.EventNumber.User.SecondName'?: string, 'UserContext.EventNumber.User.FirstLastName'?: string, 'UserContext.EventNumber.User.SecondLastName'?: string, 'UserContext.EventNumber.User.BirthDate'?: string, 'UserContext.EventNumber.User.Email'?: string, 'UserContext.EventNumber.User.IsActive'?: boolean, 'UserContext.EventNumber.User.IsAdministrator'?: boolean, 'UserContext.EventNumber.User.ListEventAdministrator'?: Array<EventAdministrator>, 'UserContext.EventNumber.User.ListCandidate'?: Array<Candidate>, 'UserContext.EventNumber.User.EventNumber'?: EventNumber, 'PathRoot'?: string }
  }): Observable<StrictHttpResponse<UnitGenericResponse>> {

    const rb = new RequestBuilder(this.rootUrl, CandidateService.ApiEventsIdEventCandidatesImagePostPath, 'post');
    if (params) {
      rb.path('idEvent', params.idEvent, {});
      rb.body(params.body, 'multipart/form-data');
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<UnitGenericResponse>;
      })
    );
  }

  /**
   * Subir Imagen.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiEventsIdEventCandidatesImagePost$Plain$Response()` instead.
   *
   * This method sends `multipart/form-data` and handles request body of type `multipart/form-data`.
   */
  apiEventsIdEventCandidatesImagePost$Plain(params: {
    idEvent: number;
    body?: { 'Image': Blob, 'IdEvent'?: number, 'TokenModel.Username'?: string, 'TokenModel.Email'?: string, 'TokenModel.Id'?: string, 'UserContext.Id'?: number, 'UserContext.DNI'?: string, 'UserContext.UserName'?: string, 'UserContext.Password'?: string, 'UserContext.TemPassword'?: string, 'UserContext.FirstName'?: string, 'UserContext.SecondName'?: string, 'UserContext.FirstLastName'?: string, 'UserContext.SecondLastName'?: string, 'UserContext.BirthDate'?: string, 'UserContext.Email'?: string, 'UserContext.IsActive'?: boolean, 'UserContext.IsAdministrator'?: boolean, 'UserContext.ListEventAdministrator'?: Array<EventAdministrator>, 'UserContext.ListCandidate'?: Array<Candidate>, 'UserContext.EventNumber.Id'?: number, 'UserContext.EventNumber.IdUser'?: number, 'UserContext.EventNumber.NumberMaxEvent'?: number, 'UserContext.EventNumber.User.Id'?: number, 'UserContext.EventNumber.User.DNI'?: string, 'UserContext.EventNumber.User.UserName'?: string, 'UserContext.EventNumber.User.Password'?: string, 'UserContext.EventNumber.User.TemPassword'?: string, 'UserContext.EventNumber.User.FirstName'?: string, 'UserContext.EventNumber.User.SecondName'?: string, 'UserContext.EventNumber.User.FirstLastName'?: string, 'UserContext.EventNumber.User.SecondLastName'?: string, 'UserContext.EventNumber.User.BirthDate'?: string, 'UserContext.EventNumber.User.Email'?: string, 'UserContext.EventNumber.User.IsActive'?: boolean, 'UserContext.EventNumber.User.IsAdministrator'?: boolean, 'UserContext.EventNumber.User.ListEventAdministrator'?: Array<EventAdministrator>, 'UserContext.EventNumber.User.ListCandidate'?: Array<Candidate>, 'UserContext.EventNumber.User.EventNumber'?: EventNumber, 'PathRoot'?: string }
  }): Observable<UnitGenericResponse> {

    return this.apiEventsIdEventCandidatesImagePost$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<UnitGenericResponse>) => r.body as UnitGenericResponse)
    );
  }

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
   * Subir Imagen.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiEventsIdEventCandidatesImagePost$Json$Response()` instead.
   *
   * This method sends `multipart/form-data` and handles request body of type `multipart/form-data`.
   */
  apiEventsIdEventCandidatesImagePost$Json(params: {
    idEvent: number;
    body?: { 'Image': Blob, 'IdEvent'?: number, 'TokenModel.Username'?: string, 'TokenModel.Email'?: string, 'TokenModel.Id'?: string, 'UserContext.Id'?: number, 'UserContext.DNI'?: string, 'UserContext.UserName'?: string, 'UserContext.Password'?: string, 'UserContext.TemPassword'?: string, 'UserContext.FirstName'?: string, 'UserContext.SecondName'?: string, 'UserContext.FirstLastName'?: string, 'UserContext.SecondLastName'?: string, 'UserContext.BirthDate'?: string, 'UserContext.Email'?: string, 'UserContext.IsActive'?: boolean, 'UserContext.IsAdministrator'?: boolean, 'UserContext.ListEventAdministrator'?: Array<EventAdministrator>, 'UserContext.ListCandidate'?: Array<Candidate>, 'UserContext.EventNumber.Id'?: number, 'UserContext.EventNumber.IdUser'?: number, 'UserContext.EventNumber.NumberMaxEvent'?: number, 'UserContext.EventNumber.User.Id'?: number, 'UserContext.EventNumber.User.DNI'?: string, 'UserContext.EventNumber.User.UserName'?: string, 'UserContext.EventNumber.User.Password'?: string, 'UserContext.EventNumber.User.TemPassword'?: string, 'UserContext.EventNumber.User.FirstName'?: string, 'UserContext.EventNumber.User.SecondName'?: string, 'UserContext.EventNumber.User.FirstLastName'?: string, 'UserContext.EventNumber.User.SecondLastName'?: string, 'UserContext.EventNumber.User.BirthDate'?: string, 'UserContext.EventNumber.User.Email'?: string, 'UserContext.EventNumber.User.IsActive'?: boolean, 'UserContext.EventNumber.User.IsAdministrator'?: boolean, 'UserContext.EventNumber.User.ListEventAdministrator'?: Array<EventAdministrator>, 'UserContext.EventNumber.User.ListCandidate'?: Array<Candidate>, 'UserContext.EventNumber.User.EventNumber'?: EventNumber, 'PathRoot'?: string }
  }): Observable<UnitGenericResponse> {

    return this.apiEventsIdEventCandidatesImagePost$Json$Response(params).pipe(
      map((r: StrictHttpResponse<UnitGenericResponse>) => r.body as UnitGenericResponse)
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
   * To access only the response body, use `apiEventsIdEventCandidatesImageDelete$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEventsIdEventCandidatesImageDelete$Plain$Response(params: {

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

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<UnitGenericResponse>;
      })
    );
  }

  /**
   * Borrar Imagen.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiEventsIdEventCandidatesImageDelete$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEventsIdEventCandidatesImageDelete$Plain(params: {

    /**
     * Nombre de imagen a Borrar
     */
    NameResoruce: string;
    idEvent: number;
  }): Observable<UnitGenericResponse> {

    return this.apiEventsIdEventCandidatesImageDelete$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<UnitGenericResponse>) => r.body as UnitGenericResponse)
    );
  }

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
   * Borrar Imagen.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiEventsIdEventCandidatesImageDelete$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEventsIdEventCandidatesImageDelete$Json(params: {

    /**
     * Nombre de imagen a Borrar
     */
    NameResoruce: string;
    idEvent: number;
  }): Observable<UnitGenericResponse> {

    return this.apiEventsIdEventCandidatesImageDelete$Json$Response(params).pipe(
      map((r: StrictHttpResponse<UnitGenericResponse>) => r.body as UnitGenericResponse)
    );
  }

}
