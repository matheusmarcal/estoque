import { BaseModel } from './base.model';
import { EmpresaModel } from './empresa.model';
import { EstoqueModel } from './estoque.model';

export class HistoricoModel  extends BaseModel < number > {

    constructor() {
        super();
    }

    empresa: EmpresaModel;
    estoque: EstoqueModel;
    quantidade: string;
    nfe: string;

}