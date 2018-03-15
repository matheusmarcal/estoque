import { Vue, Component, Prop } from 'vue-property-decorator';
import { CardTableMenu, CardTableMenuEntry, CardTableColumn } from '../../../../../ezs-common/src/component/card-table/card-table.types';
import { AppBroadcastEventBus, AppBroadcastEvent } from '../../../app.broadcast-event-bus';
import { RouterPathType } from '../../../../../ezs-common/src/model/client/router-path-type.model';
import { AppRouter } from '../../../app.router';
import { Factory } from '../../../module/constant/factory.constant';
import { EmpresaModel, TipoClieteModel } from '../../../../../ezs-common/src/model/server/empresa.model';
import { NotifyUtil, NOTIFY_TYPE } from '../../../../../ezs-common/src/util/notify/notify.util';
import { I18N_MESSAGE } from '../../../../../ezs-common/src/constant/i18n-template-messages.contant';
import { ApplicationService } from '../../../module/service/application.service';
import { TipoClienteEnumLabel } from '../../../module/constant/enum-label.constant';

interface UI {
    Empresas: Array<EmpresaModel>;
    tipoButtons: Array < any > ;
}

@Component({
    template: require('./page-empresa.html')
})
export class PageEmpresaComponent extends Vue {

    @Prop()
    alias: string;
    @Prop()
    operation: RouterPathType;
    
    model: EmpresaModel = new EmpresaModel();
    
    ui: UI = {
        Empresas: undefined,
        tipoButtons: TipoClienteEnumLabel
    };

    constructor() {
        super();
    }

    created() {

    }
    
    async mounted() {
        try {
            AppBroadcastEventBus.$emit(AppBroadcastEvent.EXIBIR_LOADER);
            if (this.operation === RouterPathType.upd) {
                this.model = await Factory.EmpresaFactory.detail(this.$route.params.id); 
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
                    await Factory.EmpresaFactory.add(this.model);
                    break;
                }
                case (RouterPathType.upd): {
                    await Factory.EmpresaFactory.update(this.model);
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

    public toggleTipoCliente(tipo: TipoClieteModel) {
            this.model.tipo = tipo;
    }

    public isTipoClienteSelected(tipo: TipoClieteModel) {
        return this.model.tipo === tipo;
    }


}