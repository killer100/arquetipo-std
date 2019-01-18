import { Component } from "@angular/core";

@Component({
    template: `
        <div>
            <button
                class="btn btn-secondary-custom btn-xs"
                role="button"
                placement="bottom"
                tooltip="Ver documentos"
                (click)="onClickVerDocumentos(reporte.numero_reporte_int)"
                [disabled]="disabled"
            >
                <i class="fa fa-list-alt" aria-hidden="true"></i>
            </button>
        </div>
    `
})
export class AppButtonDocIngresadoAccionesListaReportes {
    reporte: any;
    disabled: Boolean;
    onClickVerDocumentos: Function;
}
