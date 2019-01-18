/*===================================================================================
 Template T4 for enumerado.js
 05/11/2018 03:06:52
====================================================================================*/
define([], function () {
    "use strict";

    return {    
    "TIPOS" : [{"Value":10,"Text":"Tipo de Documento"},{"Value":11,"Text":"Tipo de Especialidad"},{"Value":12,"Text":"Estado de Documento"},{"Value":13,"Text":"Estado de Expediente PAS"},{"Value":14,"Text":"Origen de Documento"},{"Value":15,"Text":"Tipo de Documento de Identidad"},{"Value":16,"Text":"Estado de Expediente Coactivo"},{"Value":17,"Text":"Estado de Depósito"},{"Value":18,"Text":"Tipo de Cargo"},{"Value":19,"Text":"Estado de Deuda"},{"Value":20,"Text":"Tipo de Pronunciamiento"},{"Value":21,"Text":"Formato de RCONAS"},{"Value":22,"Text":"Sentido de Pronunciamiento"},{"Value":23,"Text":"Causales de Devolución"},{"Value":24,"Text":"Causales de Suspensión"},{"Value":25,"Text":"Tipo de Medida Cautelar"},{"Value":26,"Text":"Cobranza Persuasiva"},{"Value":27,"Text":"Pregunta Exclusiva"},{"Value":28,"Text":"Tipo de Domicilio"},{"Value":29,"Text":"Tipo de Fiscalización"},{"Value":30,"Text":"Objetivo de Fiscalización"},{"Value":31,"Text":"Estado de Sesión"},{"Value":32,"Text":"Estado de RCONAS"},{"Value":33,"Text":"Tipo de Sector"},{"Value":34,"Text":"Tipo de Procedencia"},{"Value":35,"Text":"Tipo de Infracción"},{"Value":36,"Text":"Unidad fiscalizada"},{"Value":37,"Text":"Tipo de Material"},{"Value":38,"Text":"Tipo de Sanción"},{"Value":39,"Text":"Tipo Unidad"},{"Value":40,"Text":"Tipo de actividad Planta"},{"Value":41,"Text":"Estado de procesamiento"},{"Value":42,"Text":"Estado de acumulado"},{"Value":43,"Text":"Tipo de medida"},{"Value":44,"Text":"Estado de Fiscalización"},{"Value":45,"Text":"Tipo de Materia"},{"Value":46,"Text":"Estado de actividad"},{"Value":47,"Text":"Calificación de Infraccion"},{"Value":48,"Text":"Cobranza Convencional"},{"Value":49,"Text":"Tipo de Entidad"},{"Value":50,"Text":"Estado de PreInicio"},{"Value":51,"Text":"Motivo de Devolución"},{"Value":52,"Text":"Estado de Demanda"},{"Value":53,"Text":"Resultado de Proceso Judicial"}],	
    "ENUMERADOS" : [{"Value":10001,"Text":"Informes","Type":10},{"Value":10002,"Text":"Oficios","Type":10},{"Value":10003,"Text":"Resoluciones Directorales","Type":10},{"Value":10004,"Text":"Solicitudes","Type":10},{"Value":10005,"Text":"Actas","Type":10},{"Value":10006,"Text":"Constancias","Type":10},{"Value":10007,"Text":"Cédulas","Type":10},{"Value":10008,"Text":"Depósito","Type":10},{"Value":10009,"Text":"Recibidos","Type":10},{"Value":10010,"Text":"Proveidos","Type":10},{"Value":10011,"Text":"Recursos","Type":10},{"Value":10012,"Text":"Sustentos","Type":10},{"Value":10013,"Text":"Tramite Interno","Type":10},{"Value":10014,"Text":"Comprobantes","Type":10},{"Value":10015,"Text":"Adjuntos de Sentencia","Type":10},{"Value":10016,"Text":"Adjuntos Demanda","Type":10},{"Value":11001,"Text":"Proveido de Solicitud","Type":11,"TypeFather":10010},{"Value":11002,"Text":"Proveido de Archivo","Type":11,"TypeFather":10010},{"Value":11003,"Text":"Proveido de Ampliación","Type":11,"TypeFather":10010},{"Value":11005,"Text":"Vistas de Causa (Pronunciamiento)","Type":11,"TypeFather":10012},{"Value":11006,"Text":"Cita de Sesión","Type":11,"TypeFather":10012},{"Value":11007,"Text":"Vistas de Causa","Type":11,"TypeFather":10012},{"Value":11008,"Text":"Otros Anexos","Type":11,"TypeFather":10012},{"Value":11009,"Text":"Documento de Sustento","Type":11,"TypeFather":10012},{"Value":11035,"Text":"Devolución de Tesoreria","Type":11,"TypeFather":10013},{"Value":11036,"Text":"Levantamiento de Suspensión de Consumo ","Type":11,"TypeFather":10013},{"Value":11037,"Text":"Suspensión de Consumo ","Type":11,"TypeFather":10013},{"Value":11038,"Text":"Fin\/Sentencia de Proceso Judicial","Type":11,"TypeFather":10013},{"Value":11039,"Text":"Inicio\/Demanda de Proceso Judicial","Type":11,"TypeFather":10013},{"Value":11040,"Text":"Archivo demanda","Type":11,"TypeFather":10016},{"Value":11041,"Text":"Resolución de instancia","Type":11,"TypeFather":10013},{"Value":11098,"Text":"Recurso de Reconsideración ","Type":11,"TypeFather":10011},{"Value":11099,"Text":"Recurso de Apelación","Type":11,"TypeFather":10011},{"Value":11101,"Text":"Informe Técnico","Type":11,"TypeFather":10001},{"Value":11102,"Text":"Informe No Mérito","Type":11,"TypeFather":10001},{"Value":11103,"Text":"Informe Final de Instrucción","Type":11,"TypeFather":10001},{"Value":11104,"Text":"Informe Preliminar","Type":11,"TypeFather":10001},{"Value":11105,"Text":"Informe de Fiscalización","Type":11,"TypeFather":10001},{"Value":11106,"Text":"Informe de No ha Lugar","Type":11,"TypeFather":10001},{"Value":11107,"Text":"Informe Legal","Type":11,"TypeFather":10001},{"Value":11108,"Text":"Informe de No Inicio","Type":11,"TypeFather":10001},{"Value":11109,"Text":"Informe de Deuda Incobrable","Type":11,"TypeFather":10001},{"Value":11110,"Text":"Informe para OGA","Type":11,"TypeFather":10001},{"Value":11111,"Text":"Informe Respuesta de OGA","Type":11,"TypeFather":10001},{"Value":11112,"Text":"Informe Técnico - Industria","Type":11,"TypeFather":10001},{"Value":11113,"Text":"Informe de Cierre","Type":11,"TypeFather":10001},{"Value":11114,"Text":"Informe Técnico de Suspensión de Coactiva","Type":11,"TypeFather":10001},{"Value":11115,"Text":"Informe Técnico de Tesoreria","Type":11,"TypeFather":10001},{"Value":11116,"Text":"Informe Técnico de Suspensión de Consumo","Type":11,"TypeFather":10001},{"Value":11201,"Text":"Oficio de Saldo","Type":11,"TypeFather":10002},{"Value":11202,"Text":"Oficio de Audiencia","Type":11,"TypeFather":10002},{"Value":11203,"Text":"Oficio de Retención de Terceros","Type":11,"TypeFather":10002},{"Value":11204,"Text":"Oficio a Sunarp","Type":11,"TypeFather":10002},{"Value":11205,"Text":"Oficio de Regulación ","Type":11,"TypeFather":10002},{"Value":11206,"Text":"Oficio de No Inicio ","Type":11,"TypeFather":10002},{"Value":11207,"Text":"Oficio No Merito","Type":11,"TypeFather":10002},{"Value":11208,"Text":"Oficio No Ha Lugar","Type":11,"TypeFather":10002},{"Value":11209,"Text":"Oficio Preliminar","Type":11,"TypeFather":10002},{"Value":11210,"Text":"Oficio de Respuesta","Type":11,"TypeFather":10002},{"Value":11211,"Text":"Oficio de Suspensión de Retención de Terceros","Type":11,"TypeFather":10002},{"Value":11212,"Text":"Oficio de Suspensión a Sunarp","Type":11,"TypeFather":10002},{"Value":11213,"Text":"Oficio de Programación UP","Type":11,"TypeFather":10002},{"Value":11214,"Text":"Oficio de Programación UP-AMP","Type":11,"TypeFather":10002},{"Value":11215,"Text":"Oficio de Denegación UP","Type":11,"TypeFather":10002},{"Value":11216,"Text":"Oficio de Programación LE","Type":11,"TypeFather":10002},{"Value":11217,"Text":"Oficio de Denegación LE","Type":11,"TypeFather":10002},{"Value":11218,"Text":"Oficio de Estese a lo resuelto","Type":11,"TypeFather":10002},{"Value":11219,"Text":"Oficio de Retención de Tesoreria","Type":11,"TypeFather":10002},{"Value":11220,"Text":"Oficio de Levantamiento de Suspensión de Consumo","Type":11,"TypeFather":10002},{"Value":11301,"Text":"Resolución CONAS","Type":11,"TypeFather":10003},{"Value":11302,"Text":"Resolución de Sanción","Type":11,"TypeFather":10003},{"Value":11303,"Text":"Resolución de Fraccionamiento","Type":11,"TypeFather":10003},{"Value":11304,"Text":"Resolución de Beneficio","Type":11,"TypeFather":10003},{"Value":11305,"Text":"Resolución de Requerimiento de Pago","Type":11,"TypeFather":10003},{"Value":11306,"Text":"Resolución de Cobranza para Banco","Type":11,"TypeFather":10003},{"Value":11307,"Text":"Resolución de Ejecución Coactiva","Type":11,"TypeFather":10003},{"Value":11308,"Text":"Resolución de Ejecución Coactiva de Cancelación","Type":11,"TypeFather":10003},{"Value":11309,"Text":"Resolución de Archivamiento","Type":11,"TypeFather":10003},{"Value":11310,"Text":"Resolución de Suspensión","Type":11,"TypeFather":10003},{"Value":11311,"Text":"Resolución de Cobranza","Type":11,"TypeFather":10003},{"Value":11312,"Text":"Resolución de Cancelación","Type":11,"TypeFather":10003},{"Value":11313,"Text":"Resolución de Levantamiento de Suspensión","Type":11,"TypeFather":10003},{"Value":11314,"Text":"Resolución de Retroactividad Benigna","Type":11,"TypeFather":10003},{"Value":11315,"Text":"Resolución de Imputación de Cargos","Type":11,"TypeFather":10003},{"Value":11316,"Text":"Resolución de Pronto Pago","Type":11,"TypeFather":10003},{"Value":11317,"Text":"Resolución de Apelación","Type":11,"TypeFather":10003},{"Value":11318,"Text":"Resolución de Reconsideración","Type":11,"TypeFather":10003},{"Value":11319,"Text":"Resolución de Suspensión para Banco","Type":11,"TypeFather":10003},{"Value":11320,"Text":"Resolución para Administrado","Type":11,"TypeFather":10003},{"Value":11401,"Text":"Solicitud de Acogimiento","Type":11,"TypeFather":10004},{"Value":11402,"Text":"Solicitud de Fraccionamiento","Type":11,"TypeFather":10004},{"Value":11403,"Text":"Solicitud de Uso de Palabra","Type":11,"TypeFather":10004},{"Value":11405,"Text":"Solicitud de Lectura de expediente","Type":11,"TypeFather":10004},{"Value":11406,"Text":"Solicitud de Ampliación","Type":11,"TypeFather":10004},{"Value":11407,"Text":"Solicitud de Retroactividad Benigna","Type":11,"TypeFather":10004},{"Value":11409,"Text":"Solicitud de Pronto Pago","Type":11,"TypeFather":10004},{"Value":11410,"Text":"Solicitud de Suspensión","Type":11,"TypeFather":10004},{"Value":11411,"Text":"Solicitud de Acceso a la Información","Type":11,"TypeFather":10004},{"Value":11412,"Text":"Solicitud de Ampliación de Palabra","Type":11,"TypeFather":10004},{"Value":11413,"Text":"Solicitud de Ampliación de Recurso","Type":11,"TypeFather":10004},{"Value":11414,"Text":"Solicitud de Impugnación de Cédula","Type":11,"TypeFather":10004},{"Value":11415,"Text":"Solicitud de Ampliación de Alegatos","Type":11,"TypeFather":10004},{"Value":11416,"Text":"Solicitud de Desistimiento de Apelación","Type":11,"TypeFather":10004},{"Value":11417,"Text":"Solicitud de Devolución del Administrado","Type":11,"TypeFather":10004},{"Value":11418,"Text":"Solicitud de Levantamiento de Suspension de Consumo","Type":11,"TypeFather":10004},{"Value":11501,"Text":"Acta de Fiscalización","Type":11,"TypeFather":10005},{"Value":11502,"Text":"Acta de Audiencia","Type":11,"TypeFather":10005},{"Value":11503,"Text":"Acta de Asistencia","Type":11,"TypeFather":10005},{"Value":11504,"Text":"Acta de Visita","Type":11,"TypeFather":10005},{"Value":11505,"Text":"Acta de Sesión ","Type":11,"TypeFather":10005},{"Value":11506,"Text":"Acta de Inasistencia","Type":11,"TypeFather":10005},{"Value":11507,"Text":"Acta de Donación","Type":11,"TypeFather":10005},{"Value":11508,"Text":"Acta de Seguimiento","Type":11,"TypeFather":10005},{"Value":11509,"Text":"Acta de Devolución al Medio Natural","Type":11,"TypeFather":10005},{"Value":11510,"Text":"Acta de Retención de Pagos","Type":11,"TypeFather":10005},{"Value":11511,"Text":"Acta de Custodia","Type":11,"TypeFather":10005},{"Value":11512,"Text":"Acta de Disposición Final","Type":11,"TypeFather":10005},{"Value":11513,"Text":"Acta de Recurso en Abandono","Type":11,"TypeFather":10005},{"Value":11514,"Text":"Acta de Entrega Recepción de Demomiso","Type":11,"TypeFather":10005},{"Value":11515,"Text":"Acta de Verificación","Type":11,"TypeFather":10005},{"Value":11516,"Text":"Acta de Coordinación","Type":11,"TypeFather":10005},{"Value":11517,"Text":"Acta de Operativo Conjunto","Type":11,"TypeFather":10005},{"Value":11518,"Text":"Acta de Instalación, Remoción, y Sustitución de Precintos de Seguridad de Instrumentos de Pesaje","Type":11,"TypeFather":10005},{"Value":11519,"Text":"Acta de Instalación, Remoción, y Sustitución de Precintos de Seguridad del Equipo del SISESAT","Type":11,"TypeFather":10005},{"Value":11520,"Text":"Acta de Decomiso","Type":11,"TypeFather":10005},{"Value":11521,"Text":"Acta de Inmovilización","Type":11,"TypeFather":10005},{"Value":11599,"Text":"Otra Acta","Type":11,"TypeFather":10005},{"Value":11601,"Text":"Constancia de Exigibilidad","Type":11,"TypeFather":10006},{"Value":11701,"Text":"Cédula de Imputación de Cargos","Type":11,"TypeFather":10007},{"Value":11702,"Text":"Cédula de Notificación Física de Administrado","Type":11,"TypeFather":10007},{"Value":11703,"Text":"Cédula de Notificación Física de Banco","Type":11,"TypeFather":10007},{"Value":11704,"Text":"Cédula de Notificación Física de Tercero","Type":11,"TypeFather":10007},{"Value":11705,"Text":"Cédula de Notificación Física de Sunarp","Type":11,"TypeFather":10007},{"Value":11706,"Text":"Cédula de Notificación Eléctronica de Administrado","Type":11,"TypeFather":10007},{"Value":11707,"Text":"Comprobantes de Transferencias","Type":11,"TypeFather":10014},{"Value":11708,"Text":"Comprobante de Devolución","Type":11,"TypeFather":10014},{"Value":11801,"Text":"Voucher ","Type":11,"TypeFather":10008},{"Value":11802,"Text":"Transferencias","Type":11,"TypeFather":10008},{"Value":11803,"Text":"Cheques","Type":11,"TypeFather":10008},{"Value":11804,"Text":"Pago bancario","Type":11,"TypeFather":10008},{"Value":11901,"Text":"Respuestas","Type":11,"TypeFather":10009},{"Value":11902,"Text":"Descargo","Type":11,"TypeFather":10009},{"Value":11951,"Text":"1ra Instancia","Type":11,"TypeFather":10015},{"Value":11952,"Text":"2da Instancia","Type":11,"TypeFather":10015},{"Value":11953,"Text":"Nulidad de Sentencia","Type":11,"TypeFather":10015},{"Value":11954,"Text":"Casación Recurso de ragravio Constitucional","Type":11,"TypeFather":10015},{"Value":12001,"Text":"Elaborado","Type":12},{"Value":12002,"Text":"Observado","Type":12},{"Value":12003,"Text":"Aprobado ","Type":12},{"Value":12004,"Text":"Aprobado","Type":12},{"Value":12005,"Text":"Denegado","Type":12},{"Value":12006,"Text":"Pendiente de Firma","Type":12},{"Value":12007,"Text":"Firmado","Type":12},{"Value":12008,"Text":"Notificado Físicamente","Type":12},{"Value":12009,"Text":"Notificado Electronicamente","Type":12},{"Value":12010,"Text":"Adjuntado","Type":12},{"Value":12011,"Text":"Pendiente de Notificación","Type":12},{"Value":12012,"Text":"Recibido","Type":12},{"Value":12013,"Text":"Derivado","Type":12},{"Value":12014,"Text":"En elaboración ","Type":12},{"Value":12015,"Text":"En registro","Type":12},{"Value":12016,"Text":"Adjuntandose","Type":12},{"Value":12017,"Text":"No Notificado","Type":12},{"Value":12018,"Text":"Generado","Type":12},{"Value":12019,"Text":"Atendido","Type":12},{"Value":13001,"Text":"Fiscalización y Supervisión","Type":13},{"Value":13002,"Text":"Sanción","Type":13},{"Value":13003,"Text":"Apelación","Type":13},{"Value":13004,"Text":"Coactiva","Type":13},{"Value":13005,"Text":"Sanción con Resolución","Type":13},{"Value":13006,"Text":"Archivado","Type":13},{"Value":13007,"Text":"Supervisión","Type":13},{"Value":13008,"Text":"Cancelado","Type":13},{"Value":13009,"Text":"Suspendido","Type":13},{"Value":14001,"Text":"Físico","Type":14},{"Value":14002,"Text":"Plantilla","Type":14},{"Value":14003,"Text":"Digital","Type":14},{"Value":14101,"Text":"Contestación de Demanda","Type":11,"TypeFather":10016},{"Value":14102,"Text":"Contestación de Cancelación","Type":11,"TypeFather":10016},{"Value":15001,"Text":"DNI","Type":15},{"Value":15002,"Text":"RUC","Type":15},{"Value":15003,"Text":"CE","Type":15},{"Value":16001,"Text":"Registrado","Type":16},{"Value":16002,"Text":"Pendiente","Type":16},{"Value":16003,"Text":"Cancelado","Type":16},{"Value":16004,"Text":"Archivado","Type":16},{"Value":16005,"Text":"Suspendido","Type":16},{"Value":16006,"Text":"No Inicio","Type":16},{"Value":16007,"Text":"Inicio","Type":16},{"Value":16008,"Text":"Cobranza ","Type":16},{"Value":17001,"Text":"Pendiente","Type":17},{"Value":17002,"Text":"Validado","Type":17},{"Value":17003,"Text":"Amortizado","Type":17},{"Value":17004,"Text":"Rechazada","Type":17},{"Value":17005,"Text":"AutoGenerado","Type":17},{"Value":17006,"Text":"Invalidado","Type":17},{"Value":18001,"Text":"Costa","Type":18},{"Value":18002,"Text":"Gasto","Type":18},{"Value":18003,"Text":"Anulación","Type":18},{"Value":19001,"Text":"Registrada","Type":19},{"Value":19002,"Text":"Exigible","Type":19},{"Value":19003,"Text":"Cancelada","Type":19},{"Value":19004,"Text":"Suspendida","Type":19},{"Value":19005,"Text":"Archivada","Type":19},{"Value":19006,"Text":"Anulada","Type":19},{"Value":20001,"Text":"Conservar Acto Administrativo Contenido en RD","Type":20},{"Value":20002,"Text":"Fin del PAS","Type":20},{"Value":20003,"Text":"Archivo","Type":20},{"Value":20004,"Text":"Prescripción","Type":20},{"Value":20005,"Text":"Improcedente","Type":20},{"Value":20006,"Text":"Inadmisible","Type":20},{"Value":20007,"Text":"Infundado","Type":20},{"Value":20008,"Text":"Nulidad de Oficio","Type":20},{"Value":20009,"Text":"Aceptar el Desistimiento","Type":20},{"Value":20010,"Text":"Rectificar Error Material","Type":20},{"Value":20011,"Text":"Rectificar Error Material de RCONAS","Type":20},{"Value":20012,"Text":"Fundado","Type":20},{"Value":20013,"Text":"Fundado en Parte","Type":20},{"Value":20014,"Text":"Prescripción de Oficio","Type":20},{"Value":20015,"Text":"Nulidad Parcial de Oficio","Type":20},{"Value":20016,"Text":"Conservar Acto Adminsitrativo Contenido en RCONAS","Type":20},{"Value":20017,"Text":"Nulidad Parcial","Type":20},{"Value":20018,"Text":"Nulidad de RCONAS","Type":20},{"Value":20019,"Text":"Sustracción de la Materia","Type":20},{"Value":20020,"Text":"Nulidad","Type":20},{"Value":20021,"Text":"Archivo en Parte","Type":20},{"Value":20022,"Text":"Requiere Información Adicional","Type":20},{"Value":20023,"Text":"Requiere Informe Técnico","Type":20},{"Value":20024,"Text":"Concluir PAS","Type":20},{"Value":20025,"Text":"Suspendido por Falta de Quorum","Type":20},{"Value":20026,"Text":"Prorrogado","Type":20},{"Value":20027,"Text":"Aplazado","Type":20},{"Value":20028,"Text":"Informe Oral","Type":20},{"Value":20029,"Text":"Otros","Type":20},{"Value":21001,"Text":"Formato RConas 1","Type":21},{"Value":21002,"Text":"Formato RConas 2","Type":21},{"Value":21003,"Text":"Formato RConas 3","Type":21},{"Value":21004,"Text":"Formato RConas 4","Type":21},{"Value":22001,"Text":"Confirmar","Type":22},{"Value":22002,"Text":"Nulidad","Type":22},{"Value":22003,"Text":"Archivo","Type":22},{"Value":22004,"Text":"Sustracción de la Materia","Type":22},{"Value":22005,"Text":"Prescripción","Type":22},{"Value":22006,"Text":"Otros","Type":22},{"Value":22007,"Text":"Inadmisible\/Improcedente\/Desistimiento","Type":22},{"Value":22008,"Text":"Conservar o Rectificar RCONAS","Type":22},{"Value":23001,"Text":"Error en Constancia de Exigibilidad","Type":23},{"Value":23002,"Text":"Error en Notificación de Cédula Personal de la Resolución Sancionadora ","Type":23},{"Value":23003,"Text":"Error en Resolución Sancionadora","Type":23},{"Value":23004,"Text":"Error en Resolcuión de Segunda Instancia-CONAS","Type":23},{"Value":23005,"Text":"Error en Notificación de Cédula personal de la Resoluciones de Segunda Instancia-CONAS","Type":23},{"Value":23006,"Text":"Por Título de Ejecución Cancelado","Type":23},{"Value":23007,"Text":"Por Título de Ejecución Judicializado","Type":23},{"Value":24001,"Text":"Demanda de Revisión Judicial","Type":24},{"Value":24002,"Text":"Demanda Contencioso Administrativo","Type":24},{"Value":24003,"Text":"Deuda u Obligación Extinguida","Type":24},{"Value":24004,"Text":"Prescripción","Type":24},{"Value":24005,"Text":"Convenio de liquidación judicial o extrajudicial","Type":24},{"Value":24006,"Text":"Acción contra persona distinta al obligado","Type":24},{"Value":24007,"Text":"Recurso Administrativo en Trámite","Type":24},{"Value":24008,"Text":"Omision de notificación de Título","Type":24},{"Value":24009,"Text":"Pérdida de Ejecutoriedad","Type":24},{"Value":25001,"Text":"Cobranza Persuasiva","Type":25},{"Value":25002,"Text":"Cobranza Convencional","Type":25},{"Value":26101,"Text":"Requerimiento de Pago","Type":26,"TypeFather":25001},{"Value":26102,"Text":"Vista Domiciliaria","Type":26,"TypeFather":25001},{"Value":26103,"Text":"Regulación de Pago","Type":26,"TypeFather":25001},{"Value":26201,"Text":"Retención de Terceros","Type":48,"TypeFather":25002},{"Value":26202,"Text":"Retencion Bancaria ","Type":48,"TypeFather":25002},{"Value":26203,"Text":"Embargo en Forma de Inscripción","Type":48,"TypeFather":25002},{"Value":27001,"Text":"SI","Type":27},{"Value":27002,"Text":"NO","Type":27},{"Value":28001,"Text":"Legal","Type":28},{"Value":28002,"Text":"Planta","Type":28},{"Value":29001,"Text":"Regular","Type":29},{"Value":29002,"Text":"Especial","Type":29},{"Value":30001,"Text":"Alcohol Etilico","Type":30},{"Value":30002,"Text":"Sustancias Químicas","Type":30},{"Value":30003,"Text":"Programa Nacional “Cómprale al Perú”","Type":30},{"Value":30004,"Text":"Facturas Negociables","Type":30},{"Value":30005,"Text":"Reglamentos Técnicos","Type":30},{"Value":31001,"Text":"Registrada","Type":31},{"Value":31002,"Text":"Programada","Type":31},{"Value":31003,"Text":"Finalizada","Type":31},{"Value":31004,"Text":"Pronunciada","Type":31},{"Value":32001,"Text":"Pendiente","Type":32},{"Value":32002,"Text":"Preevaluado","Type":32},{"Value":32003,"Text":"Registrado","Type":32},{"Value":32004,"Text":"En Atención","Type":32},{"Value":32005,"Text":"Atendido","Type":32},{"Value":32006,"Text":"Inadimisible","Type":32},{"Value":32007,"Text":"Observado","Type":32},{"Value":32008,"Text":"Por Sesionar","Type":32},{"Value":32009,"Text":"Pronunciado","Type":32},{"Value":32010,"Text":"Por Renotificar","Type":32},{"Value":32011,"Text":"Renotificado","Type":32},{"Value":33001,"Text":"Pesca","Type":33},{"Value":33002,"Text":"Industria","Type":33},{"Value":34001,"Text":"Acta de fiscalización","Type":34},{"Value":34002,"Text":"Informe técnico","Type":34},{"Value":35001,"Text":"Pesca","Type":35},{"Value":35002,"Text":"Acuicultura","Type":35},{"Value":36001,"Text":"Embarcación","Type":36},{"Value":36002,"Text":"Planta","Type":36},{"Value":37001,"Text":"Recurso","Type":37},{"Value":37002,"Text":"Producto","Type":37},{"Value":38001,"Text":"Multa","Type":38,"TypeFather":43002},{"Value":38002,"Text":"Decomiso","Type":38,"TypeFather":43001},{"Value":38003,"Text":"Suspención de permiso de pesca","Type":38,"TypeFather":43002},{"Value":38004,"Text":"Suspención de Licencia de Operación","Type":38,"TypeFather":43002},{"Value":38005,"Text":"Cancelación de Permiso de pesca","Type":38,"TypeFather":43002},{"Value":38006,"Text":"Cancelación de Licencia de Operación","Type":38,"TypeFather":43002},{"Value":38007,"Text":"Reducción","Type":38,"TypeFather":43002},{"Value":39001,"Text":"Tn","Type":39,"TypeFather":38002},{"Value":39002,"Text":"Kg","Type":39,"TypeFather":38002},{"Value":39003,"Text":"Ha","Type":39,"TypeFather":38007},{"Value":39004,"Text":"Porcentaje","Type":39,"TypeFather":38007},{"Value":39005,"Text":"UIT","Type":39,"TypeFather":38001},{"Value":39006,"Text":"Días de Suspención de Permiso","Type":39,"TypeFather":38003},{"Value":39007,"Text":"Días de Suspención Licencia","Type":39,"TypeFather":38004},{"Value":39008,"Text":"Días de Cancelación de Permiso","Type":39,"TypeFather":38005},{"Value":39009,"Text":"Días de Cancelación de Licencia","Type":39,"TypeFather":38006},{"Value":40001,"Text":"HARINA (CHI)","Type":40},{"Value":40002,"Text":"CONGELADO (CHD)","Type":40},{"Value":40003,"Text":"ENLATADO (CHD)","Type":40},{"Value":40004,"Text":"CURADO (CHD)","Type":40},{"Value":40005,"Text":"OTRAS (CHD)","Type":40},{"Value":41001,"Text":"Procesando","Type":41},{"Value":41002,"Text":"Procesado con errores","Type":41},{"Value":41003,"Text":"Procesado","Type":41},{"Value":42001,"Text":"Configurado","Type":42},{"Value":42002,"Text":"Ejecutado","Type":42},{"Value":42003,"Text":"Eliminado","Type":42},{"Value":42004,"Text":"Desacumulado","Type":42},{"Value":43001,"Text":"Medida Cautelar","Type":43},{"Value":43002,"Text":"Sanción","Type":43},{"Value":44001,"Text":"En elaboración","Type":44},{"Value":44002,"Text":"Finalizado","Type":44},{"Value":45001,"Text":"Alcohol Etílico","Type":45},{"Value":45002,"Text":"Comprale al Perú","Type":45},{"Value":45003,"Text":"Facturas Negociables","Type":45},{"Value":45004,"Text":"Sustancias quimicas susceptibles de empleo para la fabricación de armas químicas","Type":45},{"Value":45005,"Text":"Reglamentos técnicos","Type":45},{"Value":46001,"Text":"En Actividad","Type":46},{"Value":47001,"Text":"Muy Grave","Type":47},{"Value":47002,"Text":"Grave","Type":47},{"Value":47003,"Text":"Leve","Type":47},{"Value":49001,"Text":"Empresas Terceras","Type":49},{"Value":49002,"Text":"Sunarp","Type":49},{"Value":49003,"Text":"Bancos","Type":49},{"Value":50001,"Text":"No Inicio","Type":50},{"Value":50002,"Text":"Inicio","Type":50},{"Value":51001,"Text":"Devolución de Multas - Sanciones","Type":51},{"Value":51002,"Text":"Devolución  por Saldo - Coactiva","Type":51},{"Value":51003,"Text":"Devolución de Pronto Pago","Type":51},{"Value":51004,"Text":"Devolución por Decomiso","Type":51},{"Value":52001,"Text":"En Registro","Type":52},{"Value":52002,"Text":"Con Demanda","Type":52},{"Value":52003,"Text":"Con Sentencia","Type":52},{"Value":53001,"Text":"Fundada (Nulidad de PAS)","Type":53},{"Value":53002,"Text":"Infundada","Type":53},{"Value":53003,"Text":"Improcedente","Type":53}],	
          
    "TIPO_ENUMERADO" : 
	    {
		  NONE : 0, 
		  TIPO_DE_DOCUMENTO : 10, 
		  TIPO_DE_ESPECIALIDAD : 11, 
		  ESTADO_DE_DOCUMENTO : 12, 
		  ESTADO_DE_EXPEDIENTE_PAS : 13, 
		  ORIGEN_DE_DOCUMENTO : 14, 
		  TIPO_DE_DOCUMENTO_DE_IDENTIDAD : 15, 
		  ESTADO_DE_EXPEDIENTE_COACTIVO : 16, 
		  ESTADO_DE_DEPOSITO : 17, 
		  TIPO_DE_CARGO : 18, 
		  ESTADO_DE_DEUDA : 19, 
		  TIPO_DE_PRONUNCIAMIENTO : 20, 
		  FORMATO_DE_RCONAS : 21, 
		  SENTIDO_DE_PRONUNCIAMIENTO : 22, 
		  CAUSALES_DE_DEVOLUCION : 23, 
		  CAUSALES_DE_SUSPENSION : 24, 
		  TIPO_DE_MEDIDA_CAUTELAR : 25, 
		  COBRANZA_PERSUASIVA : 26, 
		  PREGUNTA_EXCLUSIVA : 27, 
		  TIPO_DE_DOMICILIO : 28, 
		  TIPO_DE_FISCALIZACION : 29, 
		  OBJETIVO_DE_FISCALIZACION : 30, 
		  ESTADO_DE_SESION : 31, 
		  ESTADO_DE_RCONAS : 32, 
		  TIPO_DE_SECTOR : 33, 
		  TIPO_DE_PROCEDENCIA : 34, 
		  TIPO_DE_INFRACCION : 35, 
		  UNIDAD_FISCALIZADA : 36, 
		  TIPO_DE_MATERIAL : 37, 
		  TIPO_DE_SANCION : 38, 
		  TIPO_UNIDAD : 39, 
		  TIPO_DE_ACTIVIDAD_PLANTA : 40, 
		  ESTADO_DE_PROCESAMIENTO : 41, 
		  ESTADO_DE_ACUMULADO : 42, 
		  TIPO_DE_MEDIDA : 43, 
		  ESTADO_DE_FISCALIZACION : 44, 
		  TIPO_DE_MATERIA : 45, 
		  ESTADO_DE_ACTIVIDAD : 46, 
		  CALIFICACION_DE_INFRACCION : 47, 
		  COBRANZA_CONVENCIONAL : 48, 
		  TIPO_DE_ENTIDAD : 49, 
		  ESTADO_DE_PREINICIO : 50, 
		  MOTIVO_DE_DEVOLUCION : 51, 
		  ESTADO_DE_DEMANDA : 52, 
		  RESULTADO_DE_PROCESO_JUDICIAL : 53, 
	    },    
        
    "CALIFICACION_DE_INFRACCION" : 
	    {
		NONE : 0, 
		MUY_GRAVE : 47001, 
		GRAVE : 47002, 
		LEVE : 47003, 
	    },    
        
    "CAUSALES_DE_DEVOLUCION" : 
	    {
		NONE : 0, 
		ERROR_EN_CONSTANCIA_DE_EXIGIBILIDAD : 23001, 
		ERROR_EN_NOTIFICACION_DE_CEDULA_PERSONAL_DE_LA_RESOLUCION_SANCIONADORA : 23002, 
		ERROR_EN_RESOLUCION_SANCIONADORA : 23003, 
		ERROR_EN_RESOLCUION_DE_SEGUNDA_INSTANCIA_CONAS : 23004, 
		ERROR_EN_NOTIFICACION_DE_CEDULA_PERSONAL_DE_LA_RESOLUCIONES_DE_SEGUNDA_INSTANCIA_CONAS : 23005, 
		POR_TITULO_DE_EJECUCION_CANCELADO : 23006, 
		POR_TITULO_DE_EJECUCION_JUDICIALIZADO : 23007, 
	    },    
        
    "CAUSALES_DE_SUSPENSION" : 
	    {
		NONE : 0, 
		DEMANDA_DE_REVISION_JUDICIAL : 24001, 
		DEMANDA_CONTENCIOSO_ADMINISTRATIVO : 24002, 
		DEUDA_U_OBLIGACION_EXTINGUIDA : 24003, 
		PRESCRIPCION : 24004, 
		CONVENIO_DE_LIQUIDACION_JUDICIAL_O_EXTRAJUDICIAL : 24005, 
		ACCION_CONTRA_PERSONA_DISTINTA_AL_OBLIGADO : 24006, 
		RECURSO_ADMINISTRATIVO_EN_TRAMITE : 24007, 
		OMISION_DE_NOTIFICACION_DE_TITULO : 24008, 
		PERDIDA_DE_EJECUTORIEDAD : 24009, 
	    },    
        
    "COBRANZA_CONVENCIONAL" : 
	    {
		NONE : 0, 
		RETENCION_DE_TERCEROS : 26201, 
		RETENCION_BANCARIA : 26202, 
		EMBARGO_EN_FORMA_DE_INSCRIPCION : 26203, 
	    },    
        
    "COBRANZA_PERSUASIVA" : 
	    {
		NONE : 0, 
		REQUERIMIENTO_DE_PAGO : 26101, 
		VISTA_DOMICILIARIA : 26102, 
		REGULACION_DE_PAGO : 26103, 
	    },    
        
    "ESTADO_DE_ACTIVIDAD" : 
	    {
		NONE : 0, 
		EN_ACTIVIDAD : 46001, 
	    },    
        
    "ESTADO_DE_ACUMULADO" : 
	    {
		NONE : 0, 
		CONFIGURADO : 42001, 
		EJECUTADO : 42002, 
		ELIMINADO : 42003, 
		DESACUMULADO : 42004, 
	    },    
        
    "ESTADO_DE_DEMANDA" : 
	    {
		NONE : 0, 
		EN_REGISTRO : 52001, 
		CON_DEMANDA : 52002, 
		CON_SENTENCIA : 52003, 
	    },    
        
    "ESTADO_DE_DEPOSITO" : 
	    {
		NONE : 0, 
		PENDIENTE : 17001, 
		VALIDADO : 17002, 
		AMORTIZADO : 17003, 
		RECHAZADA : 17004, 
		AUTOGENERADO : 17005, 
		INVALIDADO : 17006, 
	    },    
        
    "ESTADO_DE_DEUDA" : 
	    {
		NONE : 0, 
		REGISTRADA : 19001, 
		EXIGIBLE : 19002, 
		CANCELADA : 19003, 
		SUSPENDIDA : 19004, 
		ARCHIVADA : 19005, 
		ANULADA : 19006, 
	    },    
        
    "ESTADO_DE_DOCUMENTO" : 
	    {
		NONE : 0, 
		ELABORADO : 12001, 
		OBSERVADO : 12002, 
		APROBADO : 12003, 
		APROBADO_PARA_ATENCION : 12004, 
		DENEGADO : 12005, 
		PENDIENTE_DE_FIRMA : 12006, 
		FIRMADO : 12007, 
		NOTIFICADO_FISICA : 12008, 
		NOTIFICADO_ELECTRONICAMENTE : 12009, 
		ADJUNTADO : 12010, 
		PENDIENTE_DE_NOTIFICACION : 12011, 
		RECEPCIONADO : 12012, 
		DERIVADO : 12013, 
		ELABORANDOSE : 12014, 
		REGISTRANDOSE : 12015, 
		ADJUNTANDOSE : 12016, 
		NO_NOTIFICADO : 12017, 
		GENERADO : 12018, 
		ATENDIDO : 12019, 
	    },    
        
    "ESTADO_DE_EXPEDIENTE_COACTIVO" : 
	    {
		NONE : 0, 
		REGISTRADO : 16001, 
		PENDIENTE : 16002, 
		CANCELADO : 16003, 
		ARCHIVADO : 16004, 
		SUSPENDIDO : 16005, 
		NO_INICIO : 16006, 
		INICIO : 16007, 
		COBRANZA : 16008, 
	    },    
        
    "ESTADO_DE_EXPEDIENTE_PAS" : 
	    {
		NONE : 0, 
		FISCALIZACION : 13001, 
		SANCION : 13002, 
		APELACION : 13003, 
		COACTIVA : 13004, 
		SANCION_CON_RESOLUCION : 13005, 
		ARCHIVADO : 13006, 
		SUPERVISION : 13007, 
		CANCELADO : 13008, 
		SUSPENDIDO : 13009, 
	    },    
        
    "ESTADO_DE_FISCALIZACION" : 
	    {
		NONE : 0, 
		ELABORANDOSE : 44001, 
		FINALIZADO : 44002, 
	    },    
        
    "ESTADO_DE_PREINICIO" : 
	    {
		NONE : 0, 
		NO_INICIO : 50001, 
		INICIO : 50002, 
	    },    
        
    "ESTADO_DE_PROCESAMIENTO" : 
	    {
		NONE : 0, 
		PROCESANDO : 41001, 
		PROCESADO_CON_ERRORES : 41002, 
		PROCESADO : 41003, 
	    },    
        
    "ESTADO_DE_RCONAS" : 
	    {
		NONE : 0, 
		PENDIENTE : 32001, 
		PREEVALUADO : 32002, 
		REGISTRADO : 32003, 
		EN_ATENCION : 32004, 
		ATENDIDO : 32005, 
		INADMISIBLE : 32006, 
		OBSERVADO : 32007, 
		POR_SESIONAR : 32008, 
		PRONUNCIADO : 32009, 
		POR_RENOTIFICAR : 32010, 
		RENOTIFICADO : 32011, 
	    },    
        
    "ESTADO_DE_SESION" : 
	    {
		NONE : 0, 
		REGISTRADA : 31001, 
		PROGRAMADA : 31002, 
		FINALIZADA : 31003, 
		PRONUNCIADA : 31004, 
	    },    
        
    "FORMATO_DE_RCONAS" : 
	    {
		NONE : 0, 
		FORMATO_RCONAS_1 : 21001, 
		FORMATO_RCONAS_2 : 21002, 
		FORMATO_RCONAS_3 : 21003, 
		FORMATO_RCONAS_4 : 21004, 
	    },    
        
    "MOTIVO_DE_DEVOLUCION" : 
	    {
		NONE : 0, 
		DEVOLUCION_DE_MULTAS_SANCIONES : 51001, 
		DEVOLUCION_POR_SALDO_COACTIVA : 51002, 
		DEVOLUCION_DE_PRONTO_PAGO : 51003, 
		DEVOLUCION_POR_DECOMISO : 51004, 
	    },    
        
    "OBJETIVO_DE_FISCALIZACION" : 
	    {
		NONE : 0, 
		ALCOHOL_ETILICO : 30001, 
		SUSTANCIAS_QUIMICAS : 30002, 
		PROGRAMA_NACIONAL_COMPRALE_AL_PERU : 30003, 
		FACTURAS_NEGOCIABLES : 30004, 
		REGLAMENTOS_TECNICOS : 30005, 
	    },    
        
    "ORIGEN_DE_DOCUMENTO" : 
	    {
		NONE : 0, 
		FISICO : 14001, 
		PLANTILLA : 14002, 
		DIGITAL : 14003, 
	    },    
        
    "PREGUNTA_EXCLUSIVA" : 
	    {
		NONE : 0, 
		SI : 27001, 
		NO : 27002, 
	    },    
        
    "RESULTADO_DE_PROCESO_JUDICIAL" : 
	    {
		NONE : 0, 
		FUNDADA : 53001, 
		INFUNDADA : 53002, 
		IMPROCEDENTE : 53003, 
	    },    
        
    "SENTIDO_DE_PRONUNCIAMIENTO" : 
	    {
		NONE : 0, 
		CONFIRMAR : 22001, 
		NULIDAD : 22002, 
		ARCHIVO : 22003, 
		SUSTRACCION_DE_LA_MATERIA : 22004, 
		PRESCRIPCION : 22005, 
		OTROS : 22006, 
		INADMISIBLE_IMPROCEDENTE_DESISTIMIENTO : 22007, 
		CONSERVAR_O_RECTIFICAR_RCONAS : 22008, 
	    },    
        
    "TIPO_DE_ACTIVIDAD_PLANTA" : 
	    {
		NONE : 0, 
		HARINA_CHI : 40001, 
		CONGELADO_CHD : 40002, 
		ENLATADO_CHD : 40003, 
		CURADO_CHD : 40004, 
		OTRAS_CHD : 40005, 
	    },    
        
    "TIPO_DE_CARGO" : 
	    {
		NONE : 0, 
		COSTA : 18001, 
		GASTO : 18002, 
		ANULACION : 18003, 
	    },    
        
    "TIPO_DE_DOCUMENTO" : 
	    {
		NONE : 0, 
		INFORMES : 10001, 
		OFICIOS : 10002, 
		RESOLUCIONES_DIRECTORALES : 10003, 
		SOLICITUDES : 10004, 
		ACTAS : 10005, 
		CONSTANCIAS : 10006, 
		CEDULAS : 10007, 
		DEPOSITOS : 10008, 
		RECIBIDOS : 10009, 
		PROVEIDOS : 10010, 
		RECURSOS : 10011, 
		SUSTENTOS : 10012, 
		TRAMITE_INTERNO : 10013, 
		COMPROBANTES : 10014, 
		SENTENCIA : 10015, 
		DEMANDA : 10016, 
	    },    
        
    "TIPO_DE_DOCUMENTO_DE_IDENTIDAD" : 
	    {
		NONE : 0, 
		DNI : 15001, 
		RUC : 15002, 
		CE : 15003, 
	    },    
        
    "TIPO_DE_DOMICILIO" : 
	    {
		NONE : 0, 
		LEGAL : 28001, 
		PLANTA : 28002, 
	    },    
        
    "TIPO_DE_ENTIDAD" : 
	    {
		NONE : 0, 
		EMPRESAS_TERCERAS : 49001, 
		SUNARP : 49002, 
		BANCOS : 49003, 
	    },    
        
    "TIPO_DE_ESPECIALIDAD" : 
	    {
		NONE : 0, 
		PROVEIDO_DE_SOLICITUD : 11001, 
		PROVEIDO_DE_ARCHIVO : 11002, 
		PROVEIDO_DE_AMPLIACION : 11003, 
		VISTAS_DE_CAUSA_PRONUNCIAMIENTO : 11005, 
		CITA_DE_SESION : 11006, 
		VISTAS_DE_CAUSA : 11007, 
		OTROS_ANEXOS : 11008, 
		DOCUMENTO_DE_SUSTENTO : 11009, 
		DEVOLUCION_DE_TESORERIA : 11035, 
		LEVANTAMIENTO_DE_SUSPENSION_DE_CONSUMO : 11036, 
		SUSPENSION_DE_CONSUMO : 11037, 
		FIN_DE_PROCESO_JUDICIAL : 11038, 
		INICIO_DE_PROCESO_JUDICIAL : 11039, 
		ARCHIVO_DEMANDA : 11040, 
		RESOLUCION_DE_INSTANCIA : 11041, 
		RECURSO_DE_RECONSIDERACION : 11098, 
		RECURSO_DE_APELACION : 11099, 
		INFORME_TECNICO_PESCA : 11101, 
		INFORME_NO_MERITO : 11102, 
		INFORME_FINAL_DE_INSTRUCCION : 11103, 
		INFORME_PRELIMINAR : 11104, 
		INFORME_DE_FISCALIZACION : 11105, 
		INFORME_DE_NO_HA_LUGAR : 11106, 
		INFORME_LEGAL : 11107, 
		INFORME_DE_NO_INICIO : 11108, 
		INFORME_DE_DEUDA_INCOBRABLE : 11109, 
		INFORME_PARA_OGA : 11110, 
		INFORME_RESPUESTA_DE_OGA : 11111, 
		INFORME_TECNICO_INDUSTRIA : 11112, 
		INFORME_DE_CIERRE : 11113, 
		INFORME_TECNICO_DE_SUSPENSION : 11114, 
		INFORME_TECNICO_DE_TESORERIA : 11115, 
		INFORME_TECNICO_DE_SUSPENSION_DE_CONSUMO : 11116, 
		OFICIO_DE_SALDO : 11201, 
		OFICIO_DE_AUDIENCIA : 11202, 
		OFICIO_DE_RETENCION_DE_TERCEROS : 11203, 
		OFICIO_A_SUNARP : 11204, 
		OFICIO_DE_REGULACION : 11205, 
		OFICIO_DE_NO_INICIO : 11206, 
		OFICIO_NO_MERITO : 11207, 
		OFICIO_NO_HA_LUGAR : 11208, 
		OFICIO_PRELIMINAR : 11209, 
		OFICIO_DE_RESPUESTA : 11210, 
		OFICIO_DE_SUSPENSION_DE_RETENCION_DE_TERCEROS : 11211, 
		OFICIO_DE_SUSPENSION_A_SUNARP : 11212, 
		OFICIO_DE_PROGRAMACION_UP : 11213, 
		OFICIO_DE_PROGRAMACION_UP_AMP : 11214, 
		OFICIO_DE_DENEGACION_UP : 11215, 
		OFICIO_DE_PROGRAMACION_LE : 11216, 
		OFICIO_DE_DENEGACION_LE : 11217, 
		OFICIO_DE_ESTESE_A_LO_RESUELTO : 11218, 
		OFICIO_DE_RETENCION_DE_TESORERIA : 11219, 
		OFICIO_DE_LEVANTAMIENTO_DE_SUSPENSION_DE_CONSUMO : 11220, 
		RESOLUCION_CONAS : 11301, 
		RESOLUCION_DE_SANCION : 11302, 
		RESOLUCION_DE_FRACCIONAMIENTO : 11303, 
		RESOLUCION_DE_BENEFICIO : 11304, 
		RESOLUCION_DE_REQUERIMIENTO_DE_PAGO : 11305, 
		RESOLUCION_DE_COBRANZA_PARA_BANCO : 11306, 
		RESOLUCION_DE_EJECUCION_COACTIVA : 11307, 
		RESOLUCION_DE_EJECUCION_COACTIVA_DE_CANCELACION : 11308, 
		RESOLUCION_DE_ARCHIVAMIENTO : 11309, 
		RESOLUCION_DE_SUSPENSION : 11310, 
		RESOLUCION_DE_COBRANZA : 11311, 
		RESOLUCION_DE_CANCELACION : 11312, 
		RESOLUCION_DE_LEVANTAMIENTO_DE_SUSPENSION : 11313, 
		RESOLUCION_DE_RETROACTIVIDAD_BENIGNA : 11314, 
		RESOLUCION_DE_IMPUTACION_DE_CARGOS : 11315, 
		RESOLUCION_DE_PRONTO_PAGO : 11316, 
		RESOLUCION_DE_APELACION : 11317, 
		RESOLUCION_DE_RECONSIDERACION : 11318, 
		RESOLUCION_DE_SUSPENSION_PARA_BANCO : 11319, 
		RESOLUCION_PARA_ADMINISTRADO : 11320, 
		SOLICITUD_DE_ACOGIMIENTO : 11401, 
		SOLICITUD_DE_FRACCIONAMIENTO : 11402, 
		SOLICITUD_DE_USO_DE_PALABRA : 11403, 
		SOLICITUD_DE_LECTURA_DE_EXPEDIENTE : 11405, 
		SOLICITUD_DE_AMPLIACION : 11406, 
		SOLICITUD_DE_RETROACTIVIDAD_BENIGNA : 11407, 
		SOLICITUD_DE_PRONTO_PAGO : 11409, 
		SOLICITUD_DE_SUSPENSION : 11410, 
		SOLICITUD_DE_ACCESO_A_LA_INFORMACION : 11411, 
		SOLICITUD_DE_AMPLIACION_DE_PALABRA : 11412, 
		SOLICITUD_DE_AMPLIACION_DE_RECURSO : 11413, 
		SOLICITUD_DE_IMPUGNACION_DE_CEDULA : 11414, 
		SOLICITUD_DE_AMPLIACION_DE_ALEGATOS : 11415, 
		SOLICITUD_DE_DESISTIMIENTO_DE_APELACION : 11416, 
		SOLICITUD_DE_DEVOLUCION : 11417, 
		SOLICITUD_DE_LEVANTAMIENTO_DE_SUSPENSION_DE_CONSUMO : 11418, 
		ACTA_DE_FISCALIZACION : 11501, 
		ACTA_DE_AUDIENCIA : 11502, 
		ACTA_DE_ASISTENCIA : 11503, 
		ACTA_DE_VISITA : 11504, 
		ACTA_DE_SESION : 11505, 
		ACTA_DE_INASISTENCIA : 11506, 
		ACTA_DE_DONACION : 11507, 
		ACTA_DE_SEGUIMIENTO : 11508, 
		ACTA_DE_DEVOLUCION_AL_MEDIO_NATURAL : 11509, 
		ACTA_DE_RETENCION_DE_PAGOS : 11510, 
		ACTA_DE_CUSTODIA : 11511, 
		ACTA_DE_DISPOSICION_FINAL : 11512, 
		ACTA_DE_RECURSO_EN_ABANDONO : 11513, 
		ACTA_DE_ENTREGA_RECEPCION_DE_DEMOMISO : 11514, 
		ACTA_DE_VERIFICACION : 11515, 
		ACTA_DE_COORDINACION : 11516, 
		ACTA_DE_OPERATIVO_CONJUNTO : 11517, 
		ACTA_DE_INSTALACION_REMOCION_Y_SUSTITUCION_DE_PRECINTOS_DE_SEGURIDAD_DE_INSTRUMENTOS_DE_PESAJE : 11518, 
		ACTA_DE_INSTALACION_REMOCION_Y_SUSTITUCION_DE_PRECINTOS_DE_SEGURIDAD_DEL_EQUIPO_DEL_SISESAT : 11519, 
		ACTA_DE_DECOMISO : 11520, 
		ACTA_DE_INMOVILIZACION : 11521, 
		OTRA_ACTA : 11599, 
		CONSTANCIA_DE_EXIGIBILIDAD : 11601, 
		CEDULA_DE_IMPUTACION_DE_CARGOS : 11701, 
		CEDULA_DE_NOTIFICACION_FISICA_DE_ADMINISTRADO : 11702, 
		CEDULA_DE_NOTIFICACION_FISICA_DE_BANCO : 11703, 
		CEDULA_DE_NOTIFICACION_FISICA_DE_TERCERO : 11704, 
		CEDULA_DE_NOTIFICACION_FISICA_DE_SUNARP : 11705, 
		CEDULA_DE_NOTIFICACION_ELECTRONICA_DE_ADMINISTRADO : 11706, 
		COMPROBANTES_DE_TRANSFERENCIAS : 11707, 
		COMPROBANTE_DE_DEVOLUCION : 11708, 
		VOUCHER : 11801, 
		TRANSFERENCIAS : 11802, 
		CHEQUES : 11803, 
		PAGO_BANCARIO : 11804, 
		RESPUESTAS : 11901, 
		DESCARGOS : 11902, 
		_1RA_INSTANCIA : 11951, 
		_2DA_INSTANCIA : 11952, 
		NULIDAD_DE_SENTENCIA : 11953, 
		CASACION_RECURSO_RAGRAVIO : 11954, 
		CONTESTACION_DE_DEMANDA : 14101, 
		CONTESTACION_DE_CANCELACION : 14102, 
	    },    
        
    "TIPO_DE_FISCALIZACION" : 
	    {
		NONE : 0, 
		REGULAR : 29001, 
		ESPECIAL : 29002, 
	    },    
        
    "TIPO_DE_INFRACCION" : 
	    {
		NONE : 0, 
		PESCA : 35001, 
		ACUICULTURA : 35002, 
	    },    
        
    "TIPO_DE_MATERIA" : 
	    {
		NONE : 0, 
		ALCOHOL_ETILICO : 45001, 
		COMPRALE_AL_PERU : 45002, 
		FACTURAS_NEGOCIABLES : 45003, 
		SUSTANCIAS_QUIMICAS : 45004, 
		REGLAMENTOS_TECNICOS : 45005, 
	    },    
        
    "TIPO_DE_MATERIAL" : 
	    {
		NONE : 0, 
		RECURSO : 37001, 
		PRODUCTO : 37002, 
	    },    
        
    "TIPO_DE_MEDIDA" : 
	    {
		NONE : 0, 
		MEDIDA_CAUTELAR : 43001, 
		SANCION : 43002, 
	    },    
        
    "TIPO_DE_MEDIDA_CAUTELAR" : 
	    {
		NONE : 0, 
		COBRANZA_PERSUASIVA : 25001, 
		COBRANZA_CONVENCIONAL : 25002, 
	    },    
        
    "TIPO_DE_PROCEDENCIA" : 
	    {
		NONE : 0, 
		ACTA_DE_FISCALIZACION : 34001, 
		INFORME_TECNICO : 34002, 
	    },    
        
    "TIPO_DE_PRONUNCIAMIENTO" : 
	    {
		NONE : 0, 
		CONSERVAR_ACTO_ADMINISTRATIVO_CONTENIDO_EN_RD : 20001, 
		FIN_DEL_PAS : 20002, 
		ARCHIVO : 20003, 
		PRESCRIPCION : 20004, 
		IMPROCEDENTE : 20005, 
		INADMISIBLE : 20006, 
		INFUNDADO : 20007, 
		NULIDAD_DE_OFICIO : 20008, 
		ACEPTAR_EL_DESISTIMIENTO : 20009, 
		RECTIFICAR_ERROR_MATERIAL : 20010, 
		RECTIFICAR_ERROR_MATERIAL_DE_RCONAS : 20011, 
		FUNDADO : 20012, 
		FUNDADO_EN_PARTE : 20013, 
		PRESCRIPCION_DE_OFICIO : 20014, 
		NULIDAD_PARCIAL_DE_OFICIO : 20015, 
		CONSERVAR_ACTO_ADMINSITRATIVO_CONTENIDO_EN_RCONAS : 20016, 
		NULIDAD_PARCIAL : 20017, 
		NULIDAD_DE_RCONAS : 20018, 
		SUSTRACCION_DE_LA_MATERIA : 20019, 
		NULIDAD : 20020, 
		ARCHIVO_EN_PARTE : 20021, 
		REQUIERE_INFORMACION_ADICIONAL : 20022, 
		REQUIERE_INFORME_TECNICO : 20023, 
		CONCLUIR_PAS : 20024, 
		SUSPENDIDO_POR_FALTA_DE_QUORUM : 20025, 
		PRORROGADO : 20026, 
		APLAZADO : 20027, 
		INFORME_ORAL : 20028, 
		OTROS : 20029, 
	    },    
        
    "TIPO_DE_SANCION" : 
	    {
		NONE : 0, 
		MULTA : 38001, 
		DECOMISO : 38002, 
		SUSPENCION_DE_PERMISO_DE_PESCA : 38003, 
		SUSPENCION_DE_LICENCIA_DE_OPERACION : 38004, 
		CANCELACION_DE_PERMISO_DE_PESCA : 38005, 
		CANCELACION_DE_LICENCIA_DE_OPERACION : 38006, 
		REDUCCION : 38007, 
	    },    
        
    "TIPO_DE_SECTOR" : 
	    {
		NONE : 0, 
		PESCA : 33001, 
		INDUSTRIA : 33002, 
	    },    
        
    "TIPO_UNIDAD" : 
	    {
		NONE : 0, 
		TN : 39001, 
		KG : 39002, 
		HA : 39003, 
		PORCENTAJE : 39004, 
		UIT : 39005, 
		DIAS_SP : 39006, 
		DIAS_SL : 39007, 
		DIAS_CP : 39008, 
		DIAS_CL : 39009, 
	    },    
        
    "TIPO_ENUMERADO" : 
	    {
		NONE : 0, 
		TIPO_DE_DOCUMENTO : 10, 
		TIPO_DE_ESPECIALIDAD : 11, 
		ESTADO_DE_DOCUMENTO : 12, 
		ESTADO_DE_EXPEDIENTE_PAS : 13, 
		ORIGEN_DE_DOCUMENTO : 14, 
		TIPO_DE_DOCUMENTO_DE_IDENTIDAD : 15, 
		ESTADO_DE_EXPEDIENTE_COACTIVO : 16, 
		ESTADO_DE_DEPOSITO : 17, 
		TIPO_DE_CARGO : 18, 
		ESTADO_DE_DEUDA : 19, 
		TIPO_DE_PRONUNCIAMIENTO : 20, 
		FORMATO_DE_RCONAS : 21, 
		SENTIDO_DE_PRONUNCIAMIENTO : 22, 
		CAUSALES_DE_DEVOLUCION : 23, 
		CAUSALES_DE_SUSPENSION : 24, 
		TIPO_DE_MEDIDA_CAUTELAR : 25, 
		COBRANZA_PERSUASIVA : 26, 
		PREGUNTA_EXCLUSIVA : 27, 
		TIPO_DE_DOMICILIO : 28, 
		TIPO_DE_FISCALIZACION : 29, 
		OBJETIVO_DE_FISCALIZACION : 30, 
		ESTADO_DE_SESION : 31, 
		ESTADO_DE_RCONAS : 32, 
		TIPO_DE_SECTOR : 33, 
		TIPO_DE_PROCEDENCIA : 34, 
		TIPO_DE_INFRACCION : 35, 
		UNIDAD_FISCALIZADA : 36, 
		TIPO_DE_MATERIAL : 37, 
		TIPO_DE_SANCION : 38, 
		TIPO_UNIDAD : 39, 
		TIPO_DE_ACTIVIDAD_PLANTA : 40, 
		ESTADO_DE_PROCESAMIENTO : 41, 
		ESTADO_DE_ACUMULADO : 42, 
		TIPO_DE_MEDIDA : 43, 
		ESTADO_DE_FISCALIZACION : 44, 
		TIPO_DE_MATERIA : 45, 
		ESTADO_DE_ACTIVIDAD : 46, 
		CALIFICACION_DE_INFRACCION : 47, 
		COBRANZA_CONVENCIONAL : 48, 
		TIPO_DE_ENTIDAD : 49, 
		ESTADO_DE_PREINICIO : 50, 
		MOTIVO_DE_DEVOLUCION : 51, 
		ESTADO_DE_DEMANDA : 52, 
		RESULTADO_DE_PROCESO_JUDICIAL : 53, 
	    },    
        
    "UNIDAD_FISCALIZADA" : 
	    {
		NONE : 0, 
		EMBARCACION : 36001, 
		PLANTA : 36002, 
	    },    
        DescripcionEnumerado(codigo) {
            var enumerado = this.ENUMERADOS.find(function (item) {
                return item.Value == codigo;
            });
            return enumerado == null ? '' : enumerado.Text;
        },
        DescripcionTipo(codigo) {
            var enumerado = this.TIPOS.find(function (item) {
                return item.Value == codigo;
            });
            return enumerado == null ? '' : enumerado.Text;
        },
		EnumeradoPadre(codigo) {
            var enumerado = this.ENUMERADOS.find(function (item) {
                return item.Value == codigo;
            });
            return enumerado == null ? '' : enumerado.TypeFather;
        }
    };
});
