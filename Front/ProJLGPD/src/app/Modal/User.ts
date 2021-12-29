export class User {
    readonly id: string
    readonly nome: string;
    readonly senha: string;
    readonly role: string;

    public get Nome(): string {
        return this.nome;
    }

    public get Senha(): string {
        return this.senha;
    }

    public get Id(): string {
        return this.id;
    }

    public get Role(): string {
        return this.role;
    }


    constructor({ nome, senha, id, role}: { nome: string, senha: string, id: string, role: string}) {
        this.nome = nome;
        this.senha = senha;
        this.id = id;
        this.role = role;
    }
}