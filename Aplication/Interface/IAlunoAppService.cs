using Aplication.ViewModel;
using Domain.Entidade;
using Shared.Interface.AppService;

namespace Aplication.Interface
{
    public interface IAlunoAppService : IBaseCrudAppService<AlunoViewModel, Aluno>
    {
    }
}
