import { PageListaPropsInterface } from '../page-lista/page-lista-props.interface';
import { CardTableColumn, CardTableMenuEntry } from '../../../../../ezs-common/src/component/card-table/card-table.types';
import { AppRouterPath } from '../../../app.router.path';
import { AppRouter } from '../../../app.router';
import { Factory } from '../../../module/constant/factory.constant';
import { EstoqueGeralModel } from '../../../../../ezs-common/src/model/server/estoque-geral.model';

export class PageEstoqueGeralListaProps implements PageListaPropsInterface {

    columns = [
        new CardTableColumn((item: EstoqueGeralModel) => item.Produto.codigo, () => 'Produto'),
        new CardTableColumn((item: EstoqueGeralModel) => item.disponivel, () => 'Disponivel')
    ];
    menu = { row: [], main: [] };
    query = Factory.EstoqueFactory.allGeral;

}