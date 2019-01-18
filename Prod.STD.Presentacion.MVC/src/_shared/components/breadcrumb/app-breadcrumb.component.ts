import { Component, OnInit, Input } from "@angular/core";

@Component({
    selector: "app-breadcrumb",
    templateUrl: "./app-breadcrumb.component.html"
})
export class BreadCrumbComponent implements OnInit {
    @Input()
    data: Array<any>;

    constructor() {}

    ngOnInit() {}
}
