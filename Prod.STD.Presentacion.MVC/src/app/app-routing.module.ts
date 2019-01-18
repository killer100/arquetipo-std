import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AppPageNotFoundComponent } from "src/_core/components";

const routes: Routes = [
    {
        path: "",
        loadChildren: "./_modules/home/home.module#HomeModule",
        data: {
            breadcrumb: [{ label: "Inicio", link: "/", active: true }]
        }
    },
    {
        path: "mesa-partes",
        loadChildren: "./_modules/mesa-partes/mesa-partes.module#MesaPartesModule",
        data: {
            breadcrumb: [
                { label: "Inicio", link: "/", active: false },
                { label: "Mesa de Partes", link: "/mesa-partes", active: true }
            ]
        }
    },
    {
        path: "gestion-interna",
        loadChildren: "./_modules/gestion-interna/gestion-interna.module#GestionInternaModule",
        data: {
            breadcrumb: [
                { label: "Inicio", link: "/", active: false },
                { label: "Gestión Interna", link: "/gestion-interna", active: true }
            ]
        }
    },
    {
        path: "**",
        component: AppPageNotFoundComponent
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule {}
