/* tslint:disable */
/* eslint-disable */

/**
 * Clase base para respuestas
 */
export interface EventAdministratorBaseResponse {

  /**
   * Fecha de Cambio
   */
  date?: string;

  /**
   * Id Evento
   */
  idEvent?: number;

  /**
   * Id Usuario
   */
  idUser?: number;

  /**
   * Estado de EventAdministratoro
   */
  isActive?: boolean;

  /**
   * Privilegios
   */
  privileges?: null | string;
}
