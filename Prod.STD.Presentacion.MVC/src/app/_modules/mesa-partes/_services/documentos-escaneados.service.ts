import { Injectable } from "@angular/core";
import axios from "axios";

@Injectable()
export class DocumentosEscaneadosService {
    url: string = "/api/mesa-partes/documentos-escaneados";

    public FetchDocumentos(page, pageSize, filters) {
        const data = { page, pageSize, ...filters };
        return axios
            .post(`${this.url}/documentos`, data)
            .then(resp => resp.data)
            .catch(err => {
                throw err.data || err;
            });
    }

    public GenerarReporte(documentos) {
        const data = {
            documentos
        };
        return axios
            .post(`${this.url}/generar-reporte`, data)
            .then(resp => resp.data)
            .catch(err => {
                throw err.data || err;
            });
    }

    public RevertirDocumentoReporte(id_documento, id_anexo) {
        const data = {
            id_documento,
            id_anexo
        };
        return axios
            .post(`${this.url}/revertir-documento-reporte`, data)
            .then(resp => resp.data)
            .catch(err => {
                throw err.data || err;
            });
    }

    public FetchReportes(page, pageSize) {
        const data = { page, pageSize };
        return axios
            .post(`${this.url}/page-reportes`, data)
            .then(resp => resp.data)
            .catch(err => {
                throw err.data || err;
            });
    }
}
