import { Component, OnInit, Input } from "@angular/core";
import { AppModalBarcodeDocumentosIngresadosComponent } from "../../modal/app-modal-barcode-documentos-ingresados/app-modal-barcode-documentos-ingresados.component";
import { modalDefaultConfig } from "src/_shared";

@Component({
    selector: "app-input-documentos-ingresados-seleccionados",
    templateUrl: "./app-input-documentos-ingresados-seleccionados.component.html",
    styles: [
        `
            .chips-container {
                background-color: #fff;
                border: 1px solid #ccc;
                padding: 6px;
                vertical-align: middle;
                border-radius: 4px;
                width: 100%;
                min-height: 34px;
                display: block;
                overflow-y: auto;
            }

            .chip {
                vertical-align: middle;
                margin-left: 5px;
                margin-right: 5px;
                display: inline-block;
                padding: 5px;
                border-radius: 2px;
            }

            .chip-remove {
                cursor: pointer;
            }
        `
    ]
})
export class AppInputDocumentosIngresadosSeleccionadosComponent implements OnInit {
    @Input()
    items: Array<any> = [];

    @Input()
    onRemove: Function;

    @Input()
    onClickBarcode: Function;

    constructor() {}

    ngOnInit() {}
}
