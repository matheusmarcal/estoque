using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.Common;
using Domain.UsuarioDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Domain.ProdutoDomain {

    public class ProdutoRepository : IRepository<Produto> {

        private BaseContext db;

        public ProdutoRepository(BaseContext db) {
            this.db = db;
        }

        public void Add(Produto model) {
            this.db.Produtos.Add(model);
        }

        public void Update(Produto model) {
            var attachedProduto = this.db.Produtos.Find(model.ID);
            attachedProduto.Codigo = model.Codigo;
            attachedProduto.Descricao = model.Descricao;

            this.db.Produtos.Update(attachedProduto);
        }

        
        public void Disable(int ID) {
            var Produto = this.db.Produtos.Find(ID);
            Produto.Ativo = DateTime.Now;
            this.db.Produtos.Update(Produto);
        }

        public Produto Get(int ID) {
            return this.db.Produtos
            .AsNoTracking()
            .SingleOrDefault(x => x.ID == ID);
        }

        public Produto GetProduto(int ID) {
            return this.db.Produtos
            .SingleOrDefault(x => x.ID == ID);
        }

        public Produto GetByCodigo(string codigo) {
            return this.db.Produtos
            .AsNoTracking()
            .SingleOrDefault(x => x.Codigo== codigo);
        }

        public Produto GetInfo(int ID) {
            return this.db.Produtos.AsNoTracking()
            .SingleOrDefault(x => x.ID == ID);
        }

        public Produto GetInfoByCodigo(string codigo) {
            return this.db.Produtos.AsNoTracking()
            .SingleOrDefault(x => x.Codigo == codigo);
        }

        public List<Produto> GetAll(bool ativo) {
            return this.db.Produtos
            .AsNoTracking()
            .Where(x => x.Ativo.HasValue == !ativo)
            .ToList();
        }

        public List<Produto> GetAllByTermo(string termo) {
            return this.db.Produtos
            .AsNoTracking()
            .Where(x => x.Codigo.ToLower().Contains(termo.ToLower()) || x.Descricao.ToLower().Contains(termo.ToLower()))
            .ToList();
        }

        public IEnumerable<Produto> Query(Expression<Func<Produto, bool>> predicate, params Expression<Func<Produto, object>>[] includeExpressions) {
            return includeExpressions.Aggregate<Expression<Func<Produto, object>>, IQueryable<Produto>>(db.Produtos, (current, expression) => current.Include(expression)).Where(predicate.Compile());
        }

        public IDbContextTransaction BeginTransaction() {
            return this.db.Database.BeginTransaction();
        }
        
        public void SaveChanges() {
            this.db.SaveChanges();
        }

    }

}