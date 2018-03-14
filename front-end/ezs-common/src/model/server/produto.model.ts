import { BaseModel } from './base.model';

export class ProdutoModel  extends BaseModel < number > {

    constructor() {
        super();
    }

    codigo: string;
    descricao: string;

}