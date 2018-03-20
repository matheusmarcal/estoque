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
import { DropdownComponent } from './component/dropdown/dropdown';
import { FormBuilderComponent } from './component/form-builder/form-builder';
import { FlaggerComponent } from './component/flagger/flagger';


export class Provider {
    public static retrieveFactories(autenticacaoService: AutenticaoServiceInterface, interceptorOnRequestSuccess: any, interceptorOnRequestError: any) {
        return {
            UsuarioFactory: new UsuarioFactory(autenticacaoService, interceptorOnRequestSuccess, interceptorOnRequestError),
            EmpresaFactory: new EmpresaFactory(autenticacaoService, interceptorOnRequestSuccess, interceptorOnRequestError),
            EstoqueFactory: new EstoqueFactory(autenticacaoService, interceptorOnRequestSuccess, interceptorOnRequestError),
            ProdutoFactory: new ProdutoFactory(autenticacaoService, interceptorOnRequestSuccess, interceptorOnRequestError),
            HistoricoFactory: new HistoricoFactory(autenticacaoService, interceptorOnRequestSuccess, interceptorOnRequestError),
        };
    }

    public static retrieveComponents() {
        return [
            { alias: 'loader-compact', component: LoaderCompactComponent },
            { alias: 'card-table', component: CardTableComponent },
            { alias: 'selector', component: SelectorComponent },
            { alias: 'date-catcher', component: DateCatcherComponent },
            { alias: 'dropdown', component: DropdownComponent },
            { alias: 'flagger', component: FlaggerComponent },
            { alias: 'form-builder', component: FormBuilderComponent }
        ];
    }
}