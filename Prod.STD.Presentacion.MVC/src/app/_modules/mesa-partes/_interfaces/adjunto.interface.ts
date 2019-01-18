export interface IAdjunto {
    id_anexo?: number;
    id_documento: number;
    id_persona: number;
    persona?: any;
    id_persona_destino: number;
    folios: number;
    observaciones?: string;
    contenido: string;
    num_documento_anexo: string;
    id_tipo_anexo: string;
    audit_mod: any;
    persona_destino?: any;
    PuedeEditarOAnular?: Boolean;
}

export const DEFAULT_ADJUNTO = {
    id_anexo: null,
    id_documento: null,
    id_persona: null,
    persona: {},
    id_persona_destino: null,
    folios: null,
    observaciones: null,
    contenido: null,
    num_documento_anexo: null,
    id_tipo_anexo: null,
    audit_mod: null,
    persona_destino: {
        dependencia: {}
    }
};

export const DEFAULT_ADJUNTO_ERRORS = {
    id_documento: "",
    id_persona: "",
    id_persona_destino: "",
    folios: "",
    observaciones: "",
    contenido: "",
    num_documento_anexo: "",
    id_tipo_anexo: ""
};
