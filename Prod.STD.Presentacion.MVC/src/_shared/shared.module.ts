import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { FormsModule } from "@angular/forms";
import { defineLocale } from "ngx-bootstrap/chronos";
import { esLocale } from "ngx-bootstrap/locale";
import { CommonModule } from "@angular/common";
import { PaginationModule } from "ngx-bootstrap/pagination";
import { BsDropdownModule } from "ngx-bootstrap/dropdown";
import { BsDatepickerModule } from "ngx-bootstrap/datepicker";
import { NgSelectModule } from "@ng-select/ng-select";
import { ModalModule } from "ngx-bootstrap/modal";
import { TypeaheadModule } from "ngx-bootstrap/typeahead";
// components
import * as components from "./components";
// layout
/*
import { LogoSectionComponent } from "./layout/header/logo-section/logo-section.component";
import { MenuOptionsComponent } from "./layout/header/menu-options/menu-options.component";
import { HeaderComponent } from "./layout/header/header.component";
import { NotFoundComponent } from "./layout/not-found/not-found.component";
import { AppFooterComponent } from "./layout/footer/app-footer.component";
*/
// directives
import { NumberOnlyDirective, BarcodeListenerDirective, AutoFocusDirective } from "./directives";
// pipes
import { DateFormatPipe } from "./pipes/date-format.pipe";
//services
import * as services from "./services";

defineLocale("es", esLocale);

@NgModule({
    imports: [
        CommonModule,
        RouterModule,
        FormsModule,
        NgSelectModule,
        //NgxPrintModule,
        PaginationModule.forRoot(),
        BsDropdownModule.forRoot(),
        BsDatepickerModule.forRoot(),
        ModalModule.forRoot(),
        TypeaheadModule.forRoot(),
        //AccordionModule.forRoot()
    ],
    declarations: [
        // components
        components.AlertComponent,
        components.AppModalVerPdfComponent,
        components.AutocompleteComponent,
        components.BreadCrumbComponent,
        components.DatatableBodyComponent,
        components.DatatableComponent,
        components.DatatableCustomColumnComponent,
        components.DatatableHeaderComponent,
        components.DatatablePaginationComponent,
        components.DatatableToolbarComponent,
        components.DatepickerComponent,
        components.DropdownButtonComponent,
        components.ListTableBodyComponent,
        components.ListTableComponent,
        components.ListTableCustomColumnComponent,
        components.ListTableHeaderComponent,
        components.ModalEnvelopeComponent,
        components.PageTitleComponent,
        components.ProgressBarComponent,
        components.SelectComponent,
        components.TypedSelectComponent,
        components.InputRadioComponent,
        components.ShowMoreTextComponent,
        components.DatatableColumnComponent,
        // layout
        // LogoSectionComponent,
        // MenuOptionsComponent,
        // HeaderComponent,
        // NotFoundComponent,
        // AppFooterComponent,
        // pipes
        DateFormatPipe,
        //directives
        NumberOnlyDirective,
        BarcodeListenerDirective,
        AutoFocusDirective
    ],
    providers: [services.AlertService],
    entryComponents: [components.AlertComponent, components.AppModalVerPdfComponent],
    exports: [
        // components
        components.AlertComponent,
        components.AppModalVerPdfComponent,
        components.AutocompleteComponent,
        components.BreadCrumbComponent,
        components.DatatableBodyComponent,
        components.DatatableComponent,
        components.DatatableCustomColumnComponent,
        components.DatatableHeaderComponent,
        components.DatatablePaginationComponent,
        components.DatatableToolbarComponent,
        components.DatepickerComponent,
        components.DropdownButtonComponent,
        components.ListTableBodyComponent,
        components.ListTableComponent,
        components.ListTableCustomColumnComponent,
        components.ListTableHeaderComponent,
        components.ModalEnvelopeComponent,
        components.PageTitleComponent,
        components.ProgressBarComponent,
        components.SelectComponent,
        components.TypedSelectComponent,
        components.InputRadioComponent,
        components.ShowMoreTextComponent,
        components.DatatableColumnComponent,
        // HeaderComponent,
        // NotFoundComponent,
        // AppFooterComponent,
        // pipes
        DateFormatPipe,
        NumberOnlyDirective,
        BarcodeListenerDirective,
        AutoFocusDirective
    ]
})
export class SharedModule {}
