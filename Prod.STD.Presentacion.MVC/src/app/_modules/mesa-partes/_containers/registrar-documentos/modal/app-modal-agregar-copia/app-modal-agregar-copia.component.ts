import { Component, OnInit } from "@angular/core";
import { BsModalRef } from "ngx-bootstrap/modal";
import { RegistrarDocumentoService } from "src/app/_modules/mesa-partes/_services";
import { AlertService } from "src/_shared/services";
import { ComunService } from "src/app/_services/comun.service";

@Component({
    templateUrl: "./app-modal-agregar-copia.component.html",
    styles: []
})
export class AppModalAgregarCopiaComponent implements OnInit {
    loading: boolean = false;
    documento: any;
    copias: Array<any>;
    onAgregarFinish: Function;
    enum_dependencias: Array<any>;

    constructor(
        public bsModalRef: BsModalRef,
        private _alertService: AlertService,
        private _registrarDocumentoService: RegistrarDocumentoService,
        private _comunService: ComunService
    ) {
        this.enum_dependencias = [];
        this.copias = [];
    }

    ngOnInit() {
        this.loadEnumerables();
        if (this.documento && !this.documento.persona) this.documento.persona = {};
    }

    loadEnumerables = () => {
        this._comunService.FetchDependencias().then(data => {
            this.enum_dependencias = data.map(x => ({
                coddep: x.codigo_dependencia,
                dependenciaFormat: `${x.dependencia} (${x.siglas})`
            }));
        });
    };

    handleGuardar = () => {
        this._alertService.confirm(
            "warning",
            "Va a guardar las copias ¿Desea Continuar?",
            null,
            () => {
                this.guardar();
            }
        );
    };

    guardar = () => {
        this.loading = true;
        this._registrarDocumentoService
            .AgregarCopias(this.documento.id_documento, this.copias)
            .then(resp => {
                if (typeof this.onAgregarFinish === "function") this.onAgregarFinish();
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
