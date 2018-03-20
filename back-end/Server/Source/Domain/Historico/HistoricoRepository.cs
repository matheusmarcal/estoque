using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.Common;
using Domain.UsuarioDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Domain.HistoricoDomain {

    public class HistoricoRepository : IRepository<Historico> {

        private BaseContext db;

        public HistoricoRepository(BaseContext db) {
            this.db = db;
        }

        public void Add(Historico model) {
            this.db.Historicos.Add(model);
        }

        public void Update(Historico model) {
            var attachedHistorico = this.db.Historicos.Find(model.ID);
            attachedHistorico.Nfe = model.Nfe;
            attachedHistorico.Quantidade = model.Quantidade;

            this.db.Historicos.Update(attachedHistorico);
        }

        
        public void Disable(int ID) {
            var Historico = this.db.Historicos.Find(ID);
            this.db.Historicos.Update(Historico);
        }

        public Historico Get(int ID) {
            return this.db.Historicos
            .AsNoTracking()
            .SingleOrDefault(x => x.ID == ID);
        }

        public Historico GetHistorico(int ID) {
            return this.db.Historicos
            .SingleOrDefault(x => x.ID == ID);
        }

        public Historico GetByNfe(string nfe) {
            return this.db.Historicos
            .AsNoTracking()
            .SingleOrDefault(x => x.Nfe== nfe);
        }

        public Historico GetInfo(int ID) {
            return this.db.Historicos.AsNoTracking()
            .SingleOrDefault(x => x.ID == ID);
        }


        public List<Historico> GetAll(bool ativo) {
            return this.db.Historicos
            .AsNoTracking()
            .ToList();
        }

        public List<Historico> GetAllByTermo(string termo) {
            return this.db.Historicos
            .AsNoTracking()
            .Where(x => x.Nfe.ToLower().Contains(termo.ToLower()))
            .ToList();
        }

        public IEnumerable<Historico> Query(Expression<Func<Historico, bool>> predicate, params Expression<Func<Historico, object>>[] includeExpressions) {
            return includeExpressions.Aggregate<Expression<Func<Historico, object>>, IQueryable<Historico>>(db.Historicos, (current, expression) => current.Include(expression)).Where(predicate.Compile());
        }

        public IDbContextTransaction BeginTransaction() {
            return this.db.Database.BeginTransaction();
        }
        
        public void SaveChanges() {
            this.db.SaveChanges();
        }

    }

}