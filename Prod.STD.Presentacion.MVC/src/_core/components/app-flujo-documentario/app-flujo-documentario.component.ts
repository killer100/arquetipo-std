import { Component, OnInit, Input } from "@angular/core";
import { BsModalRef, BsModalService } from "ngx-bootstrap/modal";
import { AlertService } from "src/_shared/services";
import { ITableDefinition } from "../../../_shared/components/datatable/datatable.interfaces";
import axios from "axios";
import * as jspdf from "jspdf";
import html2canvas from "html2canvas";
import { AppButtonFlujoCorrespondenciasVerPdfComponent } from "./button/app-button-flujo-correspondencias-ver-pdf.component";
import { AppButtonFlujoResolucionesVerPdfComponent } from "./button/app-button-flujo-resoluciones-ver-pdf.component";
import { AppModalVerPdfComponent, modalDefaultConfig } from "src/_shared";

@Component({
    templateUrl: "./app-flujo-documentario.component.html",
    styles: [``]
})
export class AppFlujoDocumentarioComponent implements OnInit {
    loading: Boolean;

    id_documento: number;

    tipo: string;

    flujoDocumentario: any;

    tableDefAnexos: ITableDefinition;

    tableDefFlujoDependencias: ITableDefinition;

    tableDefFlujoTrabajadores: ITableDefinition;

    tableDefCorrespondencias: ITableDefinition;

    tableDefResolucion: ITableDefinition;

    tableDefExpedientesAcumulados: ITableDefinition;

    constructor(
        public bsModalRef: BsModalRef,
        private _alertService: AlertService,
        private _modalService: BsModalService
    ) {
        this.flujoDocumentario = {
            documento: {},
            anexos: [],
            flujoDependencias: [],
            flujoTrabajadores: [],
            correspondencias: [],
            resoluciones: [],
            expedientesAcumulados: []
        };

        this.tableDefAnexos = {
            columns: [
                { label: "NÚMERO", property: "num_documento_anexo" },
                { label: "RAZÓN SOCIAL", property: "razon_social" },
                { label: "FECHA", property: "fecha" },
                { label: "CONTENIDO", property: "contenido", limit: 50 },
                { label: "OBSERVACIONES", property: "observaciones", limit: 50 }
            ]
        };

        this.tableDefFlujoDependencias = {
            columns: [
                //{ label: "", property: "" },
                { label: "DOCUMENTO", property: "clase_documento" },
                { label: "NÚMERO", property: "indicativo" },
                { label: "DERIVADO", property: "fecha_registro", isDatetime: true },
                { label: "ACEPTADO", property: "fecha_recepcion", isDatetime: true },
                { label: "ASUNTO", property: "asunto", limit: 20 },
                { label: "OBSERVACIONES", property: "observaciones" },
                { label: "ORIGEN", property: "oficina_origen" },
                { label: "DESTINO", property: "oficina_destino" },
                { label: "PENDIENTE", format: item => (item.pendiente ? item.pendiente : "No") }
            ]
        };

        this.tableDefFlujoTrabajadores = {
            columns: [
                { label: "DEPENDENCIA", property: "siglas" },
                { label: "TRABAJADOR", property: "nombre_trabajador_format" },
                { label: "DERIVADO", property: "audit_trab_der", isDatetime: true },
                { label: "ACEPTADO", property: "audit_trab_rec", isDatetime: true },
                //{ label: "OBSERVACIONES", property: "" },
                { label: "AVANCE", property: "undefined" },
                {
                    label: "DOCUMENTO GENERADO",
                    format: x => `${x.descripcion || ""} ${x.indicativo_oficio || ""}`
                }
            ]
        };

        this.tableDefCorrespondencias = {
            columns: [
                {
                    label: "",
                    render: item => ({
                        component: AppButtonFlujoCorrespondenciasVerPdfComponent,
                        correspondencia: item,
                        onClickPdf: this.onClickVerPdfFlujoCorrespondencias
                    })
                },
                { label: "DOCUMENTO", property: "documento" },
                { label: "NÚMERO", property: "numero" },
                { label: "DESTINATARIO", property: "destinatario" },
                { label: "DOMICILIO", property: "domicilio" },
                { label: "ENTREGADO A COURIER", property: "fecha_entrega_courier" },
                { label: "NOTIFICADO", property: "fecha_notificacion" }
            ]
        };

        this.tableDefResolucion = {
            columns: [
                {
                    label: "",
                    render: item => ({
                        component: AppButtonFlujoResolucionesVerPdfComponent,
                        resolucion: item,
                        onClickPdf: this.onClickVerPdfFlujoResoluciones
                    })
                },
                { label: "TIPO", property: "tipo" },
                { label: "NÚMERO", property: "numero" },
                { label: "SUMILLA", property: "sumilla" },
                { label: "FECHA DE FIRMA", property: "fecha_firma", thStyle: { width: "50px" } },
                {
                    label: "FECHA DE PUBLICACIÓN",
                    property: "fecha_publicacion",
                    thStyle: { width: "50px" }
                }
            ]
        };

        this.tableDefExpedientesAcumulados = {
            columns: [
                //{ label: "", property: "" },
                { label: "HOJA DE TRÁMITE", property: "implementar" },
                { label: "RAZÓN SOCIAL", property: "implementar" },
                { label: "ASUNTO", property: "implementar" },
                { label: "FECHA", property: "implementar" }
            ]
        };
    }

