using Aplication.Interface;
using Aplication.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Shared.Interface.Validator;
using System.Collections.Generic;

namespace ServiceWeb.Controllers
{
    [Route("api/[controller]")]
    public class DisciplinaController : Controller
    {
        private readonly IDisciplinaAppService appService;

        public DisciplinaController(IDisciplinaAppService appService)
        {
            this.appService = appService;
        }

        [HttpPost("RecuperarTodos")]
        public ICollection<DisciplinaViewModel> RecuperarTodos()
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
        public DisciplinaViewModel Visualizar(string id)
        {
            var resultado = appService.RecuperarPorId(id);
            var model = resultado.Data;
            model.SomenteLeitura = true;
            return model;
        }


        [HttpPost("Cadastrar")]
        public IResultadoApplication Cadastrar(DisciplinaViewModel viewModel)
        {
            var resultado = appService.Inserir(viewModel);
            return resultado;
        }


        [HttpPost("Editar/{id}")]
        public DisciplinaViewModel Editar(string Id)
        {
            var resultado = appService.RecuperarPorId(Id);
            var model = resultado.Data;
            return model;
        }

        [HttpPost("Editar")]
        public IResultadoApplication Editar(DisciplinaViewModel viewModel)
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