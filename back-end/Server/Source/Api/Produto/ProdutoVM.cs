using Api.Common.Base;
using Domain.ProdutoDomain;

namespace Api.ProdutoApi {
    public class ProdutoVM : BaseVM<int> {
        public string Codigo { get; set; }
        public string Descricao { get; set; }

    }
}