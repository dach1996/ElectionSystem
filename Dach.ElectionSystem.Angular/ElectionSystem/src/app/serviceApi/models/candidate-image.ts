/* tslint:disable */
/* eslint-disable */
import { Candidate } from './candidate';
import { Event } from './event';

/**
 * Clase de Persistencia Imagenes de candidatos
 */
export interface CandidateImage {
  candidate?: Candidate;

  /**
   * Ambiente
   */
  environment?: null | string;
  event?: Event;

  /**
   * Id de imagen de dandidato
   */
  id?: number;

  /**
   * Id del candidato
   */
  idCandidate?: number;

  /**
   * Id del evento
   */
  idEvent?: number;

  /**
   * Imagen
   */
  image?: null | string;

  /**
   * Obtener la ruta completa de la imagen
   */
  imageFullPath?: null | string;
}
