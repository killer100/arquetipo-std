import { Component, OnInit, Input } from "@angular/core";
import { ITableDefinition, IPagination } from "./datatable.interfaces";

@Component({
    selector: "app-datatable",
    templateUrl: "./datatable.component.html"
})
export class DatatableComponent implements OnInit {
    @Input()
    tableDef: ITableDefinition;
    @Input()
    pagination: IPagination;
    @Input()
    loading: boolean = false;
    @Input()
    onChangePage: Function;
    @Input()
    onChangePageSize: Function;
    @Input()
    error: Boolean = false;

    get firstPageOrderItem() {
        return (this.pagination.page - 1) * this.pagination.pageSize + 1;
    }

    get lastPageOrderItem() {
        return (this.pagination.page - 1) * this.pagination.pageSize + this.pagination.Data.length;
    }

    constructor() {}

    handleChangePage = page => {
        this.onChangePage(page);
    };
    
    ngOnInit() {}
}
