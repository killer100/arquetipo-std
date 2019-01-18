import { Component, OnInit, NgModule } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal/bs-modal-ref.service';
import { ComunService } from 'src/app/_services/comun.service';
import { IDocumento, DEFAULT_DOCUMENTO, DEFAULT_DOCUMENTO_ERRORS } from 'src/app/_modules/gestion-interna/_interfaces';
import { FileUploader, FileLikeObject, FileItem } from 'ng2-file-upload/ng2-file-upload';
import { DocumentoService } from 'src/app/_modules/gestion-interna/_services';
import { FILE_SETTINGS } from 'src/config/app-settings';
import { ItemsList } from '@ng-select/ng-select/ng-select/items-list';
import { modalDefaultConfig } from 'src/_shared';
import { async } from 'q';
import { AppModalConfirmarRegistroComponent } from '../app-modal-confirmar-registro/app-modal-confirmar-registro.component';
import { BsModalService } from 'ngx-bootstrap/modal';
import { AlertService } from 'src/_shared/services';
import { Alert } from 'selenium-webdriver';

const URL = 'api/comun/subir-archivo-temp';

@Component({
  selector: 'app-app-modal-registro-documento',
  templateUrl: './app-modal-registro-documento.component.html',
})

export class AppModalRegistroDocumentoComponent implements OnInit {
  loading: Boolean = false;
  errors: any;
  enum_dependencias: Array<any>;
  enum_clasesDocumento: Array<any>;
  enum_tiposTratamiento: Array<any>;
  enum_itemsPregunta: Array<any>;
  enum_itemsHojaTramite: Array<any>;
  documento: IDocumento;
  uploader: FileUploader;
  errorMessage: string;
  allowedMimeType = FILE_SETTINGS.extensiones;
  maxFileSize = FILE_SETTINGS.maxFileSize;
  seccion: any = { todos: false, dvmype: false, dvpa: false, sg: false };

  constructor(
    public bsModalRef: BsModalRef,
    private _modalService: BsModalService,
    private _comunService: ComunService,
    private _alertService: AlertService,
    private _registrarDocumentoService: DocumentoService,
  ) {
    this.enum_dependencias = [];
    this.enum_clasesDocumento = [];
    this.enum_tiposTratamiento = [];
    this.enum_itemsPregunta = [];
    this.enum_itemsHojaTramite = []
    this.documento = { ...DEFAULT_DOCUMENTO };
    this.errors = { ...DEFAULT_DOCUMENTO_ERRORS };

    this.uploader = new FileUploader({
      url: URL,
      maxFileSize: this.maxFileSize,
      allowedMimeType: this.allowedMimeType,
      autoUpload: true,
    });
    this.uploader.onWhenAddingFileFailed = (item, filter, options) => this.onWhenAddingFileFailed(item, filter, options);
    this.uploader.onSuccessItem = (item, response) => this.onSuccessItem(item, response);
    //this.uploader.removeFromQueue = (item) => this.removeFromQueue(item);
  }

  ngOnInit() {
    this.loadEnumerables();
    this.documento.coddeps_destino = [];
  }
  loadEnumerables = () => {
    this._comunService.FetchClasesDocumento({ categoria: "D", procedencia: "I" }).then(data => {
      this.enum_clasesDocumento = data;
    });
    this._comunService.FetchDependencias().then(data => {
      this.enum_dependencias = data.map(x => ({
        ...x,
        coddep: x.codigo_dependencia,
        dependenciaFormat: `${x.dependencia} (${x.siglas})`
      }));
    });
    this._comunService.FetchTiposTratamiento().then(data => {
      this.enum_tiposTratamiento = data;
    });
    this._comunService.FetchTiposHojaTramite().then(data => {
      this.enum_itemsHojaTramite = data;
    });
    this._comunService.FetchItemsPreguntaCerrada().then(data => {
      this.enum_itemsPregunta = data;
    });
  };

  addCustomHojaTramite = (element) => {
    
    this._registrarDocumentoService.getDocFromHojaTramite({
      tipo_hoja_tramite: this.documento.tipo_hoja_tramite,
      num_tram_documentario: element
    }).then(data => {
        if (data.data.id_documento > 0)        
          this.documento.referencias = [...this.documento.referencias,
          {
            id_hoja_tramite: data.data.id_documento,
            numero_hoja_tramite: element,
            tipo_hoja_tramite: data.data.tipo_hoja_tramite
          }];                      
      }); 
      //element = null;   
  };

  onChangeSeccion = () => {
    this.documento.coddeps_destino = this.enum_dependencias.filter(item =>
      (item.id_tipo_dependencia === 2 || item.id_tipo_dependencia === 5) && 
      ((this.seccion.todos && ["P", "S", "I"].some(e => item.seccion)) ||
        (this.seccion.dvmype && item.seccion === "I") ||
        (this.seccion.dvpa && item.seccion === "P") ||
        (this.seccion.sg && item.seccion === "S")));
  }
  handleSubmit = () => {
    this._alertService.confirm(
      "warning",
      "Registrar documento interno. ¿Desea Continuar?",
      null,
      () => {
        this.saveDocumento();
      });
  };
  saveDocumento = async () => {
    this.loading = true;
    try {
      let promise = null;

      promise = this._registrarDocumentoService.SaveDocumentoInterno(this.documento);

      const resp = await promise;
      this._alertService.open("success", resp.msg, "Registrado", () => {
        this.bsModalRef.hide();
      });

    } catch (err) {
      const msg = err.msg;
      if (err.statuscode == 406) {
        this.errors = err.errors;
      }
      this._alertService.open("error", msg);
    }
    this.loading = false;
  }
  onWhenAddingFileFailed(item: FileLikeObject, filter: any, options: any) {
    switch (filter.name) {
      case 'fileSize':
        this.errors.adjuntos = `El archivo excede el tamaño maximo permitido de: ${((this.maxFileSize/1024)/1024)} MB.`;
        break;
      case 'mimeType':
        const allowedTypes = this.allowedMimeType.join();
        this.errors.adjuntos = `El archivo tiene un formato no permitido.`;
        break;
      default:
        this.errors.archivo = `Error al subir archivo`;
    }
  }
  onSuccessItem(item: FileItem, response: any) {
    
    var res = JSON.parse(response).data;
    this.documento.adjuntos = [...this.documento.adjuntos,
    {
      nombre_adjunto: res.fileName,
      mimetype: res.mimetype,
      size: res.size,
      codigo: res.id
    }];
    item.index =  res.id;
  }
  onRemoveFromQueue(item: FileItem) {
    item.remove();
    this.documento.adjuntos =  this.documento.adjuntos.filter(file => file.codigo !== item.index);
  }
}
