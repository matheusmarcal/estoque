using System;
using System.Collections.Generic;
using Api.Common.Base;
using Domain.UsuarioDomain;
using Microsoft.AspNetCore.Mvc;

namespace Api.UsuarioApi {

    [Route("api/usuario")]
    public class UsuarioController : BaseController {

        private UsuarioService usuarioService;

        public UsuarioController(UsuarioRepository usuarioRepository) : base(usuarioRepository) {
            this.usuarioService = new UsuarioService(usuarioRepository);
        }

        [HttpPut("add")]
        public void Add([FromBody] UsuarioVM viewModel) {
            this.usuarioService.Add(viewModel);
        }

        [HttpPost("update")]
        public void Update([FromBody] UsuarioVM viewModel) {
            this.usuarioService.Update(viewModel);
        }

        [HttpDelete("disable")]
        public void Disable(string id) {
            this.usuarioService.Disable(id);
        }

        [HttpGet("{id}")]
        public UsuarioVM Detail(string id, [FromQuery]string termo) {
            var x = this.getLogged();
            return this.usuarioService.Detail(id);
        }

        [HttpGet]
        public List<UsuarioVM> All() {
            return this.usuarioService.All();
        }


    }
}