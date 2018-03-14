using Domain.EmpresaDomain;
using Domain.ProdutoDomain;

namespace Domain.EstoqueDomain {
    public class Estoque
    {
        public int ID { get; set; }
        public float Quantidade { get; set; }
        public string Op { get; set; }
        public string Posicao { get; set; }
        public string Nfe { get; set; }

        public Produto Produto { get; set; }
        public Empresa Empresa { get; set; }
    }
}