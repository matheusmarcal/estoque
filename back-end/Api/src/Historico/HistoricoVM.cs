using Api.Common.Base;
using Domain.EmpresaDomain;
using Domain.EstoqueDomain;
using Domain.HistoricoDomain;

namespace Api.HistoricoApi {
    public class HistoricoVM : BaseVM<int> {
        public Estoque Estoque { get; set; }
        public Empresa Empresa { get; set; }
        public int Quantidade { get; set; }
        public string Nfe { get; set; }

    }
}