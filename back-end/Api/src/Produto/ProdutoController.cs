using System.Collections.Generic;
using Api.Common.Base;
using Domain.ProdutoDomain;
using Domain.UsuarioDomain;
using Microsoft.AspNetCore.Mvc;

namespace Api.ProdutoApi {

    [Route("api/Produto")]
    public class ProdutoController : BaseController {

        private ProdutoService _produtoService;
        public ProdutoController(ProdutoRepository ProdutoRepository, UsuarioRepository usuarioRepository) : base(usuarioRepository) {
            this._produtoService = new ProdutoService(ProdutoRepository);
        }

        [HttpPut("add")]
        public void Add([FromBody] ProdutoVM viewModel) {
            this._produtoService.Add(viewModel);
        }

        [HttpPost("update")]
        public void Update([FromBody] ProdutoVM viewModel) {
            this._produtoService.Update(viewModel);
        }

        [HttpDelete("disable")]
        public void Disable([FromQuery] int id) {
            this._produtoService.Disable(id);
        }

        [HttpGet("detail/{id}")]
        public ProdutoVM Detail(int id) {
            return this._produtoService.Detail(id);
        }

        [HttpGet]
        public List<ProdutoVM> All() {
            return this._produtoService.All();
        }

        [HttpGet("termo")]
        public List<ProdutoVM> AllProdutos([FromQuery]string termo) {
            if(termo==null){
                termo="";
            }
            return this._produtoService.AllByTermo(termo);
        } 

    }
}