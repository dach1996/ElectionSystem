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

import { ChangePasswordRequest } from '../models/change-password-request';
import { IncreaseEventsRequest } from '../models/increase-events-request';
import { OrderBy } from '../models/order-by';
import { RolUser } from '../models/rol-user';
import { TypeFilterUser } from '../models/type-filter-user';
import { UnitGenericResponse } from '../models/unit-generic-response';
import { UserCreateRequest } from '../models/user-create-request';
import { UserCreateResponseGenericResponse } from '../models/user-create-response-generic-response';
import { UserGetResponseGenericResponse } from '../models/user-get-response-generic-response';
import { UserUpdateRequest } from '../models/user-update-request';
import { UserUpdateResponseGenericResponse } from '../models/user-update-response-generic-response';

@Injectable({
  providedIn: 'root',
})
export class UserService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation apiUsersGet
   */
  static readonly ApiUsersGetPath = '/api/users';

  /**
   * Consultar Usuarios.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiUsersGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiUsersGet$Plain$Response(params: {

    /**
     * Nick de Usuario
     */
    Username?: string;

    /**
     * Nombre Usuario
     */
    FirstName?: string;

    /**
     * Apellido Usuario
     */
    LastName?: string;

    /**
     * Rol de Usuario
     */
    Role?: RolUser;

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
    TypeFilter?: TypeFilterUser;
  }): Observable<StrictHttpResponse<UserGetResponseGenericResponse>> {

    const rb = new RequestBuilder(this.rootUrl, UserService.ApiUsersGetPath, 'get');
    if (params) {
      rb.query('Username', params.Username, {});
      rb.query('FirstName', params.FirstName, {});
      rb.query('LastName', params.LastName, {});
      rb.query('Role', params.Role, {});
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
        return r as StrictHttpResponse<UserGetResponseGenericResponse>;
      })
    );
  }

  /**
   * Consultar Usuarios.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiUsersGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiUsersGet$Plain(params: {

    /**
     * Nick de Usuario
     */
    Username?: string;

    /**
     * Nombre Usuario
     */
    FirstName?: string;

    /**
     * Apellido Usuario
     */
    LastName?: string;

    /**
     * Rol de Usuario
     */
    Role?: RolUser;

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
    TypeFilter?: TypeFilterUser;
  }): Observable<UserGetResponseGenericResponse> {

    return this.apiUsersGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<UserGetResponseGenericResponse>) => r.body as UserGetResponseGenericResponse)
    );
  }

  /**
   * Consultar Usuarios.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiUsersGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiUsersGet$Json$Response(params: {

    /**
     * Nick de Usuario
     */
    Username?: string;

    /**
     * Nombre Usuario
     */
    FirstName?: string;

    /**
     * Apellido Usuario
     */
    LastName?: string;

    /**
     * Rol de Usuario
     */
    Role?: RolUser;

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
    TypeFilter?: TypeFilterUser;
  }): Observable<StrictHttpResponse<UserGetResponseGenericResponse>> {

    const rb = new RequestBuilder(this.rootUrl, UserService.ApiUsersGetPath, 'get');
    if (params) {
      rb.query('Username', params.Username, {});
      rb.query('FirstName', params.FirstName, {});
      rb.query('LastName', params.LastName, {});
      rb.query('Role', params.Role, {});
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
        return r as StrictHttpResponse<UserGetResponseGenericResponse>;
      })
    );
  }

  /**
   * Consultar Usuarios.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiUsersGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiUsersGet$Json(params: {

    /**
     * Nick de Usuario
     */
    Username?: string;

    /**
     * Nombre Usuario
     */
    FirstName?: string;

    /**
     * Apellido Usuario
     */
    LastName?: string;

    /**
     * Rol de Usuario
     */
    Role?: RolUser;

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
    TypeFilter?: TypeFilterUser;
  }): Observable<UserGetResponseGenericResponse> {

    return this.apiUsersGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<UserGetResponseGenericResponse>) => r.body as UserGetResponseGenericResponse)
    );
  }

  /**
   * Path part for operation apiUsersPut
   */
  static readonly ApiUsersPutPath = '/api/users';

  /**
   * Actualizar Usuario.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiUsersPut$Plain()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiUsersPut$Plain$Response(params?: {
    body?: UserUpdateRequest
  }): Observable<StrictHttpResponse<UserUpdateResponseGenericResponse>> {

    const rb = new RequestBuilder(this.rootUrl, UserService.ApiUsersPutPath, 'put');
    if (params) {
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<UserUpdateResponseGenericResponse>;
      })
    );
  }

  /**
   * Actualizar Usuario.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiUsersPut$Plain$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiUsersPut$Plain(params?: {
    body?: UserUpdateRequest
  }): Observable<UserUpdateResponseGenericResponse> {

    return this.apiUsersPut$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<UserUpdateResponseGenericResponse>) => r.body as UserUpdateResponseGenericResponse)
    );
  }

  /**
   * Actualizar Usuario.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiUsersPut$Json()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiUsersPut$Json$Response(params?: {
    body?: UserUpdateRequest
  }): Observable<StrictHttpResponse<UserUpdateResponseGenericResponse>> {

    const rb = new RequestBuilder(this.rootUrl, UserService.ApiUsersPutPath, 'put');
    if (params) {
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<UserUpdateResponseGenericResponse>;
      })
    );
  }

  /**
   * Actualizar Usuario.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiUsersPut$Json$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiUsersPut$Json(params?: {
    body?: UserUpdateRequest
  }): Observable<UserUpdateResponseGenericResponse> {

    return this.apiUsersPut$Json$Response(params).pipe(
      map((r: StrictHttpResponse<UserUpdateResponseGenericResponse>) => r.body as UserUpdateResponseGenericResponse)
    );
  }

  /**
   * Path part for operation apiUsersPost
   */
  static readonly ApiUsersPostPath = '/api/users';

  /**
   * Crear Usuario.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiUsersPost$Plain()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiUsersPost$Plain$Response(params?: {
    body?: UserCreateRequest
  }): Observable<StrictHttpResponse<UserCreateResponseGenericResponse>> {

    const rb = new RequestBuilder(this.rootUrl, UserService.ApiUsersPostPath, 'post');
    if (params) {
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<UserCreateResponseGenericResponse>;
      })
    );
  }

  /**
   * Crear Usuario.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiUsersPost$Plain$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiUsersPost$Plain(params?: {
    body?: UserCreateRequest
  }): Observable<UserCreateResponseGenericResponse> {

    return this.apiUsersPost$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<UserCreateResponseGenericResponse>) => r.body as UserCreateResponseGenericResponse)
    );
  }

  /**
   * Crear Usuario.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiUsersPost$Json()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiUsersPost$Json$Response(params?: {
    body?: UserCreateRequest
  }): Observable<StrictHttpResponse<UserCreateResponseGenericResponse>> {

    const rb = new RequestBuilder(this.rootUrl, UserService.ApiUsersPostPath, 'post');
    if (params) {
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<UserCreateResponseGenericResponse>;
      })
    );
  }

  /**
   * Crear Usuario.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiUsersPost$Json$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiUsersPost$Json(params?: {
    body?: UserCreateRequest
  }): Observable<UserCreateResponseGenericResponse> {

    return this.apiUsersPost$Json$Response(params).pipe(
      map((r: StrictHttpResponse<UserCreateResponseGenericResponse>) => r.body as UserCreateResponseGenericResponse)
    );
  }

  /**
   * Path part for operation apiUsersIdGet
   */
  static readonly ApiUsersIdGetPath = '/api/users/{id}';

  /**
   * Consultar Usuarios por Id.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiUsersIdGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiUsersIdGet$Plain$Response(params: {

    /**
     * Nick de Usuario
     */
    Username?: string;

    /**
     * Nombre Usuario
     */
    FirstName?: string;

    /**
     * Apellido Usuario
     */
    LastName?: string;

    /**
     * Rol de Usuario
     */
    Role?: RolUser;

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
    TypeFilter?: TypeFilterUser;
    id: number;
  }): Observable<StrictHttpResponse<UserGetResponseGenericResponse>> {

    const rb = new RequestBuilder(this.rootUrl, UserService.ApiUsersIdGetPath, 'get');
    if (params) {
      rb.query('Username', params.Username, {});
      rb.query('FirstName', params.FirstName, {});
      rb.query('LastName', params.LastName, {});
      rb.query('Role', params.Role, {});
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
        return r as StrictHttpResponse<UserGetResponseGenericResponse>;
      })
    );
  }

  /**
   * Consultar Usuarios por Id.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiUsersIdGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiUsersIdGet$Plain(params: {

    /**
     * Nick de Usuario
     */
    Username?: string;

    /**
     * Nombre Usuario
     */
    FirstName?: string;

    /**
     * Apellido Usuario
     */
    LastName?: string;

    /**
     * Rol de Usuario
     */
    Role?: RolUser;

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
    TypeFilter?: TypeFilterUser;
    id: number;
  }): Observable<UserGetResponseGenericResponse> {

    return this.apiUsersIdGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<UserGetResponseGenericResponse>) => r.body as UserGetResponseGenericResponse)
    );
  }

  /**
   * Consultar Usuarios por Id.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiUsersIdGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiUsersIdGet$Json$Response(params: {

    /**
     * Nick de Usuario
     */
    Username?: string;

    /**
     * Nombre Usuario
     */
    FirstName?: string;

    /**
     * Apellido Usuario
     */
    LastName?: string;

    /**
     * Rol de Usuario
     */
    Role?: RolUser;

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
    TypeFilter?: TypeFilterUser;
    id: number;
  }): Observable<StrictHttpResponse<UserGetResponseGenericResponse>> {

    const rb = new RequestBuilder(this.rootUrl, UserService.ApiUsersIdGetPath, 'get');
    if (params) {
      rb.query('Username', params.Username, {});
      rb.query('FirstName', params.FirstName, {});
      rb.query('LastName', params.LastName, {});
      rb.query('Role', params.Role, {});
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
        return r as StrictHttpResponse<UserGetResponseGenericResponse>;
      })
    );
  }

  /**
   * Consultar Usuarios por Id.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiUsersIdGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiUsersIdGet$Json(params: {

    /**
     * Nick de Usuario
     */
    Username?: string;

    /**
     * Nombre Usuario
     */
    FirstName?: string;

    /**
     * Apellido Usuario
     */
    LastName?: string;

    /**
     * Rol de Usuario
     */
    Role?: RolUser;

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
    TypeFilter?: TypeFilterUser;
    id: number;
  }): Observable<UserGetResponseGenericResponse> {

    return this.apiUsersIdGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<UserGetResponseGenericResponse>) => r.body as UserGetResponseGenericResponse)
    );
  }

  /**
   * Path part for operation apiUsersChangepasswordPost
   */
  static readonly ApiUsersChangepasswordPostPath = '/api/users/changepassword';

  /**
   * Cambiar Contraseña.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiUsersChangepasswordPost$Plain()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiUsersChangepasswordPost$Plain$Response(params?: {
    body?: ChangePasswordRequest
  }): Observable<StrictHttpResponse<UnitGenericResponse>> {

    const rb = new RequestBuilder(this.rootUrl, UserService.ApiUsersChangepasswordPostPath, 'post');
    if (params) {
      rb.body(params.body, 'application/*+json');
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
   * Cambiar Contraseña.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiUsersChangepasswordPost$Plain$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiUsersChangepasswordPost$Plain(params?: {
    body?: ChangePasswordRequest
  }): Observable<UnitGenericResponse> {

    return this.apiUsersChangepasswordPost$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<UnitGenericResponse>) => r.body as UnitGenericResponse)
    );
  }

  /**
   * Cambiar Contraseña.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiUsersChangepasswordPost$Json()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiUsersChangepasswordPost$Json$Response(params?: {
    body?: ChangePasswordRequest
  }): Observable<StrictHttpResponse<UnitGenericResponse>> {

    const rb = new RequestBuilder(this.rootUrl, UserService.ApiUsersChangepasswordPostPath, 'post');
    if (params) {
      rb.body(params.body, 'application/*+json');
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
   * Cambiar Contraseña.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiUsersChangepasswordPost$Json$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiUsersChangepasswordPost$Json(params?: {
    body?: ChangePasswordRequest
  }): Observable<UnitGenericResponse> {

    return this.apiUsersChangepasswordPost$Json$Response(params).pipe(
      map((r: StrictHttpResponse<UnitGenericResponse>) => r.body as UnitGenericResponse)
    );
  }

  /**
   * Path part for operation apiUsersIncreaseEventsPost
   */
  static readonly ApiUsersIncreaseEventsPostPath = '/api/users/increaseEvents';

  /**
   * Incrementar el número de eventos permitidos.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiUsersIncreaseEventsPost$Plain()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiUsersIncreaseEventsPost$Plain$Response(params?: {
    body?: IncreaseEventsRequest
  }): Observable<StrictHttpResponse<UnitGenericResponse>> {

    const rb = new RequestBuilder(this.rootUrl, UserService.ApiUsersIncreaseEventsPostPath, 'post');
    if (params) {
      rb.body(params.body, 'application/*+json');
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
   * Incrementar el número de eventos permitidos.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiUsersIncreaseEventsPost$Plain$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiUsersIncreaseEventsPost$Plain(params?: {
    body?: IncreaseEventsRequest
  }): Observable<UnitGenericResponse> {

    return this.apiUsersIncreaseEventsPost$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<UnitGenericResponse>) => r.body as UnitGenericResponse)
    );
  }

  /**
   * Incrementar el número de eventos permitidos.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiUsersIncreaseEventsPost$Json()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiUsersIncreaseEventsPost$Json$Response(params?: {
    body?: IncreaseEventsRequest
  }): Observable<StrictHttpResponse<UnitGenericResponse>> {

    const rb = new RequestBuilder(this.rootUrl, UserService.ApiUsersIncreaseEventsPostPath, 'post');
    if (params) {
      rb.body(params.body, 'application/*+json');
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
   * Incrementar el número de eventos permitidos.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiUsersIncreaseEventsPost$Json$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiUsersIncreaseEventsPost$Json(params?: {
    body?: IncreaseEventsRequest
  }): Observable<UnitGenericResponse> {

    return this.apiUsersIncreaseEventsPost$Json$Response(params).pipe(
      map((r: StrictHttpResponse<UnitGenericResponse>) => r.body as UnitGenericResponse)
    );
  }

}
