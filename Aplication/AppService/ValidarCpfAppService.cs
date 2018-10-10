using Aplication.Interface;
using Domain.Interface.Service;

namespace Aplication.AppService
{
    public class ValidarCpfAppService : IValidarCpfAppService
    {
        private readonly IValidarCpfService appService;

        public ValidarCpfAppService(IValidarCpfService appService)
        {
            this.appService = appService;
        }
        bool IValidarCpfAppService.ValidarCpf(string cpf)
        {
            return appService.ValidarCpf(cpf);
        }
    }
}
