using System;
using System.Collections.Generic;
using System.Linq;
using Domain.ProdutoDomain;

namespace Api.ProdutoApi {

    public class ProdutoService {

        private ProdutoRepository _ProdutoRepository;

        public ProdutoService(ProdutoRepository ProdutoRepository) {
            this._ProdutoRepository = ProdutoRepository;
        }

        public void Add(ProdutoVM viewModel) {
            var model = ProdutoAdapter.ToModel(viewModel, true);
            this._ProdutoRepository.Add(model);
            this._ProdutoRepository.SaveChanges();
        }

        public void Update(ProdutoVM viewModel) {
            var model = ProdutoAdapter.ToModel(viewModel, true);
            this._ProdutoRepository.Update(model);
            this._ProdutoRepository.SaveChanges();
        }

        public void Disable(int id) {
            this._ProdutoRepository.Disable(id);
            this._ProdutoRepository.SaveChanges();
        }

        public ProdutoVM Detail(int id) {
            return ProdutoAdapter.ToViewModel(this._ProdutoRepository.Get(id), true);
        }

        public List < ProdutoVM > All() {
            return this._ProdutoRepository.GetAll(true).Select(x => ProdutoAdapter.ToViewModel(x, true)).ToList();
        }

        public List<ProdutoVM> GetProdutoByTermo(string codigo) {
            return this._ProdutoRepository.GetAllByTermo(codigo).Select(x => ProdutoAdapter.ToViewModel(x, true)).ToList();
        }

        public List<ProdutoVM> AllByTermo(string termo) {
            return this._ProdutoRepository.GetAllByTermo(termo).Select(x=>ProdutoAdapter.ToViewModel(x,true)).ToList();
        }
    }
}