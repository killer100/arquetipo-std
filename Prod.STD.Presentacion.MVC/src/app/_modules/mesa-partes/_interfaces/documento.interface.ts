import { IAdjunto } from "./adjunto.interface";

export interface IDocumento {
    id_documento?: number;
    num_tram_documentario?: string;
    indicativo_oficio?: string;
    fecha_recepcion?: any;
    asunto?: string;
    referencia?: string;
    id_clase_documento_interno?: number;
    folios?: number;
    observaciones?: string;
    oficina_derivada?: number;
    copias?: Array<number>;
    id_persona?: number;
    persona?: any;
    id_tup?: number;
    requisitos?: Array<any>;
    anexos?: Array<IAdjunto>;
}

export const DEFAULT_DOCUMENTO = {
    id_documento: null,
    num_tram_documentario: null,
    indicativo_oficio: null,
    fecha_recepcion: null,
    asunto: null,
    referencia: null,
    id_clase_documento_interno: null,
    folios: null,
    observaciones: null,
    oficina_derivada: null,
    copias: [],
    id_persona: null,
    persona: {},
    id_tup: null,
    requisitos: [],
    anexos: []
};

export const DEFAULT_DOCUMENTO_ERRORS = {
    indicativo_oficio: "",
    fecha_recepcion: "",
    asunto: "",
    referencia: "",
    id_clase_documento_interno: "",
    folios: "",
    observaciones: "",
    oficina_derivada: "",
    copias: "",
    id_persona: "",
    id_tup: "",
    requisitos: ""
};
