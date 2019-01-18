import { Component, Input } from "@angular/core";

@Component({
    template: `
        <div class="container-buttons">
            <app-button-ver-flujo-documentario-tramite
                [disabled]="disabled"
                [id_documento]="documento.id_documento"
                tipo="E"
                [text]="documento.num_documento_anexo"
                [class]="'btn-tramite btn-link'"
            ></app-button-ver-flujo-documentario-tramite>
        </div>
    `,
    styles: [
        `
            .container-buttons {
                width: 135px;
            }
        `
    ]
})
export class AppButtonAdjuntosVerFlujoDocumentoComponent {
    @Input()
    documento: any;
    @Input()
    disabled: Boolean;
}
