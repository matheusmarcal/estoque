import { AppRouter } from '../../app.router';
import { BaseRouteConfig } from '../../../../ezs-common/src/model/client/base-route-config.model';
import { RouterPathType } from '../../../../ezs-common/src/model/client/router-path-type.model';
import { AppRouterPath } from '../../app.router.path';
import { PageListaComponent } from '../../components/page/page-lista/index';
import { PageHomeComponent } from '../../components/page/page-home/index';
import { PageUsuarioListaProps } from '../../components/page/page-usuario/page-usuario.lista-props';
import { PageUsuarioAutenticacaoComponent } from '../../components/page/page-usuario-autenticacao/index';
import { PageUsuarioComponent } from '../../components/page/page-usuario/index';
import { PageEmpresaListaProps } from '../../components/page/page-empresa/page-empresa.list-props';
import { PageEmpresaComponent } from '../../components/page/page-empresa';
import { PageEstoqueComponent } from '../../components/page/page-estoque/page-estoque';
import { PageProdutoComponent } from '../../components/page/page-produto';
import { PageProdutoListaProps } from '../../components/page/page-produto/page-produto.list-props';
import { PageEstoqueListaProps } from '../../components/page/page-estoque/page-estoque.list-props';
import { PageHistoricoComponent } from '../../components/page/page-historico';
import { PageHistoricoListaProps } from '../../components/page/page-historico/page-historico.list-props';
import { PageEstoqueGeralListaProps } from '../../components/page/page-estoque/page-estoque.geral.list-props';


export const COMPONENT_ROUTE_CONSTANT: Array < BaseRouteConfig > = [
    { menu: true, type: RouterPathType.otr, path: AppRouterPath.ROOT, name: AppRouterPath.ROOT, component: PageHomeComponent, alias: 'Home' },

    { menu: false, type: RouterPathType.otr, path: AppRouterPath.USUARIO_AUTENTICACAO, name: AppRouterPath.USUARIO_AUTENTICACAO, component: PageUsuarioAutenticacaoComponent, alias: 'Autenticação' },
    { menu: true, type: RouterPathType.list, path: AppRouterPath.USUARIO, name: AppRouterPath.USUARIO, component: PageListaComponent, alias: 'Usuários', props: new PageUsuarioListaProps() },
    { menu: false, type: RouterPathType.add, path: AppRouterPath.USUARIO_ADD, name: AppRouterPath.USUARIO_ADD, component: PageUsuarioComponent, alias: 'Usuário' },
    { menu: false, type: RouterPathType.upd, path: AppRouterPath.USUARIO_UPD, name: AppRouterPath.USUARIO_UPD, component: PageUsuarioComponent, alias: 'Usuário' },

    { menu: true, type: RouterPathType.list, path: AppRouterPath.EMPRESA, name: AppRouterPath.EMPRESA, component: PageListaComponent, alias: 'Empresas', props: new PageEmpresaListaProps() },
    { menu: false, type: RouterPathType.add, path: AppRouterPath.EMPRESA_ADD, name: AppRouterPath.EMPRESA_ADD, component: PageEmpresaComponent, alias: 'Empresa' },
    { menu: false, type: RouterPathType.upd, path: AppRouterPath.EMPRESA_UPD, name: AppRouterPath.EMPRESA_UPD, component: PageEmpresaComponent, alias: 'Empresa' },

    { menu: true, type: RouterPathType.list, path: AppRouterPath.ESTOQUE, name: AppRouterPath.ESTOQUE, component: PageListaComponent, alias: 'Estoques', props: new PageEstoqueListaProps() },
    { menu: true, type: RouterPathType.list, path: AppRouterPath.ESTOQUE_GERAL, name: AppRouterPath.ESTOQUE_GERAL, component: PageListaComponent, alias: 'Estoque Geral', props: new PageEstoqueGeralListaProps() },
    { menu: false, type: RouterPathType.add, path: AppRouterPath.ESTOQUE_ADD, name: AppRouterPath.ESTOQUE_ADD, component: PageEstoqueComponent, alias: 'Estoque' },
    { menu: false, type: RouterPathType.upd, path: AppRouterPath.ESTOQUE_UPD, name: AppRouterPath.ESTOQUE_UPD, component: PageEstoqueComponent, alias: 'Estoque' },

    { menu: true, type: RouterPathType.list, path: AppRouterPath.PRODUTO, name: AppRouterPath.PRODUTO, component: PageListaComponent, alias: 'Produtos', props: new PageProdutoListaProps() },
    { menu: false, type: RouterPathType.add, path: AppRouterPath.PRODUTO_ADD, name: AppRouterPath.PRODUTO_ADD, component: PageProdutoComponent, alias: 'Produto' },
    { menu: false, type: RouterPathType.upd, path: AppRouterPath.PRODUTO_UPD, name: AppRouterPath.PRODUTO_UPD, component: PageProdutoComponent, alias: 'Produto' },

    { menu: true, type: RouterPathType.list, path: AppRouterPath.HISTORICO, name: AppRouterPath.HISTORICO, component: PageListaComponent, alias: 'Historicos', props: new PageHistoricoListaProps() },
    { menu: false, type: RouterPathType.add, path: AppRouterPath.HISTORICO_ADD, name: AppRouterPath.HISTORICO_ADD, component: PageHistoricoComponent, alias: 'Historico' },
    { menu: false, type: RouterPathType.upd, path: AppRouterPath.HISTORICO_UPD, name: AppRouterPath.HISTORICO_UPD, component: PageHistoricoComponent, alias: 'Historico' },
    { menu: false, type: RouterPathType.add, path: AppRouterPath.HISTORICO_ADD_AUTO, name: AppRouterPath.HISTORICO_ADD_AUTO, component: PageHistoricoComponent, alias: 'Historico' },
];