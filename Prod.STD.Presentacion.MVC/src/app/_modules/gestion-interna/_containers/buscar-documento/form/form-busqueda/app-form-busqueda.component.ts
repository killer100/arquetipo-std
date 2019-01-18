import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ComunService } from 'src/app/_services/comun.service';
import { IDocumento, IDocumentoFilter } from 'src/app/_modules/gestion-interna/_interfaces/documento.interface';
import { DocumentoService } from 'src/app/_modules/gestion-interna/_services';


const INITIAL_FORM: IDocumentoFilter = {
  num_tram_documentario: null,
  fecha_inicio: null,
  fecha_fin: null,
  estado: 1,
  id_tipo_resolucion: null,
  numero_resolucion: null,
  anio_resolucion: null,
  oficina_resolucion: null,
  id_clase_documento: null,
  numero_documento: null,
  anio_documento: null,
  oficina_documento: null,
  razon_social: null,
  coddep_oficina_derivada: null,
  id_tupa: null,
  asunto: null,
  tipo_hoja_tramite: null,
  indicativo_oficio: null,
  estado_documento_interno: null
};

@Component({
  selector: 'app-form-busqueda',
  templateUrl: './app-form-busqueda.component.html'
})
export class AppFormBusquedaComponent implements OnInit {

  @Output() 
  selectEstadoBusqueda = new EventEmitter<string>();
  
  @Input()
  onSubmit: Function;
  @Input()
  disabled: Boolean = false;
  @Input()
  enum_tipos_resolucion: Array<any> = [];
  @Input()
  enum_clases_documento?: Array<any>;
  @Input()
  enum_anios: Array<any>;
  @Input()
  enum_siglas_oficina: Array<any>;
  @Input()
  enum_hoja_tramite: Array<any>;
  @Input()
  estadoBusquedaDocumento: any[];

  form: IDocumentoFilter;
  selectedItem: any;

  constructor(private _comunService: ComunService, private _documentoService: DocumentoService) {
    this.form = { ...INITIAL_FORM };
  }
  ngOnInit(): void {
    this.form.estado_documento_interno = 1;
    this.selectedItem = this.estadoBusquedaDocumento ? this.estadoBusquedaDocumento[0] : null;
    this.loadEnumerables();
  }
  changeStateDocument = (estadoBusquedaDocumento) => {
    this.selectedItem = estadoBusquedaDocumento;
    this.selectEstadoBusqueda.emit(estadoBusquedaDocumento.value);
    this.form.estado_documento_interno = estadoBusquedaDocumento.value;    
    this.handleSubmit();
  }
  handleSubmit = () => {
    if (this.form.numero_documento != null ||
        this.form.anio_documento != null ||
        this.form.oficina_documento != null)

        this.form.indicativo_oficio = this.form.numero_documento + "-" +
        this.form.anio_documento + "-PRODUCE/" +
        this.form.oficina_documento;
    else
      this.form.indicativo_oficio = null;
      this.onSubmit(this.form);
  };
  handleClear = () => {
    this.form = { ...INITIAL_FORM };
    this.onSubmit(this.form);
  };
  
  loadEnumerables = () => {
    this._comunService.FetchTiposResolucion().then(data => {
      this.enum_tipos_resolucion = data.map(x => ({
        label: x.descripcion,
        value: x.id
      }));
    });
    this._comunService.FetchClasesDocumento({ procedencia: "i", categoria: "d" }).then(data => {
      this.enum_clases_documento = data.map(x => ({
        value: x.id_clase_documento_interno,
        label: x.descripcion
      }));
    });
    this._comunService.FetchAniosDocumentos().then(data => {
      this.enum_anios = data;
    });
    this._comunService.FetchTiposHojaTramite().then(data => {
      this.enum_hoja_tramite = data;
    });
    this._comunService.FetchDependencias({ dependencias_internas: true }).then(data => {
      this.enum_siglas_oficina = data.map(x => ({ label: x.siglas, value: x.siglas }));
    });
  };
}
