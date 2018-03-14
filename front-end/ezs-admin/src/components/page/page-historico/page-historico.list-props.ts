import { PageListaPropsInterface } from '../page-lista/page-lista-props.interface';
import { CardTableColumn, CardTableMenuEntry } from '../../../../../ezs-common/src/component/card-table/card-table.types';
import { AppRouterPath } from '../../../app.router.path';
import { AppRouter } from '../../../app.router';
import { Factory } from '../../../module/constant/factory.constant';
import { HistoricoModel } from '../../../../../ezs-common/src/model/server/historico.model';

export class PageHistoricoListaProps implements PageListaPropsInterface {

    columns = [
        new CardTableColumn((item: HistoricoModel) => item.Empresa, () => 'CNPJ'),
        new CardTableColumn((item: HistoricoModel) => item.Estoque, () => 'Produto'),
        new CardTableColumn((item: HistoricoModel) => item.nfe, () => 'NFe'),
        new CardTableColumn((item: HistoricoModel) => item.quantidade, () => 'Quantidade'),
    ];
    menu = { row: [], main: [] };
    routePathAdd = AppRouterPath.EMPRESA_ADD;
    routePathUpdate = AppRouterPath.EMPRESA_UPD;
    query = Factory.HistoricoFactory.all;
    queryRemove = Factory.HistoricoFactory.disable;

}