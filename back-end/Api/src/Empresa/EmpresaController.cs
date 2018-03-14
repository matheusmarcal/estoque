using System.Collections.Generic;
using Api.Common.Base;
using Domain.EmpresaDomain;
using Domain.UsuarioDomain;
using Microsoft.AspNetCore.Mvc;

namespace Api.EmpresaApi {

    [Route("api/empresa")]
    public class EmpresaController : BaseController {

        private EmpresaService _empresaService;
        public EmpresaController(EmpresaRepository empresaRepository, UsuarioRepository usuarioRepository) : base(usuarioRepository) {
            this._empresaService = new EmpresaService(empresaRepository);
        }

        [HttpPut("add")]
        public void Add([FromBody] EmpresaVM viewModel) {
            this._empresaService.Add(viewModel);
        }

        [HttpPost("update")]
        public void Update([FromBody] EmpresaVM viewModel) {
            this._empresaService.Update(viewModel);
        }

        [HttpDelete("disable")]
        public void Disable([FromQuery] int id) {
            this._empresaService.Disable(id);
        }

        [HttpGet("{id}")]
        public EmpresaVM Detail(int id) {
            return this._empresaService.Detail(id);
        }

        [HttpGet]
        public List<EmpresaVM> All() {
            return this._empresaService.All();
        }

    }
}