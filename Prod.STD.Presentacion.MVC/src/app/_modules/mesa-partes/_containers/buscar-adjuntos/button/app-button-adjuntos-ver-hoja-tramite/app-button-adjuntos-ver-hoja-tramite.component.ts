import { Component, Input } from "@angular/core";

@Component({
    template: `
        <app-button-ver-hoja-tramite
            [disabled]="disabled"
            [id_documento]="documento.id_documento"
            [tipo]="'E'"
        ></app-button-ver-hoja-tramite>
    `,
    styles: []
})
export class AppButtonAdjuntosVerHojaTramiteComponent {
    @Input()
    documento: any;
    @Input()
    disabled: Boolean;
}
