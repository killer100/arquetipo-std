import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";
import { FormsModule } from "@angular/forms";
import { GestionInternaRoutingModule } from "./gestion-interna-routing.module";
import { SharedModule } from "src/_shared/shared.module";

import * as components from "./_containers";
import * as services from "src/app/_modules/gestion-interna/_services";
import { FileSelectDirective, FileUploader } from "ng2-file-upload/ng2-file-upload";
import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { AppModalConfirmarRegistroComponent } from './_containers/buscar-documento/modal/app-modal-confirmar-registro/app-modal-confirmar-registro.component';


@NgModule({
    imports: [
        CommonModule,
        RouterModule,
        FormsModule,
        HttpClientModule,
        SharedModule,
        GestionInternaRoutingModule,
        ButtonsModule.forRoot()
    ],
    declarations: [
        FileSelectDirective,
        components.AppFormBusquedaComponent,
        components.HomeComponent,
        components.PageBuscarDocumentoComponent,
        components.AppButtonActionsDocumentoComponent,
        components.AppButtonActionsArchivoComponent,
        components.AppButtonActionsCheckComponent,
        components.AppButtonActionsImpresionComponent,
        components.AppButtonActionsEstadoComponent,
        components.AppModalRegistroDocumentoComponent,        
        components.AppModalConfirmarRegistroComponent,
        
    ],
    entryComponents:[
        components.AppButtonActionsDocumentoComponent,
        components.AppButtonActionsArchivoComponent,
        components.AppButtonActionsCheckComponent,
        components.AppModalRegistroDocumentoComponent,
        components.AppModalConfirmarRegistroComponent,
    ],
    providers: [services.DocumentoService]
})
export class GestionInternaModule {}
