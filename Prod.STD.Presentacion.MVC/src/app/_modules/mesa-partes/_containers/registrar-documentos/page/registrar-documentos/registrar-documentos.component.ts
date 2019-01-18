import { Component, OnInit } from "@angular/core";
import { RegistrarDocumentoService } from "../../../../_services";
import { IPagination, DefaultPagination, modalDefaultConfig } from "src/_shared";
import { BsModalService } from "ngx-bootstrap/modal";
import { FormRegistroDocumentoExternoComponent } from "../../../form-registro-documento-externo";
import { FormRegistroTupaComponent } from "../../../form-registro-tupa";
import { ComunService } from "src/app/_services/comun.service";
import { CreateTableDefDocumentos, BuildFilters } from "./registrar-documentos.helpers";
import { AppFormRegistroAdjuntoComponent } from "../../../buscar-adjuntos";
import { AppModalVerAdjuntosComponent } from "../../modal/app-modal-ver-adjuntos/app-modal-ver-adjuntos.component";
import { AppModalAnularRegistroComponent } from "../../modal/app-modal-anular-registro/app-modal-anular-registro.component";
import { AppModalReactivarRegistroComponent } from "../../modal/app-modal-reactivar-registro/app-modal-reactivar-registro.component";
import { AppModalLevantarObservacionesComponent } from "../../modal/app-modal-levantar-observaciones/app-modal-levantar-observaciones.component";
import { ActivatedRoute } from "@angular/router";
import { AppModalAgregarCopiaComponent } from "../../modal/app-modal-agregar-copia/app-modal-agregar-copia.component";
import { AppModalRegDocImprimirEtiquetaComponent } from "../../modal/app-modal-reg-doc-imprimir-etiqueta/app-modal-reg-doc-imprimir-etiqueta.component";
import { AppModalRegDocVerCopiasComponent } from "../../modal/app-modal-reg-doc-ver-copias/app-modal-reg-doc-ver-copias.component";

@Component({
    selector: "app-registrar-documentos",
    templateUrl: "./registrar-documentos.component.html",
    styleUrls: ["./registrar-documentos.component.css"]
})
export class RegistrarDocumentosComponent implements OnInit {
    loading: Boolean;
    datatableError: Boolean;
    pagination: IPagination;
    DropdownRegistro: Array<any>;
    filters: any;
    enum_tipos_resolucion: Array<any> = [];
    enum_clases_documento: Array<any> = [];
    enum_siglas_oficina: Array<any> = [];
    enum_anios: Array<any> = [];
    enum_tupas: Array<any> = [];
    enum_dependencias: Array<any> = [];
    tableDef: any;

    form: {};

    constructor(
        private _registrarDocumentoService: RegistrarDocumentoService,
        private _comunService: ComunService,
        private _modalService: BsModalService,
        private route: ActivatedRoute
    ) {
        this.loading = true;
        this.datatableError = false;

        this.filters = {};

        this.DropdownRegistro = [
            { label: "TUPA", onClick: this.handleClickNuevoTupa },
            { label: "EXTERNO", onClick: this.handleClickNuevoExterno }
        ];

        this.tableDef = CreateTableDefDocumentos(
            this.openModalAdjuntarDocumento,
            this.openModalVerAdjuntos,
            this.openModalAgregarCopia,
            this.openModalEditarDocExterno,
            this.openModalEditarDocTupa,
            this.openModalAnularRegistro,
            this.openModalReactivarRegistro,
            this.openModalVerObservaciones,
            this.openModalImprimirEtiqueta,
            this.openModalVerCopias
        );

        this.pagination = { ...DefaultPagination };
    }

    ngOnInit(): void {
        this.loadEnumerables();
        const { page, pageSize } = this.pagination;
    }

    loadEnumerables = () => {
        this._comunService.FetchDependencias({}).then(data => {
            this.enum_dependencias = data.map(x => ({
                label: `${x.dependencia} (${x.siglas})`,
                value: x.codigo_dependencia
            }));
        });

        this._comunService.FetchAniosDocumentos().then(data => {
            this.enum_anios = data;
        });

        this._comunService.FetchClasesDocumento({ procedencia: "i", categoria: "d" }).then(data => {
            this.enum_clases_documento = data.map(x => ({
                value: x.id_clase_documento_interno,
                label: x.descripcion
            }));
        });

        this._comunService.FetchDependencias({ dependencias_internas: true }).then(data => {
            this.enum_siglas_oficina = data.map(x => ({ label: x.siglas, value: x.siglas }));
        });

        this._comunService.FetchTiposResolucion().then(data => {
            this.enum_tipos_resolucion = data.map(x => ({
                label: x.descripcion,
                value: x.id
            }));
        });

        this._comunService.FetchTupas().then(data => {
            this.enum_tupas = data;
        });
    };

