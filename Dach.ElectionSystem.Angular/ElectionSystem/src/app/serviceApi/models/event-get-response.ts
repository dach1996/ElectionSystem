/* tslint:disable */
/* eslint-disable */
import { EventBaseResponse } from './event-base-response';

/**
 * Clase EventGetResponse
 */
export interface EventGetResponse {

  /**
   * Lista de Eventos
   */
  listEvents?: null | Array<EventBaseResponse>;

  /**
   * Número total de evento
   */
  totalEvents?: number;
}
