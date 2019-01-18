import { Component, OnInit } from "@angular/core";
import { BsModalRef } from "ngx-bootstrap/modal";
import { ITableDefinition } from "src/_shared";
import { ComunService } from "src/app/_services/comun.service";
import { AlertService } from "src/_shared/services";
import { DocumentosIngresadosService } from "src/app/_modules/mesa-partes/_services";

@Component({
    templateUrl: "./app-modal-doc-ingresados-genera-reporte.component.html",
    styles: []
})
export class AppModalDocIngresadosGeneraReporteComponent implements OnInit {
    loading: Boolean = false;

    loadingDependencias: Boolean = false;

    loadingTrabajadores: Boolean = false;

    documentos: Array<any>;

    tableDef: ITableDefinition;

    codigo_dependencia: number;

    codigo_trabajador: number;

    observaciones: string;

    enum_dependencias: Array<any>;

    enum_trabajadores: Array<any>;

    onGenerarFinish: Function;

    constructor(
        public bsModalRef: BsModalRef,
        private _comunService: ComunService,
        private _alertService: AlertService,
        private _documentosIngresadosService: DocumentosIngresadosService
    ) {
        this.tableDef = {
            columns: [
                { label: "N°", isIndex: true },
                { label: "N° TRÁMITE", property: "numero_tramite" },
                { label: "FECHA REGISTRO", property: "fecha_registro", isDate: true },
                { label: "TIPO TRÁMITE", property: "tipo_registro_format" },
                { label: "USUARIO", property: "usuario" },
                { label: "REMITENTE", property: "razon_social" },
                { label: "ASUNTO", property: "asunto" },
                { label: "FOLIOS", property: "folios" },
                { label: "DEP.", property: "dependencia.siglas" }
            ]
        };

        this.enum_dependencias = [];
        this.enum_trabajadores = [];
        this.codigo_dependencia = null;
        this.codigo_trabajador = null;
    }

    ngOnInit() {
        this.loadEnumerables();
    }

    loadEnumerables = () => {
        this.loadingDependencias = true;
        this._comunService.FetchDependencias().then(data => {
            this.enum_dependencias = data.map(x => ({
                ...x,
                dependenciaFormat: `${x.siglas} - ${x.dependencia}`
            }));
            this.loadingDependencias = false;
        });
    };

    handleSelectDependencia = () => {
        this.codigo_trabajador = null;
        this.loadTrabajadores(this.codigo_dependencia);
    };

    loadTrabajadores = codigo_dependencia => {
        this.loadingTrabajadores = true;
        this._comunService.FetchTrabajadores([codigo_dependencia]).then(data => {
            this.enum_trabajadores = data.map(x => ({
                ...x,
                nombreFormat: `${x.apellidos_trabajador}, ${x.nombres_trabajador}`
            }));
            this.loadingTrabajadores = false;
        });
    };

    handleGeneraReporte = () => {
        if (!this.codigo_trabajador) {
            this._alertService.open("warning", "Debe seleccionar un trabajador");
            return false;
        }

        this._alertService.confirm(
            "warning",
            "Va a generar un nuevo reporte, ¿Desea continuar?",
            null,
            () => {
                this.generaReporte();
            }
        );
    };

    generaReporte = () => {
        this.loading = true;
        this._documentosIngresadosService
            .GenerarReporte(
                this.documentos,
                this.codigo_dependencia,
                this.codigo_trabajador,
                this.observaciones
            )
            .then(resp => {
                if (typeof this.onGenerarFinish === "function") this.onGenerarFinish();
                this._alertService.open("success", resp.msg, null, () => {
                    this.bsModalRef.hide();
                });
            })
            .catch(err => {
                this._alertService.open("error", err.msg);
            })
            .finally(() => {
                this.loading = false;
            });
    };
}
