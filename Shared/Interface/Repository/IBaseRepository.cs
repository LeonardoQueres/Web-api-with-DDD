using Shared.Interface.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Shared.Interface.Repository
{
    public interface IBaseRepository<TEntity, TType> where TEntity : class, IEntity<TEntity, TType>
    {
        TEntity RecuperarPorId(TType id);

        ICollection<TEntity> RecuperarTodos();

        ICollection<TEntity> Pesquisar(Expression<Func<TEntity, bool>> predicate);

        int Commit();
    }
}
