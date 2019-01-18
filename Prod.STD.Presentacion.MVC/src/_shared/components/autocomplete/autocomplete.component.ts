import { Component, OnInit, Input, EventEmitter, Output } from "@angular/core";
import { Observable } from "rxjs";

@Component({
    selector: "app-autocomplete",
    templateUrl: "./autocomplete.component.html",
    styleUrls: ["./autocomplete.component.css"]
})
export class AutocompleteComponent implements OnInit {
    @Input()
    delay?: number = 400;
    @Input()
    Model?: string;
    @Output()
    ModelChange = new EventEmitter();
    @Input()
    bindLabel: string;
    @Input()
    getData: Function;
    @Input()
    onSelect: Function;
    @Input()
    disabled?: Boolean = false;

    loading: Boolean = false;
    _source: Observable<any>;

    constructor() {
        this.setObservable();
    }

    ngOnInit() {}

    setObservable = () => {
        this._source = Observable.create((observer: any) => {
            if (typeof this.getData === "function") {
                this.getData(this.Model).then(items => {
                    observer.next(items);
                });
            }
        });
    };

    handleChange = () => {
        this.ModelChange.emit(this.Model);
    };

    handleSelect = $e => {
        if (typeof this.onSelect === "function") this.onSelect($e.item);
    };

    handleChangeTypeaheadLoading = $e => {
        this.loading = $e;
    };
}
