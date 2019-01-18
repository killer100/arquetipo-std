export const APP_INFO = {
    logo: "STD",
    nombreDesc: "Sistema de Trámite<br>Documentario",
    nombreFooter: "Sistema de Trámite Documentario versión 2.0"
};
export const FILE_SETTINGS = {
    extensiones: [
        "application/pdf", 
        "image/jpeg", 
        "image/gif", 
        "image/png", 
        "application/docx",
        "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
        "application/msword"],  
    maxFileSize: 5 * 1024 * 1024  
}
export const MENU_OPTIONS = [
    { label: "INICIO", to: "/" },
    { label: "MESA DE PARTES", to: "/mesa-partes" },
    { label: "GESTIÓN INTERNA", to: "/gestion-interna" }

    /*{
        label: "MÓDULO 1",
        only: ["coordinador", "director", "admin"],
        children: [
            { label: "Opción 1", to: "/modulo1/opcion-1", only: ["coordinador", "director"] },
            { label: "Opción 2", to: "/modulo1/opcion-2", only: ["admin", "coordinador"] },
            { divider: true },
            { label: "Opción 3", to: "/opcion-3", only: ["director"] },
            { label: "Opción 4", to: "/opcion-4", only: ["coordinador", "director"] }
        ]
    }*/
];

export const RUTAS = {
    PDF_CORRESPONDENCIAS: "",
    PDF_RESOLUCIONES: "",
    PDF_ADJUNTOS: ""
};
