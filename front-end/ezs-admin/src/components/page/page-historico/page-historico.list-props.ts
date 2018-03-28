import { PageListaPropsInterface } from '../page-lista/page-lista-props.interface';
import { CardTableColumn, CardTableMenuEntry } from '../../../../../ezs-common/src/component/card-table/card-table.types';
import { AppRouterPath } from '../../../app.router.path';
import { AppRouter } from '../../../app.router';
import { Factory } from '../../../module/constant/factory.constant';
import { HistoricoModel } from '../../../../../ezs-common/src/model/server/historico.model';

export class PageHistoricoListaProps implements PageListaPropsInterface {

    columns = [
        new CardTableColumn({
            value: (item: HistoricoModel) => item.empresa.nome,
            label: () => 'CNPJ'
        }),
        new CardTableColumn({
            value: (item: HistoricoModel) => item.estoque.produto.descricao,
            label: () => 'Produto'
        }),
        new CardTableColumn({
            value: (item: HistoricoModel) => item.nfe,
            label: () => 'NFe'
        }),
        new CardTableColumn({
            value: (item: HistoricoModel) => item.quantidade,
            label: () => 'Quantidade'
        })
    ];
    menu = { row: [], main: [] };
    routePathAdd = AppRouterPath.HISTORICO_ADD;
    routePathUpdate = AppRouterPath.HISTORICO_UPD;
    query = Factory.HistoricoFactory.all;
    queryRemove = Factory.HistoricoFactory.disable;

}