import { Component, OnInit } from "@angular/core";
import { BsModalRef, BsModalService } from "ngx-bootstrap/modal";
import { DEFAULT_DOCUMENTO, IDocumento, DEFAULT_DOCUMENTO_ERRORS } from "../../../../_interfaces";
import { ComunService } from "src/app/_services/comun.service";
import { modalDefaultConfig } from "src/_shared";
import * as moment from "moment";
import { RegistrarDocumentoService } from "../../../../_services";
import { AlertService } from "src/_shared/services";
import { TIPO_FORMULARIO } from "src/config/app-enumerados";
import { ConfirmarRegistroTupaComponent } from "../../modal/confirmar-registro-tupa/confirmar-registro-tupa.component";
import { ListaRequisitosTupaComponent } from "../../modal/lista-requisitos-tupa/lista-requisitos-tupa.component";
import { AppModalRegDocImprimirEtiquetaComponent } from "../../../registrar-documentos";

@Component({
    templateUrl: "./form-registro-tupa.component.html",
    styleUrls: ["./form-registro-tupa.component.css"]
})
export class FormRegistroTupaComponent implements OnInit {
    _tipo: number = TIPO_FORMULARIO.REGISTRO;
    id_documento?: number;
    loading: Boolean = false;
    flags_enumerados: any;
    documento: IDocumento;
    errors: any;
    _razon_social: string;
    _id_clase_tupa: number;
    onSave: Function;
    //ENUMERABLES
    enum_clasesDocumento: Array<any>;
    enum_clasesTupa: Array<any>;
    enum_tupas: Array<any>;

    constructor(
        public bsModalRef: BsModalRef,
        private _modalService: BsModalService,
        private _comunService: ComunService,
        private _registrarDocumentoService: RegistrarDocumentoService,
        private _alertService: AlertService
    ) {
        this.flags_enumerados = {
            tupas: false
        };
        this.enum_clasesDocumento = [];
        this.enum_clasesTupa = [];
        this.enum_tupas = [];
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

    loadDocumento = async () => {
        try {
            this.loading = true;
            const resp = await this._registrarDocumentoService.GetDocumentoTupa(this.id_documento);
            this._id_clase_tupa = resp.data.tupa.id_clase_tupa;
            this.loadTupas();
            resp.data.fecha_recepcion = moment(resp.data.auditmod);
            this.documento = resp.data;
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
        this._comunService.FetchClasesTupa().then(data => {
            this.enum_clasesTupa = data;
        });
    };

    loadTupas = () => {
        this.flags_enumerados.tupas = true;
        this._comunService.FetchTupas({ id_clase_tupa: this._id_clase_tupa }).then(data => {
            this.enum_tupas = data;
            this.flags_enumerados.tupas = false;
        });
    };

    loadRequisitosTupa = () => {
        this._comunService.FetchRequisitosTupa(this.documento.id_tup).then(data => {
            console.log(data);
            this.documento.requisitos = data;
        });
    };

    getPersonas = value => {
        const params = {
            razon_social: value,
            limit: 5
        };
        return this._comunService.FetchPersonas(params);
    };

    handleSelectPersona = persona => {
        this.documento.id_persona = persona.id;
        this.documento.persona = persona;
    };

    handleChangeClaseTupa = () => {
        this.documento.id_tup = null;
        if (this._id_clase_tupa == null) {
            this.enum_tupas = [];
        } else {
            this.loadTupas();
        }
    };

    handleChangeTupa = () => {
        this.documento.requisitos = [];
        if (this.documento.id_tup != null) {
            this.loadRequisitosTupa();
        }
    };

    handleSubmit = e => {
        e.preventDefault();
        this.openModalConfirm();
    };

    saveTupa = async () => {
        this.errors = this.errors = { ...DEFAULT_DOCUMENTO_ERRORS };
        this.loading = true;

        try {
            let promise = null;
            switch (this._tipo) {
                case TIPO_FORMULARIO.REGISTRO:
                    promise = this._registrarDocumentoService.SaveDocumentoTupa(this.documento);
                    break;
                case TIPO_FORMULARIO.MODIFICAR:
                    promise = this._registrarDocumentoService.UpdateDocumentoTupa(
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
            let msg = "Ocurrió un error interno";
            if (err.statuscode == 406) {
                this.errors = err.errors;
                msg = err.msg;
            }
            this._alertService.open("error", msg);
        }
        this.loading = false;
    };

    openModalConfirm = () => {
        const tupa = this.enum_tupas.find(x => x.id_tupa === this.documento.id_tup);
        const { requisitos } = this.documento;

        const requisitosTotal = requisitos.filter(x => x.id_requisito != 0).length;
        const requisitosCumplidos = requisitos.filter(
            x => x.estado_observacion == true && x.id_requisito != 0
        ).length;

        const config = {
            ...modalDefaultConfig,
            class: `modal-custom`,
            initialState: {
                asunto: tupa ? tupa.descripcion_format : null,
                razon_social: this.documento.persona.razon_social_format,
                destino: tupa ? `${tupa.dependencia} (${tupa.siglas})` : null,
                requisitosTotal: requisitosTotal,
                requisitosCumplidos: requisitosCumplidos,
                onConfirm: this.saveTupa
            }
        };
        this._modalService.show(ConfirmarRegistroTupaComponent, config);
    };

    openModalRequisitos = () => {
        const tupa = this.enum_tupas.find(x => x.id_tupa === this.documento.id_tup);
        const config = {
            ...modalDefaultConfig,
            class: `modal modal-custom container fade in modal-lg`,
            initialState: {
                title: tupa.descripcion_format,
                requisitos: JSON.parse(JSON.stringify(this.documento.requisitos)),
                onSave: this.handleSaveRequisitos
            }
        };
        this._modalService.show(ListaRequisitosTupaComponent, config);
    };

    handleSaveRequisitos = requisitos => {
        this.documento.requisitos = requisitos;
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
