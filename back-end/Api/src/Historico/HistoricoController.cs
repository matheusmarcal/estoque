using System.Collections.Generic;
using Api.Common.Base;
using Domain.HistoricoDomain;
using Domain.UsuarioDomain;
using Microsoft.AspNetCore.Mvc;

namespace Api.HistoricoApi {

    [Route("api/historico")]
    public class HistoricoController : BaseController {

        private HistoricoService _historicoService;
        public HistoricoController(HistoricoRepository historicoRepository, UsuarioRepository usuarioRepository) : base(usuarioRepository) {
            this._historicoService = new HistoricoService(historicoRepository);
        }

        [HttpPut("add")]
        public void Add([FromBody] HistoricoVM viewModel) {
            this._historicoService.Add(viewModel);
        }

        [HttpPost("update")]
        public void Update([FromBody] HistoricoVM viewModel) {
            this._historicoService.Update(viewModel);
        }

        [HttpDelete("disable")]
        public void Disable([FromQuery] int id) {
            this._historicoService.Disable(id);
        }

        [HttpGet("{id}")]
        public HistoricoVM Detail(int id) {
            return this._historicoService.Detail(id);
        }

        [HttpGet]
        public List<HistoricoVM> All() {
            return this._historicoService.All();
        }

    }
}