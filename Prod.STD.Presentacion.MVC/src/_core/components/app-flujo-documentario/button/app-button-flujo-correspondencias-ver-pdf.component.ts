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
export class AppButtonFlujoCorrespondenciasVerPdfComponent implements OnInit {
    @Input()
    correspondencia: any;
    @Input()
    onClickPdf: Function;

    ruta_pdf: string = RUTAS.PDF_CORRESPONDENCIAS;

    constructor() {}

    ngOnInit() {}

    handleClick = () => {
        const ruta = `${this.ruta_pdf}/${this.correspondencia.id_correspondencia}`;
        this.onClickPdf(ruta);
    };
}
