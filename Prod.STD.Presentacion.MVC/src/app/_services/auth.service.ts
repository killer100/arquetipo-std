import { Injectable } from "@angular/core";

const utf8_to_b64 = str => {
    return window.btoa(unescape(encodeURIComponent(str)));
};

const b64_to_utf8 = str => {
    return decodeURIComponent(escape(window.atob(str)));
};

declare global {
    interface Window {
        $$userinfo: any;
    }
}

@Injectable({
    providedIn: "root"
})
export class AuthService {
    private user: any = null;

    constructor() {
        const decoded_userdata = b64_to_utf8(window.$$userinfo);
        delete window.$$userinfo;
        this.user = JSON.parse(decoded_userdata);
    }

    public GetUser = () => this.user;
}
