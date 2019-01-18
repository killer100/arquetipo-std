import { Component, OnInit, Input } from "@angular/core";
import { BsModalService } from "ngx-bootstrap/modal";
import { AppHojaTramiteComponent } from "../app-hoja-tramite/app-hoja-tramite.component";
import { modalDefaultConfig } from "src/_shared";

@Component({
    selector: "app-button-ver-hoja-tramite",
    template: `
        <button
            [disabled]="disabled"
            role="button"
            tooltip="Hoja de ruta"
            placement="bottom"
            class="btn btn-secondary-custom btn-xs"
            (click)="handleClick()"
        >
            <i class="fa fa-file-text" aria-hidden="true"></i>
        </button>
    `,
    styles: [``]
})
export class AppButtonVerHojaTramiteComponent implements OnInit {
    @Input()
    disabled: Boolean;

    @Input()
    id_documento: number;

    @Input()
    tipo: string;

    constructor(private _modalService: BsModalService) {}

    ngOnInit() {}

    handleClick = () => {
        this._modalService.show(AppHojaTramiteComponent, {
            ...modalDefaultConfig,
            class: `modal-custom modal-lg container`,
            initialState: {
                id_documento: this.id_documento,
                tipo: this.tipo
            }
        });
    };
}
