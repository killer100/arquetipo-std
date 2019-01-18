import { Component, OnInit } from "@angular/core";
import { BsModalRef } from "ngx-bootstrap/modal";
import { IAdjunto } from "src/app/_modules/mesa-partes/_interfaces/adjunto.interface";
import { AlertService } from "src/_shared/services";
import { BuscarAdjuntosService } from "src/app/_modules/mesa-partes/_services";

@Component({
    templateUrl: "app-modal-anular-adjunto.component.html",
    styles: []
})
export class AppModalAnularAdjuntoComponent implements OnInit {
    adjunto: IAdjunto;
    motivo: string;
    loading: boolean = false;
    onAnularFinish: Function;

    constructor(
        public bsModalRef: BsModalRef,
        private _alertService: AlertService,
        private _buscarAdjuntosService: BuscarAdjuntosService
    ) {}

    ngOnInit() {}

    handleAnular = () => {
        this._alertService.confirm(
            "warning",
            "Va a anular este documento adjunto ¿Desea Continuar?",
            null,
            () => {
                this.anularAdjunto();
            }
        );
    };

    anularAdjunto = () => {
        this.loading = true;
        this._buscarAdjuntosService
            .AnularAdjunto(this.adjunto.id_anexo, this.motivo)
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
