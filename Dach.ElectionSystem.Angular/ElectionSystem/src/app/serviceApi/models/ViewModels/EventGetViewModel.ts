import { UserBaseResponse } from "../user-base-response";

export interface EventGetViewModel {

 
  dateRegister?: string;
  /**
   * Ruta de imagen para evento
   */
  image?: null | string;

  /**
   * Estado de Evento
   */
  isActive?: boolean;

  /**
   * Nombre de evento
   */
  name: string;

  /**
   * name
   */
  category: string;
  /**
   * Usuario
   */

  user? : null | UserBaseResponse;
}