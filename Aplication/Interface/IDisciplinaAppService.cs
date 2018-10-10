using Aplication.ViewModel;
using Domain.Entidade;
using Shared.Interface.AppService;

namespace Aplication.Interface
{
    public interface IDisciplinaAppService : IBaseCrudAppService<DisciplinaViewModel, Disciplina>
    {
    }
}
