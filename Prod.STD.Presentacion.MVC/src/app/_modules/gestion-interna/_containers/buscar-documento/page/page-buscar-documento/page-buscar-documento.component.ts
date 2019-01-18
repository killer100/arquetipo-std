import { Component, OnInit, Input, SimpleChanges, SimpleChange } from '@angular/core';
import { DefaultPagination, IPagination, modalDefaultConfig } from 'src/_shared';
import { DocumentoService } from 'src/app/_modules/gestion-interna/_services';
import { CreateTableDefDocsInternos, BuildFilters } from './buscar-documento.helpers';
import { BsModalService } from 'ngx-bootstrap/modal';
import { AppModalRegistroDocumentoComponent } from '../../modal/app-modal-registro-documento/app-modal-registro-documento.component';

@Component({
  selector: 'app-page-buscar-documento',
  templateUrl: './page-buscar-documento.component.html'
})
export class PageBuscarDocumentoComponent implements OnInit {

  @Input() filters: any;
  tableDef: any;
  loading: boolean;
  pagination: IPagination;
  datatableError: boolean;  
  estadoBusquedaDocumentoInterno: any[] = [
    { "label": "Por Aceptar", "value": "1", },
    { "label": "Aceptados", "value": "2", },
    { "label": "Urgentes", "value": "3", },    
    { "label": "Delegados", "value": "4", },
    { "label": "Finalizados", "value": "5", },
    { "label": "Archivados", "value": "6", }
  ];

  selectEstadoBusquedaDoc: number;

  constructor(
    private _registrarDocumentoService: DocumentoService,
    private _modalService: BsModalService
  ) {
    this.loading = false;
    this.filters = { };

    this.tableDef = CreateTableDefDocsInternos();
    this.pagination = { ...DefaultPagination }
  }

  ngOnInit() {
    const { page, pageSize } = this.pagination;
    this.getDocumentos(page, pageSize, this.filters); 
    this.selectEstadoBusquedaDoc = 1;   
  }

  changeEstadoBusqueda(value){
    this.selectEstadoBusquedaDoc = value;
  }
  handleSubmitForm = (filters) =>  {   
    this.filters = filters;
    const { pageSize } = this.pagination;
    this.getDocumentos(1, pageSize, filters);
  };
  handleChangePage = page => {
    const { pageSize } = this.pagination;
    this.getDocumentos(page, pageSize, this.filters);
  };
  handleChangePageSize = pageSize => {
    this.getDocumentos(1, pageSize, this.filters);
  };
  getDocumentos = async (page, pageSize, filters = {}) => {
    this.loading = true;
    try {
      const Response = await this._registrarDocumentoService.FetchGetDocumentos(
        page,
        pageSize,
        BuildFilters(filters)
      );

      Response.data.Data = (Response.data.Data).map(element => {
         element.cod_estado_docinterno = this.selectEstadoBusquedaDoc;
         return element;
      });

      this.loading = false;
      const pagination = Response.data;
      this.pagination.Data = pagination.Data;
      this.pagination.TotalRows = pagination.TotalRows;
      this.pagination.page = page;
      this.pagination.pageSize = pageSize;
    } catch (err) {
      this.pagination = { ...DefaultPagination };
      this.datatableError = true;
      this.loading = false;
    }
  };

  refreshData = () => {
    const { pageSize, page } = this.pagination;
    this.getDocumentos(page, pageSize, this.filters);
  };
  openModalRegistrarDocumento = () => {
    const config = {
      ...modalDefaultConfig,
      class: `modal-custom modal-lg`,
      initialState: { onSave: this.refreshData }
    };
    this._modalService.show(AppModalRegistroDocumentoComponent, config);
  };
  
}


