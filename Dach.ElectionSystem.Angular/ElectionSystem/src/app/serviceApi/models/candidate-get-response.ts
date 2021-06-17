import { CandidateBaseResponse } from './candidate-base-response';

/**
 * Clase CandidateGetResponse
 */
export interface CandidateGetResponse {

  /**
   * Lista de Candidatos
   */
  listCandidate?: null | Array<CandidateBaseResponse>;

  /**
   * Cantidad total de candidatos en el evento
   */
  totalCandidates?: number;
}
