using Api.Common.Base;
using Domain.EmpresaDomain;
using Domain.EstoqueDomain;
using Domain.ProdutoDomain;

namespace Api.EstoqueApi {
    public class EstoqueProdutoVM : BaseVM<int> {

        public Produto Produto { get; set; }
        public int Disponivel { get; set; }


    }
}