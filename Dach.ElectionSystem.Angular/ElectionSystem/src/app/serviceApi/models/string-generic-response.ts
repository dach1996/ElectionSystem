/* tslint:disable */
/* eslint-disable */

/**
 * Respuesta genérica
 */
export interface StringGenericResponse {

  /**
   * Código de respuesta
   */
  code?: number;

  /**
   * Información de vuelta al usuario
   */
  content?: null | string;

  /**
   * Mensaje al usuario
   */
  message?: null | string;

  /**
   * Response type
   */
  responseType?: null | string;
}
