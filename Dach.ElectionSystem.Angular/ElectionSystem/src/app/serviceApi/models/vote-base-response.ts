/* tslint:disable */
/* eslint-disable */

import { UserBaseResponse } from "./user-base-response";

/**
 * Clase base para respuestas
 */
export interface VoteBaseResponse {

  /**
   * Cédula Usuario
   */
  date?: null | string;

  /**
   * Cédula Usuario
   */
  hasVote?: boolean;

  /**
   * Id de Voteo
   */
  id?: number;

  /**
   * Id de Candidato
   */
  idCandidate?: number;

  /**
   * Id de Evento
   */
  idEvent?: number;

  /**
   * Id de Usuario
   */
  idUser?: number;

  /**
   * Estado de Voteo
   */
  isActive?: boolean;

  /**
   * Usuario
   */
  user?: UserBaseResponse;
}
