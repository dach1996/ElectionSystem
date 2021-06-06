/* tslint:disable */
/* eslint-disable */
import { VoteBaseResponse } from './vote-base-response';

/**
 * Clase VoteGetResponse
 */
export interface VoteGetResponse {

  /**
   * Lista de Voteos
   */
  listVotes?: null | Array<VoteBaseResponse>;

  /**
   * Número de participantes totales y contables
   */
  numberParticipantsActive?: number;

  /**
   * Número de participantes eliminados o desactivados
   */
  numberParticipantsDesactive?: number;

  /**
   * Número de participantes sin votar
   */
  numberParticipantsWithOutVote?: number;

  /**
   * Número de participantes que han votado
   */
  numberParticipantsWithVote?: number;
}
