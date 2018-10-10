using Aplication.Interface;
using Aplication.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Controllers
{
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
        public IActionResult Index()
        {
            var resultado = appService.RecuperarTodos().Data;
            return View(resultado);
        }

        public virtual IActionResult Visualizar(string id)
        {
            var resultado = appService.RecuperarPorId(id);
            var viewModel = resultado.Data;
            viewModel.TelaTurmaAluno.ApenasUmTurmaAluno = false;
            viewModel.TelaTurmaDisciplina.ApenasUmTurmaDisciplina = false;
            viewModel.SomenteLeitura = true;

            PreencheCombosTela(viewModel);

            return View("Form", viewModel);
        }

        public IActionResult Cadastrar()
        {
            var viewModel = new TurmaViewModel()
            {
                TelaTurmaAluno = new TurmaAlunoTelaViewModel()
                {
                    ApenasUmTurmaAluno = false
                },
                TelaTurmaDisciplina = new TurmaDisciplinaTelaViewModel()
                {
                    ApenasUmTurmaDisciplina = false
                }
            };

            PreencheCombosTela(viewModel);

            return View("Form", viewModel);
        }

        public IActionResult Editar(string Id)
        {
            var resultado = appService.RecuperarPorId(Id);
            var viewModel = resultado.Data;
            viewModel.TelaTurmaAluno.ApenasUmTurmaAluno = false;
            viewModel.TelaTurmaDisciplina.ApenasUmTurmaDisciplina = false;
            PreencheCombosTela(viewModel);

            return View("Form", viewModel);
        }

        [HttpPost]
        public IActionResult Cadastrar(TurmaViewModel viewModel)
        {
            var resultado = appService.Inserir(viewModel);

            if (resultado.Successo)
                resultado.RedirecionarPara(Url.Action(nameof(Index)));

            return Json(resultado.Retorno());
        }

        [HttpPost]
        public IActionResult Editar(TurmaViewModel viewModel)
        {
            var resultado = appService.Atualizar(viewModel);

            if (resultado.Successo)
                resultado.RedirecionarPara(Url.Action(nameof(Index)));

            return Json(resultado.Retorno());
        }

        [HttpPost]
        public virtual IActionResult Excluir(string id)
        {
            var resultado = appService.RemoverPorId(id);

            if (resultado.Successo)
                resultado.RedirecionarPara(Url.Action(nameof(Index)));

            return Json(resultado.Retorno());
        }

        private void PreencheCombosTela(TurmaViewModel model)
        {
            model.TelaTurmaAluno.Alunos = alunoAppService.RecuperarDropdown().Data;
            model.TelaTurmaDisciplina.Disciplinas = disciplinaAppService.RecuperarDropdown().Data;
        }
    }
}