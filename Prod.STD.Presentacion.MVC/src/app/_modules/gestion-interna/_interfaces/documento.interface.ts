export interface IDocumentoFilter {
    
        num_tram_documentario?: string;
        estado?: number;
        fecha_inicio?: any;
        fecha_fin?: any;
        coddeps_destino?: Array<number>;
        // filtros de resolucion
        id_tipo_resolucion?: number;
        numero_resolucion?: string;
        anio_resolucion?: number;
        oficina_resolucion?: string;
        // filtros de documento
        id_clase_documento?: number;
        numero_documento?: string;
        anio_documento?: number;
        oficina_documento?: string;
        tipo_hoja_tramite?: string;
        // otros filtros
        razon_social?: string;
        coddep_oficina_derivada?: number;
        id_tupa?: number;
        asunto?: string;
        indicativo_oficio?:string;
        vEstadoDocumento?:string;
        estado_documento_interno?: number;
}

export interface IDocumento {
    
        id_documento?: number;
        fecha_registro?: any;
        id_clase_documento_interno?: number;
        coddeps_destino?: Array<any>;
        asunto?: string;
        observaciones?: string;
        acciones?: Array<any>;
        folios?:number;
        es_documento_respuesta?: boolean;
        tipo_hoja_tramite?: string;
        referencias?: Array<any>;
        tiene_adjuntos?: boolean;
        si_requiere_respuesta?: boolean;
        es_urgente?: boolean;
        adjuntos?: Array<any>;

}
export const DEFAULT_DOCUMENTO = {
        id_documento  :  null,
        fecha_registro: new Date(),
        id_clase_documento_interno  :  null,
        coddeps_destino :  [],
        asunto :  null,
        observaciones :  null,
        acciones :  [],
        es_documento_respuesta :  false,        
        referencias :  [],
        tiene_adjuntos :  false,
        adjuntos:[],
        si_requiere_respuesta :  false,
        es_urgente :  false,
    };
export const DEFAULT_DOCUMENTO_ERRORS = {
        id_clase_documento: null,
        coddeps_destino: null,
        asunto: null,
        observaciones: null,
        acciones: null,
        archivo: null,
        tipo_hoja_tramite: null,
        hojas_tramite: null,
        adjuntos: null,
        folios: null
}
