/* tslint:disable */
/* eslint-disable */
import { LoginResponse } from './login-response';

/**
 * Respuesta genérica
 */
export interface LoginResponseGenericResponse {

  /**
   * Código de respuesta
   */
  code?: number;
  content?: LoginResponse;

  /**
   * Mensaje al usuario
   */
  message?: null | string;

  /**
   * Response type
   */
  responseType?: null | string;
}
