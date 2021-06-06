/* tslint:disable */
/* eslint-disable */
import { UserGetResponse } from './user-get-response';

/**
 * Respuesta genérica
 */
export interface UserGetResponseGenericResponse {

  /**
   * Código de respuesta
   */
  code?: number;
  content?: UserGetResponse;

  /**
   * Mensaje al usuario
   */
  message?: null | string;

  /**
   * Response type
   */
  responseType?: null | string;
}
