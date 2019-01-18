import { Component, OnInit, Input } from "@angular/core";

@Component({
    selector: "app-input-documentos-escaneados-seleccionados",
    templateUrl: "./app-input-documentos-escaneados-seleccionados.component.html",
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
export class AppInputDocumentosEscaneadosSeleccionadosComponent implements OnInit {
    @Input()
    items: Array<any> = [];

    @Input()
    onRemove: Function;

    constructor() {}

    ngOnInit() {}
}
