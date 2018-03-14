using Domain.ProdutoDomain;

namespace Api.ProdutoApi {

    public class ProdutoAdapter {

        public static ProdutoVM ToViewModel(Produto model, bool deep) {
            var vm = new ProdutoVM();
            vm.ID = model.ID;
            vm.Codigo = model.Codigo;
            vm.Descricao = model.Descricao;

            vm.Label = model.Descricao;

            return vm;
        }

        public static Produto ToModel(ProdutoVM vm, bool deep) {
            var model = new Produto();
            
            model.ID = vm.ID;
            model.Codigo = vm.Codigo;
            model.Descricao = vm.Descricao;


            return model;
        }

    }
}