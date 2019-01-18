import { Component, OnInit, Input } from "@angular/core";
import { IColumnDefinition } from "src/_shared";

@Component({
    selector: "tbody[app-list-table-body]",
    template: `
        <tr *ngIf="items.length == 0">
            <td [colSpan]="_columns.length" class="text-center">{{ textNoItems }}</td>
        </tr>
        <tr *ngFor="let item of items; let i = index">
            <td
                *ngFor="let column of _columns"
                class="custom-td"
                [ngClass]="column.tdClass ? column.tdClass(item) : null"
                [ngStyle]="column.tdStyle ? column.tdStyle : null"
                app-datatable-column
                [column]="column"
                [item]="item"
                [index]="i + 1"
                [loading]="loading"
            ></td>
        </tr>
    `,
    styles: [
        `
            .custom-td {
                height: 15px !important;
            }
        `
    ]
})
export class ListTableBodyComponent implements OnInit {
    @Input()
    columns: Array<IColumnDefinition>;
    @Input()
    items: Array<any>;
    @Input()
    loading: boolean;

    get textNoItems() {
        return this.loading ? "Cargando registros..." : "No hay registros";
    }

    constructor() {}

    getProperty = (obj, path) => {
        return path.split(/(\[|\]|\.)/).reduce((x, y) => {
            return "[].".indexOf(y) > -1 ? x : x === Object(x) && y in x ? x[y] : undefined;
        }, obj);
    };

    ngOnInit() {}

    get _columns(): Array<IColumnDefinition> {
        return this.columns.filter(x => x.show !== false);
    }
}
