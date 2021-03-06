using System;
using System.Collections.Generic;
using System.Linq;
using Domain.UsuarioDomain;

namespace Api.UsuarioApi {

    public class UsuarioAdapter {


        public static UsuarioInfoVM ToViewModel(UsuarioInfo model, bool deep) {
            var vm = new UsuarioInfoVM();
            vm.ID = model.ID;
            vm.Nome = model.Nome;
            vm.Label = model.Nome;
            vm.CPF = model.CPF;
            vm.RG = model.RG;
            vm.DataNascimento = model.DataNascimento;
            vm.Perfis = model.Perfis.Split(',').ToList();
            return vm;
        }

        public static UsuarioInfo ToModel(UsuarioInfoVM vm, bool deep) {
            var model = new UsuarioInfo();
            model.ID = vm.ID;
            model.Nome = vm.Nome;
            model.CPF = vm.CPF;
            model.RG = vm.RG;
            model.DataNascimento = vm.DataNascimento;
            model.Perfis = String.Join(",", vm.Perfis);
            return model;
        }

        public static UsuarioVM ToViewModel(Usuario model, bool deep) {
            var vm = new UsuarioVM();
            vm.ID = model.ID;
            vm.Username = model.Username;
            vm.Password = model.Password;

            if (model.UsuarioInfo != null && deep) {
                vm.UsuarioInfo = UsuarioAdapter.ToViewModel(model.UsuarioInfo, false);
            }

            return vm;
        }

        public static Usuario ToModel(UsuarioVM vm, bool deep) {
            var model = new Usuario();
            model.ID = vm.ID;
            model.Username = vm.Username;
            model.Password = vm.Password;

            if (vm.UsuarioInfo != null && deep) {
                model.UsuarioInfo = UsuarioAdapter.ToModel(vm.UsuarioInfo, false);
            }
            
            return model;
        }

    }
}