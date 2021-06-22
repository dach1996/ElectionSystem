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
   * Fecha  Máxima para registrar participantes
   */
  dateMaxRegisterParticipants: Date;

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
