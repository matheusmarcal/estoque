using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Domain.UsuarioDomain {

    public class UsuarioRepository : IRepository<Usuario> {

        private BaseContext db;

        public UsuarioRepository(BaseContext db) {
            this.db = db;
        }

        public void Add(Usuario model) {
            model.UsuarioInfo.ID = model.ID;
            this.db.UsuariosInfo.Add(model.UsuarioInfo);

            this.db.Usuarios.Add(model);
        }

        public void Update(Usuario model) {
            if (model.UsuarioInfo != null) {
                this.db.Attach(model.UsuarioInfo);
            }

            var attachedUsuario = this.db.Usuarios.Find(model.ID);
            attachedUsuario.Username = model.Username;
            attachedUsuario.Password = model.Password;

            this.UpdateUsuarioInfo(model.UsuarioInfo);
            this.db.Usuarios.Update(attachedUsuario);
        }

        public void UpdateUsuarioInfo(UsuarioInfo model) {
            var attachedUsuarioInfo = this.db.UsuariosInfo.Find(model.ID);
            attachedUsuarioInfo.Nome = model.Nome;
            attachedUsuarioInfo.DataNascimento = model.DataNascimento;
            attachedUsuarioInfo.CPF = model.CPF;
            attachedUsuarioInfo.RG = model.RG;
            attachedUsuarioInfo.Perfis = model.Perfis;

            this.db.UsuariosInfo.Update(attachedUsuarioInfo);
        }

        
        public void Disable(string ID) {
            var usuario = this.db.Usuarios.Find(ID);
            usuario.Ativo = DateTime.Now;
            this.db.Usuarios.Update(usuario);
        }

        public Usuario Get(string ID) {
            return this.db.Usuarios
            .AsNoTracking()
            .Include(i => i.UsuarioInfo)
            .SingleOrDefault(x => x.ID == ID);
        }

        public UsuarioInfo GetUsuarioInfo(string ID) {
            return this.db.UsuariosInfo
            .SingleOrDefault(x => x.ID == ID);
        }

        public Usuario GetByRG(string rg) {
            return this.db.Usuarios
            .AsNoTracking()
            .Include(i => i.UsuarioInfo)
            .SingleOrDefault(x => x.UsuarioInfo.RG == rg);
        }

        public UsuarioInfo GetInfo(string ID) {
            return this.db.UsuariosInfo.AsNoTracking()
            .SingleOrDefault(x => x.ID == ID);
        }

        public UsuarioInfo GetInfoByRG(string rg) {
            return this.db.UsuariosInfo.AsNoTracking()
            .SingleOrDefault(x => x.RG == rg);
        }

        public List<Usuario> GetAll(bool ativo) {
            return this.db.Usuarios
            .AsNoTracking()
            .Include(i => i.UsuarioInfo)
            .Where(x => x.Ativo.HasValue == !ativo)
            .ToList();
        }

        public List<UsuarioInfo> GetAllByTermo(string perfil, string termo) {
            return this.db.UsuariosInfo
            .AsNoTracking()
            .Where(x => x.Nome.ToLower().Contains(termo.ToLower()) || x.RG.ToLower().Contains(termo.ToLower()) || x.CPF.ToLower().Contains(termo.ToLower()) && (perfil != null ? x.Perfis.Contains(perfil) : true))
            .ToList();
        }

        public IEnumerable<Usuario> Query(Expression<Func<Usuario, bool>> predicate, params Expression<Func<Usuario, object>>[] includeExpressions) {
            return includeExpressions.Aggregate<Expression<Func<Usuario, object>>, IQueryable<Usuario>>(db.Usuarios, (current, expression) => current.Include(expression)).Where(predicate.Compile());
        }

        public IDbContextTransaction BeginTransaction() {
            return this.db.Database.BeginTransaction();
        }
        
        public void SaveChanges() {
            this.db.SaveChanges();
        }

    }

}