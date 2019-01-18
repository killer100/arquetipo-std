import { Component, OnInit, Input } from "@angular/core";
import { TIPO_FORMULARIO } from "src/config/app-enumerados";
import { BsModalRef, BsModalService } from "ngx-bootstrap/modal";
import { ComunService } from "src/app/_services/comun.service";
import {
    IAdjunto,
    DEFAULT_ADJUNTO,
    DEFAULT_ADJUNTO_ERRORS
} from "src/app/_modules/mesa-partes/_interfaces/adjunto.interface";
import * as moment from "moment";
import { BuscarAdjuntosService } from "src/app/_modules/mesa-partes/_services";
import { modalDefaultConfig } from "src/_shared";
import { AlertService } from "src/_shared/services";
import { resolve } from "q";
import { AppModalBusAdjImprimirEtiquetaAnexoComponent } from "../../modal/app-modal-bus-adj-imprimir-etiqueta-anexo/app-modal-bus-adj-imprimir-etiqueta-anexo.component";

const BuildTitle = tipo =>
    ({
        [TIPO_FORMULARIO.REGISTRO]: "Adjuntar Documento",
        [TIPO_FORMULARIO.MODIFICAR]: "Modificar Adjunto"
    }[tipo] || "Default");

const BuildSubmitText = tipo =>
    ({
        [TIPO_FORMULARIO.REGISTRO]: "Adjuntar Documento",
        [TIPO_FORMULARIO.MODIFICAR]: "Guardar"
    }[tipo] || "Default");

const BuildConfirmText = tipo =>
    ({
        [TIPO_FORMULARIO.REGISTRO]: "Va a registrar un nuevo adjunto",
        [TIPO_FORMULARIO.MODIFICAR]: "Va a modificar el documento adjunto"
    }[tipo] || "Default");

@Component({
    selector: "app-app-form-registro-adjunto",
    templateUrl: "./app-form-registro-adjunto.component.html",
    styleUrls: ["./app-form-registro-adjunto.component.css"]
})
export class AppFormRegistroAdjuntoComponent implements OnInit {
    tipo_form: Number = TIPO_FORMULARIO.REGISTRO;
    loading: Boolean = false;
    adjunto: IAdjunto;
    errors: any;
    enum_tipos_anexo: Array<any>;
    @Input()
    id_documento: number;
    @Input()
    id_anexo: number;
    onSaveFinish: Function;
    existePersonaDestino = true;

    constructor(
        public bsModalRef: BsModalRef,
        public _modalService: BsModalService,
        private _comunService: ComunService,
        private _buscarAdjuntosService: BuscarAdjuntosService,
        private _alertService: AlertService
    ) {
        this.adjunto = { ...DEFAULT_ADJUNTO, audit_mod: moment() };
        this.errors = { ...DEFAULT_ADJUNTO_ERRORS };
        this.enum_tipos_anexo = [];
    }

    get title() {
        return BuildTitle(this.tipo_form);
    }

    get submit_text() {
        return BuildSubmitText(this.tipo_form);
    }

    ngOnInit() {
        this.adjunto.id_documento = this.id_documento;
        if (this.id_anexo) {
            this.tipo_form = TIPO_FORMULARIO.MODIFICAR;
            this.loadAdjunto();
        } else {
            this.getOficinaPendiente();
            this.getNuevoNumero();
        }
        this.loadEnumerables();
    }

    handleSubmit = e => {
        e.preventDefault();
        const msg = BuildConfirmText(this.tipo_form);
        this._alertService.confirm("warning", `${msg} ¿continuar?`, null, () => {
            this.handleSaveAdjunto();
        });
    };

    loadAdjunto = () => {
        this.loading = true;
        this._buscarAdjuntosService
            .GetAdjunto(this.id_anexo)
            .then(resp => {
                if (resp.data) {
                    resp.data.audit_mod = moment(resp.data.audit_mod);
                    this.adjunto = resp.data;
                }
            })
            .finally(() => {
                this.loading = false;
            });
    };

    loadEnumerables = () => {
        this._comunService.FetchTiposAnexo().then(data => {
            this.enum_tipos_anexo = data;
        });
    };

    getNuevoNumero = () => {
        this.loading = true;
        this._buscarAdjuntosService
            .GetNuevoNumero(this.id_documento)
            .then(resp => {
                this.adjunto.num_documento_anexo = resp.msg;
            })
            .catch(err => {
                this._alertService.open("error", err.msg);
            })
            .finally(() => {
                this.loading = false;
            });
    };

    getOficinaPendiente = () => {
        this._buscarAdjuntosService
            .GetOficinaPendiente(this.id_documento)
            .then(resp => {
                if (resp.data) {
                    if (resp.data.dependencia) {
                        this.adjunto.persona_destino.dependencia = resp.data.dependencia;
                    } else {
                        this.adjunto.persona_destino.dependencia.dependencia =
                            "NO EXISTE DEPENDENCIA ACTUAL";
                    }

                    if (resp.data.director) {
                        this.adjunto.persona_destino = resp.data.director;
                        this.adjunto.persona_destino.dependencia = resp.data.dependencia;
                    } else {
                        this.adjunto.persona_destino.nombre_format =
                            "NO EXISTE DIRECTOR - NO SE PUEDE REGISTRAR";
                    }
                }
            })
            .catch(err => {
                this._alertService.open("error", err.msg);
            })
            .finally(() => {});
    };

    getPersonas = value => {
        const params = {
            razon_social: value,
            limit: 5
        };
        return this._comunService.FetchPersonas(params);
    };

    handleSelectPersona = persona => {
        this.adjunto.id_persona = persona.id;
        this.adjunto.persona = persona;
    };

    handleSaveAdjunto = async () => {
        if (!this.existePersonaDestino) {
            this._alertService.open("warning", "No se puede enviar por que no existe director.");
            return false;
        }
        this.errors = this.errors = { ...DEFAULT_ADJUNTO_ERRORS };
        this.loading = true;
        try {
            let promise = null;
            switch (this.tipo_form) {
                case TIPO_FORMULARIO.REGISTRO:
                    promise = this._buscarAdjuntosService.SaveAdjunto(this.adjunto);
                    break;
                case TIPO_FORMULARIO.MODIFICAR:
                    promise = this._buscarAdjuntosService.UpdateAdjunto(
                        this.id_anexo,
                        this.adjunto
                    );
                    break;
            }
            const resp = await promise;
            if (typeof this.onSaveFinish === "function") this.onSaveFinish();
            this._alertService.open("success", resp.msg, "Registrado", () => {
                this.openModalImprimirEtiqueta(resp.data.id_anexo);
                this.bsModalRef.hide();
            });
        } catch (err) {
            const msg = err.msg;
            if (err.statuscode == 406) this.errors = err.errors;
            this._alertService.open("error", msg);
        }
        this.loading = false;
    };

    openModalImprimirEtiqueta = id_anexo => {
        this._modalService.show(AppModalBusAdjImprimirEtiquetaAnexoComponent, {
            ...modalDefaultConfig,
            initialState: {
                id_anexo: id_anexo
            }
        });
    };
}
