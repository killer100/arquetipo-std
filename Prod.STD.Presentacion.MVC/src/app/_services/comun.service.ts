import { Injectable } from "@angular/core";
import axios from "axios";
import * as moment from "moment";

@Injectable({
    providedIn: "root"
})
export class ComunService {
    url: string = "/api/comun";

    FetchTiposResolucion = () => {
        return axios
            .get(`${this.url}/tipo-resolucion`)
            .then(resp => resp.data.data)
            .catch(err => []);
    };

    FetchClasesDocumento = filters => {
        const options = { params: { ...filters } };
        return axios
            .get(`${this.url}/clase-documento`, options)
            .then(resp => resp.data.data)
            .catch(err => []);
    };
    FetchTiposTratamiento = () => {
        return axios
            .get(`${this.url}/tipos-tratamiento`)
            .then(resp => resp.data.data)
            .catch(err => []);
    };

    FetchAniosDocumentos = (): Promise<Array<any>> => {
        return new Promise(resolve => {
            let anios = [{ value: 1000, label: "Todos" }];
            const current_year = moment().year();
            for (let i = current_year; i >= 2010; i--) {
                anios.push({ value: i, label: `${i}` });
            }
            resolve(anios);
        });
    };
    FetchTiposHojaTramite = (): Promise<Array<any>> => {
        return new Promise(resolve =>
            resolve([
                { value: "E", label: "Externo" }, 
                { value: "I", label: "Interno" }
            ])
        );
    };
    FetchItemsPreguntaCerrada = (): Promise<Array<any>> => {
        return new Promise(resolve =>
            resolve([
                { value: true, label: "SI" }, 
                { value: false, label: "NO" }
            ])
        );
    };
    FetchDependencias = (filters = null) => {
        const options = { params: { ...filters } };
        return axios
            .get(`${this.url}/dependencia`, options)
            .then(resp => resp.data.data)
            .catch(err => []);
    };

    FetchTupas = (filters = null) => {
        const options = { params: { ...filters } };
        return axios
            .get(`${this.url}/tupa`, options)
            .then(resp => resp.data.data)
            .catch(err => []);
    };

    FetchClasesTupa = () => {
        return axios
            .get(`${this.url}/clase-tupa`)
            .then(resp => resp.data.data)
            .catch(err => []);
    };

    FetchPersonas = filters => {
        const options = { params: { ...filters } };
        return axios
            .get(`${this.url}/persona`, options)
            .then(resp => resp.data.data)
            .catch(err => []);
    };

    FetchRequisitosTupa = id_tupa => {
        const options = { params: { id_tupa: id_tupa } };
        return axios
            .get(`${this.url}/requisito-tupa`, options)
            .then(resp => resp.data.data)
            .catch(err => []);
    };

    FetchTiposAnexo = () => {
        return axios
            .get(`${this.url}/tipo-anexo`)
            .then(resp => resp.data.data)
            .catch(err => []);
    };

    FetchTrabajadores = (codigos_dependencia: Array<number>) => {
        const options = { params: { codigos_dependencia: codigos_dependencia.join(",") } };
        return axios
            .get(`${this.url}/trabajador`, options)
            .then(resp => resp.data.data)
            .catch(err => []);
    };

    GetDirector = (codigo_dependencia: number) => {
        const options = { params: { codigo_dependencia: codigo_dependencia } };
        return axios
            .get(`${this.url}/trabajador-director`, options)
            .then(resp => resp.data.data)
            .catch(err => null);
    };
}
