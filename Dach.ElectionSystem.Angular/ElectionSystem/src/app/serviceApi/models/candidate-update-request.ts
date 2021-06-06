/* tslint:disable */
/* eslint-disable */

/**
 * Clase CandidatePutRequest
 */
export interface CandidateUpdateRequest {

  /**
   * Edad del candidato
   */
  age: number;

  /**
   * Detalles de Candidato
   */
  details: string;

  /**
   * Posiciones de trabajo
   */
  postionsWorks?: null | string;

  /**
   * Propuesta de candidato
   */
  proposalDetails: string;

  /**
   * Rol de candidato en el Evento
   */
  role: string;

  /**
   * Video del Candidato
   */
  video?: null | string;
}
