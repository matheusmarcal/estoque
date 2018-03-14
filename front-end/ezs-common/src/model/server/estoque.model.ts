import { BaseModel } from './base.model';

export class EstoqueModel  extends BaseModel < number > {

    constructor() {
        super();
    }

    Empresa: string;
    Produto: string;
    quantidade: string;
    nfe: string;
    posicao: string;

}