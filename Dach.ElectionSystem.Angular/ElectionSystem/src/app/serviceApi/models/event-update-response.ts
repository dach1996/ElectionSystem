/* tslint:disable */
/* eslint-disable */

/**
 * Clase EventUpdateResponse
 */
export interface EventUpdateResponse {

  /**
   * Categoría de Evento
   */
  category: string;

  /**
   * CódigoEvento
   */
  codeEvent?: null | string;

  /**
   * Fecha Máxima para registrar Candidatos
   */
  dateMaxRegisterCandidate: string;

  /**
   * Fecha  Máxima para registrar participantes
   */
  dateMaxRegisterParticipants: string;

  /**
   * Fecha máxima para realizar votación
   */
  dateMaxVote: string;

  /**
   * Fecha  mínima para realizar votación
   */
  dateMinVote: string;

  /**
   * Fecha de Registro
   */
  dateRegister?: string;

  /**
   * Descripción de evento
   */
  description: string;

  /**
   * Id de Evento
   */
  id?: number;

  /**
   * Ruta de imagen para evento
   */
  image?: null | string;

  /**
   * Estado de Evento
   */
  isActive?: boolean;

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
