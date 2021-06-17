/* tslint:disable */
/* eslint-disable */
import { AdditionalInformationCandidate } from './candidate-information-additional';
import { UserBaseResponse } from './user-base-response';

/**
 * Clase base para respuesta de candidato
 */
export interface CandidateBaseResponse {

  additionalInformation: string;
  information?: AdditionalInformationCandidate;
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

  user?: UserBaseResponse;

}
