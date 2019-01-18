import { Component, OnInit, Input } from "@angular/core";
import { IAdjunto } from "src/app/_modules/mesa-partes/_interfaces/adjunto.interface";

@Component({
    template: `
        <div>
            <button
                *ngIf="adjunto.PuedeEditarOAnular"
                class="btn btn-secondary-custom btn-icon"
                role="button"
                rel="tooltip"
                data-placement="bottom"
                title="Modificar adjunto"
                (click)="onClickModificarAdjunto(adjunto.id_anexo)"
            >
                <i class="fa fa-edit" aria-hidden="true"></i>
            </button>
            <button
                *ngIf="adjunto.PuedeEditarOAnular"
                class="btn btn-secondary-custom btn-icon"
                role="button"
                rel="tooltip"
                data-placement="bottom"
                title="Anular adjunto"
                (click)="onClickAnularAdjunto(adjunto)"
            >
                <i class="fa fa-trash"></i>
            </button>

            <button
                (click)="onClickImprimirEtiqueta(adjunto.id_anexo)"
                [disabled]="disabled"
                class="btn btn-secondary-custom btn-icon"
                href="#"
                role="button"
                rel="tooltip"
                placement="bottom"
                title="Imprimir etiquetas"
            >
                <i class="fa fa-print" aria-hidden="true"></i>
            </button>
        </div>
    `,
    styles: []
})
export class AppActionButtonsVerAdjuntosComponent implements OnInit {
    @Input()
    adjunto: IAdjunto;
    @Input()
    onClickModificarAdjunto: Function;
    @Input()
    onClickAnularAdjunto: Function;
    @Input()
    onClickImprimirEtiqueta: Function;

    constructor() {}

    ngOnInit() {}
}
