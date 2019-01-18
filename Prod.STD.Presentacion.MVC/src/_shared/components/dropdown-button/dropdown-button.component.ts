import { Component, OnInit, Input } from "@angular/core";
import { IDropDownOption } from "./dropdown-button.interfaces";

@Component({
    selector: "app-dropdown-button",
    templateUrl: "./dropdown-button.component.html"
})
export class DropdownButtonComponent implements OnInit {
    @Input()
    options: Array<IDropDownOption>;

    @Input()
    text: String;

    @Input()
    iconClass: String;

    @Input()
    buttonClass: String = "btn-primary-custom";

    @Input()
    disabled: Boolean;

    constructor() {}

    ngOnInit() {}
}
