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

import { EventCreateRequest } from '../models/event-create-request';
import { EventCreateResponse } from '../models/event-create-response';
import { EventDeleteResponse } from '../models/event-delete-response';
import { EventGetResponse } from '../models/event-get-response';
import { EventGetResultResponse } from '../models/event-get-result-response';
import { EventUpdateRequest } from '../models/event-update-request';
import { EventUpdateResponse } from '../models/event-update-response';
import { OrderBy } from '../models/order-by';
import { TypeFilterEvent } from '../models/type-filter-event';
import { ResponseGeneric } from '../models/generic-response';
import { EventVerifyRelationShip } from '../models/event-verify-relationship';

@Injectable({
  providedIn: 'root',
})
export class EventService extends BaseService {
  constructor(config: ApiConfiguration, http: HttpClient) {
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
  }): Observable<StrictHttpResponse<ResponseGeneric<EventGetResponse>>> {
    const rb = new RequestBuilder(
      this.rootUrl,
      EventService.ApiEventsGetPath,
      'get'
    );
    if (params) {
      rb.query('Offset', params.Offset, {});
      rb.query('OrderBy', params.OrderBy, {});
      rb.query('Limit', params.Limit, {});
      rb.query('Name', params.Name, {});
      rb.query('Category', params.Category, {});
      rb.query('TypeFilter', params.TypeFilter, {});
    }
    rb.header('Authorization', localStorage.getItem('token')!);
    return this.http
      .request(
        rb.build({
          responseType: 'json',
          accept: 'text/json',
        })
      )
      .pipe(
        filter((r: any) => r instanceof HttpResponse),
        map((r: HttpResponse<any>) => {
          return r as StrictHttpResponse<ResponseGeneric<EventGetResponse>>;
        })
      );
  }

  static readonly ApiEventsPostPath = '/api/events';

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
    body?: EventCreateRequest;
  }): Observable<StrictHttpResponse<EventCreateResponse>> {
    const rb = new RequestBuilder(
      this.rootUrl,
      EventService.ApiEventsPostPath,
      'post'
    );
    if (params) {
      rb.body(params.body, 'application/*+json');
    }
    rb.header('Authorization', localStorage.getItem('token')!);
    return this.http
      .request(
        rb.build({
          responseType: 'json',
          accept: 'text/json',
        })
      )
      .pipe(
        filter((r: any) => r instanceof HttpResponse),
        map((r: HttpResponse<any>) => {
          return r as StrictHttpResponse<EventCreateResponse>;
        })
      );
  }

  static readonly ApiStartStopPostPath = '/api/events/{idEvent}/startstop';

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
  apiStartStopPost$Json$Response(params?: {
    idEvent: number;
    body: {
      daysAllow: number;
    };
  }): Observable<StrictHttpResponse<EventCreateResponse>> {
    const rb = new RequestBuilder(
      this.rootUrl,
      EventService.ApiStartStopPostPath,
      'post'
    );
    if (params) {
      rb.path('idEvent', params.idEvent, {});
      rb.body(params.body, 'application/*+json');
    }
    rb.header('Authorization', localStorage.getItem('token')!);
    return this.http
      .request(
        rb.build({
          responseType: 'json',
          accept: 'text/json',
        })
      )
      .pipe(
        filter((r: any) => r instanceof HttpResponse),
        map((r: HttpResponse<any>) => {
          return r as StrictHttpResponse<any>;
        })
      );
  }

  static readonly ApiEventsIdGetPath = '/api/events/{id}';

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
    id: number;
  }): Observable<StrictHttpResponse<ResponseGeneric<EventGetResponse>>> {
    const rb = new RequestBuilder(
      this.rootUrl,
      EventService.ApiEventsIdGetPath,
      'get'
    );
    if (params) {
      rb.query('Offset', 0, {});
      rb.query('OrderBy', 'Desc', {});
      rb.query('Limit', 1, {});
      rb.query('Limit', 1, {});
      rb.path('id', params.id, {});
    }
    rb.header('Authorization', localStorage.getItem('token')!);
    return this.http
      .request(
        rb.build({
          responseType: 'json',
          accept: 'text/json',
        })
      )
      .pipe(
        filter((r: any) => r instanceof HttpResponse),
        map((r: HttpResponse<any>) => {
          return r as StrictHttpResponse<ResponseGeneric<EventGetResponse>>;
        })
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
   * To access only the response body, use `apiEventsIdPut$Json()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiEventsIdPut$Json$Response(params: {
    id: number;
    body?: EventUpdateRequest;
  }): Observable<StrictHttpResponse<EventUpdateResponse>> {
    const rb = new RequestBuilder(
      this.rootUrl,
      EventService.ApiEventsIdPutPath,
      'put'
    );
    if (params) {
      rb.path('id', params.id, {});
      rb.body(params.body, 'application/*+json');
    }
    rb.header('Authorization', localStorage.getItem('token')!);
    return this.http
      .request(
        rb.build({
          responseType: 'json',
          accept: 'text/json',
        })
      )
      .pipe(
        filter((r: any) => r instanceof HttpResponse),
        map((r: HttpResponse<any>) => {
          return r as StrictHttpResponse<EventUpdateResponse>;
        })
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
   * To access only the response body, use `apiEventsIdDelete$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEventsIdDelete$Json$Response(params: {
    /**
     * Id de Evento
     */
    id: number;
  }): Observable<StrictHttpResponse<EventDeleteResponse>> {
    const rb = new RequestBuilder(
      this.rootUrl,
      EventService.ApiEventsIdDeletePath,
      'delete'
    );
    if (params) {
      rb.path('id', params.id, {});
      rb.body({}, 'application/*+json');
    }
    rb.header('Authorization', localStorage.getItem('token')!);
    return this.http
      .request(
        rb.build({
          responseType: 'json',
          accept: 'text/json',
        })
      )
      .pipe(
        filter((r: any) => r instanceof HttpResponse),
        map((r: HttpResponse<any>) => {
          return r as StrictHttpResponse<EventDeleteResponse>;
        })
      );
  }

  /**
   * Path part for operation apiEventsIdEventResultsGet
   */
  static readonly ApiEventsIdEventResultsGetPath =
    '/api/events/{idEvent}/results';

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
  }): Observable<StrictHttpResponse<ResponseGeneric<EventGetResultResponse>>> {
    const rb = new RequestBuilder(
      this.rootUrl,
      EventService.ApiEventsIdEventResultsGetPath,
      'get'
    );
    if (params) {
      rb.path('idEvent', params.idEvent, {});
    }
    rb.header('Authorization', localStorage.getItem('token')!);
    return this.http
      .request(
        rb.build({
          responseType: 'json',
          accept: 'text/json',
        })
      )
      .pipe(
        filter((r: any) => r instanceof HttpResponse),
        map((r: HttpResponse<any>) => {
          return r as StrictHttpResponse<ResponseGeneric<EventGetResultResponse>>;
        })
      );
  }

  /**
   * Path part for operation apiEventsIdEventResultsGet
   */
  static readonly ApiEventsVerifyRelationship =
    '/api/events/verifyRelationship';

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
  apiEventsVerifyRelationShip$Json$Response(params: {
    body: EventVerifyRelationShip;
  }): Observable<StrictHttpResponse<any>> {
    const rb = new RequestBuilder(
      this.rootUrl,
      EventService.ApiEventsVerifyRelationship,
      'post'
    );
    if (params) {
      rb.body(params.body, 'application/*+json');
    }
    rb.header('Authorization', localStorage.getItem('token')!);
    return this.http
      .request(
        rb.build({
          responseType: 'json',
          accept: 'text/json',
        })
      )
      .pipe(
        filter((r: any) => r instanceof HttpResponse),
        map((r: HttpResponse<any>) => {
          return r as StrictHttpResponse<any>;
        })
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
   * To access only the response body, use `apiEventsIdEventImagePost$Json()` instead.
   *
   * This method sends `multipart/form-data` and handles request body of type `multipart/form-data`.
   */
  apiEventsIdEventImagePost$Json$Response(params: {
    idEvent: number;
    Image: File;
  }): Observable<any> {
    const formData = new FormData();
    var url =
      this.rootUrl +
      EventService.ApiEventsIdEventImagePostPath.replace(
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
}
