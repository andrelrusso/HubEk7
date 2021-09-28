using FrontEk7.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FrontEk7.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly EFContexto Db;
        private readonly DbSet<T> DbSet;

        public BaseRepository(EFContexto context)
        {
            Db = context;
            DbSet = Db.Set<T>();
        }

        public virtual T Adicionar(T entity)
        {
            DbSet.Add(entity);
            Db.SaveChanges();

            return entity;
        }

        public virtual void Atualizar(T obj)
        {
            DbSet.Update(obj);
            Db.SaveChanges();
        }

        public virtual T Consultar(object id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<T> Listar()
        {
            return DbSet.AsQueryable();
        }
        public void Excluir(T entity)
        {
            DbSet.Remove(entity);
            Db.SaveChanges();
        }

        public async Task<T> AdicionarAsync(T entity)
        {
            DbSet.Add(entity);
            await Db.SaveChangesAsync();

            return entity;
        }

        public async Task AtualizarAsync(T obj)
        {
            DbSet.Update(obj);
            await Db.SaveChangesAsync();
        }

        public async Task ExcluirAsync(T entity)
        {
            DbSet.Remove(entity);
            await Db.SaveChangesAsync();
        }


        //public async Task<T> ConsultarAsync(object id)
        //{
        //    try
        //    {
        //        return await DbSet.FindAsync(id);

        //    }
        //    catch(Exception ex)
        //    {
        //        throw;
        //    }
        //}

        public virtual async Task<T> ConsultarAsync(Expression<Func<T, bool>> criteria, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Db.Set<T>();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(criteria);
        }

        public async Task<IEnumerable<T>> ListarAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> ListarAsync(Expression<Func<T, bool>> criteria, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Db.Set<T>();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.Where(criteria).ToListAsync();
        }
    }
}