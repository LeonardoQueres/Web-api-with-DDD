using Aplication.Interface;
using Aplication.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Shared.Interface.Validator;
using System.Collections.Generic;

namespace ServiceWeb.Controllers
{
    [Route("api/[controller]")]
    public class AlunoController : Controller
    {
        private readonly IAlunoAppService appService;

        public AlunoController(IAlunoAppService appService)
        {
            this.appService = appService;
        }


        [HttpPost("RecuperarTodos")]
        public ICollection<AlunoViewModel> RecuperarTodos()
        {
            var resultado = appService.RecuperarTodos().Data;
            return resultado;
        }

        [HttpPost("RecuperarDropdown")]
        public IDictionary<string, string> RecuperarDropdown()
        {
            var resultado = appService.RecuperarDropdown().Data;
            return resultado;
        }

        [HttpPost("Visualizar/{id}")]
        public AlunoViewModel Visualizar(string id)
        {
            var resultado = appService.RecuperarPorId(id);
            var model = resultado.Data;
            model.SomenteLeitura = true;
            return model;
        }


        [HttpPost("Cadastrar")]
        public IResultadoApplication Cadastrar(AlunoViewModel viewModel)
        {
            var resultado = appService.Inserir(viewModel);
            return resultado;
        }


        [HttpPost("Editar/{id}")]
        public AlunoViewModel Editar(string Id)
        {
            var resultado = appService.RecuperarPorId(Id);
            var model = resultado.Data;
            return model;
        }

        [HttpPost("Editar")]
        public IResultadoApplication Editar(AlunoViewModel viewModel)
        {
            var resultado = appService.Atualizar(viewModel);
            return resultado;
        }

        [HttpPost("Excluir/{id}")]
        public IResultadoApplication Excluir(string id)
        {
            var resultado = appService.RemoverPorId(id);
            return resultado;
        }
    }
}