
/**
 * Respuesta genérica
 */
export interface ResponseGeneric<T> {

  /**
   * Código de respuesta
   */
  code?: number;
  /**
   * Contenido
   */
  content?: T;

  /**
   * Mensaje al usuario
   */
  message?: null | string;

  /**
   * Response type
   */
  responseType?: null | string;
}
