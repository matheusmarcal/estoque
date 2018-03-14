import { PageListaPropsInterface } from '../page-lista/page-lista-props.interface';
import { CardTableColumn, CardTableMenuEntry } from '../../../../../ezs-common/src/component/card-table/card-table.types';
import { AppRouterPath } from '../../../app.router.path';
import { AppRouter } from '../../../app.router';
import { Factory } from '../../../module/constant/factory.constant';
import { EstoqueModel } from '../../../../../ezs-common/src/model/server/estoque.model';

export class PageEstoqueListaProps implements PageListaPropsInterface {

    columns = [
        new CardTableColumn((item: EstoqueModel) => item.Empresa, () => 'CNPJ'),
        new CardTableColumn((item: EstoqueModel) => item.Produto, () => 'Produto'),
        new CardTableColumn((item: EstoqueModel) => item.nfe, () => 'NFe'),
        new CardTableColumn((item: EstoqueModel) => item.quantidade, () => 'Quantidade'),
        new CardTableColumn((item: EstoqueModel) => item.posicao, () => 'Posição')
    ];
    menu = { row: [], main: [] };
    routePathAdd = AppRouterPath.EMPRESA_ADD;
    routePathUpdate = AppRouterPath.EMPRESA_UPD;
    query = Factory.EstoqueFactory.all;
    queryRemove = Factory.EstoqueFactory.disable;

}