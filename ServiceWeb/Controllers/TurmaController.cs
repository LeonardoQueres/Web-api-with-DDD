using Aplication.Interface;
using Aplication.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Shared.Interface.Validator;
using System.Collections.Generic;

namespace ServiceWeb.Controllers
{
    [Route("api/[controller]")]
    public class TurmaController : Controller
    {
        private readonly ITurmaAppService appService;
        private readonly IAlunoAppService alunoAppService;
        private readonly IDisciplinaAppService disciplinaAppService;

        public TurmaController(ITurmaAppService appService, IAlunoAppService alunoAppService, IDisciplinaAppService disciplinaAppService)
        {
            this.appService = appService;
            this.alunoAppService = alunoAppService;
            this.disciplinaAppService = disciplinaAppService;
        }

        [HttpPost("RecuperarTodos")]
        public ICollection<TurmaViewModel> Index()
        {
            var resultado = appService.RecuperarTodos().Data;
            return resultado;
        }


        [HttpPost("Visualizar/{id}")]
        public TurmaViewModel Visualizar(string id)
        {
            var resultado = appService.RecuperarPorId(id);
            var viewModel = resultado.Data;
            viewModel.TelaTurmaAluno.ApenasUmTurmaAluno = false;
            viewModel.TelaTurmaDisciplina.ApenasUmTurmaDisciplina = false;
            viewModel.SomenteLeitura = true;

            return viewModel;
        }


        [HttpPost("Cadastrar")]
        public IResultadoApplication Cadastrar(TurmaViewModel viewModel)
        {
            var resultado = appService.Inserir(viewModel);
            return resultado;
        }


        [HttpPost("Editar/{id}")]
        public TurmaViewModel Editar(string Id)
        {
            var resultado = appService.RecuperarPorId(Id);
            var model = resultado.Data;
            return model;
        }

        [HttpPost("Editar")]
        public IResultadoApplication Editar(TurmaViewModel viewModel)
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