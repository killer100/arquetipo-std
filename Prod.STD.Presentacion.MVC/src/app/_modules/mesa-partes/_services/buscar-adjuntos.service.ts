import { Injectable } from "@angular/core";
import axios from "axios";
import { IAdjunto } from "../_interfaces/adjunto.interface";

@Injectable()
export class BuscarAdjuntosService {
    url: string = "/api/mesa-partes/buscar-adjuntos";

    public FetchAdjuntos(page, pageSize, filters) {
        const data = { page, pageSize, ...filters };
        return axios
            .post(`${this.url}/anexos/search`, data)
            .then(resp => resp.data)
            .catch(err => {
                throw err.data || err;
            });
    }

    public SaveAdjunto(adjunto: IAdjunto) {
        return axios
            .post(`${this.url}/anexos`, adjunto)
            .then(resp => resp.data)
            .catch(err => {
                throw err.data || err;
            });
    }

    public UpdateAdjunto(id_adjunto: number, adjunto: IAdjunto) {
        return axios
            .put(`${this.url}/anexos/${id_adjunto}`, adjunto)
            .then(resp => resp.data)
            .catch(err => {
                throw err.data || err;
            });
    }

    public GetNuevoNumero(id_documento) {
        return axios
            .get(`${this.url}/anexos/nuevo-numero`, { params: { id_documento: id_documento } })
            .then(resp => resp.data)
            .catch(err => {
                throw err.data || err;
            });
    }

    public GetAdjunto(id_anexo) {
        return axios
            .get(`${this.url}/anexos/${id_anexo}`)
            .then(resp => resp.data)
            .catch(err => {
                throw err.data || err;
            });
    }

    public AnularAdjunto(id_anexo, motivo) {
        const data = { id_anexo, motivo_anulacion: motivo };
        return axios
            .post(`${this.url}/anexos/anular`, data)
            .then(resp => resp.data)
            .catch(err => {
                throw err.data || err;
            });
    }

    public GetOficinaPendiente(id_documento) {
        const params = { id_documento };
        return axios
            .get(`${this.url}/documento/ultima-dependencia-pendiente`, { params })
            .then(resp => resp.data)
            .catch(err => {
                throw err.data || err;
            });
    }
}
