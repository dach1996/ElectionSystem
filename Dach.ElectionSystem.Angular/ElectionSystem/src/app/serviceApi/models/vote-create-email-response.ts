/* tslint:disable */
/* eslint-disable */

/**
 * Clase VoteCreateEmailResponse
 */
export interface VoteCreateEmailResponse {

  /**
   * Lista de Correos de usuarios registrados
   */
  emailUserRegister?: null | Array<string>;

  /**
   * Lista de Correos de usuarios no registrados
   */
  emailUserWithOutRegister?: null | Array<string>;

  /**
   * Número de correos de Usuarios
   */
  numberRegister?: number;

  /**
   * Cantidad de Correos de usuarios no registrados
   */
  numberSendEmail?: number;
}
