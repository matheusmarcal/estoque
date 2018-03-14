import { AutenticaoServiceInterface } from './service/autenticacao.service.interface';
import { Factory as UsuarioFactory } from './factory/usuario/usuario.factory';
import { Factory as EmpresaFactory } from './factory/empresa/empresa.factory';
import { Factory as EstoqueFactory } from './factory/estoque/estoque.factory';
import { Factory as ProdutoFactory } from './factory/produto/produto.factory';
import { Factory as HistoricoFactory } from './factory/historico/historico.factory';
import { LoaderCompactComponent } from './component/loader-compact/loader-compact';
import { CardTableComponent } from './component/card-table/card-table';
import { SelectorComponent } from './component/selector/selector';
import { DateCatcherComponent } from './component/date-catcher/date-catcher';


export class Provider {
    public static retrieveFactories(autenticacaoService: AutenticaoServiceInterface) {
        return {
            UsuarioFactory: new UsuarioFactory(autenticacaoService),
            EmpresaFactory: new EmpresaFactory(autenticacaoService),
            EstoqueFactory: new EstoqueFactory(autenticacaoService),
            ProdutoFactory: new ProdutoFactory(autenticacaoService),
            HistoricoFactory: new HistoricoFactory(autenticacaoService),

        };
    }

    public static retrieveComponents() {
        return [
            { alias: 'loader-compact', component: LoaderCompactComponent },
            { alias: 'card-table', component: CardTableComponent },
            { alias: 'selector', component: SelectorComponent },
            { alias: 'date-catcher', component: DateCatcherComponent }
        ];
    }
}