import { Component, Input } from "@angular/core";

@Component({
    template: `
        <app-button-ver-flujo-documentario-tramite
            [disabled]="disabled"
            [id_documento]="documento.id_documento"
            tipo="E"
            [text]="documento.numero_tramite"
            [class]="'btn-tramite btn-link'"
        ></app-button-ver-flujo-documentario-tramite>
    `
})
export class AppDocIngresadoVerFlujoDocumentoComponent {
    @Input()
    documento: any;
    @Input()
    disabled: Boolean;
}
