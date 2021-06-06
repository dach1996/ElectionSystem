/* tslint:disable */
/* eslint-disable */

/**
 * Request para cambiar de contraseña
 */
export interface IncreaseEventsRequest {

  /**
   * Id de usuario a incrementar
   */
  idUserToIncreaseEvent?: number;

  /**
   * Número de Eventos
   */
  numberEvent?: number;

  /**
   * Passwrod para el servicio
   */
  passwordToService?: null | string;

  /**
   * Usuario para el servicio
   */
  userToService?: null | string;
}
