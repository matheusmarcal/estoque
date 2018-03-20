using Api.Common.Base;
using Domain.EmpresaDomain;

namespace Api.EmpresaApi {
    public class EmpresaVM : BaseVM<int> {
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public Tipo Tipo { get; set; }

    }
}