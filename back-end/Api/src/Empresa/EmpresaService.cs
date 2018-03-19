using System.Collections.Generic;
using System.Linq;
using Domain.EmpresaDomain;

namespace Api.EmpresaApi {

    public class EmpresaService {

        private EmpresaRepository _EmpresaRepository;

        public EmpresaService(EmpresaRepository EmpresaRepository) {
            this._EmpresaRepository = EmpresaRepository;
        }

        public void Add(EmpresaVM viewModel) {
            var model = EmpresaAdapter.ToModel(viewModel, true);
            this._EmpresaRepository.Add(model);
            this._EmpresaRepository.SaveChanges();
        }

        public void Update(EmpresaVM viewModel) {
            var model = EmpresaAdapter.ToModel(viewModel, true);
            this._EmpresaRepository.Update(model);
            this._EmpresaRepository.SaveChanges();
        }

        public void Disable(int id) {
            this._EmpresaRepository.Disable(id);
            this._EmpresaRepository.SaveChanges();
        }

        public EmpresaVM Detail(int id) {
            return EmpresaAdapter.ToViewModel(this._EmpresaRepository.Get(id), true);
        }

        public List < EmpresaVM > All() {
            return this._EmpresaRepository.GetAll(true).Select(x => EmpresaAdapter.ToViewModel(x, true)).ToList();
        }
        public List<EmpresaVM> GetEmpresaByTermo(string nome) {
            return this._EmpresaRepository.GetAllByTermo(nome).Select(x => EmpresaAdapter.ToViewModel(x, true)).ToList();
        }

        public List<EmpresaVM> AllByTermo(string termo) {
            return this._EmpresaRepository.GetAllByTermo(termo).Select(x=>EmpresaAdapter.ToViewModel(x,true)).ToList();
        }
    }
}