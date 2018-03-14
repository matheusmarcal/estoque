using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Common;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Domain.ProdutoDomain {
    public class Produto : IBaseModel
    {
        public int ID { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public DateTime? Ativo { get; set; }
    }
}