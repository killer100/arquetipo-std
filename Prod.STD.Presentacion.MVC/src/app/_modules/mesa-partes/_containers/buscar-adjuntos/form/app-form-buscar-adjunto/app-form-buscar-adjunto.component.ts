import { Component, OnInit, Input } from "@angular/core";
import { AlertService } from "src/_shared/services";
import { ComunService } from "src/app/_services/comun.service";

const DEFAULT_FORM = {
    num_documento_anexo: null,
    coddep_oficina_derivada: null,
    fecha_inicio: null,
    fecha_fin: null
};

@Component({
    selector: "app-form-buscar-adjunto",
    templateUrl: "./app-form-buscar-adjunto.component.html",
    styles: []
})
export class AppFormBuscarAdjuntoComponent implements OnInit {
    loadingEnumerables: Boolean = false;
    @Input()
    onSubmit: Function;
    @Input()
    disabled: boolean = false;

    form: any;
    enum_dependencias: Array<any>;

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

    handleSubmit = () => {
        this.search();
    };

    handleClear = () => {
        this.form = { ...DEFAULT_FORM };
        this.onSubmit({ ...this.form });
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
        this.onSubmit({ ...this.form });
    };

    validateDates = () => {
        if (this.form.fecha_inicio != null && this.form.fecha_fin != null) {
            return this.form.fecha_fin.isSameOrAfter(this.form.fecha_inicio);
        }
        return true;
    };
}
