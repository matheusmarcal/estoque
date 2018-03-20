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
            if (model.Empresa != null) {
                this.db.Attach(model.Empresa);
            }
            if (model.Produto != null) {
                this.db.Attach(model.Produto);
            }
            this.db.Estoques.Add(model);
        }

        public void Update(Estoque model) {
            if (model.Empresa != null) {
                this.db.Attach(model.Empresa);
            }
            if (model.Produto != null) {
                this.db.Attach(model.Produto);
            }
            var attachedEstoque = this.db.Estoques.Find(model.ID);
            attachedEstoque.Empresa = this.db.Empresas.SingleOrDefault(x => x.ID == model.ID);
            attachedEstoque.Produto = this.db.Produtos.SingleOrDefault(x => x.ID == model.ID); ;
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
            .Include(i => i.Empresa)
            .Include(i => i.Produto)
            .SingleOrDefault(x => x.ID == ID);
        }

        public Estoque GetByCodigo(string codigo) {
            return this.db.Estoques
            .AsNoTracking()
            .SingleOrDefault(x => x.Produto.Codigo == codigo);
        }

        public List<Estoque> GetAll(bool ativo) {
            return this.db.Estoques
            .Include(i => i.Empresa)
            .Include(i => i.Produto)
            .AsNoTracking()
            .Where(x => x.Quantidade != 0)
            .ToList();
        }

        public List<Estoque> GetAllDistinctByProduto() {
            return this.db.Estoques
            .GroupBy(x => x.Produto.ID)
            .Select(x => x.First())
            .ToList();
        }

        public List<Estoque> GetAllByCodigo(string codigo) {
            return this.db.Estoques.AsNoTracking()
            .Where(x => x.Produto.Codigo == codigo)
            .ToList();
        }

        public List<Estoque> GetAllByTermo(string termo) {
            return this.db.Estoques
            .AsNoTracking()
            .Where(x => x.Produto.Codigo.ToLower().Contains(termo.ToLower()) || x.Produto.Descricao.ToLower().Contains(termo.ToLower()))
            .ToList();
        }

        public int GetDisponiveis(int ID) {
            var historicos = this.db.Historicos.Where(x => x.Estoque.ID == ID).ToList();
            var disponiveis = this.db.Estoques.SingleOrDefault(x => x.ID == ID).Quantidade;
            historicos.ForEach(x => {
                disponiveis -= x.Quantidade;
            });

            return disponiveis;
        }

        public int GetDisponiveisByProduto(int ID) {
            var estoques = this.db.Estoques.Include(x => x.Produto).Where(x => x.Produto.ID == ID).ToList();
            var disponiveis = 0;
            estoques.ForEach(x => {
                disponiveis += x.Quantidade;
            });

            var historicos = this.db.Historicos.Include(x => x.Estoque).Where(x => x.Estoque.Produto.ID == ID).ToList();
            historicos.ForEach(x => {
                disponiveis -= x.Quantidade;
            });

            return disponiveis;
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