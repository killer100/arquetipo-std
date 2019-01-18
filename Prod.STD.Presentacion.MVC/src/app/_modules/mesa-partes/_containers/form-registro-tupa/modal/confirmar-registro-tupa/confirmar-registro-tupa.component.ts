import { Component, OnInit } from "@angular/core";
import { BsModalRef } from "ngx-bootstrap/modal";

@Component({
    templateUrl: "./confirmar-registro-tupa.component.html",
    styles: []
})
export class ConfirmarRegistroTupaComponent implements OnInit {
    razon_social: string;
    asunto: string;
    destino: any;
    onConfirm: Function;
    requisitosTotal: number;
    requisitosCumplidos: number;

    constructor(public bsModalRef: BsModalRef) {}

    ngOnInit() {}

    handleConfirm = () => {
        this.onConfirm();
        this.bsModalRef.hide();
    };
}
