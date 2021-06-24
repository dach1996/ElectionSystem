/* tslint:disable */
/* eslint-disable */

import { UserBaseResponse } from './user-base-response';

/**
 * Clase base para respuestas
 */
export interface EventBaseResponse {
  /**
   * Categoría de Evento
   */
  category: string;

  /**
   * CódigoEvento
   */
  codeEvent?: null | string;

  /**
   * Fecha  Máxima para registrar participantes
   */
  dateMaxRegisterParticipants: Date;

  /**
   * Fecha máxima para realizar votación
   */
  dateMaxVote: Date;

  /**
   * Fecha  mínima para realizar votación
   */
  dateMinVote: Date;

  /**
   * Fecha de Registro
   */
  dateRegister?: Date;

  /**
   * Descripción de evento
   */
  description: string;

  /**
   * Id de Evento
   */
  id?: number;

  /**
   * Ruta de imagen para evento
   */
  image?: null | string;

  /**
   * Estado de Evento
   */
  isActive?: boolean;

  /**
   * Permitir máximo personas para Evento
   */
  maxPeople: boolean;

  /**
   * Nombre de evento
   */
  name: string;

  /**
   * Máximo de Candidatos
   */
  numberMaxCandidate: number;

  /**
   * Número máximo de personas para evento
   */
  numberMaxPeople: number;

  /**
   * Usuario
   */
  user: UserBaseResponse;

  /**
   * Evento ha comenzado
   */
  isStarted: boolean;

  /**
   * Evento ha terminado
   */
  isFinished: boolean;
}
