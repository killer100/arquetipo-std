import { Component, OnInit, Input } from "@angular/core";
import { ESTADO_DOCUMENTO, TIPO_DOCUMENTO } from "src/config/app-enumerados";

@Component({
    templateUrl: "./action-buttons-documento.component.html",
    styles: ["./action-buttons-documento.component.css"]
})
export class ActionButtonsDocumentoComponent implements OnInit {
    @Input() documento: any;
    @Input() disabled: Boolean = false;
    @Input() onClickAdjuntarDocumento: Function;
    @Input() onClickVerAdjuntos: Function;
    @Input() onClickAgregarCopia: Function;
    @Input() onClickEditarDocExterno: Function;
    @Input() onClickEditaDocTupa: Function;
    @Input() onClickAnularRegistro: Function;
    @Input() onClickReactivarRegistro: Function;
    @Input() onClickVerObservaciones: Function;
    @Input() onClickImprimirEtiqueta: Function;
    @Input() onClickVerCopia: Function;

    constructor() {}

    ngOnInit() {}

    get showButtonVerObservaciones() {
        return (
            this.documento.id_estado_documento == ESTADO_DOCUMENTO.OBSERVADO &&
            !this.documento.aceptado_dependencia_inicial
        );
    }

    get showButtonVerReactivar() {
        return this.documento.id_estado_documento == ESTADO_DOCUMENTO.FINALIZADO;
    }

    get showButtonAdjuntarDocumento() {
        return this.documento.id_estado_documento != ESTADO_DOCUMENTO.FINALIZADO;
    }

    handleClickEditarRegistro = () => {
        switch (this.documento.id_tipo_documento) {
            case TIPO_DOCUMENTO.EXTERNO:
                this.onClickEditarDocExterno(this.documento.id_documento);
                break;
            case TIPO_DOCUMENTO.TUPA:
                this.onClickEditaDocTupa(this.documento.id_documento);
                break;
        }
    };
}
