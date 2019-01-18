import { Component, OnInit, Input } from "@angular/core";

@Component({
    template: `
        <div>
            <app-button-ver-hoja-tramite
                [disabled]="disabled"
                [id_documento]="documento.id_documento"
                [tipo]="'E'"
            ></app-button-ver-hoja-tramite
            >&nbsp;&nbsp;
            <label class="checkbox-inline" *ngIf="!documento.documento_digitalizado">
                <input
                    type="checkbox"
                    [checked]="checked"
                    (click)="handleChange($event)"
                    [disabled]="disabled"
                />&nbsp;
            </label>
        </div>
    `,
    styles: []
})
export class AppDocIngresadoButtonEscaneadoComponent implements OnInit {
    @Input()
    documento: any;
    @Input()
    onCheck: any;
    @Input()
    selected: Array<any>;
    @Input()
    disabled: Boolean = false;

    constructor() {}

    ngOnInit() {}

    get checked(): Boolean {
        return (
            this.selected.filter(
                x =>
                    x.id_documento == this.documento.id_documento &&
                    x.id_anexo == this.documento.id_anexo
            ).length > 0
        );
    }

    handleChange = e => {
        this.onCheck(e.target.checked, this.documento);
    };
}
