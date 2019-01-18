import { Component, OnInit, Input } from "@angular/core";
import { ITableDefinition } from "src/_shared";

@Component({
    selector: "app-list-table",
    templateUrl: "./list-table.component.html"
})
export class ListTableComponent implements OnInit {
    @Input()
    tableDef: ITableDefinition;
    @Input()
    items: Array<any>;
    @Input()
    loading: boolean = false;

    constructor() {}

    ngOnInit() {}
}