    ngOnInit() {
        this.loadFlujo();
    }

    loadFlujo = () => {
        let promise = null;

        if (this.tipo == "E") promise = this.getFlujoDocumentoExterno(this.id_documento);

        if (this.tipo == "I") promise = this.getFlujoDocumentoInterno(this.id_documento);

        if (!promise) return false;

        this.loading = true;
        promise
            .then(resp => {
                this.flujoDocumentario.documento = resp.data.flujoDocumentario.documento;
                this.flujoDocumentario.flujoDependencias =
                    resp.data.flujoDocumentario.flujoDependencias;
                this.flujoDocumentario.flujoTrabajadores =
                    resp.data.flujoDocumentario.flujoTrabajadores;
                this.flujoDocumentario.correspondencias =
                    resp.data.flujoDocumentario.correspondencias;
                this.flujoDocumentario.resoluciones = resp.data.flujoDocumentario.resoluciones;
                this.flujoDocumentario.anexos = resp.data.flujoDocumentario.anexos;
            })
            .catch(err => {
                this._alertService.open("error", err.msg);
            })
            .finally(() => {
                this.loading = false;
            });
    };

    getFlujoDocumentoExterno = id_documento => {
        return axios
            .get("/api/comun/flujo-documento-externo", {
                params: { id_documento: id_documento }
            })
            .then(resp => {
                return resp.data;
            });
    };

    getFlujoDocumentoInterno = id_documento => {
        return axios
            .get("/api/comun/flujo-documento-interno", {
                params: { id_documento: id_documento }
            })
            .then(resp => {
                return resp.data;
            });
    };

    captureScreen = () => {
        var data = document.getElementById("cuerpo-test");
        html2canvas(data, { scale: 1 }).then(canvas => {
            // Few necessary setting options

            //document.getElementById("cuerpo-test").style.overflow = "hidden";

            var imgWidth = 208;
            var pageHeight = 1000;
            var imgHeight = (canvas.height * imgWidth) / canvas.width;
            console.log(imgHeight);
            var heightLeft = imgHeight;

            const contentDataURL = canvas.toDataURL("image/png", [0.0, 1.0]);

            const options = {
                pagesplit: true
            };

            let pdf = new jspdf("p", "mm", "a4"); // A4 size page of PDF
            var position = 0;
            pdf.addImage(contentDataURL, "PNG", 0, position, imgWidth, imgHeight);
            pdf.save("flujo-documentario.pdf"); // Generated PDF
        });
    };

    onClickVerPdfFlujoCorrespondencias = ruta => {
        this._modalService.show(AppModalVerPdfComponent, {
            ...modalDefaultConfig,
            class: `modal-custom modal-lg`,
            initialState: {
                ruta: ruta
            }
        });
    };

    onClickVerPdfFlujoResoluciones = ruta => {
        this._modalService.show(AppModalVerPdfComponent, {
            ...modalDefaultConfig,
            class: `modal-custom modal-lg`,
            initialState: {
                ruta: ruta
            }
        });
    };
}
