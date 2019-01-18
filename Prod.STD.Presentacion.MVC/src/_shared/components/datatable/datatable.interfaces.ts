export interface IPagination {
    page: number;
    pageSize: number;
    TotalRows: number;
    Data: Array<any>;
}

export interface IColumnDefinition {
    label: String;
    property?: String;
    isDate?: Boolean;
    render?: Function;
    show?: Boolean;
    isIndex?: Boolean;
    tdClass?: Function;
    thClass?: Function;
    tdStyle?: any;
    thStyle?: any;
    format?: Function;
    limit?: number;
    isDatetime?: Boolean;
}

export interface ITableDefinition {
    columns: Array<IColumnDefinition>;
}

export const DefaultPagination: IPagination = {
    Data: [],
    TotalRows: 0,
    pageSize: 10,
    page: 1
};
