import { Injectable } from '@angular/core';
import axios from 'axios';
import { BehaviorSubject } from 'rxjs';
import { IDocumento } from '../_interfaces';

@Injectable()
export class DocumentoService {
  
  url: string = "/api/gestion-interna/documento"
  vEstadoDocumento = new BehaviorSubject("A"); 
  currentVEstado = this.vEstadoDocumento.asObservable();

  actualizarValorEstado(nValue: string){
    this.vEstadoDocumento.next(nValue);
  }
  public FetchGetDocumentos(page, pageSize, filters){
    const data = { page, pageSize, ...filters};
    return axios
      .post(`${this.url}/getDocumentos`, data)
      .then(resp => resp.data)
      .catch(err => {
        throw err.data || err;
      });
  }
  public getDocFromHojaTramite(filters){
    const data = { ...filters};
    return axios
      .post(`${this.url}/getDocFromHojaTramite`, data)
      .then(resp => resp.data)
      .catch(err => {
        throw err.data || err;
      });
  }
  public SaveDocumentoInterno(documento: IDocumento) {
      return axios
          .post(`${this.url}/documento-interno`, documento)
          .then(resp => resp.data)
          .catch(err => {
              console.log(err);
              throw err.data || err;
          });
  }
}
