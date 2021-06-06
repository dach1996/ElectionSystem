/* tslint:disable */
/* eslint-disable */
import { Unit } from './unit';

/**
 * Respuesta genérica
 */
export interface UnitGenericResponse {

  /**
   * Código de respuesta
   */
  code?: number;
  content?: Unit;

  /**
   * Mensaje al usuario
   */
  message?: null | string;

  /**
   * Response type
   */
  responseType?: null | string;
}
