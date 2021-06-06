/* tslint:disable */
/* eslint-disable */
import { Candidate } from './candidate';
import { EventAdministrator } from './event-administrator';
import { EventNumber } from './event-number';

/**
 * Mapeo de Tabla Usuarios
 */
export interface User {

  /**
   * Fecha de nacimiento Usuario
   */
  birthDate?: null | string;

  /**
   * Cédula Usuario
   */
  dni?: null | string;

  /**
   * Email Usuario
   */
  email?: null | string;
  eventNumber?: EventNumber;

  /**
   * Primer Apellido Usuario
   */
  firstLastName?: null | string;

  /**
   * Primer nombre Usuario
   */
  firstName?: null | string;

  /**
   * Id único usuario
   */
  id?: number;

  /**
   * Estado de Usuario
   */
  isActive?: boolean;

  /**
   * Estado de Usuario
   */
  isAdministrator?: boolean;

  /**
   * Lista de Candidatos que puede ser el usuario
   */
  listCandidate?: null | Array<Candidate>;

  /**
   * Lista de Eventos administradors por el usuario
   */
  listEventAdministrator?: null | Array<EventAdministrator>;

  /**
   * Contraseña Usuario
   */
  password?: null | string;

  /**
   * Segundo Apellido Usuario
   */
  secondLastName?: null | string;

  /**
   * Segundo nombre Usuario
   */
  secondName?: null | string;

  /**
   * Contraseña Usuario
   */
  temPassword?: null | string;

  /**
   * Nick Usuario
   */
  userName?: null | string;
}
