import { Component, OnInit } from "@angular/core";
import { BsModalRef } from "ngx-bootstrap/modal";
import { DomSanitizer } from "@angular/platform-browser";

@Component({
    template: `
        <app-modal-envelope modal-title="PDF" [onClose]="bsModalRef.hide">
            <div body><iframe class="component-iframe" [src]="url"></iframe></div>
            <div footer>
                <button
                    (click)="bsModalRef.hide()"
                    type="button"
                    class="btn btn-default-custom"
                    data-dismiss="modal"
                >
                    <i class="fa fa-ban fa-lg" aria-hidden="true"></i> Cerrar
                </button>
            </div>
        </app-modal-envelope>
    `,
    styles: [
        `
            .component-iframe {
                width: 100%;
                min-height: 600px;
            }
        `
    ]
})
export class AppModalVerPdfComponent implements OnInit {
    ruta: string;
    url: any;
    constructor(public bsModalRef: BsModalRef, private sanitizer: DomSanitizer) {}

    ngOnInit() {
        this.url = this.sanitizer.bypassSecurityTrustResourceUrl(this.ruta);
    }
}
