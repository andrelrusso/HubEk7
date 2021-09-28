using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FrontEk7.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        T Adicionar(T obj);
        Task<T> AdicionarAsync(T obj);
        void Atualizar(T obj);
        Task AtualizarAsync(T obj);
        void Excluir(T entity);
        Task ExcluirAsync(T entity);
        T Consultar(object id);
        Task<T> ConsultarAsync(Expression<Func<T, bool>> criteria, params Expression<Func<T, object>>[] includes);
        IEnumerable<T> Listar();
        Task<IEnumerable<T>> ListarAsync();
        Task<IEnumerable<T>> ListarAsync(Expression<Func<T, bool>> criteria, params Expression<Func<T, object>>[] includes);
    }
}
