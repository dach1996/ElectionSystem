/* tslint:disable */
/* eslint-disable */
import { UserUpdateResponse } from './user-update-response';

/**
 * Respuesta genérica
 */
export interface UserUpdateResponseGenericResponse {

  /**
   * Código de respuesta
   */
  code?: number;
  content?: UserUpdateResponse;

  /**
   * Mensaje al usuario
   */
  message?: null | string;

  /**
   * Response type
   */
  responseType?: null | string;
}
