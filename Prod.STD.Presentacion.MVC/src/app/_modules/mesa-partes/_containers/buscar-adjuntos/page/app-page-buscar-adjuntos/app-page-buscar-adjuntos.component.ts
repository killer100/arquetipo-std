import { Component, OnInit } from "@angular/core";
import { IPagination, DefaultPagination, modalDefaultConfig } from "src/_shared";
import { BuscarAdjuntosService } from "src/app/_modules/mesa-partes/_services";
import { AppButtonAcionsBuscarAdjuntoComponent } from "../../button/app-button-acions-buscar-adjunto/app-button-acions-buscar-adjunto.component";
import { BsModalService } from "ngx-bootstrap/modal";
import { AppFormRegistroAdjuntoComponent } from "../../form/app-form-registro-adjunto/app-form-registro-adjunto.component";
import { AppModalAnularAdjuntoComponent } from "../../modal/app-modal-anular-adjunto/app-modal-anular-adjunto.component";
import { AppModalBusAdjImprimirEtiquetaAnexoComponent } from "../../modal/app-modal-bus-adj-imprimir-etiqueta-anexo/app-modal-bus-adj-imprimir-etiqueta-anexo.component";
import { AppButtonAdjuntosVerHojaTramiteComponent } from "../../button/app-button-adjuntos-ver-hoja-tramite/app-button-adjuntos-ver-hoja-tramite.component";
import { AppButtonAdjuntosVerFlujoDocumentoComponent } from "../../button/app-button-adjuntos-ver-flujo-documento/app-doc-escaneado-ver-flujo-documento.component";

@Component({
    templateUrl: "./app-page-buscar-adjuntos.component.html",
    styles: []
})
export class AppPageBuscarAdjuntosComponent implements OnInit {
    loading: Boolean = true;
    pagination: IPagination;
    tableDef: any;
    filters: any = {};
    datatableError: Boolean = false;

    constructor(
        private _buscarAdjuntoService: BuscarAdjuntosService,
        private _modalService: BsModalService
    ) {
        this.tableDef = {
            columns: [
                { label: "N°", isIndex: true },
                {
                    label: "",
                    render: (item, loading) => ({
                        component: AppButtonAdjuntosVerHojaTramiteComponent,
                        documento: item,
                        disabled: loading
                    })
                },
                {
                    label: "N° REGISTRO",
                    render: (item, loading) => ({
                        component: AppButtonAdjuntosVerFlujoDocumentoComponent,
                        documento: item,
                        disabled: loading
                    })
                },
                { label: "RAZÓN SOCIAL", property: "persona.razon_social_format" },
                { label: "ASUNTO", property: "contenido" },
                { label: "FECHA", property: "audit_mod", isDate: true },
                { label: "DERIVADO", property: "persona_destino.dependencia.siglas" },
                {
                    label: "ACCIÓN",
                    render: (item, loading) => ({
                        component: AppButtonAcionsBuscarAdjuntoComponent,
                        adjunto: item,
                        onClickModificarAdjunto: this.handleClickModificarAdjunto,
                        onClickAnularAdjunto: this.handleClickAnularAdjunto,
                        onClickImprimirEtiqueta: this.handleClickImprimirEtiqueta
                    })
                }
            ]
        };
        this.pagination = { ...DefaultPagination };
    }

    ngOnInit() {
        //this.handleRefresh();
    }

    handleRefresh = () => {
        this.getData(this.pagination.page, this.pagination.pageSize, this.filters);
    };

    handleSearch = filters => {
        this.filters = filters;
        this.getData(1, this.pagination.pageSize, filters);
    };

    handleChangePage = page => {
        this.getData(page, this.pagination.pageSize, this.filters);
    };

    handleChangePageSize = pageSize => {
        this.getData(1, pageSize, this.filters);
    };

    getData = (page, pageSize, filters) => {
        this.datatableError = false;
        this.loading = true;
        this._buscarAdjuntoService
            .FetchAdjuntos(page, pageSize, filters)
            .then(resp => {
                const pagination = resp.data;
                this.pagination = {
                    page: page,
                    Data: pagination.Data,
                    pageSize: pageSize,
                    TotalRows: pagination.TotalRows
                };
                this.loading = false;
            })
            .catch(() => {
                this.pagination = { ...DefaultPagination };
                this.datatableError = true;
                this.loading = false;
            });
    };

    handleClickModificarAdjunto = id_anexo => {
        this._modalService.show(AppFormRegistroAdjuntoComponent, {
            ...modalDefaultConfig,
            initialState: {
                id_anexo: id_anexo,
                onSaveFinish: () => {
                    this.handleRefresh();
                }
            }
        });
    };

    handleClickAnularAdjunto = anexo => {
        this._modalService.show(AppModalAnularAdjuntoComponent, {
            ...modalDefaultConfig,
            class: `modal-custom modal-lg`,
            initialState: {
                adjunto: anexo,
                onAnularFinish: () => {
                    this.handleRefresh();
                }
            }
        });
    };

    handleClickImprimirEtiqueta = id_anexo => {
        this._modalService.show(AppModalBusAdjImprimirEtiquetaAnexoComponent, {
            ...modalDefaultConfig,
            initialState: {
                id_anexo: id_anexo
            }
        });
    };
}
