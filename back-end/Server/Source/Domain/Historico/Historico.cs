using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.EmpresaDomain;
using Domain.EstoqueDomain;

namespace Domain.HistoricoDomain {
    public class Historico
    {
        public int ID { get; set; }
        public int Quantidade { get; set; }
        public string Nfe { get; set; }

        public Estoque Estoque { get; set; }
        public Empresa Comprador { get; set; }
    }
}