import { ColorEstadoComponent } from "../../button/color-estado/color-estado.component";
import { ActionButtonsDocumentoComponent } from "../../button/action-buttons-documento/action-buttons-documento.component";
import { IFormBuscarDocumento } from "src/app/_modules/mesa-partes/_interfaces";
import { AppButtonVerDetalleDocumentoComponent } from "../../button/app-button-ver-detalle-documento/app-button-ver-detalle-documento.component";
import { AppButtonVerHojaTramiteComponent } from "../../button/app-button-ver-hoja-tramite/app-button-ver-hoja-tramite.component";

export const CreateTableDefDocumentos = (
    onClickAdjuntarDocumento,
    onClickVerAdjuntos,
    onClickAgregarCopia,
    onClickEditarDocExterno,
    onClickEditarDocTupa,
    onClickAnularRegistro,
    onClickReactivarRegistro,
    onClickVerObservaciones,
    onClickImprimirEtiqueta,
    onClickVerCopia
) => ({
    columns: [
        {
            label: "",
            render: (item, loading) => ({
                component: AppButtonVerHojaTramiteComponent,
                documento: item,
                disabled: loading
            }),
            tdClass: item => ({ "borde-tupa": item.id_tup })
        },
        {
            label: "N° REGISTRO",
            render: (item, loading) => ({
                component: AppButtonVerDetalleDocumentoComponent,
                documento: item,
                disabled: loading
            })
        },
        { label: "FECHA DE RECEPCIÓN", property: "auditmod", isDatetime: true },
        { label: "RAZÓN SOCIAL", property: "persona.razon_social_format" },
        { label: "ASUNTO", property: "asunto", limit: 50 },
        { label: "FOLIOS", property: "folios" },
        { label: "UBICACIÓN INICIAL", property: "dependencia_inicial.siglas" },
        { label: "UBICACIÓN ACTUAL", property: "dependencia_actual.siglas" },
        { label: "REGISTRADO POR", property: "usuario" },
        { label: "CLAVE", property: "clave" },
        {
            label: "ESTADO",
            render: item => ({
                component: ColorEstadoComponent,
                estado_documento: item.estado_documento
            })
        },
        {
            label: "ACCIONES",
            render: (item, loading) => ({
                component: ActionButtonsDocumentoComponent,
                documento: item,
                disabled: loading,
                onClickAdjuntarDocumento: onClickAdjuntarDocumento,
                onClickVerAdjuntos: onClickVerAdjuntos,
                onClickAgregarCopia: onClickAgregarCopia,
                onClickEditarDocExterno: onClickEditarDocExterno,
                onClickEditaDocTupa: onClickEditarDocTupa,
                onClickAnularRegistro: onClickAnularRegistro,
                onClickReactivarRegistro: onClickReactivarRegistro,
                onClickVerObservaciones: onClickVerObservaciones,
                onClickImprimirEtiqueta: onClickImprimirEtiqueta,
                onClickVerCopia: onClickVerCopia
            }),
            tdClass: () => ({ "text-center": true })
        }
    ]
});

export const BuildFilters = (filters: IFormBuscarDocumento) => {
    let indicativo_oficio_hijo = null;
    let numero_resolucion = null;

    if (filters.numero_documento && filters.anio_documento && filters.oficina_documento) {
        indicativo_oficio_hijo = `${filters.numero_documento}-${filters.anio_documento}-PRODUCE/${
            filters.oficina_documento
        }`;
    }
    if (filters.numero_resolucion && filters.anio_resolucion) {
        numero_resolucion = `${filters.numero_resolucion}-${filters.anio_resolucion}-PRODUCE`;
        if (filters.oficina_resolucion)
            numero_resolucion = `${numero_resolucion}/${filters.oficina_resolucion}`;
    }

    return {
        indicativo_oficio: "",
        num_tram_documentario: filters.num_tram_documentario,
        id_clases_documento: null,
        id_tupas: filters.id_tupa ? [filters.id_tupa] : null,
        asunto: filters.asunto,
        fecha_registro_inicio: filters.fecha_inicio,
        fecha_registro_fin: filters.fecha_fin,
        id_estados_documento: filters.estado ? [filters.estado] : null,
        razon_social: filters.razon_social,
        id_clase_documento_hijo: filters.id_clase_documento,
        indicativo_oficio_hijo: indicativo_oficio_hijo,
        oficina_derivada: filters.coddep_oficina_derivada,
        id_tipo_resolucion: filters.id_tipo_resolucion,
        numero_resolucion: numero_resolucion
    };
};
