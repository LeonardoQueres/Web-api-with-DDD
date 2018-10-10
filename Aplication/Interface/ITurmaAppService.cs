using Aplication.ViewModel;
using Domain.Entidade;
using Shared.Interface.AppService;

namespace Aplication.Interface
{
    public interface ITurmaAppService : IBaseCrudAppService<TurmaViewModel, Turma>
    {
    }
}
