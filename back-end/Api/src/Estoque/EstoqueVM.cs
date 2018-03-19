using Api.Common.Base;
using Domain.EmpresaDomain;
using Domain.EstoqueDomain;
using Domain.ProdutoDomain;

namespace Api.EstoqueApi {
    public class EstoqueVM : BaseVM<int> {
        public int Quantidade { get; set; }
        public string Op { get; set; }
        public string Posicao { get; set; }
        public string Nfe { get; set; }

        public Produto Produto { get; set; }
        public Empresa Empresa { get; set; }

    }
}