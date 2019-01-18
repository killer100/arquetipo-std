import { Component, OnInit, Input } from "@angular/core";
import { IColumnDefinition } from "./datatable.interfaces";

@Component({
    selector: "td[app-datatable-column]",
    template: `
        <span *ngIf="column.isIndex; else noIndex">{{ index }}</span>

        <ng-template #noIndex>
            <app-datatable-custom-column
                *ngIf="column.render"
                [definition]="column.render(item, loading)"
            >
            </app-datatable-custom-column>
            <div [ngSwitch]="typeColumn" *ngIf="!column.render">
                <span *ngSwitchCase="TYPE.DATE">{{
                    getProperty(item, column.property) | dateFormat
                }}</span>
                <span *ngSwitchCase="TYPE.DATETIME">{{
                    getProperty(item, column.property) | dateFormat: "":"DD/MM/YYYY HH:mm:ss"
                }}</span>
                <span *ngSwitchCase="TYPE.FORMAT">{{ column.format(item) }}</span>
                <span *ngSwitchCase="TYPE.LIMIT"
                    ><app-show-more-text
                        [text]="getProperty(item, column.property)"
                        [limit]="column.limit"
                    ></app-show-more-text
                ></span>
                <span *ngSwitchCase="TYPE.TEXT">{{ getProperty(item, column.property) }}</span>
            </div>
        </ng-template>
    `,
    styles: [
        `
            .custom-td {
                height: 15px !important;
            }
        `
    ]
})
export class DatatableColumnComponent implements OnInit {
    @Input()
    column: IColumnDefinition;
    @Input()
    item: any;
    @Input()
    index: number;
    @Input()
    loading: boolean;

    TYPE = {
        DATE: 1,
        FORMAT: 2,
        LIMIT: 3,
        TEXT: 4,
        DATETIME: 5
    };

    constructor() {}

    getProperty = (obj, path) => {
        return path.split(/(\[|\]|\.)/).reduce((x, y) => {
            return "[].".indexOf(y) > -1 ? x : x === Object(x) && y in x ? x[y] : undefined;
        }, obj);
    };

    ngOnInit() {}

    get typeColumn() {
        if (this.column.isDate) return this.TYPE.DATE;
        else if (this.column.isDatetime) return this.TYPE.DATETIME;
        else if (this.column.format) return this.TYPE.FORMAT;
        else if (this.column.limit) return this.TYPE.LIMIT;
        else return this.TYPE.TEXT;
    }
}
