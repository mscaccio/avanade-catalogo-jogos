using ExemploApiCatalogoJogos.Exceptions;
using ExemploApiCatalogoJogos.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ExemploCatalogoJogos.Controllers
{

    public class JogosController : Controller
    {
        private readonly IJogoService _jogoService;

        public JogosController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }

        public IActionResult Index()
        {
            return View("Listar");
        }

        public IActionResult Inserir()
        {
            return View("NovoJogo");
        }

        public async Task<IActionResult> Editar(Guid Id)
        {
            try
            {
                var jogoViewModel = await _jogoService.Obter(Id);

                return View("EditarJogo", jogoViewModel);
            }
            catch (JogoNaoCadastradoException)
            {
                return NotFound("Não existe este jogo");
            }
        }
    }
}