import { Component, OnInit } from "@angular/core";
import { BsModalRef } from "ngx-bootstrap/modal";
import { RegistrarDocumentoService } from "src/app/_modules/mesa-partes/_services";
import { ITableDefinition } from "src/_shared";

@Component({
    template: `
        <app-modal-envelope
            [loading]="loading"
            modal-title="Copias del documento"
            [onClose]="bsModalRef.hide"
        >
            <div body><app-list-table [items]="copias" [tableDef]="tableDef"></app-list-table></div>
            <div footer>
                <button
                    (click)="bsModalRef.hide()"
                    type="button"
                    class="btn btn-default-custom"
                    data-dismiss="modal"
                >
                    <i class="fa fa-ban fa-lg" aria-hidden="true"></i> Cancelar
                </button>
            </div>
        </app-modal-envelope>
    `,
    styles: []
})
export class AppModalRegDocVerCopiasComponent implements OnInit {
    loading: Boolean = false;
    id_documento: number;
    copias: Array<any>;
    tableDef: ITableDefinition;

    constructor(
        public bsModalRef: BsModalRef,
        private _registrarDocumentoService: RegistrarDocumentoService
    ) {
        this.copias = [];
        this.tableDef = {
            columns: [
                { label: "#	", isIndex: true },
                { label: "DEPENDENCIA", property: "dependencia.dependencia" },
                { label: "SIGLAS", property: "dependencia.siglas" }
            ]
        };
    }

    ngOnInit() {
        this.loadCopias();
    }

    loadCopias = () => {
        this.loading = true;
        this._registrarDocumentoService
            .GetCopiasPorDocumento(this.id_documento)
            .then(resp => {
                this.copias = resp.data.copias;
                this.loading = false;
            })
            .catch(() => {
                this.loading = false;
            });
    };
}
