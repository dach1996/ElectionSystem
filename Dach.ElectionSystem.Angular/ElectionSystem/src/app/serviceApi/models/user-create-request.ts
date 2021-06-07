/* tslint:disable */
/* eslint-disable */

/**
 * Request para crear Usuarios
 */
export interface UserCreateRequest {

  /**
   * Fecha de nacimiento Usuario
   */
  birthDate: Date;

  /**
   * Cédula Usuario
   */
  dni: string;

  /**
   * Email Usuario
   */
  email: string;

  /**
   * Primer Apellido Usuario
   */
  firstLastName: string;

  /**
   * Primer nombre Usuario
   */
  firstName: string;

  /**
   * Constraseña de Usuario
   */
  password: string;

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
