export interface PageDataTable {
    handleRefresh();

    handleSearch(filters);

    handleChangePageSize(pageSize);

    handleChangePage(page);

    getData(page, pageSize, filters);
}
