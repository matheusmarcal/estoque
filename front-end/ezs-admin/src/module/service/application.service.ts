import { I18N_LANG, I18N_ENUM_LABELS_CONSTANTS } from '../../../../ezs-common/src/constant/i18n-template-messages.contant';
import { UsuarioInfoModel } from '../../../../ezs-common/src/model/server/usuario-info.model';
import { ENUM_CONTANT } from '../../../../ezs-common/src/constant/enum.contant';
import { Factory } from '../constant/factory.constant';

class Service {

    private language: I18N_LANG = I18N_LANG.ptBR;
    private usuarioInfo: UsuarioInfoModel;
    private views: Array < string > ;
    private admin: boolean;
    private loading: boolean = false;

    setLanguage(language: I18N_LANG) {
        this.language = language;
    }

    getLanguage() {
        return this.language;
    }

    setUsuarioInfo(usuarioInfo: UsuarioInfoModel) {
        this.usuarioInfo = usuarioInfo;
    }

    getUsuarioInfo() {
        return this.usuarioInfo;
    }

    setViews(views: Array < string > ) {
        this.views = views;
    }

    getViews() {
        return this.views;
    }

    getEnumLabels(enumerable: ENUM_CONTANT) {
        return I18N_ENUM_LABELS_CONSTANTS.filter(x => x.enumerable === enumerable && x.lang === this.language);
    }

    setLoading(loading: boolean) {
        this.loading = !!loading;
    }

    isLoading() {
        return this.loading;
    }

    isReady() {
        return true;
    }

    isAdmin() {
        return this.admin;
    }

    configureDefaults = async () => {
        this.setLoading(true);
        // this.views = await Factory.UsuarioFactory.meAuthorizedView();
        // this.usuarioInfo = await Factory.UsuarioFactory.me();
        this.setLoading(false);
    }

}

export const ApplicationService = new Service();