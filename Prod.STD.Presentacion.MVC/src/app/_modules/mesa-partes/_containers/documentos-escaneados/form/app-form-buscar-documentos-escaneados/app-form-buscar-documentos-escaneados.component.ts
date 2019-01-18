import { Component, OnInit, Input } from "@angular/core";
import { AlertService } from "src/_shared/services";
import { ComunService } from "src/app/_services/comun.service";
import * as moment from "moment";

const DEFAULT_FORM = {
    coddep: null,
    fecha_inicio: moment()
        .startOf("day")
        .utc(true),
    fecha_fin: moment()
        .endOf("day")
        .utc(true),
    estado: 1
};

@Component({
    selector: "app-form-buscar-documentos-escaneados",
    templateUrl: "./app-form-buscar-documentos-escaneados.component.html",
    styles: []
})
export class AppFormBuscarDocumentosEscaneadosComponent implements OnInit {
    @Input()
    onSubmit: Function;
    @Input()
    disabled: Boolean;

    loadingEnumerables: Boolean = false;
    enum_dependencias: Array<any>;
    form: any;

    constructor(private _alertService: AlertService, private _comunService: ComunService) {
        this.form = { ...DEFAULT_FORM };
        this.enum_dependencias = [];
    }

    ngOnInit() {
        this.search();
        this.loadEnumerables();
    }

    loadEnumerables = () => {
        this.loadingEnumerables = true;
        this._comunService.FetchDependencias({}).then(data => {
            this.enum_dependencias = data.map(x => ({
                ...x,
                label: `${x.dependencia} (${x.siglas})`
            }));
            this.loadingEnumerables = false;
        });
    };

    handleChangeEstado = (estado = null) => {
        this.form.estado = estado;
        this.search();
    };

    handleSubmit = e => {
        e.preventDefault();
        this.search();
    };

    handleClear = () => {
        this.form = { ...DEFAULT_FORM };
        this.onSubmit({ ...this.buildFilters(this.form) });
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
        this.onSubmit({ ...this.buildFilters(this.form) });
    };

    validateDates = () => {
        if (this.form.fecha_inicio != null && this.form.fecha_fin != null) {
            return this.form.fecha_fin.isSameOrAfter(this.form.fecha_inicio);
        }
        return true;
    };

    buildFilters = filters => ({
        ...filters
    });
}
