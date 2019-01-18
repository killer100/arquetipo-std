export interface IFormBuscarDocumento {
    num_tram_documentario?: string;
    estado?: number;
    fecha_inicio?: any;
    fecha_fin?: any;
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
    
}
