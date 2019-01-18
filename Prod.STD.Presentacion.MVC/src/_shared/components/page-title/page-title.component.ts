import { Component, OnInit, Input } from "@angular/core";

@Component({
    selector: "app-page-title",
    template: `
        <div class="row">
            <div class="col-sm-6 col-xs-12">
                <div class="page-header-custom">
                    <h1 class="title-custom">{{ text }}</h1>
                </div>
            </div>
            <div class="col-sm-6 col-xs-12 text-right right-column"><ng-content></ng-content></div>
        </div>
    `,
    styles: [
        `
            @media (max-width: 480px) {
                .right-column {
                    text-align: left;
                    padding-top: 10px;
                    padding-bottom: 10px;
                }
            }
        `
    ]
})
export class PageTitleComponent implements OnInit {
    @Input()
    text: String = "";

    constructor() {}

    ngOnInit() {}
}
