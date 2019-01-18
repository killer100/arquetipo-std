import { Component, OnInit, Input } from "@angular/core";
import { BsModalRef } from "ngx-bootstrap/modal";

@Component({
    templateUrl: "./confirmar-registro.component.html",
    styles: []
})
export class ConfirmarRegistroExternoComponent implements OnInit {
    @Input()
    razon_social: string;
    @Input()
    asunto: string;
    @Input()
    destino: any;
    @Input()
    onConfirm: Function;
    copias: Array<any>;

    constructor(public bsModalRef: BsModalRef) {}

    ngOnInit() {
        console.log(this.copias);
    }

    handleConfirm = () => {
        this.onConfirm();
        this.bsModalRef.hide();
    };

    get destinatario_copias() {
        return this.copias.map(x => x.dependenciaFormat).join(", ");
    }
}
