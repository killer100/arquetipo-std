import { Injectable } from "@angular/core";
import { BsModalService } from "ngx-bootstrap/modal";
import { AlertComponent } from "../components";
import { modalDefaultConfig } from "../components/modal-envelope/modal-default-config";

@Injectable({
    providedIn: "root"
})
export class AlertService {
    constructor(private _modalService: BsModalService) {}
    /*
    type: success, error, warning, info
    */
    open = (type: string, msg: string, title: string = null, onOk: Function = undefined) => {
        const state = {
            type,
            msg,
            title,
            onOk
        };
        const config = { ...modalDefaultConfig, class: "modal-custom", initialState: state };
        this._modalService.show(AlertComponent, config);
    };

    confirm = (
        type: string,
        msg: string,
        title: string = null,
        onConfirm: Function = undefined
    ) => {
        const state = {
            type,
            msg,
            title,
            onOk: onConfirm,
            cancelButton: true
        };
        const config = { ...modalDefaultConfig, class: "modal-custom", initialState: state };
        this._modalService.show(AlertComponent, config);
    };
}
