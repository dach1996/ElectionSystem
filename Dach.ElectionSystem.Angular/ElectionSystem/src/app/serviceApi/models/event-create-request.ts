/* tslint:disable */
/* eslint-disable */

/**
 * Clase EventCreateRequest
 */
export interface EventCreateRequest {

  /**
   * Categoría de Evento
   */
  category: string;

  /**
   * Fecha Máxima para registrar Candidatos
   */
  dateMaxRegisterCandidate: Date;

  /**
   * Fecha  Máxima para registrar participantes
   */
  dateMaxRegisterParticipants: Date;

  /**
   * Fecha máxima para realizar votación
   */
  dateMaxVote: Date;

  /**
   * Fecha  mínima para realizar votación
   */
  dateMinVote: Date;

  /**
   * Descripción de evento
   */
  description: string;

  /**
   * Permitir máximo personas para Evento
   */
  maxPeople: boolean;

  /**
   * Nombre de evento
   */
  name: string;

  /**
   * Máximo de Candidatos
   */
  numberMaxCandidate: number;

  /**
   * Número máximo de personas para evento
   */
  numberMaxPeople: number;
}
