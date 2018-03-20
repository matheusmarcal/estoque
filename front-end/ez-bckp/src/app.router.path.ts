import { RouteConfig } from 'vue-router';

export enum AppRouterPath {

    ROOT = '/',
        ABOUT = '/about',

        USUARIO_AUTENTICACAO = '/usuario/autenticacao',
        USUARIO = '/usuario',
        USUARIO_ADD = '/usuario/add',
        USUARIO_UPD = '/usuario/:id/upd',
        USUARIO_ALUNO = '/usuario/:id/aluno',
        USUARIO_PROFESSOR = '/usuario/:id/professor',
        USUARIO_ADD_EXTERNAL = '/usuario/cadastro',

        HISTORICO = '/historico',
        HISTORICO_ADD = '/hsitorico/add',
        HISTORICO_UPD = '/historico/:id/upd',

        EMPRESA = '/empresa',
        EMPRESA_ADD = '/empresa/add',
        EMPRESA_UPD = '/empresa/:id/upd',

        PRODUTO = '/produto',
        PRODUTO_ADD = '/produto/add',
        PRODUTO_UPD = '/produto/:id/upd',

        ESTOQUE = '/estoque',
        ESTOQUE_GERAL = '/estoque/geral',
        ESTOQUE_ADD = '/estoque/add',
        ESTOQUE_UPD = '/estoque/:id/upd/',

}



