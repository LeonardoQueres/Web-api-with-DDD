using Shared.Interface.Entity;
using Shared.Interface.Validator;
using System.Collections.Generic;

namespace Shared.Interface.AppService
{
    public interface IBaseAppService<TViewModel, TEntity, TType> where TEntity : class, IEntity<TEntity, TType>
    {
        IResultadoApplication<ICollection<TViewModel>> RecuperarTodos();
        IResultadoApplication<TViewModel> RecuperarPorId(TType id);
    }
}
