/* tslint:disable */
/* eslint-disable */

/**
 * Response para crear usuario
 */
export interface UserCreateResponse {

  /**
   * Fecha de nacimiento Usuario
   */
  birthDate: string;

  /**
   * Cédula Usuario
   */
  dni: string;

  /**
   * Email Usuario
   */
  email?: null | string;

  /**
   * Primer Apellido Usuario
   */
  firstLastName: string;

  /**
   * Primer nombre Usuario
   */
  firstName: string;

  /**
   * Id de usuario
   */
  id?: number;

  /**
   * Estado del Usuario
   */
  isActive?: boolean;

  /**
   * Número maximo de eventos permitidos
   */
  maxEventsAllow?: number;

  /**
   * Segundo Apellido Usuario
   */
  secondLastName?: null | string;

  /**
   * Segundo nombre Usuario
   */
  secondName?: null | string;

  /**
   * Nick Usuario
   */
  userName: string;
}
