import { Injectable } from "@angular/core";
import axios from "axios";
import { IDocumento } from "../_interfaces";
import { IAdjunto } from "../_interfaces/adjunto.interface";

@Injectable()
export class RegistrarDocumentoService {
    url: string = "/api/mesa-partes/registrar-documento";

    public FetchDocumentos(page, pageSize, filters) {
        const data = { page, pageSize, ...filters };
        return axios
            .post(`${this.url}/documentos`, data)
            .then(resp => resp.data)
            .catch(err => {
                throw err.data || err;
            });
    }

    public GetDocumentoExterno(id_documento) {
        return axios
            .get(`${this.url}/documento-externo/${id_documento}`)
            .then(resp => resp.data)
            .catch(err => {
                throw err.data || err;
            });
    }

    public GetDocumentoTupa(id_documento) {
        return axios
            .get(`${this.url}/documento-tupa/${id_documento}`)
            .then(resp => resp.data)
            .catch(err => {
                throw err.data || err;
            });
    }

    public SaveDocumentoExterno(documento: IDocumento) {
        return axios
            .post(`${this.url}/documento-externo`, documento)
            .then(resp => resp.data)
            .catch(err => {
                console.log(err);
                throw err.data || err;
            });
    }

    public SaveDocumentoTupa(documento: IDocumento) {
        return axios
            .post(`${this.url}/documento-tupa`, documento)
            .then(resp => resp.data)
            .catch(err => {
                throw err.data || err;
            });
    }

    public UpdateDocumentoExterno(id_documento: number, documento: IDocumento) {
        return axios
            .put(`${this.url}/documento-externo/${id_documento}`, documento)
            .then(resp => resp.data)
            .catch(err => {
                throw err.data || err;
            });
    }

    public UpdateDocumentoTupa(id_documento: number, documento: IDocumento) {
        return axios
            .put(`${this.url}/documento-tupa/${id_documento}`, documento)
            .then(resp => resp.data)
            .catch(err => {
                throw err.data || err;
            });
    }

    public GetAnexosPorDocumento(id_documento) {
        return axios
            .get(`${this.url}/documento/${id_documento}/anexo`)
            .then(resp => resp.data)
            .catch(err => {
                throw err.data || err;
            });
    }

    public GetRequisitosPorDocumento(id_documento) {
        return axios
            .get(`${this.url}/documento/${id_documento}/requisitos`)
            .then(resp => resp.data)
            .catch(err => {
                throw err.data || err;
            });
    }

    public AnularRegistro(id_documento, motivo) {
        const data = {
            id_documento,
            observaciones: motivo
        };
        return axios
            .post(`${this.url}/documento/actions/anular`, data)
            .then(resp => resp.data)
            .catch(err => {
                throw err.data || err;
            });
    }

    public AgregarCopias(id_documento, copias: Array<any>) {
        const data = {
            id_documento,
            copias: copias
        };
        return axios
            .post(`${this.url}/documento/actions/agregar-copias`, data)
            .then(resp => resp.data)
            .catch(err => {
                throw err.data || err;
            });
    }

    public LevantarObservaciones(id_documento) {
        const data = {
            id_documento
        };
        return axios
            .post(`${this.url}/documento/actions/levantar-observaciones`, data)
            .then(resp => resp.data)
            .catch(err => {
                throw err.data || err;
            });
    }

    public ReactivarRegistro(id_documento, form) {
        const data = {
            id_documento,
            ...form
        };
        return axios
            .post(`${this.url}/documento/actions/reactivar-registro`, data)
            .then(resp => resp.data)
            .catch(err => {
                throw err.data || err;
            });
    }

    public GetOficinasFinalizadas(id_documento) {
        return axios
            .get(`${this.url}/documento/${id_documento}/query/oficinas-finalizadas`)
            .then(resp => resp.data)
            .catch(err => {
                throw err.data || err;
            });
    }

    public GetCopiasPorDocumento(id_documento) {
        return axios
            .get(`${this.url}/documento/${id_documento}/copias`)
            .then(resp => resp.data)
            .catch(err => {
                throw err.data || err;
            });
    }
}
