import { BaseModel } from './base.model';
import { ProdutoModel } from './produto.model';

export class EstoqueGeralModel  extends BaseModel < number > {

    constructor() {
        super();
    }

    Produto: ProdutoModel;
    disponivel: string;


}