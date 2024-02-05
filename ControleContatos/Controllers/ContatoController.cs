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
            try
            {
                bool apagado = _contatoRepositorio.Apagar(id);

                if(apagado)
                {
                    TempData["MensagemSucesso"] = "Contato excluido com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não conseguimos excluir sem contato";

                }
                // redirecionando para a página index no retorno
                return RedirectToAction("Index");
            }

            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos excluir seu contato, tente novamente! Detalhes do erro:{ex.Message}";
                return RedirectToAction("Index");

            }
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                // verifica se os dados são válidos
                if (ModelState.IsValid)
                {
                    // adicionando contato no banco
                    _contatoRepositorio.Adicionar(contato);
                    // variavel temporária para armazenar a mensagem de sucesso
                    TempData["MensagemSucesso"] = "Contato adicionado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(contato);

            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos adicionar seu contato, tente novamente! Detalhes do erro:{ex.Message}";
                return View(contato);
            }
            
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", contato);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos alterar seu contato, tente novamente! Detalhes do erro:{ex.Message}";
                // especificando a view
                return RedirectToAction("Index");
            }
        }
    }
}
