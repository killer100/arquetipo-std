import { Component, OnInit, Input } from "@angular/core";
import { IColumnDefinition } from "./datatable.interfaces";

@Component({
    selector: "thead[app-datatable-header]",
    template: `
        <tr>
            <th *ngFor="let column of _columns" [ngStyle]="column.thStyle ? column.thStyle : null">
                {{ column.label }}
            </th>
        </tr>
    `,
    styles: []
})
export class DatatableHeaderComponent implements OnInit {
    @Input()
    columns: Array<IColumnDefinition>;

    constructor() {}

    ngOnInit() {}

    get _columns(): Array<IColumnDefinition> {
        return this.columns.filter(x => x.show !== false);
    }
}
