import { BaseModel } from './base.model';
import { EmpresaModel } from './empresa.model';
import { ProdutoModel } from './produto.model';

export class EstoqueModel  extends BaseModel < number > {

    constructor() {
        super();
    }

    Empresa: EmpresaModel;
    Produto: ProdutoModel;
    op: string;
    quantidade: string;
    nfe: string;
    posicao: string;

}