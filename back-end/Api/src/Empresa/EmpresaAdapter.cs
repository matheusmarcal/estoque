using Domain.EmpresaDomain;

namespace Api.EmpresaApi {

    public class EmpresaAdapter {

        public static EmpresaVM ToViewModel(Empresa model, bool deep) {
            var vm = new EmpresaVM();
            vm.ID = model.ID;
            vm.Nome = model.Nome;
            vm.Cnpj = model.Cnpj;
            vm.Email = model.Email;
            vm.Telefone = model.Telefone;
            vm.Tipo = model.Tipo;

            vm.Label = model.Nome;

            return vm;
        }

        public static Empresa ToModel(EmpresaVM vm, bool deep) {
            var model = new Empresa();
            
            model.ID = vm.ID;
            model.Nome = vm.Nome;
            model.Cnpj = vm.Cnpj;
            model.Email = vm.Email;
            model.Telefone = vm.Telefone;
            model.Tipo = vm.Tipo;

            return model;
        }

    }
}