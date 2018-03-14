import { BaseModel } from './base.model';

export class UsuarioInfoModel extends BaseModel < string > {

    constructor() {
        super();
    }
    
    nome: string;
    dataNascimento: string;
    rg: string;
    cpf: string;
    perfis: Array < string > ;

}