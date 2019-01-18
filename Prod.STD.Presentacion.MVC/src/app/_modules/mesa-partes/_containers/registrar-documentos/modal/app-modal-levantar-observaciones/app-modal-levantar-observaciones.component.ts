import { Component, OnInit } from "@angular/core";
import { IDocumento, DEFAULT_DOCUMENTO } from "src/app/_modules/mesa-partes/_interfaces";
import { BsModalRef } from "ngx-bootstrap/modal";
import { AlertService } from "src/_shared/services";
import { RegistrarDocumentoService } from "src/app/_modules/mesa-partes/_services";

@Component({
    templateUrl: "./app-modal-levantar-observaciones.component.html",
    styleUrls: []
})
export class AppModalLevantarObservacionesComponent implements OnInit {
    loading: Boolean = false;
    documento: any;
    tableDef: any;
    requisitos: Array<any>;
    observacion_general: string;
    onLevantarObsFinish: Function;

    constructor(
        public bsModalRef: BsModalRef,
        private _alertService: AlertService,
        private _registrarDocumentoService: RegistrarDocumentoService
    ) {
        this.documento = { ...DEFAULT_DOCUMENTO };
        this.requisitos = [];
        this.tableDef = {
            columns: [
                { label: "#", property: "_index_number" },
                { label: "Requisitos", property: "descripcion_format" },
                { label: "Detalle por observación", property: "observaciones" }
            ]
        };
    }

    ngOnInit() {
        if (this.documento && !this.documento.persona) this.documento.persona = {};
        this.loadRequisitos();
    }

    loadRequisitos = () => {
        this.loading = true;
        this._registrarDocumentoService
            .GetRequisitosPorDocumento(this.documento.id_documento)
            .then(resp => {
                if (resp.data.requisitos) {
                    this.requisitos = resp.data.requisitos
                        .filter(x => x.id_requisito != 0)
                        .map((x, i) => ({
                            ...x,
                            _index_number: i + 1
                        }));

                    const obs = resp.data.requisitos.filter(x => x.id_requisito == 0);

                    this.observacion_general =
                        obs.length > 0
                            ? obs[0].observaciones || "Sin Observaciones"
                            : "Sin Observaciones";
                }
            })
            .finally(() => {
                this.loading = false;
            });
    };

    handleLevantarObservaciones = () => {
        this._alertService.confirm(
            "warning",
            "Va a levantar las observaciones del documento ¿Desea continuar?",
            null,
            () => {
                this.levantarObservaciones();
            }
        );
    };

    levantarObservaciones = () => {
        this.loading = true;
        this._registrarDocumentoService
            .LevantarObservaciones(this.documento.id_documento)
            .then(resp => {
                if (typeof this.onLevantarObsFinish === "function") this.onLevantarObsFinish();
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
