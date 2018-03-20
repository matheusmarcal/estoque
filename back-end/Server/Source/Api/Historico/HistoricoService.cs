using System.Collections.Generic;
using System.Linq;
using Domain.HistoricoDomain;

namespace Api.HistoricoApi {

    public class HistoricoService {

        private HistoricoRepository _historicoRepository;

        public HistoricoService(HistoricoRepository historicoRepository) {
            this._historicoRepository = historicoRepository;
        }

        public void Add(HistoricoVM viewModel) {
            var model = HistoricoAdapter.ToModel(viewModel, true);
            this._historicoRepository.Add(model);
            this._historicoRepository.SaveChanges();
        }

        public void Update(HistoricoVM viewModel) {
            var model = HistoricoAdapter.ToModel(viewModel, true);
            this._historicoRepository.Update(model);
            this._historicoRepository.SaveChanges();
        }

        public void Disable(int id) {
            this._historicoRepository.Disable(id);
            this._historicoRepository.SaveChanges();
        }

        public HistoricoVM Detail(int id) {
            return HistoricoAdapter.ToViewModel(this._historicoRepository.Get(id), true);
        }

        public List < HistoricoVM > All() {
            return this._historicoRepository.GetAll(true).Select(x => HistoricoAdapter.ToViewModel(x, true)).ToList();
        }
    }
}