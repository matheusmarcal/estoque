import { Vue, Component, Prop } from 'vue-property-decorator';
import { CardTableMenu, CardTableMenuEntry, CardTableColumn } from '../../../../../ezs-common/src/component/card-table/card-table.types';
import { AppBroadcastEventBus, AppBroadcastEvent } from '../../../app.broadcast-event-bus';
import { RouterPathType } from '../../../../../ezs-common/src/model/client/router-path-type.model';
import { AppRouter } from '../../../app.router';
import { Factory } from '../../../module/constant/factory.constant';
import { EstoqueModel } from '../../../../../ezs-common/src/model/server/estoque.model';
import { NotifyUtil, NOTIFY_TYPE } from '../../../../../ezs-common/src/util/notify/notify.util';
import { ApplicationService } from '../../../module/service/application.service';
import { ProdutoModel } from '../../../../../ezs-common/src/model/server/produto.model';
import { EmpresaModel } from '../../../../../ezs-common/src/model/server/empresa.model';
import { I18N_ERROR_GENERIC } from '../../../../../ezs-common/src/constant/i18n-template-messages.contant';
import { AppRouterPath } from '../../../app.router.path';

interface UI {
    Estoques: Array<EstoqueModel>;
}

@Component({
    template: require('./page-estoque.html')
})
export class PageEstoqueComponent extends Vue {

    @Prop()
    alias: string;
    @Prop()
    operation: RouterPathType;
    
    model: EstoqueModel = new EstoqueModel();
    
    constructor() {
        super();
    }

    created() {

    }

    queryProduto = Factory.ProdutoFactory.allByTermo;
    queryEmpresa = Factory.EmpresaFactory.allByTermo;

    produtoLabel= (item: ProdutoModel) => {
        let labelObj = {} as any;
        labelObj.key = item.descricao;
        labelObj.label = `<div><span>${item.descricao}</span><div><div><span style="float:left;">${item.codigo}</span></div>`;
        return labelObj;
    }

    empresaLabel= (item: EmpresaModel) => {
        let labelObj = {} as any;
        labelObj.key = item.nome;
        labelObj.label = `<div><span>${item.nome}</span><div><div><span style="float:left;">${item.cnpj}</span></div>`;
        return labelObj;
    }
    
    async mounted() {
        try {
            AppBroadcastEventBus.$emit(AppBroadcastEvent.EXIBIR_LOADER);
            if (this.operation === RouterPathType.upd) {
                this.model = await Factory.EstoqueFactory.detail(this.$route.params.id); 
            }
        }
        catch (e) {
            NotifyUtil.exception(e, ApplicationService.getLanguage());
            AppRouter.back();
        }
        finally {
            AppBroadcastEventBus.$emit(AppBroadcastEvent.ESCONDER_LOADER);
        }
    }

    async save() {
        try {
            AppBroadcastEventBus.$emit(AppBroadcastEvent.EXIBIR_LOADER);
            switch (this.operation) {
                case (RouterPathType.add): {
                    await Factory.EstoqueFactory.add(this.model);
                    break;
                }
                case (RouterPathType.upd): {
                    await Factory.EstoqueFactory.update(this.model);
                    break;
                }
            }
            NotifyUtil.successG(I18N_ERROR_GENERIC.MODELO_SALVAR, ApplicationService.getLanguage());
            AppRouter.push(AppRouterPath.ESTOQUE);
        }
        catch (e) {
            NotifyUtil.exception(e, ApplicationService.getLanguage());
        }
        finally {
            AppBroadcastEventBus.$emit(AppBroadcastEvent.ESCONDER_LOADER);
        }
    }


}