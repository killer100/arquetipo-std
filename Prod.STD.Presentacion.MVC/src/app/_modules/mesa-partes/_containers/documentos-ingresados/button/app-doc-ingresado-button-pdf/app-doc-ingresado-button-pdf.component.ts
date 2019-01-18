import { Component, OnInit, Input } from "@angular/core";

@Component({
    template: `
        <button
            *ngIf="documento.pdf; else show_no"
            class="btn btn-secondary-custom btn-xs"
            role="button"
            placement="bottom"
            tooltip="Ver PDF"
            (click)="handleOpenPdf()"
            [disabled]="disabled"
        >
            <i class="fa fa-file-pdf-o" aria-hidden="true"></i>
        </button>

        <ng-template #show_no> No </ng-template>
    `,
    styles: []
})
export class AppDocIngresadoButtonPdfComponent implements OnInit {
    @Input()
    documento: any;
    @Input()
    onClickPdf: Function;
    @Input()
    disabled: Boolean = false;

    constructor() {}

    ngOnInit() {}

    handleOpenPdf = () => {
        this.onClickPdf(this.documento.pdf);
    };
}
