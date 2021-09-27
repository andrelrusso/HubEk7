using System;
using System.Collections.Generic;
using System.Text;

namespace FrontEk7.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly EFContexto Db;
        private readonly DbSet<T> DbSet;

        public BaseRepositorio(EFContexto context)
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

        public async Task<T> AdicionarAsync(T entity)
        {
            DbSet.Add(entity);
            await Db.SaveChangesAsync();

            return entity;
        }

        public virtual void Atualizar(T obj)
        {
            DbSet.Update(obj);
            Db.SaveChanges();
        }

        public async Task AtualizarAsync(T entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            await Db.SaveChangesAsync();
        }


        public virtual T Consultar(object id)
        {
            return DbSet.Find(id);
        }

        public virtual async Task<T> ConsultarAsync(object id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<IReadOnlyList<T>> ConsultarTodosAsync()
        {
            return await DbSet.ToListAsync();
        }

        public T Consultar(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = DbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query.FirstOrDefault(predicate);
        }


        public virtual IReadOnlyList<T> ConsultarLista(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, bool disableTracking = true, params Expression<Func<T, object>>[] includes)
        {
            var query = ApplyFilterQuery(predicate, orderBy, disableTracking, includes);
            return query.ToList();
        }


        public virtual IReadOnlyList<TResult> ConsultarLista<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, bool disableTracking = true, params Expression<Func<T, object>>[] includes) where TResult : class
        {
            var query = ApplyFilterQuery(predicate, orderBy, disableTracking, includes);
            return query.Select(selector).ToList();
        }

        public virtual IReadOnlyList<T> ConsultarListaTop(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int take = 10, bool disableTracking = true, params Expression<Func<T, object>>[] includes)
        {
            var query = ApplyFilterQuery(predicate, orderBy, disableTracking, includes);
            return query.Take(take).ToList();
        }

        public virtual IReadOnlyList<TResult> ConsultarListaTop<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int take = 10, bool disableTracking = true, params Expression<Func<T, object>>[] includes) where TResult : class
        {
            var query = ApplyFilterQuery(predicate, orderBy, disableTracking, includes);
            return query.Select(selector).Take(take).ToList();
        }


        public void Excluir(T entity)
        {
            DbSet.Remove(entity);
            Db.SaveChanges();
        }

        public async Task ExcluirAsync(T entity)
        {
            DbSet.Remove(entity);
            await Db.SaveChangesAsync();
        }

        public async Task ExcluirAsync(object id)
        {
            var entity = await DbSet.FindAsync(id);
            DbSet.Remove(entity);
            await Db.SaveChangesAsync();
        }

        public int Contar()
        {
            return DbSet.Count();
        }

        public int Contar(Expression<Func<T, bool>> predicate = null)
        {
            IQueryable<T> query = DbSet;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query.Count();
        }

        public async Task<int> ContarAsync()
        {
            return await DbSet.CountAsync();
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        private IQueryable<T> ApplyFilterQuery(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, bool disableTracking = true, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = DbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }

        public bool Existe(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Any(predicate);
        }
    }
}
