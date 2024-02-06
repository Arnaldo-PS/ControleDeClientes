using ControleClientes.Models;
using ControleClientes.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleClientes.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        public ClienteController(IClienteRepositorio clienteRepositorio) 
        {
            _clienteRepositorio = clienteRepositorio;
        }
        public IActionResult Index()
        {
            // retorna uma lista de dados para a view
            List<ClienteModel> clientes = _clienteRepositorio.BuscarTodos();
            return View(clientes);
        }

        public IActionResult Criar()
        {
            return View();
        }

        // recebe como parametro o id do contato
        public IActionResult Editar(int id)
        {
            // busco o contato pelo id
            ClienteModel cliente = _clienteRepositorio.ListarPorId(id);
            // retorno ele para minha view
            return View(cliente);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ClienteModel cliente = _clienteRepositorio.ListarPorId(id);
            return View(cliente);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _clienteRepositorio.Apagar(id);

                if(apagado)
                {
                    TempData["MensagemSucesso"] = "Cliente excluido com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não conseguimos excluir seu cliente";

                }
                // redirecionando para a página index no retorno
                return RedirectToAction("Index");
            }

            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos excluir seu cliente, tente novamente! Detalhes do erro:{ex.Message}";
                return RedirectToAction("Index");

            }
        }

        [HttpPost]
        public IActionResult Criar(ClienteModel cliente)
        {
            try
            {
                // verifica se os dados são válidos
                if (ModelState.IsValid)
                {
                    // adicionando cliente no banco
                    _clienteRepositorio.Adicionar(cliente);
                    // variavel temporária para armazenar a mensagem de sucesso
                    TempData["MensagemSucesso"] = "Cliente adicionado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(cliente);

            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos adicionar seu cliente, tente novamente! Detalhes do erro:{ex.Message}";
                return View(cliente);
            }
            
        }

        [HttpPost]
        public IActionResult Alterar(ClienteModel cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clienteRepositorio.Atualizar(cliente);
                    TempData["MensagemSucesso"] = "Cliente alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", cliente);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos alterar seu cliente, tente novamente! Detalhes do erro:{ex.Message}";
                // especificando a view
                return RedirectToAction("Index");
            }
        }
    }
}
