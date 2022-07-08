export class DataMapping {
    readonly idProceso: number;
    readonly nome: string;
    readonly subproceso_nome: string;
    readonly area_subprocesso: string;
    readonly descricao_processo: string;
    readonly id_dado: number;
    readonly dados_regulares: string;
    readonly dados_Senssiveis: string;
    readonly baseLegal_lei: string;
    readonly descricaoBase_lei: string;
    readonly compartilhamento_interno: string;
    readonly compartilhamento_Externo: string;
    readonly destino_final: string;
    readonly controlador: string;
    readonly operador: string;
    readonly armazenamento_Fisico: string;
    readonly armazenamento_Digital: string;
    readonly id_DataMapping: number;
    readonly empresa: string;
    readonly area: string;
    readonly responsavel: string;

    constructor({ IdProceso, nome, subproceso_nome, area_subprocesso, descricao_processo, id_dado,
        dados_regulares, dados_Senssiveis, baseLegal_lei, descricaoBase_lei, compartilhamento_interno,
        compartilhamento_Externo, destino_final, controlador, operador, armazenamento_Fisico,
        armazenamento_Digital, id_DataMapping, empresa, area, responsavel }:
        {
            IdProceso: number, nome: string, subproceso_nome: string, area_subprocesso: string,
            descricao_processo: string, id_dado: number, dados_regulares: string,
            dados_Senssiveis: string, baseLegal_lei: string, descricaoBase_lei: string, compartilhamento_interno: string
            compartilhamento_Externo: string, destino_final: string, controlador: string, operador: string,
            armazenamento_Fisico: string, armazenamento_Digital: string, id_DataMapping: number,
            empresa: string, area: string, responsavel: string
        }) {
        this.idProceso = IdProceso;
        this.nome = nome;
        this.subproceso_nome = subproceso_nome;
        this.area_subprocesso = area_subprocesso;
        this.descricao_processo = descricao_processo;
        this.id_dado = id_dado;
        this.dados_regulares = dados_regulares;
        this.dados_Senssiveis = dados_Senssiveis;
        this.baseLegal_lei = baseLegal_lei;
        this.descricaoBase_lei = descricaoBase_lei;
        this.compartilhamento_interno = compartilhamento_interno;
        this.compartilhamento_Externo = compartilhamento_Externo;
        this.destino_final = destino_final;
        this.controlador = controlador;
        this.operador = operador;
        this.armazenamento_Fisico = armazenamento_Fisico;
        this.armazenamento_Digital = armazenamento_Digital;
        this.id_DataMapping = id_DataMapping;
        this.empresa = empresa;
        this.area = area;
        this.responsavel = responsavel;
    }

    public get IdProceso(): number {
        return this.idProceso;
    }

    public get Nome(): string {
        return this.nome;
    }

    public get Subproceso_nome(): string {
        return this.subproceso_nome;
    }

    public get Area_subprocesso(): string {
        return this.area_subprocesso;
    }

    public get Descricao_processo(): string {
        return this.descricao_processo;
    }

    public get Id_dado(): number {
        return this.id_dado;
    }

    public get Dados_regulares(): string {
        return this.dados_regulares;
    }

    public get Dados_Senssiveis(): string {
        return this.dados_Senssiveis
    }

    public get BaseLegal_lei(): string {
        return this.baseLegal_lei;
    }

    public get DescricaoBase_lei(): string {
        return this.descricaoBase_lei;
    }

    public get Compartilhamento_interno(): string {
        return this.compartilhamento_interno;
    }

    public get Compartilhamento_Externo(): string {
        return this.compartilhamento_Externo;
    }

    public get Destino_final(): string {
        return this.destino_final;
    }

    public get Controlador(): string {
        return this.controlador;
    }

    public get Operador(): string {
        return this.operador;
    }

    public get Armazenamento_Fisico(): string {
        return this.armazenamento_Fisico;
    }

    public get Armazenamento_Digital(): string {
        return this.armazenamento_Digital;
    }

    public get Id_DataMapping(): number {
        return this.id_DataMapping;
    }

    public get Empresa(): string {
        return this.empresa;
    }

    public get Area(): string {
        return this.area;
    }

    public get Responsavel(): string {
        return this.responsavel;
    }
}