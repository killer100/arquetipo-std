import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import {
    RegistrarDocumentosComponent,
    AppPageBuscarAdjuntosComponent,
    DocumentosIngresadosComponent,
    AppPageDocumentosEscaneadosComponent,
    HomeComponent
} from "./_containers";
const routes: Routes = [
    { path: "", component: HomeComponent },
    {
        path: "registrar-documento",
        component: RegistrarDocumentosComponent,
        data: {
            breadcrumb: [
                { label: "Inicio", link: "/", active: false },
                { label: "Mesa de Partes", link: "/mesa-partes", active: false },
                { label: "Registros", link: "/mesa-partes/registrar-documento", active: true }
            ]
        }
    },
    {
        path: "buscar-adjuntos",
        component: AppPageBuscarAdjuntosComponent,
        data: {
            breadcrumb: [
                { label: "Inicio", link: "/", active: false },
                { label: "Mesa de Partes", link: "/mesa-partes", active: false },
                { label: "Registros", link: "/mesa-partes/buscar-adjuntos", active: true }
            ]
        }
    },
    {
        path: "documentos-ingresados",
        component: DocumentosIngresadosComponent,
        data: {
            breadcrumb: [
                { label: "Inicio", link: "/", active: false },
                { label: "Mesa de Partes", link: "/mesa-partes", active: false },
                {
                    label: "Documentos Ingresados",
                    link: "/mesa-partes/documentos-ingresados",
                    active: true
                }
            ]
        }
    },
    {
        path: "documentos-escaneados",
        component: AppPageDocumentosEscaneadosComponent,
        data: {
            breadcrumb: [
                { label: "Inicio", link: "/", active: false },
                { label: "Mesa de Partes", link: "/mesa-partes", active: false },
                {
                    label: "Documentos Escaneados",
                    link: "/mesa-partes/documentos-escaneados",
                    active: true
                }
            ]
        }
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)]
})
export class MesaPartesRoutingModule {}
