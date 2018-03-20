using Domain.EstoqueDomain;

namespace Api.EstoqueApi {

    public class EstoqueAdapter {

        public static EstoqueVM ToViewModel(Estoque model, bool deep) {
            var vm = new EstoqueVM();
            vm.ID = model.ID;
            vm.Quantidade = model.Quantidade;
            vm.Op = model.Op;
            vm.Posicao = model.Posicao;
            vm.Nfe = model.Nfe;
            vm.Produto = model.Produto;
            vm.Empresa = model.Empresa;

            return vm;
        }

        public static Estoque ToModel(EstoqueVM vm, bool deep) {
            var model = new Estoque();
            
            model.ID = vm.ID;
            model.Quantidade = vm.Quantidade;
            model.Op = vm.Op;
            model.Posicao = vm.Posicao;
            model.Nfe = vm.Nfe;
            model.Produto = vm.Produto;
            model.Empresa = vm.Empresa;

            return model;
        }

        public static EstoqueProdutoVM ToEstoqueProdutoViewModel(Estoque model, int disponivel,bool deep) {
            var vm = new EstoqueProdutoVM();

            vm.Produto = model.Produto;
            vm.Disponivel = disponivel;

            return vm;
        }

    }
}