import { IDocumento, IDocumentoFilter } from "src/app/_modules/gestion-interna/_interfaces/";
import { AppButtonActionsDocumentoComponent } from "../../button/app-button-actions-documento/app-button-actions-documento.component";
import { AppButtonActionsArchivoComponent } from "../../button/app-button-actions-archivo/app-button-actions-archivo.component";
import { AppButtonActionsCheckComponent } from "../../button/app-button-actions-check/app-button-actions-check.component";


export const CreateTableDefDocsInternos = 
( 
)=>({
    columns:[
        {label:"N°", property:"", isIndex: true},
        {label:"TIPO", property:"tipo_hoja_tramite"},
        {label:"HOJA DE TRÁMITE", property:"numero_hoja_tramite"},
        {label:"RAZÓN SOCIAL", property:"persona.razon_social_format"},
        {label:"DOCUMENTO", property:"indicativo_oficio"},
        {label:"ASUNTO", property:"asunto"},
        {label:"FECHA", property:"auditmod", isDate: true},
        {
            label:"ARCHIVO", 
            render:(item, loading) =>({
                component: AppButtonActionsArchivoComponent
            })
        },{
            label:"ACCIÓN", 
            render:(item, loading) =>({
                component: AppButtonActionsDocumentoComponent,
                documento: item,
            })
        },
        {
            label:"", 
            render:(item, loading) =>({
                component: AppButtonActionsCheckComponent
            })
        }
    ]
});

export const BuildFilters = (filters: IDocumentoFilter) => {
    return {
        indicativo_oficio: filters.indicativo_oficio,
        num_tram_documentario: filters.num_tram_documentario,
        id_clases_documento: filters.id_clase_documento ? [filters.id_clase_documento] : null,
        id_tupas: filters.id_tupa ? [filters.id_tupa] : null,
        asunto: filters.asunto,
        fecha_registro_inicio: filters.fecha_inicio,
        fecha_registro_fin: filters.fecha_fin,
        id_estados_documento: filters.estado ? [filters.estado] : null,
        razon_social: filters.razon_social,
        tipo_hoja_tramite: filters.tipo_hoja_tramite,
        estado_documento_interno: filters.estado_documento_interno ? filters.estado_documento_interno : 1
    };
};