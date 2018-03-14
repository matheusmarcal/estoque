using Domain.EmpresaDomain;
using Domain.EstoqueDomain;
using Domain.HistoricoDomain;
using Domain.ProdutoDomain;
using Domain.UsuarioDomain;
using Microsoft.EntityFrameworkCore;

namespace Domain.Common {

    public class BaseContext : DbContext {

        public BaseContext(DbContextOptions<BaseContext> options) : base(options) {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioInfo> UsuariosInfo { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
        public DbSet<Historico> Historicos { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
       
    }
}