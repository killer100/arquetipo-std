import { RouterModule, Routes } from "@angular/router";
import { NgModule } from "@angular/core";

import {
    HomeComponent, PageBuscarDocumentoComponent
} from "./_containers";

const routes: Routes = [
    { path: "", component: HomeComponent },
    { 
        path: "documentos", 
        component: PageBuscarDocumentoComponent,
        data: {
            breadcrumb: [
                { label: "Inicio", link: "/", active: false },
                { label: "Gestión Interna", link: "/gestion-interna", active: false },
                { label: "Buscar Documento", link: "/gestion-interna/documentos", active: true }
            ]
        }
    }
];
@NgModule({
    imports: [RouterModule.forChild(routes)]
})
export class GestionInternaRoutingModule {}