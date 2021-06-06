/* tslint:disable */
/* eslint-disable */
import { UserCreateResponse } from './user-create-response';

/**
 * Respuesta genérica
 */
export interface UserCreateResponseGenericResponse {

  /**
   * Código de respuesta
   */
  code?: number;
  content?: UserCreateResponse;

  /**
   * Mensaje al usuario
   */
  message?: null | string;

  /**
   * Response type
   */
  responseType?: null | string;
}
