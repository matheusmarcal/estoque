using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.EmpresaDomain {
    public enum Tipo { Cliente, Fornecedor, Ambos }

    public class Empresa : IBaseModel
    {
        public int ID { get; set; }
        public string Cnpj { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public Tipo Tipo { get; set; } = Tipo.Cliente;

        public DateTime? Ativo { get; set; }
    }
    
}

