import { Component, OnInit } from "@angular/core";
import { BsModalRef } from "ngx-bootstrap/modal";
import { DocumentosIngresadosService } from "src/app/_modules/mesa-partes/_services";
import { AlertService } from "src/_shared/services";
import { ITableDefinition } from "src/_shared";

@Component({
    selector: "app-app-modal-barcode-documentos-ingresados",
    template: `
        <app-modal-envelope
            [loading]="loading"
            modal-title="Escanear códigos de barra"
            [onClose]="bsModalRef.hide"
        >
            <div body>
                <div class="form-group">
                    <label class="control-label">Escanear</label>
                    <textarea
                        autofocus
                        number-only
                        [disabled]="loading"
                        class="form-control"
                        name="observaciones"
                        rows="2"
                        maxlength="20"
                        [(ngModel)]="codigo"
                        [disabled]="loading"
                        (keyup.enter)="onEnter()"
                    ></textarea>
                </div>
                <app-list-table [tableDef]="tableDef" [items]="documentos"></app-list-table>
            </div>
            <div footer>
                <button
                    [disabled]="loading"
                    type="button"
                    (click)="handleAddDocumentos()"
                    class="btn btn-primary-custom"
                >
                    <i class="fa fa-check-circle-o fa-lg"></i> Agregar
                </button>
                <button
                    (click)="bsModalRef.hide()"
                    [disabled]="loading"
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
export class AppModalBarcodeDocumentosIngresadosComponent implements OnInit {
    loading: Boolean = false;

    documentos: Array<any>;

    codigo: string = "";

    tableDef: ITableDefinition;

    onAddDocumentos: Function;

    constructor(
        public bsModalRef: BsModalRef,
        private _alertService: AlertService,
        private _documentosIngresadosService: DocumentosIngresadosService
    ) {
        this.documentos = [];
        this.tableDef = {
            columns: [
                { label: "N°", isIndex: true },
                { label: "N° TRÁMITE", property: "numero_tramite" },
                { label: "FECHA REGISTRO", property: "fecha_registro", isDate: true },
                { label: "TIPO TRÁMITE", property: "tipo_registro_format" },
                { label: "USUARIO", property: "usuario" },
                { label: "REMITENTE", property: "razon_social" },
                { label: "ASUNTO", property: "asunto" },
                { label: "FOLIOS", property: "folios" },
                { label: "DEP.", property: "dependencia.siglas" }
            ]
        };
    }

    ngOnInit() {}

    onEnter = () => {
        const codigo = this.codigo;
        this.codigo = "";
        this.loadDocumento(codigo);
    };
    //15471952
    loadDocumento = codigo => {
        this.loading = true;
        this._documentosIngresadosService
            .GetDocumento(codigo)
            .then(resp => {
                const movimiento = resp.data.movimiento_documento.find(x => !x.id_oficio);

                this.documentos.push({
                    asunto: resp.data.asunto,
                    dependencia: movimiento ? movimiento.dependencia_destino : null,
                    folios: resp.data.folios,
                    id_anexo: 0,
                    id_documento: resp.data.id_documento,
                    numero_tramite: resp.data.num_tram_documentario,
                    razon_social: resp.data.persona.razon_social_format,
                    tipo_registro: 1,
                    tipo_registro_format: "DOCUMENTO",
                    usuario: resp.data.usuario,
                    fecha_registro: resp.data.auditmod
                });
            })
            .catch(err => {
                this._alertService.open("error", err.msg);
            })
            .finally(() => {
                this.loading = false;
            });
    };

    handleAddDocumentos = () => {
        this.onAddDocumentos(this.documentos);
        this.bsModalRef.hide();
    };
}
