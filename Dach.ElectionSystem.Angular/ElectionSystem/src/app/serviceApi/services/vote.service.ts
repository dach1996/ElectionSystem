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
import { ResponseGeneric } from '../models/generic-response';

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
    rb.header('Authorization', localStorage.getItem('token')!);
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
   * Path part for operation apiVotesEventsIdEventUsersIdUserDelete
   */
  static readonly ApiVotesEventsIdEventUsersIdUserDeletePath = '/api/votes/events/{idEvent}/users/{idUser}';



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
  }): Observable<StrictHttpResponse<ResponseGeneric<VoteDeleteResponse>>> {

    const rb = new RequestBuilder(this.rootUrl, VoteService.ApiVotesEventsIdEventUsersIdUserDeletePath, 'delete');
    if (params) {
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
        return r as StrictHttpResponse<ResponseGeneric<VoteDeleteResponse>>
      })
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
    rb.header('Authorization', localStorage.getItem('token')!);
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
   * Path part for operation apiVotesEventsIdEventGet
   */
  static readonly ApiVotesEventsIdEventGetPath = '/api/votes/events/{idEvent}';



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
     * Cantidad de Registros
     */
    Limit: number;
    idEvent: number;
  }): Observable<StrictHttpResponse<ResponseGeneric<VoteGetResponse>>> {

    const rb = new RequestBuilder(this.rootUrl, VoteService.ApiVotesEventsIdEventGetPath, 'get');
    if (params) {
      rb.query('Offset', '0', {});
      rb.query('OrderBy', 'Desc', {});
      rb.query('Limit', params.Limit, {});
      rb.path('idEvent', params.idEvent, {});
    }
    rb.header('Authorization', localStorage.getItem('token')!);
    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<ResponseGeneric<VoteGetResponse>>;
      })
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
   * To access only the response body, use `apiVotesEventsIdEventPost$Json()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiVotesEventsAutoCreatePost$Json$Response(params: {
    idEvent: number;
    body?: VoteAutoCreateRequest
  }): Observable<StrictHttpResponse<VoteAutoCreateResponse>> {

    const rb = new RequestBuilder(this.rootUrl, VoteService.ApiVotesEventsIdEventPostPath, 'post');
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
        return r as StrictHttpResponse<VoteAutoCreateResponse>;
      })
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
    rb.header('Authorization', localStorage.getItem('token')!);
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


}
