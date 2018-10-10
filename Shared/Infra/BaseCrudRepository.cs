using Microsoft.EntityFrameworkCore;
using Shared.Infra;
using Shared.Interface.Entity;
using Shared.Interface.Repository;
using System.Collections.Generic;

namespace FileSys.Shared.Infrastructure.Data
{
    public abstract class BaseCrudRepository<TEntity> : BaseRepository<TEntity, string>, IBaseCrudRepository<TEntity>
        where TEntity : class, IEntityCrud<TEntity>
    {
        public BaseCrudRepository(DbContext context) : base(context)
        {
        }

        public abstract IDictionary<string, string> RecuperarDropDown();

        void IBaseCrudRepository<TEntity>.Inserir(TEntity entity)
        {
            base.Inserir(entity);
        }

        void IBaseCrudRepository<TEntity>.Atualizar(TEntity entity)
        {
            base.Atualizar(entity);
        }

        void IBaseCrudRepository<TEntity>.Remover(TEntity entity)
        {
            base.Remover(entity);
        }

        void IBaseCrudRepository<TEntity>.RemoverPorId(string id)
        {
            base.RemoverPorId(id);
        }
    }
}
