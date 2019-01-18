import { Component, OnInit, Input } from "@angular/core";
import { BsModalRef } from "ngx-bootstrap/modal";

@Component({
    template: `
        <app-modal-envelope modal-title="Imrpimir etiquetas" [onClose]="bsModalRef.hide">
            <div body>
                <div class="text-center">
                    <button
                        class="btn btn-link-custom"
                        title="Imprimir etiqueta administrado"
                        (click)="imprimirEtiquetaAdministrado()"
                    >
                        Imprimir código de barras ADMINISTRADO
                    </button>
                </div>
                <div class="text-center">
                    <button
                        class="btn btn-link-custom"
                        title="Imprimir etiqueta produce"
                        (click)="imprimirEtiquetaProduce()"
                    >
                        Imprimir código de barras PRODUCE
                    </button>
                </div>
            </div>
            <div footer>
                <button
                    (click)="bsModalRef.hide()"
                    type="button"
                    class="btn btn-default-custom"
                    data-dismiss="modal"
                >
                    <i class="fa fa-ban fa-lg" aria-hidden="true"></i> Cancelar
                </button>
            </div>
        </app-modal-envelope>
    `,
    styles: []
})
export class AppModalBusAdjImprimirEtiquetaAnexoComponent implements OnInit {
    id_anexo: number;

    constructor(public bsModalRef: BsModalRef) {}

    ngOnInit() {}

    imprimirEtiquetaAdministrado = () => {
        window.open(
            `/api/mesa-partes/buscar-adjuntos/anexos/${this.id_anexo}/etiqueta-administrado`,
            "window",
            "menubar=0,toolbar=0,scrollbars=yes,location=0,directories=0,status=0,resizable=0,top=0,left=0,width=560,height=400"
        );
    };

    imprimirEtiquetaProduce = () => {
        window.open(
            `/api/mesa-partes/buscar-adjuntos/anexos/${this.id_anexo}/etiqueta-produce`,
            "window",
            "menubar=0,toolbar=0,scrollbars=yes,location=0,directories=0,status=0,resizable=0,top=0,left=0,width=560,height=400"
        );
    };
}
