import { Directive, ElementRef, HostListener, Input } from "@angular/core";

@Directive({
    selector: "[number-only]"
})
export class NumberOnlyDirective {
    @Input()
    decimals: number = 0;
    // Allow decimal numbers. The \. is only allowed once to occur

    //private regexWithDecimals: RegExp = new RegExp(/^[0-9]+(\.[0-9]*){0,1}$/g);

    private regexWithDecimals1 = /\d|\./;
    private regexWithOutDecimals: RegExp = new RegExp(/^\d+$/);

    // Allow key codes for special events. Reflect :
    // Backspace, tab, end, home

    private specialKeys: Array<string> = [
        "Backspace",
        "Tab",
        "End",
        "Home",
        "ArrowLeft",
        "ArrowRight",
        "ArrowUp",
        "ArrowDown"
    ];

    constructor(private el: ElementRef) {}

    @HostListener("keypress", ["$event"])
    onKeyDown(event: KeyboardEvent) {
        const keyCode = event.keyCode || event.which;
        const keyValue = event.key || String.fromCharCode(keyCode);

        if (
            !(this.decimals > 0 ? this.regexWithDecimals1 : this.regexWithOutDecimals).test(
                keyValue
            )
        ) {
            event.preventDefault();
        }

        if (this.decimals > 0) {
            const regexWithDecimals2 = `^\\d+(\\.\\d{0,${this.decimals}})?$`;
            const target: any = event.target;

            const number =
                target.value.substr(0, target.selectionStart) +
                keyValue +
                target.value.substr(target.selectionStart);
            if (target.value !== "" && !new RegExp(regexWithDecimals2).test(number)) {
                event.preventDefault();
            }
        }

        /*
        // Allow Backspace, tab, end, and home keys
        if (this.specialKeys.indexOf(event.key) !== -1) {
            return;
        }

        // Do not use event.keycode this is deprecated.
        // See: https://developer.mozilla.org/en-US/docs/Web/API/KeyboardEvent/keyCode
        let current: string = this.el.nativeElement.value;
        // We need this because the current value on the DOM element
        // is not yet updated with the value from this event
        let next: string = current.concat(event.key);
        if (next && !String(next).match(regex)) {
            event.preventDefault();
        }*/
    }

    @HostListener("paste", ["$event"])
    blockPaste(e: KeyboardEvent) {
        e.preventDefault();
    }
}
