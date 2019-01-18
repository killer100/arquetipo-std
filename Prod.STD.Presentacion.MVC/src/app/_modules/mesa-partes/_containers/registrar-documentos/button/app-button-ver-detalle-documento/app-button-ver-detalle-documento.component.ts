import { Component, Input } from "@angular/core";

@Component({
    template: `
        <div class="container-buttons">
            <app-button-ver-flujo-documentario-tramite
                [disabled]="disabled"
                [id_documento]="documento.id_documento"
                tipo="E"
                [text]="documento.num_tram_documentario"
                [class]="'btn-tramite btn-link'"
            ></app-button-ver-flujo-documentario-tramite>
        </div>
    `,
    styles: [
        `
            .container-buttons {
                width: 120px;
            }
        `
    ]
})
export class AppButtonVerDetalleDocumentoComponent {
    documento: any;
    disabled: Boolean;
}
