import { PageListaPropsInterface } from '../page-lista/page-lista-props.interface';
import { CardTableColumn, CardTableMenuEntry } from '../../../../../ezs-common/src/component/card-table/card-table.types';
import { AppRouterPath } from '../../../app.router.path';
import { Factory } from '../../../module/constant/factory.constant';
import { EstoqueModel } from '../../../../../ezs-common/src/model/server/estoque.model';
import { AppRouter } from '../../../app.router';

export class PageEstoqueListaProps implements PageListaPropsInterface {

    async doRetirar(item: EstoqueModel) {
        AppRouter.push({ name: AppRouterPath.HISTORICO_ADD_AUTO, params: { idEstoque: item.id.toString() } });
    }

    columns = [
        new CardTableColumn({
            value: (item: EstoqueModel) => item.empresa.nome,
            label: () => 'CNPJ'
        }),
        new CardTableColumn({
            value: (item: EstoqueModel) => item.produto.descricao,
            label: () => 'Produto'
        }),
        new CardTableColumn({
            value: (item: EstoqueModel) => item.op,
            label: () => 'OP'
        }),
        new CardTableColumn({
            value: (item: EstoqueModel) => item.nfe,
            label: () => 'NFe'
        }),
        new CardTableColumn({
            value: (item: EstoqueModel) => item.quantidade,
            label: () => 'Quantidade'
        }),
        new CardTableColumn({
            value: (item: EstoqueModel) => item.posicao,
            label: () => 'Posição'
        })
    ];
    menu = {
        row: [
            new CardTableMenuEntry({
                label: (item) => 'Retirar',
                method: (item) => this.doRetirar(item),
                btnClass: (item) => ['btn-primary'],
                iconClass: (item) => ['fa', 'fa-plus']
            })
        ],
         main: []
    };
    routePathAdd = AppRouterPath.ESTOQUE_ADD;
    routePathUpdate = AppRouterPath.ESTOQUE_UPD;
    query = Factory.EstoqueFactory.all;
    queryRemove = Factory.EstoqueFactory.disable;

}