import "./polyfills";

import { enableProdMode } from "@angular/core";
import { platformBrowserDynamic } from "@angular/platform-browser-dynamic";

import { AppModule } from "./app/app.module";
import { RegisterInterceptors } from "./config/http-settings";
import { environment } from "./environments/environment";

if (environment.production) {
    enableProdMode();
}

//enableProdMode();
RegisterInterceptors();
/*
window.onresize = () => {
    console.log(window.innerHeight);
    //const content: any = document.querySelector(".modal-content");
    const body: any = document.querySelector(".modal-body");

    if (body) {
        body.style.height = window.innerHeight - 120 + "px";
        body.style.maxHeight = window.innerHeight - 120 + "px";
    }
};
*/
platformBrowserDynamic()
    .bootstrapModule(AppModule)
    .then(ref => {
        // Ensure Angular destroys itself on hot reloads.
        if (window["ngRef"]) {
            window["ngRef"].destroy();
        }
        window["ngRef"] = ref;

        // Otherwise, log the boot error
    })
    .catch(err => console.error(err));
