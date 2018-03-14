using Domain.HistoricoDomain;

namespace Api.HistoricoApi {

    public class HistoricoAdapter {

        public static HistoricoVM ToViewModel(Historico model, bool deep) {
            var vm = new HistoricoVM();
            vm.ID = model.ID;
            vm.Estoque = model.Estoque;
            vm.Empresa = model.Empresa;
            vm.Quantidade = model.Quantidade;
            vm.Nfe = model.Nfe;

            return vm;
        }

        public static Historico ToModel(HistoricoVM vm, bool deep) {
            var model = new Historico();
            
            model.ID = vm.ID;
            model.Estoque = vm.Estoque;
            model.Empresa = vm.Empresa;
            model.Quantidade = vm.Quantidade;
            model.Nfe = vm.Nfe;

            return model;
        }

    }
}