import { Component, OnInit } from "@angular/core";
import { BsModalRef } from "ngx-bootstrap/modal";
import { RegistrarDocumentoService } from "src/app/_modules/mesa-partes/_services";
import { AlertService } from "src/_shared/services";

@Component({
    templateUrl: "./app-modal-anular-registro.component.html",
    styles: []
})
export class AppModalAnularRegistroComponent implements OnInit {
    loading: boolean = false;
    documento: any;
    motivo: string;
    onAnularFinish: Function;

    constructor(
        public bsModalRef: BsModalRef,
        private _alertService: AlertService,
        private _registrarDocumentoService: RegistrarDocumentoService
    ) {}

    ngOnInit() {
        if (this.documento && !this.documento.persona) this.documento.persona = {};
    }

    handleAnular = () => {
        this._alertService.confirm(
            "warning",
            "Va a anular este registro ¿Desea Continuar?",
            null,
            () => {
                this.anularRegistro();
            }
        );
    };

    anularRegistro = () => {
        this.loading = true;
        this._registrarDocumentoService
            .AnularRegistro(this.documento.id_documento, this.motivo)
            .then(resp => {
                if (typeof this.onAnularFinish === "function") this.onAnularFinish();
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
