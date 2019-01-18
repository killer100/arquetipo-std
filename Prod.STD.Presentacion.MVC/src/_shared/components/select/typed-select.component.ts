import {
    Component,
    OnInit,
    Input,
    Output,
    EventEmitter,
    OnChanges,
    SimpleChanges,
    ContentChild,
    TemplateRef
} from "@angular/core";
import {NgSelectModule, NgOption} from '@ng-select/ng-select';
import axios from "axios";

@Component({
    selector: "app-typed-select",
    template: `
        <ng-select 
            [placeholder]="defaultOptionText"
            notFoundText="No se encontraron resultados"
            class="ng-select-bootstrap"
            [items]="items"
            [bindValue]="bindValue"
            [bindLabel]="bindLabel"
            [(ngModel)]="_model"
            (change)="handleChange($event)"
            [loading]="loading"
            [disabled]="disabled || loading"
            [multiple]="multiple"
            [closeOnSelect]="closeOnSelect"
            [addTag]="addTag" 
            [isOpen]="isOpen">              
            <ng-template ng-option-tmp let-item="item" *ngIf="optionTemplate">
                <ng-container *ngTemplateOutlet="optionTemplate; context:{item: item}"></ng-container>
            </ng-template>
        </ng-select> 
        
    `,
    styles: []
})
export class TypedSelectComponent implements OnInit, OnChanges {
    @Input() items?: Array<any> = [];
    @Input() bindValue?: string = "value";
    @Input() bindLabel?: string = "label";
    @Input() asObject?: Boolean = false;
    @Input() url?: string;
    @Input() responseField?: string;
    @Input() Model?: any;
    @Output() ModelChange = new EventEmitter();
    @Input() disabled: Boolean = false;
    @Input() multiple: Boolean = false;
    @Input() closeOnSelect: boolean = true;
    @Input() isOpen?: boolean = null;
    @Input() addTag?: any;
    @Input() onSelect?: Function;
    @Input() defaultOptionText: string = "--Seleccionar--";

    _model: any = null;

    loading: Boolean = false;

    @ContentChild('optionTemplate', { read: TemplateRef }) optionTemplate: TemplateRef<any>;
    
    constructor() {}

    ngOnInit() {
        this.getItems();
    }

    ngOnChanges(changes: SimpleChanges): void {
        
        if (changes.Model) {
            if (!this.multiple) {
                if (this.asObject) {
                    this._model = changes.Model.currentValue
                        ? changes.Model.currentValue[this.bindValue]
                        : null;
                } else {
                    this._model = changes.Model.currentValue ? changes.Model.currentValue : null;
                }
            } else {
                if (this.asObject) {
                    this._model =
                        changes.Model.currentValue == null
                            ? null
                            : changes.Model.currentValue.map(x => x[this.bindValue]);
                } else {
                    this._model = changes.Model.currentValue;
                }
            }
        }
    }

    handleChange = $e => {
        if (this.asObject) {
            if (!this.multiple) {
                this.Model = this.items.find(x => x[this.bindValue] == this._model);
            } else {
                this.Model = this.items.filter(x => this._model.includes(x[this.bindValue]));
            }
        } else {
            this.Model = this._model;
        }
        this.ModelChange.emit(this.Model);
        if (typeof this.onSelect === "function") this.onSelect();
    };
    getItems = async () => {
        if (this.url) {
            try {
                this.loading = true;
                const resp = await axios.get(this.url);
                this.loading = false;
                if (this.responseField) this.items = resp.data[this.responseField];
                else this.items = resp.data;
            } catch (error) {}
        }
    };
}
