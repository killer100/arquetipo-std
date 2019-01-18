import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";
import { AccordionModule } from "ngx-bootstrap/accordion";
import { TooltipModule } from "ngx-bootstrap/tooltip";
import { NgxPrintModule } from "ngx-print";
import { SharedModule } from "src/_shared/shared.module";
import * as components from "./components";

@NgModule({
    imports: [
        CommonModule,
        RouterModule,
        FormsModule,
        SharedModule,
        NgxPrintModule,
        AccordionModule.forRoot(),
        TooltipModule.forRoot()
    ],
    declarations: [
        components.LogoSectionComponent,
        components.MenuOptionsComponent,
        components.AppHeaderComponent,
        components.AppPageNotFoundComponent,
        components.AppFooterComponent,
        components.AppFlujoDocumentarioComponent,
        components.AppHojaTramiteComponent,
        components.AppButtonFlujoCorrespondenciasVerPdfComponent,
        components.AppButtonFlujoResolucionesVerPdfComponent,
        components.AppButtonVerHojaTramiteComponent,
        components.AppButtonVerFlujoDocumentarioComponent
    ],
    providers: [],
    entryComponents: [
        components.AppFlujoDocumentarioComponent,
        components.AppHojaTramiteComponent,
        components.AppButtonFlujoCorrespondenciasVerPdfComponent,
        components.AppButtonFlujoResolucionesVerPdfComponent
    ],
    exports: [
        components.AppHeaderComponent,
        components.AppPageNotFoundComponent,
        components.AppFooterComponent,
        components.AppFlujoDocumentarioComponent,
        components.AppHojaTramiteComponent,
        components.AppButtonVerHojaTramiteComponent,
        components.AppButtonVerFlujoDocumentarioComponent
    ]
})
export class CoreModule {}
