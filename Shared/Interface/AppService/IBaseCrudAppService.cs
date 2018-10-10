using Shared.Interface.Entity;
using Shared.Interface.Validator;
using Shared.Validator;
using System.Collections.Generic;

namespace Shared.Interface.AppService
{
    public interface IBaseCrudAppService<TViewModel, TEntity> : IBaseAppService<TViewModel, TEntity, string>
         where TEntity : class, IEntity<TEntity, string>
    {
        IResultadoApplication Inserir(TViewModel viewModel);
        IResultadoApplication Atualizar(TViewModel viewModel);
        IResultadoApplication RemoverPorId(string id);
        IResultadoApplication<IDictionary<string, string>> RecuperarDropdown();
    }
}
