using Shared.Validator;

namespace Shared.Interface.Entity
{
    public interface IEntityCrud<TEntity> : IEntity<TEntity, string> where TEntity : class
    {

        void PreencherDados(TEntity data);
        ResultadoValidacao Validar();
    }
}
