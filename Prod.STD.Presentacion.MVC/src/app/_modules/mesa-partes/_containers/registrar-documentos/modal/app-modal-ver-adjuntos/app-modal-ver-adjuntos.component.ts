import { Component, OnInit } from "@angular/core";
import { RegistrarDocumentoService } from "src/app/_modules/mesa-partes/_services";
import { DEFAULT_DOCUMENTO } from "src/app/_modules/mesa-partes/_interfaces";
import { BsModalRef, BsModalService } from "ngx-bootstrap/modal";
import { AppActionButtonsVerAdjuntosComponent } from "../../button/app-action-buttons-ver-adjuntos/app-action-buttons-ver-adjuntos.component";
import { modalDefaultConfig } from "src/_shared";
import {
    AppFormRegistroAdjuntoComponent,
    AppModalAnularAdjuntoComponent,
    AppModalBusAdjImprimirEtiquetaAnexoComponent
} from "../../../buscar-adjuntos";

@Component({
    selector: "app-app-modal-ver-adjuntos",
    templateUrl: "./app-modal-ver-adjuntos.component.html",
    styleUrls: ["./app-modal-ver-adjuntos.component.css"]
})
export class AppModalVerAdjuntosComponent implements OnInit {
    loading: boolean = false;
    documento: any;
    adjuntos: Array<any>;
    tableDef: any;
    refreshDocumentos: Function;

    constructor(
        private _modalService: BsModalService,
        public bsModalRef: BsModalRef,
        private _registrarDocumentoService: RegistrarDocumentoService
    ) {
        this.documento = { ...DEFAULT_DOCUMENTO };
        this.adjuntos = [];
        this.tableDef = {
            columns: [
                { label: "#	", property: "_index_number" },
                { label: "N° ADJUNTO", property: "num_documento_anexo" },
                { label: "TIPO DOCUMENTO", property: "tipo_anexo.descripcion" },
                { label: "N° DE FOLIOS", property: "folios" },
                { label: "RAZÓN SOCIAL", property: "persona.razon_social_format" },
                { label: "DESTINO", property: "persona_destino.dependencia.siglas" },
                {
                    label: "ACCIÓN",
                    render: item => ({
                        component: AppActionButtonsVerAdjuntosComponent,
                        adjunto: item,
                        onClickModificarAdjunto: this.handleClickModificarAdjunto,
                        onClickAnularAdjunto: this.handleClickAnularAdjunto,
                        onClickImprimirEtiqueta: this.handleClickImprimirEtiqueta
                    })
                }
            ]
        };
    }

    ngOnInit() {
        this.loadAnexos();
    }

    loadAnexos = () => {
        this.loading = true;
        this._registrarDocumentoService
            .GetAnexosPorDocumento(this.documento.id_documento)
            .then(resp => {
                if (resp.data.anexos)
                    this.adjuntos = resp.data.anexos.map((x, i) => ({
                        ...x,
                        _index_number: i + 1
                    }));
            })
            .finally(() => {
                this.loading = false;
            });
    };

    handleClickModificarAdjunto = id_anexo => {
        this._modalService.show(AppFormRegistroAdjuntoComponent, {
            ...modalDefaultConfig,
            initialState: {
                id_anexo: id_anexo,
                onSaveFinish: () => {
                    this.loadAnexos();
                }
            }
        });
    };

    handleClickAnularAdjunto = anexo => {
        this._modalService.show(AppModalAnularAdjuntoComponent, {
            ...modalDefaultConfig,
            class: `modal-custom modal-lg`,
            initialState: {
                adjunto: anexo,
                onAnularFinish: () => {
                    this.loadAnexos();
                    this.refreshDocumentos();
                }
            }
        });
    };

    handleClickImprimirEtiqueta = id_anexo => {
        this._modalService.show(AppModalBusAdjImprimirEtiquetaAnexoComponent, {
            ...modalDefaultConfig,
            initialState: {
                id_anexo: id_anexo
            }
        });
    };
}
