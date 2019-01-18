import { Component, OnInit, Input } from "@angular/core";
import { IColumnDefinition } from "./datatable.interfaces";

@Component({
    selector: "tbody[app-datatable-body]",
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
                [index]="i + pageStart"
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
export class DatatableBodyComponent implements OnInit {
    @Input()
    columns: Array<IColumnDefinition>;
    @Input()
    items: Array<any>;
    @Input()
    loading: boolean;
    @Input()
    error: boolean = false;
    @Input()
    pageStart: number = 0;

    get textNoItems() {
        return this.loading
            ? "Cargando registros..."
            : this.error
            ? "Ocurrió un error al cargar los datos"
            : "No se encontraron registros";
    }

    constructor() {}

    ngOnInit() {}

    get _columns(): Array<IColumnDefinition> {
        return this.columns.filter(x => x.show !== false);
    }
}
