using ControleContatos.Models;
using ControleContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio) 
        {
            _contatoRepositorio = contatoRepositorio;
        }
        public IActionResult Index()
        {
            // retorna uma lista de dados para a view
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        // recebe como parametro o id do contato
        public IActionResult Editar(int id)
        {
            // busco o contato pelo id
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            // retorno ele para minha view
            return View(contato);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            _contatoRepositorio.Apagar(id); 
            // redirecionando para a página index no retorno
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            // verifica se os dados são válidos
            if(ModelState.IsValid)
            {
                _contatoRepositorio.Adicionar(contato);
                return RedirectToAction("Index");
            }

            return View(contato);
            
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            if (ModelState.IsValid)
            {
                _contatoRepositorio.Atualizar(contato);
                return RedirectToAction("Index");
            }

            // especificando a view
            return View("Editar", contato);
        }
    }
}
