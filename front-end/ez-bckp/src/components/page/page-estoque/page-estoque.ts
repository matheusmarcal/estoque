import { Vue, Component, Prop } from 'vue-property-decorator';
import { CardTableMenu, CardTableMenuEntry, CardTableColumn } from '../../../../../ezs-common/src/component/card-table/card-table.types';
import { AppBroadcastEventBus, AppBroadcastEvent } from '../../../app.broadcast-event-bus';
import { RouterPathType } from '../../../../../ezs-common/src/model/client/router-path-type.model';
import { AppRouter } from '../../../app.router';
import { Factory } from '../../../module/constant/factory.constant';
import { EstoqueModel } from '../../../../../ezs-common/src/model/server/estoque.model';
import { NotifyUtil, NOTIFY_TYPE } from '../../../../../ezs-common/src/util/notify/notify.util';
import { I18N_MESSAGE } from '../../../../../ezs-common/src/constant/i18n-template-messages.contant';
import { ApplicationService } from '../../../module/service/application.service';
import { ProdutoModel } from '../../../../../ezs-common/src/model/server/produto.model';
import { EmpresaModel } from '../../../../../ezs-common/src/model/server/empresa.model';

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
        labelObj.key = item.label;
        labelObj.label = `<div><span>${item.descricao}</span><div><div><span style="float:left;">${item.codigo}</span></div>`;
        return labelObj;
    }

    empresaLabel= (item: EmpresaModel) => {
        let labelObj = {} as any;
        labelObj.key = item.label;
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
            NotifyUtil.notifyI18NError(I18N_MESSAGE.CONSULTAR_FALHA, ApplicationService.getLanguage(), NOTIFY_TYPE.ERROR, e);
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
            NotifyUtil.notifyI18N(I18N_MESSAGE.MODELO_SALVAR, ApplicationService.getLanguage(), NOTIFY_TYPE.SUCCESS);
        }
        catch (e) {
            NotifyUtil.notifyI18NError(I18N_MESSAGE.MODELO_SALVAR_FALHA, ApplicationService.getLanguage(), NOTIFY_TYPE.ERROR, e);
        }
        finally {
            AppBroadcastEventBus.$emit(AppBroadcastEvent.ESCONDER_LOADER);
        }
    }


}