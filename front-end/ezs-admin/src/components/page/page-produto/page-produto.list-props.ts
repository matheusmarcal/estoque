import { PageListaPropsInterface } from '../page-lista/page-lista-props.interface';
import { CardTableColumn, CardTableMenuEntry } from '../../../../../ezs-common/src/component/card-table/card-table.types';
import { AppRouterPath } from '../../../app.router.path';
import { AppRouter } from '../../../app.router';
import { Factory } from '../../../module/constant/factory.constant';
import { ProdutoModel } from '../../../../../ezs-common/src/model/server/produto.model';

export class PageProdutoListaProps implements PageListaPropsInterface {

    columns = [
        new CardTableColumn({
            value: (item: ProdutoModel) => item.codigo,
            label: () => 'Código'
        }),
        new CardTableColumn({
            value: (item: ProdutoModel) => item.descricao,
            label: () => 'Descrição'
        })
    ];
    menu = { row: [], main: [] };
    routePathAdd = AppRouterPath.PRODUTO_ADD;
    routePathUpdate = AppRouterPath.PRODUTO_UPD;
    query = Factory.ProdutoFactory.all;
    queryRemove = Factory.ProdutoFactory.disable;

}