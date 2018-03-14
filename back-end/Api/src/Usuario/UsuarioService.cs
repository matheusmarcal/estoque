using System.Collections.Generic;
using System.Linq;

using Domain.UsuarioDomain;

namespace Api.UsuarioApi {

    public class UsuarioService {

        private UsuarioRepository _usuarioRepository;

        public UsuarioService(UsuarioRepository usuarioRepository) {
            this._usuarioRepository = usuarioRepository;
        }

        public void Add(UsuarioVM viewModel) {
            var model = UsuarioAdapter.ToModel(viewModel, true);
            this._usuarioRepository.Add(model);

            this._usuarioRepository.SaveChanges();
        }

        public void Update(UsuarioVM viewModel) {
            var model = UsuarioAdapter.ToModel(viewModel, true);
            this._usuarioRepository.Update(model);

            this._usuarioRepository.SaveChanges();
        }


        public void Disable(string id) {
            this._usuarioRepository.Disable(id);
        }

        public UsuarioVM Detail(string id) {
            var usuario = UsuarioAdapter.ToViewModel(this._usuarioRepository.Get(id), true);
            usuario.UsuarioInfo = this.DetailUsuarioInfo(id);
            return usuario;
        }

        public UsuarioInfoVM DetailUsuarioInfo(string id) {
            var usuarioInfo = this._usuarioRepository.GetUsuarioInfo(id);
            return UsuarioAdapter.ToViewModel(usuarioInfo, true);
        }

        public List<UsuarioVM> All() {
            return this._usuarioRepository.GetAll(true).Select(x => UsuarioAdapter.ToViewModel(x, true)).ToList();
        }

        public List<UsuarioInfoVM> GetAllByTermo(string perfil, string termo) {
            return this._usuarioRepository.GetAllByTermo(perfil, termo).Select(x => UsuarioAdapter.ToViewModel(x, true)).ToList();
        }

    }
}