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
import { EventAdministrator } from '../models/event-administrator';
import { EventCreateRequest } from '../models/event-create-request';
import { EventCreateResponse } from '../models/event-create-response';
import { EventDeleteResponse } from '../models/event-delete-response';
import { EventGetResponse } from '../models/event-get-response';
import { EventGetResultResponse } from '../models/event-get-result-response';
import { EventNumber } from '../models/event-number';
import { EventUpdateRequest } from '../models/event-update-request';
import { EventUpdateResponse } from '../models/event-update-response';
import { OrderBy } from '../models/order-by';
import { TypeFilterEvent } from '../models/type-filter-event';
import { Unit } from '../models/unit';

@Injectable({
  providedIn: 'root',
})
export class EventService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation apiEventsGet
   */
  static readonly ApiEventsGetPath = '/api/events';

  /**
   * Consulta de Eventos.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiEventsGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEventsGet$Plain$Response(params: {

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
     * Nombre de evento
     */
    Name?: string;

    /**
     * Categoría de Evento
     */
    Category?: string;

    /**
     * Tipo de Filtros
     */
    TypeFilter?: TypeFilterEvent;
  }): Observable<StrictHttpResponse<EventGetResponse>> {

    const rb = new RequestBuilder(this.rootUrl, EventService.ApiEventsGetPath, 'get');
    if (params) {
      rb.query('Offset', params.Offset, {});
      rb.query('OrderBy', params.OrderBy, {});
      rb.query('Limit', params.Limit, {});
      rb.query('Name', params.Name, {});
      rb.query('Category', params.Category, {});
      rb.query('TypeFilter', params.TypeFilter, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<EventGetResponse>;
      })
    );
  }

  /**
   * Consulta de Eventos.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiEventsGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEventsGet$Plain(params: {

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
     * Nombre de evento
     */
    Name?: string;

    /**
     * Categoría de Evento
     */
    Category?: string;

    /**
     * Tipo de Filtros
     */
    TypeFilter?: TypeFilterEvent;
  }): Observable<EventGetResponse> {

    return this.apiEventsGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<EventGetResponse>) => r.body as EventGetResponse)
    );
  }

  /**
   * Consulta de Eventos.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiEventsGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEventsGet$Json$Response(params: {

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
     * Nombre de evento
     */
    Name?: string;

    /**
     * Categoría de Evento
     */
    Category?: string;

    /**
     * Tipo de Filtros
     */
    TypeFilter?: TypeFilterEvent;
  }): Observable<StrictHttpResponse<EventGetResponse>> {

    const rb = new RequestBuilder(this.rootUrl, EventService.ApiEventsGetPath, 'get');
    if (params) {
      rb.query('Offset', params.Offset, {});
      rb.query('OrderBy', params.OrderBy, {});
      rb.query('Limit', params.Limit, {});
      rb.query('Name', params.Name, {});
      rb.query('Category', params.Category, {});
      rb.query('TypeFilter', params.TypeFilter, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<EventGetResponse>;
      })
    );
  }

  /**
   * Consulta de Eventos.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiEventsGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEventsGet$Json(params: {

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
     * Nombre de evento
     */
    Name?: string;

    /**
     * Categoría de Evento
     */
    Category?: string;

    /**
     * Tipo de Filtros
     */
    TypeFilter?: TypeFilterEvent;
  }): Observable<EventGetResponse> {

    return this.apiEventsGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<EventGetResponse>) => r.body as EventGetResponse)
    );
  }

  /**
   * Path part for operation apiEventsPost
   */
  static readonly ApiEventsPostPath = '/api/events';

  /**
   * Crear nuevo evento.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiEventsPost$Plain()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiEventsPost$Plain$Response(params?: {
    body?: EventCreateRequest
  }): Observable<StrictHttpResponse<EventCreateResponse>> {

    const rb = new RequestBuilder(this.rootUrl, EventService.ApiEventsPostPath, 'post');
    if (params) {
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<EventCreateResponse>;
      })
    );
  }

  /**
   * Crear nuevo evento.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiEventsPost$Plain$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiEventsPost$Plain(params?: {
    body?: EventCreateRequest
  }): Observable<EventCreateResponse> {

    return this.apiEventsPost$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<EventCreateResponse>) => r.body as EventCreateResponse)
    );
  }

  /**
   * Crear nuevo evento.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiEventsPost$Json()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiEventsPost$Json$Response(params?: {
    body?: EventCreateRequest
  }): Observable<StrictHttpResponse<EventCreateResponse>> {

    const rb = new RequestBuilder(this.rootUrl, EventService.ApiEventsPostPath, 'post');
    if (params) {
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<EventCreateResponse>;
      })
    );
  }

  /**
   * Crear nuevo evento.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiEventsPost$Json$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiEventsPost$Json(params?: {
    body?: EventCreateRequest
  }): Observable<EventCreateResponse> {

    return this.apiEventsPost$Json$Response(params).pipe(
      map((r: StrictHttpResponse<EventCreateResponse>) => r.body as EventCreateResponse)
    );
  }

  /**
   * Path part for operation apiEventsIdGet
   */
  static readonly ApiEventsIdGetPath = '/api/events/{id}';

  /**
   * Consulta de Evento.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiEventsIdGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEventsIdGet$Plain$Response(params: {

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
     * Nombre de evento
     */
    Name?: string;

    /**
     * Categoría de Evento
     */
    Category?: string;

    /**
     * Tipo de Filtros
     */
    TypeFilter?: TypeFilterEvent;
    id: number;
  }): Observable<StrictHttpResponse<EventGetResponse>> {

    const rb = new RequestBuilder(this.rootUrl, EventService.ApiEventsIdGetPath, 'get');
    if (params) {
      rb.query('Offset', params.Offset, {});
      rb.query('OrderBy', params.OrderBy, {});
      rb.query('Limit', params.Limit, {});
      rb.query('Name', params.Name, {});
      rb.query('Category', params.Category, {});
      rb.query('TypeFilter', params.TypeFilter, {});
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<EventGetResponse>;
      })
    );
  }

  /**
   * Consulta de Evento.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiEventsIdGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEventsIdGet$Plain(params: {

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
     * Nombre de evento
     */
    Name?: string;

    /**
     * Categoría de Evento
     */
    Category?: string;

    /**
     * Tipo de Filtros
     */
    TypeFilter?: TypeFilterEvent;
    id: number;
  }): Observable<EventGetResponse> {

    return this.apiEventsIdGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<EventGetResponse>) => r.body as EventGetResponse)
    );
  }

  /**
   * Consulta de Evento.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiEventsIdGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEventsIdGet$Json$Response(params: {

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
     * Nombre de evento
     */
    Name?: string;

    /**
     * Categoría de Evento
     */
    Category?: string;

    /**
     * Tipo de Filtros
     */
    TypeFilter?: TypeFilterEvent;
    id: number;
  }): Observable<StrictHttpResponse<EventGetResponse>> {

    const rb = new RequestBuilder(this.rootUrl, EventService.ApiEventsIdGetPath, 'get');
    if (params) {
      rb.query('Offset', params.Offset, {});
      rb.query('OrderBy', params.OrderBy, {});
      rb.query('Limit', params.Limit, {});
      rb.query('Name', params.Name, {});
      rb.query('Category', params.Category, {});
      rb.query('TypeFilter', params.TypeFilter, {});
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<EventGetResponse>;
      })
    );
  }

  /**
   * Consulta de Evento.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiEventsIdGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEventsIdGet$Json(params: {

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
     * Nombre de evento
     */
    Name?: string;

    /**
     * Categoría de Evento
     */
    Category?: string;

    /**
     * Tipo de Filtros
     */
    TypeFilter?: TypeFilterEvent;
    id: number;
  }): Observable<EventGetResponse> {

    return this.apiEventsIdGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<EventGetResponse>) => r.body as EventGetResponse)
    );
  }

  /**
   * Path part for operation apiEventsIdPut
   */
  static readonly ApiEventsIdPutPath = '/api/events/{id}';

  /**
   * Actualizar Evento.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiEventsIdPut$Plain()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiEventsIdPut$Plain$Response(params: {
    id: number;
    body?: EventUpdateRequest
  }): Observable<StrictHttpResponse<EventUpdateResponse>> {

    const rb = new RequestBuilder(this.rootUrl, EventService.ApiEventsIdPutPath, 'put');
    if (params) {
      rb.path('id', params.id, {});
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<EventUpdateResponse>;
      })
    );
  }

  /**
   * Actualizar Evento.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiEventsIdPut$Plain$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiEventsIdPut$Plain(params: {
    id: number;
    body?: EventUpdateRequest
  }): Observable<EventUpdateResponse> {

    return this.apiEventsIdPut$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<EventUpdateResponse>) => r.body as EventUpdateResponse)
    );
  }

  /**
   * Actualizar Evento.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiEventsIdPut$Json()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiEventsIdPut$Json$Response(params: {
    id: number;
    body?: EventUpdateRequest
  }): Observable<StrictHttpResponse<EventUpdateResponse>> {

    const rb = new RequestBuilder(this.rootUrl, EventService.ApiEventsIdPutPath, 'put');
    if (params) {
      rb.path('id', params.id, {});
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<EventUpdateResponse>;
      })
    );
  }

  /**
   * Actualizar Evento.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiEventsIdPut$Json$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiEventsIdPut$Json(params: {
    id: number;
    body?: EventUpdateRequest
  }): Observable<EventUpdateResponse> {

    return this.apiEventsIdPut$Json$Response(params).pipe(
      map((r: StrictHttpResponse<EventUpdateResponse>) => r.body as EventUpdateResponse)
    );
  }

  /**
   * Path part for operation apiEventsIdDelete
   */
  static readonly ApiEventsIdDeletePath = '/api/events/{id}';

  /**
   * Desactivar Evento.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiEventsIdDelete$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEventsIdDelete$Plain$Response(params: {

    /**
     * Id de Evento
     */
    IdEvent: number;
    id: string;
  }): Observable<StrictHttpResponse<EventDeleteResponse>> {

    const rb = new RequestBuilder(this.rootUrl, EventService.ApiEventsIdDeletePath, 'delete');
    if (params) {
      rb.path('IdEvent', params.IdEvent, {});
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<EventDeleteResponse>;
      })
    );
  }

  /**
   * Desactivar Evento.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiEventsIdDelete$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEventsIdDelete$Plain(params: {

    /**
     * Id de Evento
     */
    IdEvent: number;
    id: string;
  }): Observable<EventDeleteResponse> {

    return this.apiEventsIdDelete$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<EventDeleteResponse>) => r.body as EventDeleteResponse)
    );
  }

  /**
   * Desactivar Evento.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiEventsIdDelete$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEventsIdDelete$Json$Response(params: {

    /**
     * Id de Evento
     */
    IdEvent: number;
    id: string;
  }): Observable<StrictHttpResponse<EventDeleteResponse>> {

    const rb = new RequestBuilder(this.rootUrl, EventService.ApiEventsIdDeletePath, 'delete');
    if (params) {
      rb.path('IdEvent', params.IdEvent, {});
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<EventDeleteResponse>;
      })
    );
  }

  /**
   * Desactivar Evento.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiEventsIdDelete$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEventsIdDelete$Json(params: {

    /**
     * Id de Evento
     */
    IdEvent: number;
    id: string;
  }): Observable<EventDeleteResponse> {

    return this.apiEventsIdDelete$Json$Response(params).pipe(
      map((r: StrictHttpResponse<EventDeleteResponse>) => r.body as EventDeleteResponse)
    );
  }

  /**
   * Path part for operation apiEventsIdEventResultsGet
   */
  static readonly ApiEventsIdEventResultsGetPath = '/api/events/{idEvent}/results';

  /**
   * Consulta de resultados.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiEventsIdEventResultsGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEventsIdEventResultsGet$Plain$Response(params: {
    idEvent: number;
  }): Observable<StrictHttpResponse<EventGetResultResponse>> {

    const rb = new RequestBuilder(this.rootUrl, EventService.ApiEventsIdEventResultsGetPath, 'get');
    if (params) {
      rb.path('idEvent', params.idEvent, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<EventGetResultResponse>;
      })
    );
  }

  /**
   * Consulta de resultados.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiEventsIdEventResultsGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEventsIdEventResultsGet$Plain(params: {
    idEvent: number;
  }): Observable<EventGetResultResponse> {

    return this.apiEventsIdEventResultsGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<EventGetResultResponse>) => r.body as EventGetResultResponse)
    );
  }

  /**
   * Consulta de resultados.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiEventsIdEventResultsGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEventsIdEventResultsGet$Json$Response(params: {
    idEvent: number;
  }): Observable<StrictHttpResponse<EventGetResultResponse>> {

    const rb = new RequestBuilder(this.rootUrl, EventService.ApiEventsIdEventResultsGetPath, 'get');
    if (params) {
      rb.path('idEvent', params.idEvent, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<EventGetResultResponse>;
      })
    );
  }

  /**
   * Consulta de resultados.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiEventsIdEventResultsGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEventsIdEventResultsGet$Json(params: {
    idEvent: number;
  }): Observable<EventGetResultResponse> {

    return this.apiEventsIdEventResultsGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<EventGetResultResponse>) => r.body as EventGetResultResponse)
    );
  }

  /**
   * Path part for operation apiEventsIdEventImagePost
   */
  static readonly ApiEventsIdEventImagePostPath = '/api/events/{idEvent}/image';

  /**
   * Guardar Imágen del evento.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiEventsIdEventImagePost$Plain()` instead.
   *
   * This method sends `multipart/form-data` and handles request body of type `multipart/form-data`.
   */
  apiEventsIdEventImagePost$Plain$Response(params: {
    idEvent: number;
    body?: { 'Image': Blob, 'IdEvent'?: number, 'TokenModel.Username'?: string, 'TokenModel.Email'?: string, 'TokenModel.Id'?: string, 'UserContext.Id'?: number, 'UserContext.DNI'?: string, 'UserContext.UserName'?: string, 'UserContext.Password'?: string, 'UserContext.TemPassword'?: string, 'UserContext.FirstName'?: string, 'UserContext.SecondName'?: string, 'UserContext.FirstLastName'?: string, 'UserContext.SecondLastName'?: string, 'UserContext.BirthDate'?: string, 'UserContext.Email'?: string, 'UserContext.IsActive'?: boolean, 'UserContext.IsAdministrator'?: boolean, 'UserContext.ListEventAdministrator'?: Array<EventAdministrator>, 'UserContext.ListCandidate'?: Array<Candidate>, 'UserContext.EventNumber.Id'?: number, 'UserContext.EventNumber.IdUser'?: number, 'UserContext.EventNumber.NumberMaxEvent'?: number, 'UserContext.EventNumber.User.Id'?: number, 'UserContext.EventNumber.User.DNI'?: string, 'UserContext.EventNumber.User.UserName'?: string, 'UserContext.EventNumber.User.Password'?: string, 'UserContext.EventNumber.User.TemPassword'?: string, 'UserContext.EventNumber.User.FirstName'?: string, 'UserContext.EventNumber.User.SecondName'?: string, 'UserContext.EventNumber.User.FirstLastName'?: string, 'UserContext.EventNumber.User.SecondLastName'?: string, 'UserContext.EventNumber.User.BirthDate'?: string, 'UserContext.EventNumber.User.Email'?: string, 'UserContext.EventNumber.User.IsActive'?: boolean, 'UserContext.EventNumber.User.IsAdministrator'?: boolean, 'UserContext.EventNumber.User.ListEventAdministrator'?: Array<EventAdministrator>, 'UserContext.EventNumber.User.ListCandidate'?: Array<Candidate>, 'UserContext.EventNumber.User.EventNumber'?: EventNumber, 'PathRoot'?: string }
  }): Observable<StrictHttpResponse<Unit>> {

    const rb = new RequestBuilder(this.rootUrl, EventService.ApiEventsIdEventImagePostPath, 'post');
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
        return r as StrictHttpResponse<Unit>;
      })
    );
  }

  /**
   * Guardar Imágen del evento.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiEventsIdEventImagePost$Plain$Response()` instead.
   *
   * This method sends `multipart/form-data` and handles request body of type `multipart/form-data`.
   */
  apiEventsIdEventImagePost$Plain(params: {
    idEvent: number;
    body?: { 'Image': Blob, 'IdEvent'?: number, 'TokenModel.Username'?: string, 'TokenModel.Email'?: string, 'TokenModel.Id'?: string, 'UserContext.Id'?: number, 'UserContext.DNI'?: string, 'UserContext.UserName'?: string, 'UserContext.Password'?: string, 'UserContext.TemPassword'?: string, 'UserContext.FirstName'?: string, 'UserContext.SecondName'?: string, 'UserContext.FirstLastName'?: string, 'UserContext.SecondLastName'?: string, 'UserContext.BirthDate'?: string, 'UserContext.Email'?: string, 'UserContext.IsActive'?: boolean, 'UserContext.IsAdministrator'?: boolean, 'UserContext.ListEventAdministrator'?: Array<EventAdministrator>, 'UserContext.ListCandidate'?: Array<Candidate>, 'UserContext.EventNumber.Id'?: number, 'UserContext.EventNumber.IdUser'?: number, 'UserContext.EventNumber.NumberMaxEvent'?: number, 'UserContext.EventNumber.User.Id'?: number, 'UserContext.EventNumber.User.DNI'?: string, 'UserContext.EventNumber.User.UserName'?: string, 'UserContext.EventNumber.User.Password'?: string, 'UserContext.EventNumber.User.TemPassword'?: string, 'UserContext.EventNumber.User.FirstName'?: string, 'UserContext.EventNumber.User.SecondName'?: string, 'UserContext.EventNumber.User.FirstLastName'?: string, 'UserContext.EventNumber.User.SecondLastName'?: string, 'UserContext.EventNumber.User.BirthDate'?: string, 'UserContext.EventNumber.User.Email'?: string, 'UserContext.EventNumber.User.IsActive'?: boolean, 'UserContext.EventNumber.User.IsAdministrator'?: boolean, 'UserContext.EventNumber.User.ListEventAdministrator'?: Array<EventAdministrator>, 'UserContext.EventNumber.User.ListCandidate'?: Array<Candidate>, 'UserContext.EventNumber.User.EventNumber'?: EventNumber, 'PathRoot'?: string }
  }): Observable<Unit> {

    return this.apiEventsIdEventImagePost$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<Unit>) => r.body as Unit)
    );
  }

  /**
   * Guardar Imágen del evento.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiEventsIdEventImagePost$Json()` instead.
   *
   * This method sends `multipart/form-data` and handles request body of type `multipart/form-data`.
   */
  apiEventsIdEventImagePost$Json$Response(params: {
    idEvent: number;
    body?: { 'Image': Blob, 'IdEvent'?: number, 'TokenModel.Username'?: string, 'TokenModel.Email'?: string, 'TokenModel.Id'?: string, 'UserContext.Id'?: number, 'UserContext.DNI'?: string, 'UserContext.UserName'?: string, 'UserContext.Password'?: string, 'UserContext.TemPassword'?: string, 'UserContext.FirstName'?: string, 'UserContext.SecondName'?: string, 'UserContext.FirstLastName'?: string, 'UserContext.SecondLastName'?: string, 'UserContext.BirthDate'?: string, 'UserContext.Email'?: string, 'UserContext.IsActive'?: boolean, 'UserContext.IsAdministrator'?: boolean, 'UserContext.ListEventAdministrator'?: Array<EventAdministrator>, 'UserContext.ListCandidate'?: Array<Candidate>, 'UserContext.EventNumber.Id'?: number, 'UserContext.EventNumber.IdUser'?: number, 'UserContext.EventNumber.NumberMaxEvent'?: number, 'UserContext.EventNumber.User.Id'?: number, 'UserContext.EventNumber.User.DNI'?: string, 'UserContext.EventNumber.User.UserName'?: string, 'UserContext.EventNumber.User.Password'?: string, 'UserContext.EventNumber.User.TemPassword'?: string, 'UserContext.EventNumber.User.FirstName'?: string, 'UserContext.EventNumber.User.SecondName'?: string, 'UserContext.EventNumber.User.FirstLastName'?: string, 'UserContext.EventNumber.User.SecondLastName'?: string, 'UserContext.EventNumber.User.BirthDate'?: string, 'UserContext.EventNumber.User.Email'?: string, 'UserContext.EventNumber.User.IsActive'?: boolean, 'UserContext.EventNumber.User.IsAdministrator'?: boolean, 'UserContext.EventNumber.User.ListEventAdministrator'?: Array<EventAdministrator>, 'UserContext.EventNumber.User.ListCandidate'?: Array<Candidate>, 'UserContext.EventNumber.User.EventNumber'?: EventNumber, 'PathRoot'?: string }
  }): Observable<StrictHttpResponse<Unit>> {

    const rb = new RequestBuilder(this.rootUrl, EventService.ApiEventsIdEventImagePostPath, 'post');
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
        return r as StrictHttpResponse<Unit>;
      })
    );
  }

  /**
   * Guardar Imágen del evento.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiEventsIdEventImagePost$Json$Response()` instead.
   *
   * This method sends `multipart/form-data` and handles request body of type `multipart/form-data`.
   */
  apiEventsIdEventImagePost$Json(params: {
    idEvent: number;
    body?: { 'Image': Blob, 'IdEvent'?: number, 'TokenModel.Username'?: string, 'TokenModel.Email'?: string, 'TokenModel.Id'?: string, 'UserContext.Id'?: number, 'UserContext.DNI'?: string, 'UserContext.UserName'?: string, 'UserContext.Password'?: string, 'UserContext.TemPassword'?: string, 'UserContext.FirstName'?: string, 'UserContext.SecondName'?: string, 'UserContext.FirstLastName'?: string, 'UserContext.SecondLastName'?: string, 'UserContext.BirthDate'?: string, 'UserContext.Email'?: string, 'UserContext.IsActive'?: boolean, 'UserContext.IsAdministrator'?: boolean, 'UserContext.ListEventAdministrator'?: Array<EventAdministrator>, 'UserContext.ListCandidate'?: Array<Candidate>, 'UserContext.EventNumber.Id'?: number, 'UserContext.EventNumber.IdUser'?: number, 'UserContext.EventNumber.NumberMaxEvent'?: number, 'UserContext.EventNumber.User.Id'?: number, 'UserContext.EventNumber.User.DNI'?: string, 'UserContext.EventNumber.User.UserName'?: string, 'UserContext.EventNumber.User.Password'?: string, 'UserContext.EventNumber.User.TemPassword'?: string, 'UserContext.EventNumber.User.FirstName'?: string, 'UserContext.EventNumber.User.SecondName'?: string, 'UserContext.EventNumber.User.FirstLastName'?: string, 'UserContext.EventNumber.User.SecondLastName'?: string, 'UserContext.EventNumber.User.BirthDate'?: string, 'UserContext.EventNumber.User.Email'?: string, 'UserContext.EventNumber.User.IsActive'?: boolean, 'UserContext.EventNumber.User.IsAdministrator'?: boolean, 'UserContext.EventNumber.User.ListEventAdministrator'?: Array<EventAdministrator>, 'UserContext.EventNumber.User.ListCandidate'?: Array<Candidate>, 'UserContext.EventNumber.User.EventNumber'?: EventNumber, 'PathRoot'?: string }
  }): Observable<Unit> {

    return this.apiEventsIdEventImagePost$Json$Response(params).pipe(
      map((r: StrictHttpResponse<Unit>) => r.body as Unit)
    );
  }

}
