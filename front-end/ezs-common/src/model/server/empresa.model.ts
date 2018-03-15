import { BaseModel } from './base.model';

export class EmpresaModel  extends BaseModel < number > {

    constructor() {
        super();
    }

    nome: string;
    cnpj: string;
    telefone: string;
    email: string;
    tipo: TipoClieteModel;

}
export enum TipoClieteModel {
    Cliente = 0,
    Fornecedor = 1,
    Ambos = 2
}