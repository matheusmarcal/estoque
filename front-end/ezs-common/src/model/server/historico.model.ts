import { BaseModel } from './base.model';

export class HistoricoModel  extends BaseModel < number > {

    constructor() {
        super();
    }

    Empresa: string;
    Estoque: string;
    quantidade: string;
    nfe: string;

}