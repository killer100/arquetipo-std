import { Component, OnInit } from "@angular/core";
import { BsModalRef } from "ngx-bootstrap/modal";
import { ITableDefinition } from "src/_shared";
import { ComunService } from "src/app/_services/comun.service";
import { AlertService } from "src/_shared/services";
import { DocumentosEscaneadosService } from "src/app/_modules/mesa-partes/_services";

@Component({
    templateUrl: "./app-modal-doc-escaneados-genera-reporte.component.html",
    styles: []
})
export class AppModalDocEscaneadosGeneraReporteComponent implements OnInit {
    loading: Boolean = false;

    documentos: Array<any>;

    tableDef: ITableDefinition;

    onGenerarFinish: Function;

    constructor(
        public bsModalRef: BsModalRef,
        private _comunService: ComunService,
        private _alertService: AlertService,
        private _documentosEscaneadosService: DocumentosEscaneadosService
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
    }

    ngOnInit() {}

    handleGeneraReporte = () => {
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
        this._documentosEscaneadosService
            .GenerarReporte(this.documentos)
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
