import { Component, OnInit, Input } from "@angular/core";

@Component({
    selector: "app-app-button-acions-buscar-adjunto",
    templateUrl: "./app-button-acions-buscar-adjunto.component.html",
    styles: [
        `
            .container-buttons {
                width: 100px;
                text-align: center;
            }
        `
    ]
})
export class AppButtonAcionsBuscarAdjuntoComponent implements OnInit {
    @Input() adjunto: any;
    @Input() disabled: Boolean = false;
    @Input() onClickAdjuntarDocumento: Function;
    @Input() onClickVerAdjuntos: Function;
    @Input() onClickImprimirEtiqueta: Function;

    constructor() {}

    ngOnInit() {}
}
