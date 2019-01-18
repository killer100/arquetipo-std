import { Component, OnInit } from "@angular/core";
import { BsModalRef } from "ngx-bootstrap/modal";

@Component({
    selector: "app-lista-requisitos-tupa",
    templateUrl: "./lista-requisitos-tupa.component.html",
    styles: []
})
export class ListaRequisitosTupaComponent implements OnInit {
    title: string;

    requisitos: Array<any>;

    requisito_general: any;

    onSave: Function;

    constructor(public bsModalRef: BsModalRef) {}

    ngOnInit() {
        this.requisito_general = this.requisitos.find(x => x.id_requisito == 0);
        if (!this.requisito_general) this.requisito_general = this.getDefaultRequisitoGeneral();
        this.requisitos = this.requisitos.filter(x => x.id_requisito != 0);
    }

    handleRegister = () => {
        const requisitos = [...this.requisitos, this.requisito_general];
        if (typeof this.onSave === "function") this.onSave(requisitos);
        this.bsModalRef.hide();
    };

    getDefaultRequisitoGeneral = () => ({
        id_requisito: 0
    });
}
