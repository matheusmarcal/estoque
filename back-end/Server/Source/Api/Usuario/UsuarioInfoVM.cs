
using System;
using System.Collections.Generic;
using Api.Common.Base;

namespace Api.UsuarioApi {

    public class UsuarioInfoVM : BaseVM<string> {

        public UsuarioInfoVM() {
            
        }

        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public bool Ativo { get; set; } = true;
        public List<string> Perfis { get; set; }

    }
}