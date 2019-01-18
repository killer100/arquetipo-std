import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";
import { FormsModule } from "@angular/forms";
import { AccordionModule } from "ngx-bootstrap/accordion";
import { BsDropdownModule } from "ngx-bootstrap/dropdown";
import { TooltipModule } from "ngx-bootstrap/tooltip";
import { ModalModule } from "ngx-bootstrap/modal";
import { TypeaheadModule } from "ngx-bootstrap/typeahead";
import { SharedModule } from "../../../_shared/shared.module";
import { MesaPartesRoutingModule } from "./mesa-partes-routing.module";
import { CoreModule } from "src/_core/core.module";

import * as components from "./_containers";

import * as services from "./_services";

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        HttpClientModule,
        RouterModule,
        HttpClientModule,
        SharedModule,
        CoreModule,
        AccordionModule.forRoot(),
        BsDropdownModule.forRoot(),
        ModalModule.forRoot(),
        TooltipModule.forRoot(),
        TypeaheadModule.forRoot(),
        MesaPartesRoutingModule
    ],
    declarations: [
        components.AppFormBuscarAdjuntoComponent,
        components.AppPageBuscarAdjuntosComponent,
        components.RegistrarDocumentosComponent,
        components.FormBuscarDocumentoComponent,
        components.DocumentosIngresadosComponent,
        components.AppFormBuscarDocumentosEscaneadosComponent,
        components.AppPageDocumentosEscaneadosComponent,
        components.AppInputDocumentosIngresadosSeleccionadosComponent,
        components.AppFormBuscarDocumentosIngresadosComponent,
        components.HomeComponent,
        components.FormRegistroDocumentoExternoComponent,
        components.FormRegistroTupaComponent,
        components.ActionButtonsDocumentoComponent,
        components.ConfirmarRegistroExternoComponent,
        components.ColorEstadoComponent,
        components.ConfirmarRegistroTupaComponent,
        components.ListaRequisitosTupaComponent,
        components.AppFormRegistroAdjuntoComponent,
        components.AppModalVerAdjuntosComponent,
        components.AppActionButtonsVerAdjuntosComponent,
        components.AppModalAnularAdjuntoComponent,
        components.AppModalAnularRegistroComponent,
        components.AppModalReactivarRegistroComponent,
        components.AppModalLevantarObservacionesComponent,
        components.AppButtonAcionsBuscarAdjuntoComponent,
        components.AppDocIngresadoButtonEscaneadoComponent,
        components.AppDocIngresadoButtonAccionComponent,
        components.AppDocIngresadoButtonPdfComponent,
        components.AppButtonVerDetalleDocumentoComponent,
        components.AppButtonVerHojaTramiteComponent,
        components.AppModalAgregarCopiaComponent,
        components.AppModalDocIngresadosGeneraReporteComponent,
        components.AppModalDocIngresadosListaReportesComponent,
        components.AppInputDocumentosEscaneadosSeleccionadosComponent,
        components.AppDocEscaneadoButtonEscaneadoComponent,
        components.AppModalDocEscaneadosGeneraReporteComponent,
        components.AppModalBarcodeDocumentosIngresadosComponent,
        components.AppDocEscaneadoButtonPdfComponent,
        components.AppDocEscaneadoButtonAccionComponent,
        components.AppModalDocEscaneadosListaReportesComponent,
        components.AppModalRegDocImprimirEtiquetaComponent,
        components.AppModalRegDocVerCopiasComponent,
        components.AppModalBusAdjImprimirEtiquetaAnexoComponent,
        components.AppDocIngresadoVerFlujoDocumentoComponent,
        components.AppDocEscaneadoVerFlujoDocumentoComponent,
        components.AppButtonAdjuntosVerHojaTramiteComponent,
        components.AppButtonAdjuntosVerFlujoDocumentoComponent,
        components.AppButtonDocIngresadoAccionesListaReportes,
        components.AppButtonDocEscaneadoAccionesListaReportes
    ],
    entryComponents: [
        components.FormRegistroDocumentoExternoComponent,
        components.FormRegistroTupaComponent,
        components.ActionButtonsDocumentoComponent,
        components.ConfirmarRegistroExternoComponent,
        components.ColorEstadoComponent,
        components.ConfirmarRegistroTupaComponent,
        components.ListaRequisitosTupaComponent,
        components.AppFormRegistroAdjuntoComponent,
        components.AppModalVerAdjuntosComponent,
        components.AppActionButtonsVerAdjuntosComponent,
        components.AppModalAnularAdjuntoComponent,
        components.AppModalAnularRegistroComponent,
        components.AppModalReactivarRegistroComponent,
        components.AppModalLevantarObservacionesComponent,
        components.AppButtonAcionsBuscarAdjuntoComponent,
        components.AppDocIngresadoButtonEscaneadoComponent,
        components.AppDocIngresadoButtonAccionComponent,
        components.AppDocIngresadoButtonPdfComponent,
        components.AppButtonVerDetalleDocumentoComponent,
        components.AppButtonVerHojaTramiteComponent,
        components.AppModalAgregarCopiaComponent,
        components.AppModalDocIngresadosGeneraReporteComponent,
        components.AppModalDocIngresadosListaReportesComponent,
        components.AppInputDocumentosEscaneadosSeleccionadosComponent,
        components.AppDocEscaneadoButtonEscaneadoComponent,
        components.AppModalDocEscaneadosGeneraReporteComponent,
        components.AppModalBarcodeDocumentosIngresadosComponent,
        components.AppDocEscaneadoButtonPdfComponent,
        components.AppDocEscaneadoButtonAccionComponent,
        components.AppModalDocEscaneadosListaReportesComponent,
        components.AppModalRegDocImprimirEtiquetaComponent,
        components.AppModalRegDocVerCopiasComponent,
        components.AppModalBusAdjImprimirEtiquetaAnexoComponent,
        components.AppDocIngresadoVerFlujoDocumentoComponent,
        components.AppDocEscaneadoVerFlujoDocumentoComponent,
        components.AppButtonAdjuntosVerHojaTramiteComponent,
        components.AppButtonAdjuntosVerFlujoDocumentoComponent,
        components.AppButtonDocIngresadoAccionesListaReportes,
        components.AppButtonDocEscaneadoAccionesListaReportes
    ],
    providers: [
        services.BuscarAdjuntosService,
        services.DocumentosEscaneadosService,
        services.DocumentosIngresadosService,
        services.RegistrarDocumentoService
    ]
})
export class MesaPartesModule {}
