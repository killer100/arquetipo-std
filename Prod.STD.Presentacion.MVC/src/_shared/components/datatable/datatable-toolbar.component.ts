import { Component, OnInit, Input } from "@angular/core";

@Component({
    selector: "app-datatable-toolbar",
    template: `
        <div class="row">
            <div class="col-sm-3">
                <div class="form-inline cant-reg mb-3">
                    <label
                        >Mostrar
                        <select
                            [disabled]="disabled"
                            (change)="handleChangeSelect($event)"
                            class="form-control input-sm"
                        >
                            <option *ngFor="let val of pageSizeOptions" value="{{val}}">{{
                                val
                            }}</option>
                        </select>
                        registros
                    </label>
                </div>
            </div>
            <div class="col-sm-9">
                <div class="text-right mb-9"><ng-content></ng-content></div>
            </div>
        </div>
    `,
    styles: []
})
export class DatatableToolbarComponent implements OnInit {
    @Input()
    pageSizeOptions: Array<number> = [10, 25, 50, 100];
    @Input()
    onChangePageSize: Function;
    @Input()
    disabled: Boolean;

    constructor() {}

    ngOnInit() {}

    handleChangeSelect = $event => {
        this.onChangePageSize($event.target.value);
    };
}
