import { Component, OnInit } from "@angular/core";
import { BsModalService, BsModalRef } from "ngx-bootstrap/modal";
import { ComunService } from "src/app/_services/comun.service";
import { DEFAULT_DOCUMENTO, IDocumento, DEFAULT_DOCUMENTO_ERRORS } from "../../../../_interfaces";
import { RegistrarDocumentoService } from "../../../../_services";
import { modalDefaultConfig } from "src/_shared";
import { AlertService } from "src/_shared/services";
import * as moment from "moment";
import { TIPO_FORMULARIO } from "src/config/app-enumerados";
import { ConfirmarRegistroExternoComponent } from "../../modal/confirmar-registro-externo/confirmar-registro-externo.component";
import { AppModalRegDocImprimirEtiquetaComponent } from "../../../registrar-documentos";

@Component({
    templateUrl: "./form-registro-documento-externo.component.html",
    styleUrls: ["./form-registro-documento-externo.component.css"]
})
export class FormRegistroDocumentoExternoComponent implements OnInit {
    _tipo: number = TIPO_FORMULARIO.REGISTRO;
    id_documento?: number;
    loading: Boolean = false;
    documento: IDocumento;
    errors: any;
    _razon_social: string;
    onSave: Function;
    //ENUMERABLES
    enum_clasesDocumento: Array<any>;
    enum_dependencias: Array<any>;

    constructor(
        public bsModalRef: BsModalRef,
        private _modalService: BsModalService,
        private _comunService: ComunService,
        private _registrarDocumentoService: RegistrarDocumentoService,
        private _alertService: AlertService
    ) {
        this.enum_clasesDocumento = [];
        this.enum_dependencias = [];
        this.documento = { ...DEFAULT_DOCUMENTO, fecha_recepcion: moment() };
        this.errors = { ...DEFAULT_DOCUMENTO_ERRORS };
    }

    ngOnInit() {
        this.loadEnumerables();
        if (this.id_documento) {
            this._tipo = TIPO_FORMULARIO.MODIFICAR;
            this.loadDocumento();
        }
    }

    getPersonas = value => {
        const params = {
            razon_social: value,
            limit: 5
        };
        return this._comunService.FetchPersonas(params);
    };

    loadDocumento = async () => {
        try {
            this.loading = true;

            const resp = await this._registrarDocumentoService.GetDocumentoExterno(
                this.id_documento
            );
            this.documento = this.formatDataFromServer(resp.data);
            this._razon_social = this.documento.persona.razon_social_format;
        } catch (e) {
            this._alertService.open("error", e.msg);
        }
        this.loading = false;
    };

    loadEnumerables = () => {
        this._comunService.FetchClasesDocumento({ categoria: "d", procedencia: "e" }).then(data => {
            this.enum_clasesDocumento = data;
        });

        this._comunService.FetchDependencias().then(data => {
            this.enum_dependencias = data.map(x => ({
                ...x,
                coddep: x.codigo_dependencia,
                dependenciaFormat: `${x.dependencia} (${x.siglas})`
            }));
        });
    };

    handleSubmit = () => {
        this.openModalConfirm();
    };

    openModalConfirm = () => {
        const config = {
            ...modalDefaultConfig,
            class: `modal-custom`,
            initialState: {
                asunto: this.documento.asunto,
                razon_social: this.documento.persona.razon_social_format,
                destino: this.enum_dependencias.find(
                    x => x.codigo_dependencia === this.documento.oficina_derivada
                ),
                onConfirm: this.saveDocumento,
                copias: this.documento.copias
            }
        };
        this._modalService.show(ConfirmarRegistroExternoComponent, config);
    };

    saveDocumento = async () => {
        this.errors = this.errors = { ...DEFAULT_DOCUMENTO_ERRORS };
        this.loading = true;
        try {
            let promise = null;
            switch (this._tipo) {
                case TIPO_FORMULARIO.REGISTRO:
                    promise = this._registrarDocumentoService.SaveDocumentoExterno(this.documento);
                    break;
                case TIPO_FORMULARIO.MODIFICAR:
                    promise = this._registrarDocumentoService.UpdateDocumentoExterno(
                        this.id_documento,
                        this.documento
                    );
                    break;
            }
            const resp = await promise;

            this._alertService.open("success", resp.msg, "Registrado", () => {
                this.openModalImprimirEtiqueta(resp.data.id_documento);
                if (typeof this.onSave == "function") this.onSave();
                this.bsModalRef.hide();
            });
        } catch (err) {
            const msg = err.msg;
            if (err.statuscode == 406) {
                this.errors = err.errors;
            }
            this._alertService.open("error", msg);
        }
        this.loading = false;
    };

    handleSelectPersona = persona => {
        this.documento.id_persona = persona.id;
        this.documento.persona = persona;
    };

    formatDataFromServer = (data: any) => {
        data.fecha_recepcion = moment(data.auditmod);
        if (!data.persona) data.persona = {};
        const primer_movimiento = data.movimiento_documento.find(x => x.id_oficio == null);
        if (primer_movimiento != undefined)
            data.oficina_derivada = primer_movimiento.id_dependencia_destino;
        if (data.copias && data.copias.length > 0) {
            data.copias = data.copias.map(x => {
                x.dependenciaFormat = `${x.dependencia.dependencia} (${x.dependencia.siglas})`;
                return x;
            });
        }
        return data;
    };

    // PROPIEDADES CALCULADAS
    get title() {
        switch (this._tipo) {
            case TIPO_FORMULARIO.REGISTRO:
                return "Nuevo Registro";
            case TIPO_FORMULARIO.MODIFICAR:
                return "Modificar Registro";
            case TIPO_FORMULARIO.SOLO_LECTURA:
                return "Registro";
        }
    }

    get submit_text() {
        switch (this._tipo) {
            case TIPO_FORMULARIO.REGISTRO:
                return "Registrar";
            case TIPO_FORMULARIO.MODIFICAR:
                return "Guardar";
            case TIPO_FORMULARIO.SOLO_LECTURA:
                return "-";
        }
    }

    openModalImprimirEtiqueta = id_documento => {
        this._modalService.show(AppModalRegDocImprimirEtiquetaComponent, {
            ...modalDefaultConfig,
            initialState: {
                id_documento: id_documento
            }
        });
    };
}
