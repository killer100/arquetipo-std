import { Component, OnInit } from "@angular/core";
import { PageDataTable } from "src/app/_interfaces/page-datatable.interface";
import {
    IPagination,
    DefaultPagination,
    ITableDefinition,
    modalDefaultConfig,
    AppModalVerPdfComponent
} from "src/_shared";
import { DocumentosIngresadosService } from "src/app/_modules/mesa-partes/_services/documentos-ingresados.service";
import { AppDocIngresadoButtonAccionComponent } from "../../button/app-doc-ingresado-button-accion/app-doc-ingresado-button-accion.component";
import { AppDocIngresadoButtonEscaneadoComponent } from "../../button/app-doc-ingresado-button-escaneado/app-doc-ingresado-button-escaneado.component";
import { AppDocIngresadoButtonPdfComponent } from "../../button/app-doc-ingresado-button-pdf/app-doc-ingresado-button-pdf.component";
import { BsModalService } from "ngx-bootstrap/modal";
import { AlertService } from "src/_shared/services";
import { AppModalDocIngresadosGeneraReporteComponent } from "../../modal/app-modal-doc-ingresados-genera-reporte/app-modal-doc-ingresados-genera-reporte.component";
import { AppModalDocIngresadosListaReportesComponent } from "../../modal/app-modal-doc-ingresados-lista-reportes/app-modal-doc-ingresados-lista-reportes.component";
import { AppModalBarcodeDocumentosIngresadosComponent } from "../../modal/app-modal-barcode-documentos-ingresados/app-modal-barcode-documentos-ingresados.component";
import { AppDocIngresadoVerFlujoDocumentoComponent } from "../../button/app-doc-ingresado-ver-flujo-documento/app-doc-ingresado-ver-flujo-documento.component";

@Component({
    templateUrl: "./documentos-ingresados.component.html",
    styles: []
})
export class DocumentosIngresadosComponent implements OnInit, PageDataTable {
    filters: any = {};

    loading: Boolean = true;
    datatableError: Boolean = false;
    pagination: IPagination;
    tableDef: ITableDefinition;
    documentosSeleccionados: Array<any> = [];

    constructor(
        private _documentosIngresadosService: DocumentosIngresadosService,
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
                        component: AppDocIngresadoButtonEscaneadoComponent,
                        documento: item,
                        onCheck: this.handleSeleccionarDocumento,
                        selected: this.documentosSeleccionados,
                        disabled: loading
                    })
                },
                {
                    label: "",
                    render: (item, loading) => ({
                        component: AppDocIngresadoButtonPdfComponent,
                        documento: item,
                        onClickPdf: this.handleClickPdf,
                        disabled: loading
                    })
                },
                {
                    label: "N° DOCUMENTO",
                    render: (item, loading) => ({
                        component: AppDocIngresadoVerFlujoDocumentoComponent,
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
                        component: AppDocIngresadoButtonAccionComponent,
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
        this._documentosIngresadosService
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

    handleSeleccionarDocumento = (checked, documento) => {
        if (checked) {
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

    handleClickPdf = ruta => {
        this._modalService.show(AppModalVerPdfComponent, {
            ...modalDefaultConfig,
            class: `modal-custom modal-lg`,
            initialState: {
                ruta: ruta
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

    handleOpenGeneraReporte = () => {
        if (this.documentosSeleccionados.length == 0) {
            this._alertService.open("warning", "Debe seleccionar al menos un documento");
            return false;
        }

        this._modalService.show(AppModalDocIngresadosGeneraReporteComponent, {
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

    revertirDocumentoReporte = documento => {
        this.loading = true;
        this._documentosIngresadosService
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

    handleOpenListaReportes = () => {
        this._modalService.show(AppModalDocIngresadosListaReportesComponent, {
            ...modalDefaultConfig,
            class: `modal-custom modal-lg container`
        });
    };

    cleanDocumentosSeleccionados = () => {
        this.documentosSeleccionados = [];
    };

    handleOpenModalBarcodes = () => {
        this._modalService.show(AppModalBarcodeDocumentosIngresadosComponent, {
            ...modalDefaultConfig,
            class: `modal-custom modal-lg`,
            initialState: {
                onAddDocumentos: documentos => {
                    documentos.forEach(doc => {
                        const cont = this.documentosSeleccionados.filter(
                            x => x.id_documento == doc.id_documento && x.id_anexo == doc.id_anexo
                        ).length;
                        if (cont == 0) this.documentosSeleccionados.push(doc);
                    });
                }
            }
        });
    };
}
