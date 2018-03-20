using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.Common;
using Domain.UsuarioDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Domain.EmpresaDomain {

    public class EmpresaRepository : IRepository<Empresa> {

        private BaseContext db;

        public EmpresaRepository(BaseContext db) {
            this.db = db;
        }

        public void Add(Empresa model) {
            this.db.Empresas.Add(model);
        }

        public void Update(Empresa model) {
            var attachedEmpresa = this.db.Empresas.Find(model.ID);
            attachedEmpresa.Cnpj = model.Cnpj;
            attachedEmpresa.Email = model.Email;
            attachedEmpresa.Nome = model.Nome;
            attachedEmpresa.Telefone = model.Telefone;
            attachedEmpresa.Tipo = model.Tipo;
            attachedEmpresa.Ativo = model.Ativo;

            this.db.Empresas.Update(attachedEmpresa);
        }

        
        public void Disable(int ID) {
            var Empresa = this.db.Empresas.Find(ID);
            Empresa.Ativo = DateTime.Now;
            this.db.Empresas.Update(Empresa);
        }

        public Empresa Get(int ID) {
            return this.db.Empresas
            .AsNoTracking()
            .SingleOrDefault(x => x.ID == ID);
        }

        public Empresa GetEmpresa(int ID) {
            return this.db.Empresas
            .SingleOrDefault(x => x.ID == ID);
        }

        public Empresa GetByCnpj(string cnpj) {
            return this.db.Empresas
            .AsNoTracking()
            .SingleOrDefault(x => x.Cnpj== cnpj);
        }
        public Empresa GetByNome(string nome) {
            return this.db.Empresas
            .AsNoTracking()
            .SingleOrDefault(x => x.Nome== nome);
        }

        public Empresa GetInfo(int ID) {
            return this.db.Empresas.AsNoTracking()
            .SingleOrDefault(x => x.ID == ID);
        }

        public List<Empresa> GetAll(bool ativo) {
            return this.db.Empresas
            .AsNoTracking()
            .Where(x => x.Ativo.HasValue == !ativo)
            .ToList();
        }

        public List<Empresa> GetAllByTermo(string termo) {
            return this.db.Empresas
            .AsNoTracking()
            .Where(x => x.Cnpj.ToLower().Contains(termo.ToLower()) || x.Nome.ToLower().Contains(termo.ToLower()))
            .ToList();
        }

        public IEnumerable<Empresa> Query(Expression<Func<Empresa, bool>> predicate, params Expression<Func<Empresa, object>>[] includeExpressions) {
            return includeExpressions.Aggregate<Expression<Func<Empresa, object>>, IQueryable<Empresa>>(db.Empresas, (current, expression) => current.Include(expression)).Where(predicate.Compile());
        }

        public IDbContextTransaction BeginTransaction() {
            return this.db.Database.BeginTransaction();
        }
        
        public void SaveChanges() {
            this.db.SaveChanges();
        }

    }

}