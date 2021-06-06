/* tslint:disable */
/* eslint-disable */
import { CandidateImage } from './candidate-image';
import { Event } from './event';
import { User } from './user';
import { Vote } from './vote';

/**
 * Clase de Persistencia Candidatos
 */
export interface Candidate {

  /**
   * Edad de Candidato
   */
  age?: number;

  /**
   * Detalles de Candidato
   */
  details?: null | string;
  event?: Event;

  /**
   * Id Candidato
   */
  id?: number;

  /**
   * Id del evento
   */
  idEvent?: number;

  /**
   * Id del Usuario
   */
  idUser?: number;

  /**
   * Estado de Candidato
   */
  isActive?: boolean;

  /**
   * Relación con Imagenes de candidato
   */
  listCandidateImage?: null | Array<CandidateImage>;

  /**
   * Relación con Votos
   */
  listVotes?: null | Array<Vote>;

  /**
   * Puestos Laborales de candidato
   */
  postionsWorks?: null | string;

  /**
   * Propuesta de Candidato
   */
  proposalDetails?: null | string;

  /**
   * Rol de Candidato
   */
  role?: null | string;
  user?: User;

  /**
   * Ruta Video de Candidato
   */
  video?: null | string;
}
