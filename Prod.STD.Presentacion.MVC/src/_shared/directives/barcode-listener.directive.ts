import { Directive, ElementRef, HostListener, Input } from "@angular/core";

@Directive({
    selector: "[barcode-listener]"
})
export class BarcodeListenerDirective {
    @Input()
    decimals: number = 0;
    // Allow decimal numbers. The \. is only allowed once to occur

    // Allow key codes for special events. Reflect :
    // Backspace, tab, end, home

    constructor(private el: ElementRef) {}

    @HostListener("keypress", ["$event"])
    onKeyPress(event: KeyboardEvent) {
        const keyCode = event.keyCode || event.which;
        if (keyCode == 13) {
            alert("asdasd");
        }
    }

    @HostListener("keydown", ["$event"])
    onKeyDown(e: KeyboardEvent) {
        //e.preventDefault();
    }

    @HostListener("paste", ["$event"])
    blockPaste(e: KeyboardEvent) {
        e.preventDefault();
    }
}
