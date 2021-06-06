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

import { OrderBy } from '../models/order-by';
import { VoteAutoCreateRequest } from '../models/vote-auto-create-request';
import { VoteAutoCreateResponse } from '../models/vote-auto-create-response';
import { VoteCreateEmailRequest } from '../models/vote-create-email-request';
import { VoteCreateEmailResponse } from '../models/vote-create-email-response';
import { VoteCreateResponse } from '../models/vote-create-response';
import { VoteDeleteResponse } from '../models/vote-delete-response';
import { VoteGetResponse } from '../models/vote-get-response';
import { VoteUpdateResponse } from '../models/vote-update-response';

@Injectable({
  providedIn: 'root',
})
export class VoteService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation apiVotesEventsIdEventUsersIdUserPost
   */
  static readonly ApiVotesEventsIdEventUsersIdUserPostPath = '/api/votes/events/{idEvent}/users/{idUser}';

  /**
   * Registrar Participante siendo Administrador.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiVotesEventsIdEventUsersIdUserPost$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiVotesEventsIdEventUsersIdUserPost$Plain$Response(params: {
    idEvent: number;
    idUser: number;
  }): Observable<StrictHttpResponse<VoteCreateResponse>> {

    const rb = new RequestBuilder(this.rootUrl, VoteService.ApiVotesEventsIdEventUsersIdUserPostPath, 'post');
    if (params) {
      rb.path('idEvent', params.idEvent, {});
      rb.path('idUser', params.idUser, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<VoteCreateResponse>;
      })
    );
  }

  /**
   * Registrar Participante siendo Administrador.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiVotesEventsIdEventUsersIdUserPost$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiVotesEventsIdEventUsersIdUserPost$Plain(params: {
    idEvent: number;
    idUser: number;
  }): Observable<VoteCreateResponse> {

    return this.apiVotesEventsIdEventUsersIdUserPost$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<VoteCreateResponse>) => r.body as VoteCreateResponse)
    );
  }

  /**
   * Registrar Participante siendo Administrador.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiVotesEventsIdEventUsersIdUserPost$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiVotesEventsIdEventUsersIdUserPost$Json$Response(params: {
    idEvent: number;
    idUser: number;
  }): Observable<StrictHttpResponse<VoteCreateResponse>> {

    const rb = new RequestBuilder(this.rootUrl, VoteService.ApiVotesEventsIdEventUsersIdUserPostPath, 'post');
    if (params) {
      rb.path('idEvent', params.idEvent, {});
      rb.path('idUser', params.idUser, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<VoteCreateResponse>;
      })
    );
  }

  /**
   * Registrar Participante siendo Administrador.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiVotesEventsIdEventUsersIdUserPost$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiVotesEventsIdEventUsersIdUserPost$Json(params: {
    idEvent: number;
    idUser: number;
  }): Observable<VoteCreateResponse> {

    return this.apiVotesEventsIdEventUsersIdUserPost$Json$Response(params).pipe(
      map((r: StrictHttpResponse<VoteCreateResponse>) => r.body as VoteCreateResponse)
    );
  }

  /**
   * Path part for operation apiVotesEventsIdEventUsersIdUserDelete
   */
  static readonly ApiVotesEventsIdEventUsersIdUserDeletePath = '/api/votes/events/{idEvent}/users/{idUser}';

  /**
   * Activar o Desactivar Votante.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiVotesEventsIdEventUsersIdUserDelete$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiVotesEventsIdEventUsersIdUserDelete$Plain$Response(params: {
    idEvent: number;
    idUser: number;
  }): Observable<StrictHttpResponse<VoteDeleteResponse>> {

    const rb = new RequestBuilder(this.rootUrl, VoteService.ApiVotesEventsIdEventUsersIdUserDeletePath, 'delete');
    if (params) {
      rb.path('idEvent', params.idEvent, {});
      rb.path('idUser', params.idUser, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<VoteDeleteResponse>;
      })
    );
  }

  /**
   * Activar o Desactivar Votante.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiVotesEventsIdEventUsersIdUserDelete$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiVotesEventsIdEventUsersIdUserDelete$Plain(params: {
    idEvent: number;
    idUser: number;
  }): Observable<VoteDeleteResponse> {

    return this.apiVotesEventsIdEventUsersIdUserDelete$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<VoteDeleteResponse>) => r.body as VoteDeleteResponse)
    );
  }

  /**
   * Activar o Desactivar Votante.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiVotesEventsIdEventUsersIdUserDelete$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiVotesEventsIdEventUsersIdUserDelete$Json$Response(params: {
    idEvent: number;
    idUser: number;
  }): Observable<StrictHttpResponse<VoteDeleteResponse>> {

    const rb = new RequestBuilder(this.rootUrl, VoteService.ApiVotesEventsIdEventUsersIdUserDeletePath, 'delete');
    if (params) {
      rb.path('idEvent', params.idEvent, {});
      rb.path('idUser', params.idUser, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<VoteDeleteResponse>;
      })
    );
  }

  /**
   * Activar o Desactivar Votante.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiVotesEventsIdEventUsersIdUserDelete$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiVotesEventsIdEventUsersIdUserDelete$Json(params: {
    idEvent: number;
    idUser: number;
  }): Observable<VoteDeleteResponse> {

    return this.apiVotesEventsIdEventUsersIdUserDelete$Json$Response(params).pipe(
      map((r: StrictHttpResponse<VoteDeleteResponse>) => r.body as VoteDeleteResponse)
    );
  }

  /**
   * Path part for operation apiVotesEventsIdEventUsersPost
   */
  static readonly ApiVotesEventsIdEventUsersPostPath = '/api/votes/events/{idEvent}/users';

  /**
   * Registrar Participantes por  correo electrónico siendo Administrador.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiVotesEventsIdEventUsersPost$Plain()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiVotesEventsIdEventUsersPost$Plain$Response(params: {
    idEvent: number;
    body?: VoteCreateEmailRequest
  }): Observable<StrictHttpResponse<VoteCreateEmailResponse>> {

    const rb = new RequestBuilder(this.rootUrl, VoteService.ApiVotesEventsIdEventUsersPostPath, 'post');
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
        return r as StrictHttpResponse<VoteCreateEmailResponse>;
      })
    );
  }

  /**
   * Registrar Participantes por  correo electrónico siendo Administrador.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiVotesEventsIdEventUsersPost$Plain$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiVotesEventsIdEventUsersPost$Plain(params: {
    idEvent: number;
    body?: VoteCreateEmailRequest
  }): Observable<VoteCreateEmailResponse> {

    return this.apiVotesEventsIdEventUsersPost$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<VoteCreateEmailResponse>) => r.body as VoteCreateEmailResponse)
    );
  }

  /**
   * Registrar Participantes por  correo electrónico siendo Administrador.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiVotesEventsIdEventUsersPost$Json()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiVotesEventsIdEventUsersPost$Json$Response(params: {
    idEvent: number;
    body?: VoteCreateEmailRequest
  }): Observable<StrictHttpResponse<VoteCreateEmailResponse>> {

    const rb = new RequestBuilder(this.rootUrl, VoteService.ApiVotesEventsIdEventUsersPostPath, 'post');
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
        return r as StrictHttpResponse<VoteCreateEmailResponse>;
      })
    );
  }

  /**
   * Registrar Participantes por  correo electrónico siendo Administrador.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiVotesEventsIdEventUsersPost$Json$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiVotesEventsIdEventUsersPost$Json(params: {
    idEvent: number;
    body?: VoteCreateEmailRequest
  }): Observable<VoteCreateEmailResponse> {

    return this.apiVotesEventsIdEventUsersPost$Json$Response(params).pipe(
      map((r: StrictHttpResponse<VoteCreateEmailResponse>) => r.body as VoteCreateEmailResponse)
    );
  }

  /**
   * Path part for operation apiVotesEventsIdEventGet
   */
  static readonly ApiVotesEventsIdEventGetPath = '/api/votes/events/{idEvent}';

  /**
   * Consultar Participantes.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiVotesEventsIdEventGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiVotesEventsIdEventGet$Plain$Response(params: {

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
  }): Observable<StrictHttpResponse<VoteGetResponse>> {

    const rb = new RequestBuilder(this.rootUrl, VoteService.ApiVotesEventsIdEventGetPath, 'get');
    if (params) {
      rb.query('Offset', params.Offset, {});
      rb.query('OrderBy', params.OrderBy, {});
      rb.query('Limit', params.Limit, {});
      rb.path('idEvent', params.idEvent, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<VoteGetResponse>;
      })
    );
  }

  /**
   * Consultar Participantes.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiVotesEventsIdEventGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiVotesEventsIdEventGet$Plain(params: {

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
  }): Observable<VoteGetResponse> {

    return this.apiVotesEventsIdEventGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<VoteGetResponse>) => r.body as VoteGetResponse)
    );
  }

  /**
   * Consultar Participantes.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiVotesEventsIdEventGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiVotesEventsIdEventGet$Json$Response(params: {

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
  }): Observable<StrictHttpResponse<VoteGetResponse>> {

    const rb = new RequestBuilder(this.rootUrl, VoteService.ApiVotesEventsIdEventGetPath, 'get');
    if (params) {
      rb.query('Offset', params.Offset, {});
      rb.query('OrderBy', params.OrderBy, {});
      rb.query('Limit', params.Limit, {});
      rb.path('idEvent', params.idEvent, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<VoteGetResponse>;
      })
    );
  }

  /**
   * Consultar Participantes.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiVotesEventsIdEventGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiVotesEventsIdEventGet$Json(params: {

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
  }): Observable<VoteGetResponse> {

    return this.apiVotesEventsIdEventGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<VoteGetResponse>) => r.body as VoteGetResponse)
    );
  }

  /**
   * Path part for operation apiVotesEventsIdEventPost
   */
  static readonly ApiVotesEventsIdEventPostPath = '/api/votes/events/{idEvent}';

  /**
   * Autoregistrase en el evento siendo usuario.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiVotesEventsIdEventPost$Plain()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiVotesEventsIdEventPost$Plain$Response(params: {
    idEvent: number;
    body?: VoteAutoCreateRequest
  }): Observable<StrictHttpResponse<VoteAutoCreateResponse>> {

    const rb = new RequestBuilder(this.rootUrl, VoteService.ApiVotesEventsIdEventPostPath, 'post');
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
        return r as StrictHttpResponse<VoteAutoCreateResponse>;
      })
    );
  }

  /**
   * Autoregistrase en el evento siendo usuario.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiVotesEventsIdEventPost$Plain$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiVotesEventsIdEventPost$Plain(params: {
    idEvent: number;
    body?: VoteAutoCreateRequest
  }): Observable<VoteAutoCreateResponse> {

    return this.apiVotesEventsIdEventPost$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<VoteAutoCreateResponse>) => r.body as VoteAutoCreateResponse)
    );
  }

  /**
   * Autoregistrase en el evento siendo usuario.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiVotesEventsIdEventPost$Json()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiVotesEventsIdEventPost$Json$Response(params: {
    idEvent: number;
    body?: VoteAutoCreateRequest
  }): Observable<StrictHttpResponse<VoteAutoCreateResponse>> {

    const rb = new RequestBuilder(this.rootUrl, VoteService.ApiVotesEventsIdEventPostPath, 'post');
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
        return r as StrictHttpResponse<VoteAutoCreateResponse>;
      })
    );
  }

  /**
   * Autoregistrase en el evento siendo usuario.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiVotesEventsIdEventPost$Json$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiVotesEventsIdEventPost$Json(params: {
    idEvent: number;
    body?: VoteAutoCreateRequest
  }): Observable<VoteAutoCreateResponse> {

    return this.apiVotesEventsIdEventPost$Json$Response(params).pipe(
      map((r: StrictHttpResponse<VoteAutoCreateResponse>) => r.body as VoteAutoCreateResponse)
    );
  }

  /**
   * Path part for operation apiVotesEventsIdEventCandidatesIdCandidatePut
   */
  static readonly ApiVotesEventsIdEventCandidatesIdCandidatePutPath = '/api/votes/events/{idEvent}/candidates/{idCandidate}';

  /**
   * Votar.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiVotesEventsIdEventCandidatesIdCandidatePut$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiVotesEventsIdEventCandidatesIdCandidatePut$Plain$Response(params: {
    idEvent: number;
    idCandidate: number;
  }): Observable<StrictHttpResponse<VoteUpdateResponse>> {

    const rb = new RequestBuilder(this.rootUrl, VoteService.ApiVotesEventsIdEventCandidatesIdCandidatePutPath, 'put');
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
        return r as StrictHttpResponse<VoteUpdateResponse>;
      })
    );
  }

  /**
   * Votar.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiVotesEventsIdEventCandidatesIdCandidatePut$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiVotesEventsIdEventCandidatesIdCandidatePut$Plain(params: {
    idEvent: number;
    idCandidate: number;
  }): Observable<VoteUpdateResponse> {

    return this.apiVotesEventsIdEventCandidatesIdCandidatePut$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<VoteUpdateResponse>) => r.body as VoteUpdateResponse)
    );
  }

  /**
   * Votar.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiVotesEventsIdEventCandidatesIdCandidatePut$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiVotesEventsIdEventCandidatesIdCandidatePut$Json$Response(params: {
    idEvent: number;
    idCandidate: number;
  }): Observable<StrictHttpResponse<VoteUpdateResponse>> {

    const rb = new RequestBuilder(this.rootUrl, VoteService.ApiVotesEventsIdEventCandidatesIdCandidatePutPath, 'put');
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
        return r as StrictHttpResponse<VoteUpdateResponse>;
      })
    );
  }

  /**
   * Votar.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiVotesEventsIdEventCandidatesIdCandidatePut$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiVotesEventsIdEventCandidatesIdCandidatePut$Json(params: {
    idEvent: number;
    idCandidate: number;
  }): Observable<VoteUpdateResponse> {

    return this.apiVotesEventsIdEventCandidatesIdCandidatePut$Json$Response(params).pipe(
      map((r: StrictHttpResponse<VoteUpdateResponse>) => r.body as VoteUpdateResponse)
    );
  }

}
