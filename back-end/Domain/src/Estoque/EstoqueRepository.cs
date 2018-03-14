using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.Common;
using Domain.UsuarioDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Domain.EstoqueDomain {

    public class EstoqueRepository : IRepository<Estoque> {

        private BaseContext db;

        public EstoqueRepository(BaseContext db) {
            this.db = db;
        }

        public void Add(Estoque model) {
            this.db.Estoques.Add(model);
        }

        public void Update(Estoque model) {
            if(model.Empresa != null) {
                this.db.Attach(model.Empresa);
            }
            if(model.Produto != null) {
                this.db.Attach(model.Produto);
            }
            var attachedEstoque = this.db.Estoques.Find(model.ID);
            attachedEstoque.Empresa.ID = model.Empresa.ID;
            attachedEstoque.Produto.ID = model.Produto.ID;
            attachedEstoque.Nfe = model.Nfe;
            attachedEstoque.Op = model.Op;
            attachedEstoque.Quantidade = model.Quantidade;
            attachedEstoque.Posicao = model.Posicao;

            this.db.Estoques.Update(attachedEstoque);
        }

        
        public void Disable(int ID) {
            var Estoque = this.db.Estoques.Find(ID);
            Estoque.Quantidade = 0;
            this.db.Estoques.Update(Estoque);
        }

        public Estoque Get(int ID) {
            return this.db.Estoques
            .AsNoTracking()
            .SingleOrDefault(x => x.ID == ID);
        }

        public Estoque GetEstoque(int ID) {
            return this.db.Estoques
            .SingleOrDefault(x => x.ID == ID);
        }

        public Estoque GetByCodigo(string codigo) {
            return this.db.Estoques
            .AsNoTracking()
            .SingleOrDefault(x => x.Produto.Codigo == codigo);
        }

        public Estoque GetInfo(int ID) {
            return this.db.Estoques.AsNoTracking()
            .SingleOrDefault(x => x.ID == ID);
        }

        public Estoque GetInfoByCodigo(string codigo) {
            return this.db.Estoques.AsNoTracking()
            .SingleOrDefault(x => x.Produto.Codigo == codigo);
        }

        public List<Estoque> GetAll(bool ativo) {
            return this.db.Estoques
            .AsNoTracking()
            .Where(x => x.Quantidade != 0)
            .ToList();
        }

        public List<Estoque> GetAllByTermo(string termo) {
            return this.db.Estoques
            .AsNoTracking()
            .Where(x => x.Produto.Codigo.ToLower().Contains(termo.ToLower()) || x.Produto.Descricao.ToLower().Contains(termo.ToLower()))
            .ToList();
        }

        public IEnumerable<Estoque> Query(Expression<Func<Estoque, bool>> predicate, params Expression<Func<Estoque, object>>[] includeExpressions) {
            return includeExpressions.Aggregate<Expression<Func<Estoque, object>>, IQueryable<Estoque>>(db.Estoques, (current, expression) => current.Include(expression)).Where(predicate.Compile());
        }

        public IDbContextTransaction BeginTransaction() {
            return this.db.Database.BeginTransaction();
        }
        
        public void SaveChanges() {
            this.db.SaveChanges();
        }

    }

}