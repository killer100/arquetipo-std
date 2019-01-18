import { Component } from "@angular/core";
import { APP_INFO, MENU_OPTIONS } from "../config/app-settings";
import { AuthService } from "./_services/auth.service";
import {
    ActivatedRoute,
    Router,
    NavigationEnd,
    RouteConfigLoadStart,
    RouteConfigLoadEnd
} from "@angular/router";

@Component({
    selector: "my-app",
    templateUrl: "./app.component.html",
    styles: []
})
export class AppComponent {
    appInfo = { ...APP_INFO };
    menuOptions = [...MENU_OPTIONS];
    user: any;
    userFullname: string = "";
    breadcrumb: any;
    loadingRouteConfig: boolean;

    constructor(_authService: AuthService, private route: ActivatedRoute, private router: Router) {
        this.user = _authService.GetUser();
        this.buildUserFullname();
    }

    ngOnInit(): void {
        this.subsCribeNavigationEnd();
        this.subscribeLoadRouteConfig();
    }

    subscribeLoadRouteConfig = () => {
        this.router.events.subscribe(event => {
            if (event instanceof RouteConfigLoadStart) {
                this.loadingRouteConfig = true;
            } else if (event instanceof RouteConfigLoadEnd) {
                this.loadingRouteConfig = false;
            }
        });
    };

    subsCribeNavigationEnd = () => {
        this.router.events.subscribe(val => {
            if (val instanceof NavigationEnd) {
                let route = this.route.firstChild;
                while (route.firstChild) {
                    route = route.firstChild;
                }
                route.data.subscribe(x => {
                    this.breadcrumb = x.breadcrumb;
                });
            }
        });
    };

    buildUserFullname = () => {
        this.userFullname = `${this.user.ApellidoPaterno}, ${this.user.Nombres}`;
    };
}
