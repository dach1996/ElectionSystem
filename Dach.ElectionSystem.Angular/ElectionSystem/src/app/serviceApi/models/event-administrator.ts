/* tslint:disable */
/* eslint-disable */
import { Event } from './event';
import { User } from './user';

/**
 * Tabla Administradores de eventos
 */
export interface EventAdministrator {

  /**
   * Fecha de registro
   */
  date?: string;
  event?: Event;

  /**
   * Id Candidato
   */
  id?: number;

  /**
   * Id Evento
   */
  idEvent?: number;

  /**
   * Id Usuario
   */
  idUser?: number;

  /**
   * Estado del Administrador
   */
  isActive?: boolean;

  /**
   * Privilegios
   */
  privileges?: null | string;
  user?: User;
}
