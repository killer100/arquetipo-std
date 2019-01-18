import { Directive, ElementRef, OnInit, Input, Renderer } from "@angular/core";

@Directive({ selector: "[auto-focus]" })
export class AutoFocusDirective implements OnInit {
    @Input("auto-focus") isFocused: boolean;

    constructor(private hostElement: ElementRef, private renderer: Renderer) {}

    ngOnInit() {
        if (this.isFocused) {
            this.renderer.invokeElementMethod(this.hostElement.nativeElement, "focus");
        }
    }
}
