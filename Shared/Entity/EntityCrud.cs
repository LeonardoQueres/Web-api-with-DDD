using FluentValidation;
using Shared.Interface.Entity;
using Shared.Validator;

namespace Shared.Entity
{
    public abstract class EntityCrud<TEntity> : Entity<TEntity, string>, IEntityCrud<TEntity> where TEntity : class
    {
        public abstract AbstractValidator<TEntity> Validador { get; }

        public abstract void PreencherDados(TEntity data);

        public abstract ResultadoValidacao Validar();

        protected virtual ResultadoValidacao ExecutarValidacaoPadrao(TEntity entity)
        {
            return Validador.Validate(entity).Transformar();
        }
    }
}
