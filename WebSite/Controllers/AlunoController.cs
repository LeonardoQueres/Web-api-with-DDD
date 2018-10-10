using Aplication.Interface;
using Aplication.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IAlunoAppService appService;

        public AlunoController(IAlunoAppService appService)
        {
            this.appService = appService;
        }

        public IActionResult Index()
        {
            var resultado = appService.RecuperarTodos().Data;
            return View(resultado);
        }

        public virtual IActionResult Visualizar(string id)
        {
            var resultado = appService.RecuperarPorId(id);
            var model = resultado.Data;
            model.SomenteLeitura = true;

            PreencheCombosTela(model);

            return View("Form", model);
        }

        public IActionResult Cadastrar()
        {
            var viewModel = new AlunoViewModel();
            PreencheCombosTela(viewModel);

            return View("Form", viewModel);
        }

        public IActionResult Editar(string Id)
        {
            var resultado = appService.RecuperarPorId(Id);
            var viewModel = resultado.Data;
            PreencheCombosTela(viewModel);

            return View("Form", viewModel);
        }

        [HttpPost]
        public IActionResult Cadastrar(AlunoViewModel viewModel)
        {
            var resultado = appService.Inserir(viewModel);

            if (resultado.Successo)
                resultado.RedirecionarPara(Url.Action(nameof(Index)));

            return Json(resultado.Retorno());
        }

        [HttpPost]
        public IActionResult Editar(AlunoViewModel viewModel)
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

        private void PreencheCombosTela(AlunoViewModel model)
        {
        }
    }
}