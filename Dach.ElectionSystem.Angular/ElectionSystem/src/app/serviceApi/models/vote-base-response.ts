/* tslint:disable */
/* eslint-disable */

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
}
