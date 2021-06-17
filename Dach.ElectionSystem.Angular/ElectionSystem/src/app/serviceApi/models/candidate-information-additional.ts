/**
 * Clase base para respuesta de candidato
 */
export interface AdditionalInformationCandidate {

  alias?: string;
  likes: string;
  pastime: string;
  urlVideo: string;
  goals: string;
  sports: string;
}

export interface AdditionalInformation {

  additionalInformation?: AdditionalInformationCandidate
}