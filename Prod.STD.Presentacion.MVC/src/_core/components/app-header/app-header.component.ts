import { Component, OnInit, Input } from "@angular/core";

@Component({
    selector: "app-header",
    templateUrl: "./app-header.component.html"
})
export class AppHeaderComponent implements OnInit {
    @Input() logo: string;
    @Input() nombreDesc: string;
    @Input() menuOptions: Array<object>;
    @Input() userFullname: string;

    constructor() {}

    ngOnInit() {}
}
