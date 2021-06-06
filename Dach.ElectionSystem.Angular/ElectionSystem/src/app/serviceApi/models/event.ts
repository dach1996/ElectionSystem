/* tslint:disable */
/* eslint-disable */
import { Candidate } from './candidate';
import { EventAdministrator } from './event-administrator';
import { User } from './user';
import { Vote } from './vote';

/**
 * Clase de persistencia Eventos
 */
export interface Event {

  /**
   * Permitir libre inscripción al evento
   */
  allowFreeAccess?: boolean;

  /**
   * Categoría de Evento.
   */
  category?: null | string;

  /**
   * Código de Evento
   */
  codeEvent?: null | string;

  /**
   * Fecha de Registro
   */
  dateMaxRegisterCandidate: string;

  /**
   * Fecha de Registro
   */
  dateMaxRegisterParticipants: string;

  /**
   * Fecha de Registro
   */
  dateMaxVote: string;

  /**
   * Fecha de Registro
   */
  dateMinVote: string;

  /**
   * Fecha de Registro
   */
  dateRegister: string;

  /**
   * Descripción de Evento
   */
  description?: null | string;

  /**
   * Id de evento
   */
  id?: number;

  /**
   * Id Usuario Creador de evento
   */
  idUser?: number;

  /**
   * Dirección de foto de Evento
   */
  image?: null | string;

  /**
   * Evento está Activo
   */
  isActive?: boolean;

  /**
   * Borrado Lógico del Evento
   */
  isDelete?: boolean;

  /**
   * Eventos Usuarios
   */
  listCandidate?: null | Array<Candidate>;

  /**
   * Eventos Usuarios
   */
  listEventAdministrator?: null | Array<EventAdministrator>;

  /**
   * Eventos Usuarios
   */
  listVote?: null | Array<Vote>;

  /**
   * Permitir  máximo de personas por evento
   */
  maxPeople?: boolean;

  /**
   * Nombre evento
   */
  name?: null | string;

  /**
   * Número máximo de candidatos
   */
  numberMaxCandidate?: number;

  /**
   * Numero máximo de participantes
   */
  numberMaxPeople?: number;
  userCreator?: User;
}
