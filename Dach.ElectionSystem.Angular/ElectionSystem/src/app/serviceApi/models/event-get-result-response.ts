/* tslint:disable */
/* eslint-disable */
import { CandidateWithVote } from './candidate-with-vote';
import { EventBaseResponse } from './event-base-response';

/**
 * Clase EventGetResponse
 */
export interface EventGetResultResponse {

  /**
   * Candidatas
   */
  candidates?: null | Array<CandidateWithVote>;
  event?: EventBaseResponse;

  /**
   * Total de Votos en el evento
   */
  totalParticipantsVotes?: number;

  /**
   * Total participantes sin votar
   */
  totalParticipantsWithOutVotes?: number;
}
