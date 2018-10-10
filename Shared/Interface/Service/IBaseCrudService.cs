using Shared.Interface.Entity;
using Shared.Validator;
using System.Collections.Generic;

namespace Shared.Interface.Service
{
    public interface IBaseCrudService<TEntity> : IBaseService<TEntity, string> where TEntity : class, IEntity<TEntity, string>
    {
        ResultadoValidacao Inserir(TEntity model);

        ResultadoValidacao Atualizar(TEntity model);

        void RemoverPorId(string id);

        IDictionary<string, string> RecuperarDropDown();
    }
}
