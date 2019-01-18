import { Component, OnInit, Input } from "@angular/core";
import { IColumnDefinition } from "src/_shared";

@Component({
    selector: "thead[app-list-table-header]",
    template: `
        <tr>
            <th *ngFor="let column of _columns" [ngStyle]="column.thStyle ? column.thStyle : null">
                {{ column.label }}
            </th>
        </tr>
    `,
    styles: ["th {text-align: left!important; }"]
})
export class ListTableHeaderComponent implements OnInit {
    @Input()
    columns: Array<IColumnDefinition>;

    constructor() {}

    ngOnInit() {}

    get _columns(): Array<IColumnDefinition> {
        return this.columns.filter(x => x.show !== false);
    }
}
