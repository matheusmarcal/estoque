using Domain.EstoqueDomain;

namespace Api.EstoqueApi {

    public class EstoqueAdapter {

        public static EstoqueVM ToViewModel(Estoque model, bool deep) {
            var vm = new EstoqueVM();
            vm.ID = model.ID;
            vm.Empresa = model.Empresa;
            vm.Produto = model.Produto;
            vm.Op = model.Op;
            vm.Nfe = model.Nfe;
            vm.Quantidade = model.Quantidade;
            vm.Posicao = model.Posicao;
            
            return vm;
        }

        public static Estoque ToModel(EstoqueVM vm, bool deep) {
            var model = new Estoque();
            
            model.ID = vm.ID;
            model.Empresa = vm.Empresa;
            model.Produto = vm.Produto;
            model.Op = vm.Op;
            model.Nfe = vm.Nfe;
            model.Quantidade = vm.Quantidade;
            model.Posicao = vm.Posicao;

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