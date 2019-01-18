import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";

@Component({
    templateUrl: "./home.component.html",
    styles: []
})
export class HomeComponent implements OnInit {

    constructor(private route: ActivatedRoute) {}

    ngOnInit() {
    }
}