    handleSubmitForm = filters => {
        this.filters = filters;
        const { pageSize } = this.pagination;
        this.getDocumentos(1, pageSize, filters);
    };

    handleChangePage = page => {
        const { pageSize } = this.pagination;
        this.getDocumentos(page, pageSize, this.filters);
    };

    handleChangePageSize = pageSize => {
        this.getDocumentos(1, pageSize, this.filters);
    };

    handleClickNuevoTupa = () => {
        this.openModalRegistrarDocTupa();
    };

    handleClickNuevoExterno = () => {
        this.openModalRegistrarDocExterno();
    };

    refreshData = () => {
        const { pageSize, page } = this.pagination;
        this.getDocumentos(page, pageSize, this.filters);
    };

    getDocumentos = async (page, pageSize, filters = {}) => {
        this.loading = true;
        try {
            const Response = await this._registrarDocumentoService.FetchDocumentos(
                page,
                pageSize,
                BuildFilters(filters)
            );
            this.loading = false;
            const pagination = Response.data;
            this.pagination.Data = pagination.Data;
            this.pagination.TotalRows = pagination.TotalRows;
            this.pagination.page = page;
            this.pagination.pageSize = pageSize;
        } catch (err) {
            this.pagination = { ...DefaultPagination };
            this.datatableError = true;
            this.loading = false;
        }
    };

    openModalRegistrarDocExterno = () => {
        const config = {
            ...modalDefaultConfig,
            class: `modal-custom modal-lg`,
            initialState: { onSave: this.refreshData }
        };
        this._modalService.show(FormRegistroDocumentoExternoComponent, config);
    };

    openModalRegistrarDocTupa = () => {
        const config = {
            ...modalDefaultConfig,
            class: `modal-custom modal-lg`,
            initialState: { onSave: this.refreshData }
        };
        this._modalService.show(FormRegistroTupaComponent, config);
    };

    openModalEditarDocExterno = id_documento => {
        this._modalService.show(FormRegistroDocumentoExternoComponent, {
            ...modalDefaultConfig,
            class: `modal-custom modal-lg`,
            initialState: { id_documento: id_documento, onSave: this.refreshData }
        });
    };

    openModalEditarDocTupa = id_documento => {
        this._modalService.show(FormRegistroTupaComponent, {
            ...modalDefaultConfig,
            class: `modal-custom modal-lg`,
            initialState: { id_documento: id_documento, onSave: this.refreshData }
        });
    };

    openModalAdjuntarDocumento = id_documento => {
        this._modalService.show(AppFormRegistroAdjuntoComponent, {
            ...modalDefaultConfig,
            initialState: {
                id_documento: id_documento,
                onSaveFinish: () => {
                    this.refreshData();
                }
            }
        });
    };

    openModalVerAdjuntos = documento => {
        this._modalService.show(AppModalVerAdjuntosComponent, {
            ...modalDefaultConfig,
            class: `modal-custom modal-lg`,
            initialState: {
                documento: documento,
                refreshDocumentos: () => {
                    this.refreshData();
                }
            }
        });
    };

    openModalAgregarCopia = documento => {
        this._modalService.show(AppModalAgregarCopiaComponent, {
            ...modalDefaultConfig,
            class: `modal-custom modal-lg`,
            initialState: {
                documento: documento,
                onAgregarFinish: () => {
                    this.refreshData();
                }
            }
        });
    };

    openModalAnularRegistro = documento => {
        this._modalService.show(AppModalAnularRegistroComponent, {
            ...modalDefaultConfig,
            class: `modal-custom modal-lg`,
            initialState: {
                documento: documento,
                onAnularFinish: () => {
                    this.refreshData();
                }
            }
        });
    };

    openModalReactivarRegistro = documento => {
        this._modalService.show(AppModalReactivarRegistroComponent, {
            ...modalDefaultConfig,
            class: `modal-custom modal-lg`,
            initialState: {
                documento: documento,
                onReactivarFinish: () => {
                    this.refreshData();
                }
            }
        });
    };

    openModalVerObservaciones = documento => {
        this._modalService.show(AppModalLevantarObservacionesComponent, {
            ...modalDefaultConfig,
            class: `modal-custom modal-lg`,
            initialState: {
                documento: documento,
                onLevantarObsFinish: () => {
                    this.refreshData();
                }
            }
        });
    };

    openModalImprimirEtiqueta = id_documento => {
        this._modalService.show(AppModalRegDocImprimirEtiquetaComponent, {
            ...modalDefaultConfig,
            initialState: {
                id_documento: id_documento
            }
        });
    };

    openModalVerCopias = id_documento => {
        this._modalService.show(AppModalRegDocVerCopiasComponent, {
            ...modalDefaultConfig,
            initialState: {
                id_documento: id_documento
            }
        });
    };
}
