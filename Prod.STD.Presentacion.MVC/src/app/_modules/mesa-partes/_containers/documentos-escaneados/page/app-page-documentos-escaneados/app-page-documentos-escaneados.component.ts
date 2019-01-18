import { Component, OnInit } from "@angular/core";
import {
    IPagination,
    ITableDefinition,
    DefaultPagination,
    modalDefaultConfig,
    AppModalVerPdfComponent
} from "src/_shared";
import { AlertService } from "src/_shared/services";
import { BsModalService } from "ngx-bootstrap/modal";
import { DocumentosEscaneadosService } from "src/app/_modules/mesa-partes/_services/documentos-escaneados.service";
import { AppDocEscaneadoButtonEscaneadoComponent } from "../../button/app-doc-escaneado-button-escaneado/app-doc-escaneado-button-escaneado.component";
import { AppModalDocEscaneadosGeneraReporteComponent } from "../../modal/app-modal-doc-escaneados-genera-reporte/app-modal-doc-escaneados-genera-reporte.component";
import { AppDocEscaneadoButtonPdfComponent } from "../../button/app-doc-escaneado-button-pdf/app-doc-escaneado-button-pdf.component";
import { AppDocEscaneadoButtonAccionComponent } from "../../button/app-doc-escaneado-button-accion/app-doc-escaneado-button-accion.component";
import { AppModalDocEscaneadosListaReportesComponent } from "../../modal/app-modal-doc-escaneados-lista-reportes/app-modal-doc-escaneados-lista-reportes.component";
import { AppDocEscaneadoVerFlujoDocumentoComponent } from "../../button/app-doc-escaneado-ver-flujo-documento/app-doc-escaneado-ver-flujo-documento.component";

@Component({
    templateUrl: "./app-page-documentos-escaneados.component.html",
    styles: []
})
export class AppPageDocumentosEscaneadosComponent implements OnInit {
    filters: any = {};
    loading: Boolean = true;
    datatableError: Boolean = false;
    pagination: IPagination;
    tableDef: ITableDefinition;
    documentosSeleccionados: Array<any> = [];

    constructor(
        private _documentosEscaneadosService: DocumentosEscaneadosService,
        private _modalService: BsModalService,
        private _alertService: AlertService
    ) {
        this.pagination = { ...DefaultPagination };
        this.tableDef = {
            columns: [
                { label: "N°", isIndex: true, tdClass: item => ({ "borde-tupa": item.esTupa }) },
                {
                    label: "ESCANEADO",
                    render: (item, loading) => ({
                        component: AppDocEscaneadoButtonEscaneadoComponent,
                        documento: item,
                        onCheck: this.handleSeleccionarDocumento,
                        selected: this.documentosSeleccionados,
                        disabled: loading
                    })
                },
                {
                    label: "",
                    render: (item, loading) => ({
                        component: AppDocEscaneadoButtonPdfComponent,
                        documento: item,
                        onClickPdf: this.handleClickPdf,
                        disabled: loading
                    })
                },
                {
                    label: "N° DOCUMENTO",
                    render: (item, loading) => ({
                        component: AppDocEscaneadoVerFlujoDocumentoComponent,
                        documento: item,
                        disabled: loading
                    })
                },
                { label: "FOLIOS", property: "folios" },
                { label: "FECHA REGISTRO", property: "fecha_registro", isDate: true },
                { label: "TIPO REGISTRO", property: "tipo_registro_format" },
                { label: "DEPENDENCIA", property: "dependencia.siglas" },
                { label: "ASUNTO", property: "asunto_format", limit: 50 },
                { label: "RAZÓN SOCIAL", property: "razon_social" },
                { label: "USUARIO", property: "usuario" },
                { label: "N° REPORTE", property: "numero_reporte_full" },
                {
                    label: "ACCIÓN",
                    render: (item, loading) => ({
                        component: AppDocEscaneadoButtonAccionComponent,
                        documento: item,
                        disabled: loading,
                        onClickRevertir: this.handleClickRevertir
                    })
                }
            ]
        };
    }

    ngOnInit() {}

    handleRefresh = () => {
        this.getData(this.pagination.page, this.pagination.pageSize, this.filters);
    };

    handleSearch = (filters: any) => {
        this.filters = filters;
        this.getData(1, this.pagination.pageSize, this.filters);
    };

    handleChangePageSize = (pageSize: any) => {
        this.getData(1, pageSize, this.filters);
    };

    handleChangePage = (page: any) => {
        this.getData(page, this.pagination.pageSize, this.filters);
    };

    getData = (page: any, pageSize: any, filters: any) => {
        this.datatableError = false;
        this.loading = true;
        this._documentosEscaneadosService
            .FetchDocumentos(page, pageSize, filters)
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

    handleSeleccionarDocumento = (event, documento) => {
        if (!this.filters.coddep) {
            this._alertService.open("warning", "Primero debe buscar una dependencia");
            event.preventDefault();
            return false;
        }
        if (event.target.checked) {
            this.documentosSeleccionados.push(documento);
        } else {
            this.handleDeleteDocumentoSeleccionado(documento);
        }
    };

    handleDeleteDocumentoSeleccionado = documento => {
        const doc = this.documentosSeleccionados.find(
            x => x.id_documento == documento.id_documento && x.id_anexo == documento.id_anexo
        );
        this.documentosSeleccionados.splice(this.documentosSeleccionados.indexOf(doc), 1);
    };

    handleOpenGeneraReporte = () => {
        if (this.documentosSeleccionados.length == 0) {
            this._alertService.open("warning", "Debe seleccionar al menos un documento");
            return false;
        }

        this._modalService.show(AppModalDocEscaneadosGeneraReporteComponent, {
            ...modalDefaultConfig,
            class: `modal-custom modal-lg`,
            initialState: {
                documentos: this.documentosSeleccionados,
                onGenerarFinish: () => {
                    this.cleanDocumentosSeleccionados();
                    this.handleRefresh();
                }
            }
        });
    };

    handleClickRevertir = documento => {
        this._alertService.confirm(
            "warning",
            "Se va a revertir el documento seleccionado ¿Desea continuar?",
            null,
            () => {
                this.revertirDocumentoReporte(documento);
            }
        );
    };

    revertirDocumentoReporte = documento => {
        this.loading = true;
        this._documentosEscaneadosService
            .RevertirDocumentoReporte(documento.id_documento, documento.id_anexo)
            .then(resp => {
                this._alertService.open("success", resp.msg);
                this.handleRefresh();
            })
            .catch(err => {
                this._alertService.open("error", err.msg);
            })
            .finally(() => {
                this.loading = false;
            });
    };

    handleClickPdf = ruta => {
        this._modalService.show(AppModalVerPdfComponent, {
            ...modalDefaultConfig,
            class: `modal-custom modal-lg`,
            initialState: {
                ruta: ruta
            }
        });
    };

    handleOpenListaReportes = () => {
        this._modalService.show(AppModalDocEscaneadosListaReportesComponent, {
            ...modalDefaultConfig,
            class: `modal-custom modal-lg container`
        });
    };

    cleanDocumentosSeleccionados = () => {
        this.documentosSeleccionados = [];
    };
}
