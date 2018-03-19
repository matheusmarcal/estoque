using System.Collections.Generic;
using System.Linq;
using Domain.EstoqueDomain;

namespace Api.EstoqueApi {

    public class EstoqueService {

        private EstoqueRepository _estoqueRepository;

        public EstoqueService(EstoqueRepository estoqueRepository) {
            this._estoqueRepository = estoqueRepository;
        }

        public void Add(EstoqueVM viewModel) {
            var model = EstoqueAdapter.ToModel(viewModel, true);
            this._estoqueRepository.Add(model);
            this._estoqueRepository.SaveChanges();
        }

        public void Update(EstoqueVM viewModel) {
            var model = EstoqueAdapter.ToModel(viewModel, true);
            this._estoqueRepository.Update(model);
            this._estoqueRepository.SaveChanges();
        }

        public void Disable(int id) {
            this._estoqueRepository.Disable(id);
            this._estoqueRepository.SaveChanges();
        }

        public EstoqueVM Detail(int id) {
            return EstoqueAdapter.ToViewModel(this._estoqueRepository.Get(id), true);
        }

        public List < EstoqueVM > All() {
            return this._estoqueRepository.GetAll(true).Select(x => EstoqueAdapter.ToViewModel(x, true)).ToList();
        }

        public List < EstoqueProdutoVM > EstoqueGeral() {
            return this._estoqueRepository.GetAllDistinctByProduto().Select(x=> EstoqueAdapter.ToEstoqueProdutoViewModel(x,this._estoqueRepository.GetDisponiveisByProduto(x.Produto.ID), true)).ToList();
        }
    }
}