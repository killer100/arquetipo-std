import {
    Component,
    OnInit,
    OnChanges,
    Input,
    ViewChild,
    ViewContainerRef,
    ComponentFactoryResolver,
    ComponentFactory
} from "@angular/core";

@Component({
    selector: "app-list-table-custom-column",
    template: `
        <template #itemContainer></template>
    `
})
export class ListTableCustomColumnComponent implements OnInit, OnChanges {
    @Input()
    definition: any;
    componentRef: any;

    @ViewChild("itemContainer", { read: ViewContainerRef })
    entry: ViewContainerRef;
    constructor(private resolver: ComponentFactoryResolver) {}

    createComponent(): void {
        this.entry.clear();

        const { component, ...props } = this.definition;

        const factory: ComponentFactory<any> = this.resolver.resolveComponentFactory(component);
        const componentRef: any = this.entry.createComponent(factory);

        Object.keys(props).forEach(i => {
            componentRef.instance[i] = props[i];
        });
    }

    ngOnInit() {
        this.createComponent();
    }

    ngOnChanges(): void {
        this.createComponent();
    }
    destroyComponent(): void {
        this.componentRef.destroy();
    }
}
