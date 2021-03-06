import { Vue, Component, Prop } from 'vue-property-decorator';
import { CardTableMenu, CardTableMenuEntry, CardTableColumn } from '../../../../../ezs-common/src/component/card-table/card-table.types';
import { AppBroadcastEventBus, AppBroadcastEvent } from '../../../app.broadcast-event-bus';
import { RouterPathType } from '../../../../../ezs-common/src/model/client/router-path-type.model';
import { AppRouter } from '../../../app.router';
import { Factory } from '../../../module/constant/factory.constant';
import { HistoricoModel } from '../../../../../ezs-common/src/model/server/historico.model';
import { NotifyUtil, NOTIFY_TYPE } from '../../../../../ezs-common/src/util/notify/notify.util';
import { ApplicationService } from '../../../module/service/application.service';
import { I18N_ERROR_GENERIC } from '../../../../../ezs-common/src/constant/i18n-template-messages.contant';
import { EmpresaModel } from '../../../../../ezs-common/src/model/server/empresa.model';

interface UI {
    Historicos: Array<HistoricoModel>;
}

@Component({
    template: require('./page-historico.html')
})
export class PageHistoricoComponent extends Vue {

    @Prop()
    alias: string;
    @Prop()
    operation: RouterPathType;

    model: HistoricoModel = new HistoricoModel();

    constructor() {
        super();
    }

    created() {

    }

    queryEmpresa = Factory.EmpresaFactory.allByTermo;

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
                this.model = await Factory.HistoricoFactory.detail(this.$route.params.id);
            }
            else if (this.operation === RouterPathType.add && !!this.$route.params.idEstoque) {
                let estoque = await Factory.EstoqueFactory.detail(this.$route.params.idEstoque);
                this.model.estoque = estoque;
                setTimeout(()=>{
                    this.$forceUpdate();
                });
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
                    await Factory.HistoricoFactory.add(this.model);
                    break;
                }
                case (RouterPathType.upd): {
                    await Factory.HistoricoFactory.update(this.model);
                    break;
                }
            }
            NotifyUtil.successG(I18N_ERROR_GENERIC.MODELO_SALVAR, ApplicationService.getLanguage());
        }
        catch (e) {
            NotifyUtil.exception(e, ApplicationService.getLanguage());
        }
        finally {
            AppBroadcastEventBus.$emit(AppBroadcastEvent.ESCONDER_LOADER);
        }
    }


}