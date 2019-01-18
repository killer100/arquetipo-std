import { Component, OnInit } from "@angular/core";
import { BsModalRef } from "ngx-bootstrap/modal";
import { AlertService } from "src/_shared/services";
import { RegistrarDocumentoService } from "src/app/_modules/mesa-partes/_services";
import { ComunService } from "src/app/_services/comun.service";

@Component({
    templateUrl: "./app-modal-reactivar-registro.component.html",
    styles: []
})
export class AppModalReactivarRegistroComponent implements OnInit {
    loading: Boolean = false;
    documento: any;
    onReactivarFinish: Function;
    form: { observaciones: string; oficina_derivada: number };
    enum_dependencias: Array<any>;
    errors: { observaciones: string; oficina_derivada: string };

    constructor(
        public bsModalRef: BsModalRef,
        private _alertService: AlertService,
        private _registrarDocumentoService: RegistrarDocumentoService
    ) {
        this.form = { observaciones: "", oficina_derivada: null };
        this.errors = { observaciones: null, oficina_derivada: null };
        this.enum_dependencias = [];
    }

    ngOnInit() {
        if (this.documento && !this.documento.persona) this.documento.persona = {};
        this.loadEnumerables();
    }

    loadEnumerables = () => {
        this._registrarDocumentoService
            .GetOficinasFinalizadas(this.documento.id_documento)
            .then(resp => {
                this.enum_dependencias = resp.data.dependencias;
            });
    };

    handleReactivar = () => {
        this._alertService.confirm(
            "warning",
            "Va a reactivar el registro ¿Desea continuar?",
            null,
            () => {
                this.reactivar();
            }
        );
    };

    reactivar = () => {
        this.loading = true;
        this.errors = this.errors = { observaciones: null, oficina_derivada: null };
        this._registrarDocumentoService
            .ReactivarRegistro(this.documento.id_documento, this.form)
            .then(resp => {
                if (typeof this.onReactivarFinish === "function") this.onReactivarFinish();
                this._alertService.open("success", resp.msg, null, () => {
                    this.bsModalRef.hide();
                });
            })
            .catch(err => {
                const msg = err.msg;
                if (err.statuscode == 406) this.errors = err.errors;
                this._alertService.open("error", msg);
            })
            .finally(() => {
                this.loading = false;
            });
    };
}
