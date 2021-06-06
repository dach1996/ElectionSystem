/* tslint:disable */
/* eslint-disable */
import { UserBaseResponse } from './user-base-response';

/**
 * Clase LoginResponse
 */
export interface LoginResponse {

  /**
   * Respuesta Token
   */
  token?: null | string;
  user?: UserBaseResponse;
}
