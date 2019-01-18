import { Component, OnInit, Input } from "@angular/core";
import { IFormBuscarDocumento } from "../../../../_interfaces";
import * as moment from "moment";
import { AlertService } from "src/_shared/services";

const INITIAL_FORM: IFormBuscarDocumento = {
    num_tram_documentario: null,
    fecha_inicio: null,
    fecha_fin: null,
    estado: null,
    id_tipo_resolucion: null,
    numero_resolucion: null,
    anio_resolucion: null,
    oficina_resolucion: null,
    id_clase_documento: null,
    numero_documento: null,
    anio_documento: null,
    oficina_documento: null,
    razon_social: null,
    coddep_oficina_derivada: null,
    id_tupa: null,
    asunto: null
};

@Component({
    selector: "app-form-buscar-documento",
    templateUrl: "./form-buscar-documento.component.html"
})
export class FormBuscarDocumentoComponent implements OnInit {
    @Input()
    onSubmit: Function;

    @Input()
    disabled: Boolean = false;

    @Input()
    enum_tipos_resolucion?: Array<any>;

    @Input()
    enum_clases_documento?: Array<any>;

    @Input()
    enum_siglas_oficina: Array<any>;

    @Input()
    enum_anios: Array<any>;

    @Input()
    enum_tupas: Array<any>;

    @Input()
    enum_dependencias: Array<any>;

    form: IFormBuscarDocumento;

    constructor(private _alertService: AlertService) {
        this.form = { ...INITIAL_FORM };
    }

    handleSubmit = () => {
        this.search();
    };

    search = () => {
        if (!this.validateDates()) {
            this._alertService.open(
                "warning",
                "La fecha inicial debe ser menor o igual a la fecha final",
                null
            );
            return false;
        }
        this.onSubmit(this.form);
    };

    validateDates = () => {
        if (this.form.fecha_inicio != null && this.form.fecha_fin != null) {
            return this.form.fecha_fin.isSameOrAfter(this.form.fecha_inicio);
        }
        return true;
    };

    ngOnInit() {
        this.search();
    }

    handleClear = () => {
        this.form = { ...INITIAL_FORM };
        this.onSubmit(this.form);
    };
}
