import { BaseModel } from './base.model';

export class EmpresaModel  extends BaseModel < number > {

    constructor() {
        super();
    }

    nome: string;
    cnpj: string;
    telefone: string;
    email: string;
    tipo: string;

}