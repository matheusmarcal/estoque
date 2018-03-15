import { PageListaPropsInterface } from '../page-lista/page-lista-props.interface';
import { CardTableColumn, CardTableMenuEntry } from '../../../../../ezs-common/src/component/card-table/card-table.types';
import { AppRouterPath } from '../../../app.router.path';
import { AppRouter } from '../../../app.router';
import { Factory } from '../../../module/constant/factory.constant';
import { EmpresaModel } from '../../../../../ezs-common/src/model/server/empresa.model';
import { TipoClienteEnumLabel } from '../../../module/constant/enum-label.constant';

export class PageEmpresaListaProps implements PageListaPropsInterface {

    columns = [
        new CardTableColumn((item: EmpresaModel) => item.cnpj, () => 'CNPJ'),
        new CardTableColumn((item: EmpresaModel) => item.nome, () => 'Nome'),
        new CardTableColumn((item: EmpresaModel) => item.telefone, () => 'Telefone'),
        new CardTableColumn((item: EmpresaModel) => item.email, () => 'Email'),
        new CardTableColumn((item: EmpresaModel) => TipoClienteEnumLabel.find(x=>x.value==item.tipo).labelShort, () => 'Tipo')
    ];
    menu = { row: [], main: [] };
    routePathAdd = AppRouterPath.EMPRESA_ADD;
    routePathUpdate = AppRouterPath.EMPRESA_UPD;
    query = Factory.EmpresaFactory.all;
    queryRemove = Factory.EmpresaFactory.disable;

}