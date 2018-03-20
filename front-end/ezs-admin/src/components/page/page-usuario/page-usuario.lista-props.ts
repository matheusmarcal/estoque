import { PageListaPropsInterface } from '../page-lista/page-lista-props.interface';
import { CardTableColumn, CardTableMenuEntry } from '../../../../../ezs-common/src/component/card-table/card-table.types';
import { AppRouterPath } from '../../../app.router.path';
import { AppRouter } from '../../../app.router';
import { Factory } from '../../../module/constant/factory.constant';
import { UsuarioModel } from '../../../../../ezs-common/src/model/server/usuario.model';

export class PageUsuarioListaProps implements PageListaPropsInterface {

    columns = [
        new CardTableColumn({
            value: (item: UsuarioModel) => item.username,
            label: () => 'Username'
        }),
        new CardTableColumn({
            value: (item: UsuarioModel) => item.usuarioInfo.nome,
            label: () => 'Nome'
        })
    ];
    menu = {
        row: [],
        main: []
    };
    routePathAdd = AppRouterPath.USUARIO_ADD;
    routePathUpdate = AppRouterPath.USUARIO_UPD;
    query = Factory.UsuarioFactory.all;
    queryRemove = Factory.UsuarioFactory.disable;

}