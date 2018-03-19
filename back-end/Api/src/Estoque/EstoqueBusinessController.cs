using System.Collections.Generic;
using Api.Common.Base;
using Domain.EstoqueDomain;
using Domain.UsuarioDomain;
using Microsoft.AspNetCore.Mvc;

namespace Api.EstoqueApi {

    [Route("api/estoque/business")]
    public class EstoqueBusinessController : BaseController {

        private EstoqueService _estoqueService;
        public EstoqueBusinessController(EstoqueRepository estoqueRepository, UsuarioRepository usuarioRepository) : base(usuarioRepository) {
            this._estoqueService = new EstoqueService(estoqueRepository);
        }

        [HttpGet("geral")]
        public List <EstoqueProdutoVM> EstoqueGeral() {
            return this._estoqueService.EstoqueGeral();
        }

        

    }
}