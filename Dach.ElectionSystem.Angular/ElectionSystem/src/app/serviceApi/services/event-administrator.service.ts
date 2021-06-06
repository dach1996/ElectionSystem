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

import { EventAdministratorCreateRequest } from '../models/event-administrator-create-request';
import { EventAdministratorCreateResponse } from '../models/event-administrator-create-response';
import { EventAdministratorDesactiveResponse } from '../models/event-administrator-desactive-response';
import { EventAdministratorGetResponse } from '../models/event-administrator-get-response';

@Injectable({
  providedIn: 'root',
})
export class EventAdministratorService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation apiEventAdministratorsIdEventUsersIdUserPost
   */
  static readonly ApiEventAdministratorsIdEventUsersIdUserPostPath = '/api/EventAdministrators/{idEvent}/users/{idUser}';

  /**
   * Crear nuevo EventAdministratoro.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiEventAdministratorsIdEventUsersIdUserPost$Plain()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiEventAdministratorsIdEventUsersIdUserPost$Plain$Response(params: {
    idEvent: number;
    idUser: number;
    body?: EventAdministratorCreateRequest
  }): Observable<StrictHttpResponse<EventAdministratorCreateResponse>> {

    const rb = new RequestBuilder(this.rootUrl, EventAdministratorService.ApiEventAdministratorsIdEventUsersIdUserPostPath, 'post');
    if (params) {
      rb.path('idEvent', params.idEvent, {});
      rb.path('idUser', params.idUser, {});
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<EventAdministratorCreateResponse>;
      })
    );
  }

  /**
   * Crear nuevo EventAdministratoro.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiEventAdministratorsIdEventUsersIdUserPost$Plain$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiEventAdministratorsIdEventUsersIdUserPost$Plain(params: {
    idEvent: number;
    idUser: number;
    body?: EventAdministratorCreateRequest
  }): Observable<EventAdministratorCreateResponse> {

    return this.apiEventAdministratorsIdEventUsersIdUserPost$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<EventAdministratorCreateResponse>) => r.body as EventAdministratorCreateResponse)
    );
  }

  /**
   * Crear nuevo EventAdministratoro.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiEventAdministratorsIdEventUsersIdUserPost$Json()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiEventAdministratorsIdEventUsersIdUserPost$Json$Response(params: {
    idEvent: number;
    idUser: number;
    body?: EventAdministratorCreateRequest
  }): Observable<StrictHttpResponse<EventAdministratorCreateResponse>> {

    const rb = new RequestBuilder(this.rootUrl, EventAdministratorService.ApiEventAdministratorsIdEventUsersIdUserPostPath, 'post');
    if (params) {
      rb.path('idEvent', params.idEvent, {});
      rb.path('idUser', params.idUser, {});
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<EventAdministratorCreateResponse>;
      })
    );
  }

  /**
   * Crear nuevo EventAdministratoro.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiEventAdministratorsIdEventUsersIdUserPost$Json$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiEventAdministratorsIdEventUsersIdUserPost$Json(params: {
    idEvent: number;
    idUser: number;
    body?: EventAdministratorCreateRequest
  }): Observable<EventAdministratorCreateResponse> {

    return this.apiEventAdministratorsIdEventUsersIdUserPost$Json$Response(params).pipe(
      map((r: StrictHttpResponse<EventAdministratorCreateResponse>) => r.body as EventAdministratorCreateResponse)
    );
  }

  /**
   * Path part for operation apiEventAdministratorsIdEventUsersIdUserDelete
   */
  static readonly ApiEventAdministratorsIdEventUsersIdUserDeletePath = '/api/EventAdministrators/{idEvent}/users/{idUser}';

  /**
   * Activar / Desactivar Administrador de Evento.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiEventAdministratorsIdEventUsersIdUserDelete$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEventAdministratorsIdEventUsersIdUserDelete$Plain$Response(params: {
    idEvent: number;
    idUser: number;
  }): Observable<StrictHttpResponse<EventAdministratorDesactiveResponse>> {

    const rb = new RequestBuilder(this.rootUrl, EventAdministratorService.ApiEventAdministratorsIdEventUsersIdUserDeletePath, 'delete');
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
        return r as StrictHttpResponse<EventAdministratorDesactiveResponse>;
      })
    );
  }

  /**
   * Activar / Desactivar Administrador de Evento.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiEventAdministratorsIdEventUsersIdUserDelete$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEventAdministratorsIdEventUsersIdUserDelete$Plain(params: {
    idEvent: number;
    idUser: number;
  }): Observable<EventAdministratorDesactiveResponse> {

    return this.apiEventAdministratorsIdEventUsersIdUserDelete$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<EventAdministratorDesactiveResponse>) => r.body as EventAdministratorDesactiveResponse)
    );
  }

  /**
   * Activar / Desactivar Administrador de Evento.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiEventAdministratorsIdEventUsersIdUserDelete$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEventAdministratorsIdEventUsersIdUserDelete$Json$Response(params: {
    idEvent: number;
    idUser: number;
  }): Observable<StrictHttpResponse<EventAdministratorDesactiveResponse>> {

    const rb = new RequestBuilder(this.rootUrl, EventAdministratorService.ApiEventAdministratorsIdEventUsersIdUserDeletePath, 'delete');
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
        return r as StrictHttpResponse<EventAdministratorDesactiveResponse>;
      })
    );
  }

  /**
   * Activar / Desactivar Administrador de Evento.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiEventAdministratorsIdEventUsersIdUserDelete$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEventAdministratorsIdEventUsersIdUserDelete$Json(params: {
    idEvent: number;
    idUser: number;
  }): Observable<EventAdministratorDesactiveResponse> {

    return this.apiEventAdministratorsIdEventUsersIdUserDelete$Json$Response(params).pipe(
      map((r: StrictHttpResponse<EventAdministratorDesactiveResponse>) => r.body as EventAdministratorDesactiveResponse)
    );
  }

  /**
   * Path part for operation apiEventAdministratorsIdEventGet
   */
  static readonly ApiEventAdministratorsIdEventGetPath = '/api/EventAdministrators/{idEvent}';

  /**
   * Consulta lista de administradores por evento.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiEventAdministratorsIdEventGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEventAdministratorsIdEventGet$Plain$Response(params: {
    idEvent: number;
  }): Observable<StrictHttpResponse<EventAdministratorGetResponse>> {

    const rb = new RequestBuilder(this.rootUrl, EventAdministratorService.ApiEventAdministratorsIdEventGetPath, 'get');
    if (params) {
      rb.path('idEvent', params.idEvent, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<EventAdministratorGetResponse>;
      })
    );
  }

  /**
   * Consulta lista de administradores por evento.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiEventAdministratorsIdEventGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEventAdministratorsIdEventGet$Plain(params: {
    idEvent: number;
  }): Observable<EventAdministratorGetResponse> {

    return this.apiEventAdministratorsIdEventGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<EventAdministratorGetResponse>) => r.body as EventAdministratorGetResponse)
    );
  }

  /**
   * Consulta lista de administradores por evento.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiEventAdministratorsIdEventGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEventAdministratorsIdEventGet$Json$Response(params: {
    idEvent: number;
  }): Observable<StrictHttpResponse<EventAdministratorGetResponse>> {

    const rb = new RequestBuilder(this.rootUrl, EventAdministratorService.ApiEventAdministratorsIdEventGetPath, 'get');
    if (params) {
      rb.path('idEvent', params.idEvent, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<EventAdministratorGetResponse>;
      })
    );
  }

  /**
   * Consulta lista de administradores por evento.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiEventAdministratorsIdEventGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEventAdministratorsIdEventGet$Json(params: {
    idEvent: number;
  }): Observable<EventAdministratorGetResponse> {

    return this.apiEventAdministratorsIdEventGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<EventAdministratorGetResponse>) => r.body as EventAdministratorGetResponse)
    );
  }

}
