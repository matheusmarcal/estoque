using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.EmpresaDomain;
using Domain.UsuarioDomain;
using Domain.ProdutoDomain;
using Microsoft.EntityFrameworkCore;

namespace Domain.Common {
    public static class BaseContextInitializer {
        public static void Initialize(BaseContext context) {
            var listUsuario = getBaseUsuarios();
            var listEmpresa = getBaseEmpresa();
            var listProduto = getBaseProduto();
            context.Usuarios.AddRange(listUsuario);
            context.Empresas.AddRange(listEmpresa);
            context.Produtos.AddRange(listProduto);


            context.SaveChanges();
        }


        public static Usuario[] getBaseUsuarios() {
            var carvalho = new Usuario() {
                Username = "dev",
                Password = "dev",
                Email = "dev@ezschool.com",
            };
            var carvalhoInfo = new UsuarioInfo() {
                ID = carvalho.ID,
                Nome = "Matheus Carvalho",
                DataNascimento = DateTime.ParseExact("1994-12-19", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                Perfis = String.Join(",", new string[] { UsuarioPerfil.ADMIN, UsuarioPerfil.PROFESSOR, UsuarioPerfil.ALUNO, UsuarioPerfil.COMPANHIA }),
                CPF = "42187917835",
                RG = "421920816"
            };
            carvalho.UsuarioInfo = carvalhoInfo;

            var marcal = new Usuario() {
                Username = "qa",
                Password = "qa",
                Email = "qa@ezschool.com"
            };
            var marcalInfo = new UsuarioInfo() {
                ID = marcal.ID,
                Nome = "Matheus Marçal",
                DataNascimento = DateTime.ParseExact("1994-12-19", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                Perfis = String.Join(",", new string[] { UsuarioPerfil.ADMIN, UsuarioPerfil.PROFESSOR, UsuarioPerfil.ALUNO, UsuarioPerfil.COMPANHIA }),
                CPF = "42187917835",
                RG = "421920816"
            };
            marcal.UsuarioInfo = marcalInfo;

            var thais = new Usuario() {
                Username = "thsmimi",
                Password = "12345678",
                Email = "tha_araujo@hotmail.com"
            };
            var thaisInfo = new UsuarioInfo() {
                ID = thais.ID,
                Nome = "Thais Araújo Santos",
                DataNascimento = DateTime.ParseExact("1994-12-19", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                Perfis = String.Join(",", new string[] { UsuarioPerfil.ADMIN, UsuarioPerfil.PROFESSOR, UsuarioPerfil.ALUNO, UsuarioPerfil.COMPANHIA }),
                CPF = "52176819820",
                RG = "510984128"
            };
            thais.UsuarioInfo = thaisInfo;

            var barbara = new Usuario() {
                Username = "anabarbara",
                Password = "12345678",
                Email = "ana_barbara@hotmail.com"
            };
            var barbaraInfo = new UsuarioInfo() {
                ID = barbara.ID,
                Nome = "Ana Bárbara",
                DataNascimento = DateTime.ParseExact("1994-12-19", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                Perfis = String.Join(",", new string[] { UsuarioPerfil.ADMIN, UsuarioPerfil.PROFESSOR, UsuarioPerfil.ALUNO, UsuarioPerfil.COMPANHIA }),
                CPF = "768309116406",
                RG = "760942814"
            };
            barbara.UsuarioInfo = barbaraInfo;

            return new Usuario[] {
                    carvalho,
                    marcal,
                    thais,
                    barbara
                };

        }
        public static Empresa[] getBaseEmpresa() {
            var fabril = new Empresa() {
                Cnpj = "00.303.119/0001-33",
                Nome = "Fabril Tecnica de Elementos Padronizados LTDA",
                Telefone = "(11)4658-1222",
                Email = "dober@dober.com.br"
            };

            var matheus = new Empresa() {
                Cnpj = "25.385.913/0001-02",
                Nome = "Matheus Marçal",
                Telefone = "(12)98201-9251",
                Email = "matheus@dober.com.br"
            };

            return new Empresa[] {
                fabril,
                matheus
            };
        }

        public static Produto[] getBaseProduto() {
            var produto1 = new Produto() {
                Codigo = "0117000283501",
                Descricao = "PINO PESADO (EN 28.752) - 17 x 28 MM."
            };

            var produto2 = new Produto() {
                Codigo = "0402501200101",
                Descricao = "ANEL ELASTICO (DIN 472) I25"
            };

            var produto3 = new Produto() {
                Codigo = "0327205000701",
                Descricao = "ANEL ELÁSTICO (DIN 471) E272"
            };

            return new Produto[] {
                produto1,
                produto2,
                produto3
            };
        }
    }
}