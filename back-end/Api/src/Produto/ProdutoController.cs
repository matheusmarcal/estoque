using System.Collections.Generic;
using Api.Common.Base;
using Domain.ProdutoDomain;
using Domain.UsuarioDomain;
using Microsoft.AspNetCore.Mvc;

namespace Api.ProdutoApi {

    [Route("api/Produto")]
    public class ProdutoController : BaseController {

        private ProdutoService _ProdutoService;
        public ProdutoController(ProdutoRepository ProdutoRepository, UsuarioRepository usuarioRepository) : base(usuarioRepository) {
            this._ProdutoService = new ProdutoService(ProdutoRepository);
        }

        [HttpPut("add")]
        public void Add([FromBody] ProdutoVM viewModel) {
            this._ProdutoService.Add(viewModel);
        }

        [HttpPost("update")]
        public void Update([FromBody] ProdutoVM viewModel) {
            this._ProdutoService.Update(viewModel);
        }

        [HttpDelete("disable")]
        public void Disable([FromQuery] int id) {
            this._ProdutoService.Disable(id);
        }

        [HttpGet("{id}")]
        public ProdutoVM Detail(int id) {
            return this._ProdutoService.Detail(id);
        }

        [HttpGet]
        public List<ProdutoVM> All() {
            return this._ProdutoService.All();
        }

    }
}