import { Component, OnInit, Input } from "@angular/core";
import { BsModalRef } from "ngx-bootstrap/modal";
import axios from "axios";
import { AlertService } from "src/_shared/services";
import { ITableDefinition } from "../../../_shared/components/datatable/datatable.interfaces";

@Component({
    templateUrl: "./app-hoja-tramite.component.html",
    styles: [
        `
            .container-cargando-datos {
                margin-top: 25px;
                margin-bottom: 25px;
            }
        `
    ]
})
export class AppHojaTramiteComponent implements OnInit {
    loading: Boolean;

    id_documento: number;

    tipo: string;

    hoja_tramite: any;

    tableDef: ITableDefinition;

    constructor(public bsModalRef: BsModalRef, private _alertService: AlertService) {
        this.hoja_tramite = { documento: {}, rutas: [] };
        this.tableDef = {
            columns: [
                { label: "Destino", property: "oficina_destino" },
                { label: "Documento generado", property: "documento" },
                { label: "Acciones", property: "acciones" },
                { label: "Fecha", property: "fecha_registro" },
                { label: "Aceptado por", property: "aceptado_por" },
                { label: "Derivado por", property: "derivado_por" },
                { label: "Delegado a", property: "delegado_a" }
            ]
        };
    }

    ngOnInit() {
        this.loadHojaTramite();
    }

    loadHojaTramite = () => {
        let promise = null;

        if (this.tipo == "I") promise = this.getHojaTramiteDocumentoInterno(this.id_documento);

        if (this.tipo == "E") promise = this.getHojaTramiteDocumentoExterno(this.id_documento);

        if (!promise) return false;

        this.loading = true;
        promise
            .then(resp => {
                this.hoja_tramite = resp.data.hojaTramite;
            })
            .catch(err => {
                this._alertService.open("error", err.msg);
            })
            .finally(() => {
                this.loading = false;
            });
    };

    getHojaTramiteDocumentoExterno = id_documento => {
        return axios
            .get("/api/comun/hoja-tramite-documento-externo", {
                params: { id_documento: id_documento }
            })
            .then(resp => {
                return resp.data;
            });
    };

    getHojaTramiteDocumentoInterno = id_documento => {
        return axios
            .get("/api/comun/hoja-tramite-documento-interno", {
                params: { id_documento: id_documento }
            })
            .then(resp => {
                return resp.data;
            });
    };
}
