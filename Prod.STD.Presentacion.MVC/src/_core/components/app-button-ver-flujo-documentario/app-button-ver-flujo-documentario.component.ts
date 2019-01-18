import { Component, OnInit, Input } from "@angular/core";
import { BsModalService } from "ngx-bootstrap/modal";
import { modalDefaultConfig } from "src/_shared";
import { AppFlujoDocumentarioComponent } from "../app-flujo-documentario";

@Component({
    selector: "app-button-ver-flujo-documentario-tramite",
    template: `
        <button
            [disabled]="disabled"
            role="button"
            tooltip="Flujo documentario"
            placement="bottom"
            class="{{ class }}"
            (click)="handleClick()"
        >
            <span *ngIf="text">{{ text }}</span>
            <ng-content></ng-content>
        </button>
    `,
    styles: [``]
})
export class AppButtonVerFlujoDocumentarioComponent implements OnInit {
    @Input()
    loading: Boolean;

    @Input()
    disabled: Boolean;

    @Input()
    id_documento: number;

    @Input()
    tipo: string;

    @Input()
    text: string;

    @Input()
    class: string;

    constructor(private _modalService: BsModalService) {}

    ngOnInit() {}

    handleClick = () => {
        this._modalService.show(AppFlujoDocumentarioComponent, {
            ...modalDefaultConfig,
            class: `modal-custom container`,
            initialState: {
                id_documento: this.id_documento,
                tipo: this.tipo
            }
        });
    };
}
