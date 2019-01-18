import { Component, OnInit, Input } from "@angular/core";
import { ESTADO_DOCUMENTO } from "src/config/app-enumerados";

@Component({
    template: `
        <span class="label label-{{labelClass}}">{{ estado_documento.descripcion }}</span>
    `,
    styles: []
})
export class ColorEstadoComponent implements OnInit {
    @Input()
    estado_documento: any;

    labelClass: string = "primary";

    constructor() {}

    ngOnInit() {
        this.labelClass = this.buildLabelClass();
    }

    buildLabelClass = () => {
        switch (this.estado_documento.id_estado_documento) {
            case ESTADO_DOCUMENTO.REGISTRADO:
                return "primary";
            case ESTADO_DOCUMENTO.DERIVADO:
                return "info";
            case ESTADO_DOCUMENTO.OBSERVADO:
                return "warning";
            case ESTADO_DOCUMENTO.FINALIZADO:
                return "success";
            case ESTADO_DOCUMENTO.POR_DIGITALIZAR:
                return "default";
            default:
                return "default";
        }
    };
}
