/* tslint:disable */
/* eslint-disable */
import { Candidate } from './candidate';
import { Event } from './event';
import { User } from './user';

/**
 * Clase para persistencia de votos
 */
export interface Vote {
  candidate?: Candidate;

  /**
   * Cédula Usuario
   */
  dateInscription?: string;

  /**
   * Cédula Usuario
   */
  dateVote?: null | string;
  event?: Event;

  /**
   * Cédula Usuario
   */
  hasVote?: boolean;

  /**
   * Id único usuario
   */
  id?: number;

  /**
   * Cédula Usuario
   */
  idCandidate?: number;

  /**
   * Cédula Usuario
   */
  idEvent?: number;

  /**
   * Cédula Usuario
   */
  idUser?: number;

  /**
   * Cédula Usuario
   */
  isActive?: boolean;
  user?: User;
}
