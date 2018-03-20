using System.Collections.Generic;
using Api.Common.Base;
using Domain.EstoqueDomain;
using Domain.UsuarioDomain;
using Microsoft.AspNetCore.Mvc;

namespace Api.EstoqueApi {

    [Route("api/estoque")]
    public class EstoqueController : BaseController {

        private EstoqueService _estoqueService;
        public EstoqueController(EstoqueRepository estoqueRepository, UsuarioRepository usuarioRepository) : base(usuarioRepository) {
            this._estoqueService = new EstoqueService(estoqueRepository);
        }

        [HttpPut("add")]
        public void Add([FromBody] EstoqueVM viewModel) {
            this._estoqueService.Add(viewModel);
        }

        [HttpPost("update")]
        public void Update([FromBody] EstoqueVM viewModel) {
            this._estoqueService.Update(viewModel);
        }

        [HttpDelete("disable")]
        public void Disable([FromQuery] int id) {
            this._estoqueService.Disable(id);
        }

        [HttpGet("{id}")]
        public EstoqueVM Detail(int id) {
            return this._estoqueService.Detail(id);
        }

        [HttpGet]
        public List<EstoqueVM> All() {
            return this._estoqueService.All();
        }

    }
}