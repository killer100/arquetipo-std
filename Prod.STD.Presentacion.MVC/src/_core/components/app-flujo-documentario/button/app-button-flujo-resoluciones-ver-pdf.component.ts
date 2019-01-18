import { Component, OnInit, Input } from "@angular/core";
import { RUTAS } from "src/config/app-settings";

@Component({
    template: `
        <button
            class="btn btn-secondary-custom btn-xs"
            (click)="handleClick()"
            role="button"
            title="Ver Pdf"
        >
            <i class="fa fa-file-text" aria-hidden="true"></i>
        </button>
    `
})
export class AppButtonFlujoResolucionesVerPdfComponent implements OnInit {
    @Input()
    resolucion: any;
    @Input()
    onClickPdf: Function;

    ruta_pdf: string = RUTAS.PDF_RESOLUCIONES;

    constructor() {}

    ngOnInit() {}

    handleClick = () => {
        const ruta = `${this.ruta_pdf}/${this.resolucion.id_resolucion}`;
        this.onClickPdf(ruta);
    };
}
