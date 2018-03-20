import { EnumLabel } from '../../../../ezs-common/src/model/client/enum-label.model';
import { TipoClieteModel } from '../../../../ezs-common/src/model/server/empresa.model';

export const TipoClienteEnumLabel: Array<EnumLabel> = [
    { labelShort: 'Cliente', label: 'Cliente', value: TipoClieteModel.Cliente },
    { labelShort: 'Fornecedor', label: 'Fornecedor', value: TipoClieteModel.Fornecedor },
    { labelShort: 'Ambos', label: 'Ambos', value: TipoClieteModel.Ambos }
    
];