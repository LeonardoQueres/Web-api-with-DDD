﻿using Shared.Interface.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Shared.Interface.Service
{
    public interface IBaseService<TEntity, TTYpe> where TEntity : class, IEntity<TEntity, TTYpe>
    {
        TEntity RecuperarPorId(TTYpe id);

        ICollection<TEntity> RecuperarTodos();

        ICollection<TEntity> Pesquisar(Expression<Func<TEntity, bool>> predicate);

        int Commit();
    }
}
