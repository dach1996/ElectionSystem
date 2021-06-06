/* tslint:disable */
/* eslint-disable */
import { UserBaseResponse } from './user-base-response';

/**
 * Modelo para respuesta
 */
export interface CandidateWithVote {

  /**
   * Edad del candidato
   */
  age: number;

  /**
   * Detalles de Candidato
   */
  details: string;

  /**
   * Id de candidato
   */
  id?: number;

  /**
   * Id del Usuario
   */
  idUser?: number;

  /**
   * Id de candidato
   */
  isActive?: boolean;

  /**
   * Lista de Imágenes
   */
  listCandidateImage?: null | Array<string>;

  /**
   * Cantidad de Votos
   */
  numberVotes?: number;

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
  user?: UserBaseResponse;

  /**
   * Video del Candidato
   */
  video?: null | string;
}
