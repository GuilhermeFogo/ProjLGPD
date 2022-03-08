export class User {
    readonly id: number
    readonly nome: string;
    readonly senha: string;
    readonly role: string;
    readonly email: string

    public get Nome(): string {
        return this.nome;
    }

    public get Senha(): string {
        return this.senha;
    }

    public get Id(): number {
        return this.id;
    }

    public get Role(): string {
        return this.role;
    }

    public get Email() : string {
        return this.email;
    }

    constructor({ nome, senha, id, role, email}: { nome: string, senha: string, id: number, role: string, email: string}) {
        this.nome = nome;
        this.senha = senha;
        this.id = id;
        this.role = role;
        this.email = email;
    }
}