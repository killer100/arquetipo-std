import { Component, OnInit, Input } from "@angular/core";

@Component({
    selector: "app-show-more-text",
    template: `
        <p>
            {{ available_text + (!open && largerText ? "..." : "") }}
            <a
                *ngIf="largerText"
                class="show-more-button"
                href="javascript:"
                (click)="toogleOpen()"
                >{{ open ? "Ver menos" : "Ver más" }}</a
            >
        </p>
    `,
    styles: [
        `
            p {
                margin-bottom: 0px;
            }
            .show-more-button {
                font-size: 11px;
            }
        `
    ]
})
export class ShowMoreTextComponent implements OnInit {
    @Input()
    text: string;

    @Input()
    limit: number = 20;

    @Input()
    largerText: Boolean;

    open: Boolean = false;

    constructor() {}

    ngOnInit(): void {
        if (this.text.length > this.limit) this.largerText = true;
    }

    get available_text(): string {
        if (!this.largerText) return this.text;

        if (!this.open) {
            return this.text != null ? this.text.substring(0, this.limit) : "";
        } else {
            return this.text;
        }
    }

    toogleOpen = () => {
        this.open = this.open ? false : true;
    };
}
