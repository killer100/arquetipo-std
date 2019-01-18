import { Component, OnInit, Input } from "@angular/core";

@Component({
    template: `
        <button
            *ngIf="documento.documento_estado"
            class="btn btn-link-custom btn-icon"
            role="button"
            rel="tooltip"
            data-placement="bottom"
            title="Revertir"
            [disabled]="disabled"
            (click)="onClickRevertir(documento)"
        >
            <i class="fa fa-refresh" aria-hidden="true"></i>
        </button>
    `,
    styles: []
})
export class AppDocEscaneadoButtonAccionComponent implements OnInit {
    @Input()
    disabled: Boolean = false;
    @Input()
    documento: any;
    @Input()
    onClickRevertir: Function;

    constructor() {}

    ngOnInit() {}
}
