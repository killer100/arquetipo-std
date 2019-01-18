import { Component, OnInit } from "@angular/core";
import { BsModalRef } from "ngx-bootstrap/modal";
import { PageDataTable } from "src/app/_interfaces/page-datatable.interface";
import { ITableDefinition, IPagination, DefaultPagination } from "src/_shared";
import { DocumentosIngresadosService } from "src/app/_modules/mesa-partes/_services";
import { AppButtonDocIngresadoAccionesListaReportes } from "../../button/app-button-doc-ingresado-acciones-lista-reportes/app-button-doc-ingresado-acciones-lista-reportes";

@Component({
    selector: "app-app-modal-doc-ingresados-lista-reportes",
    templateUrl: "./app-modal-doc-ingresados-lista-reportes.component.html",
    styles: []
})
export class AppModalDocIngresadosListaReportesComponent implements OnInit {
    loading: Boolean = false;

    datatableError: Boolean = false;

    tableDef: ITableDefinition;

    pagination: IPagination;

    constructor(
        public bsModalRef: BsModalRef,
        private _documentosIngresadosService: DocumentosIngresadosService
    ) {
        this.tableDef = {
            columns: [
                {
                    label: "NÚMERO",
                    property: "numero_reporte",
                    tdStyle: { "white-space": "nowrap" }
                },
                { label: "USUARIO", property: "user_registro" },
                { label: "FECHA REGISTRO", property: "fecha_registro" },
                { label: "ENTREGADO POR", property: "trabajador_entregado" },
                { label: "RECIBIDO POR", property: "trabajador_recibido" },
                { label: "RECIBIDO EL", property: "fecha_recibido" },
                {
                    label: "ACCIÓN",
                    render: (item, loading) => ({
                        component: AppButtonDocIngresadoAccionesListaReportes,
                        reporte: item,
                        disabled: loading,
                        onClickVerDocumentos: this.handleClickVerDocumentos
                    })
                }
            ]
        };

        this.pagination = { ...DefaultPagination };
    }

    ngOnInit() {
        this.getData(this.pagination.page, this.pagination.pageSize);
    }

    handleChangePageSize = (pageSize: any) => {
        this.getData(1, pageSize);
    };
    handleChangePage = (page: any) => {
        this.getData(page, this.pagination.pageSize);
    };
    getData = (page: any, pageSize: any) => {
        this.datatableError = false;
        this.loading = true;
        this._documentosIngresadosService
            .FetchReportes(page, pageSize)
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

    handleClickVerDocumentos = numero_reporte => {
        location.href = `/api/mesa-partes/documentos-ingresados/ver-documentos-reporte?numero_reporte=${numero_reporte}`;
    };
}
