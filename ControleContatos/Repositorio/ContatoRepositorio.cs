using ControleContatos.Data;
using ControleContatos.Models;

namespace ControleContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<ContatoModel> BuscarTodos()
        {
            // retorna uma lista de contatos
            return _bancoContext.Contatos.ToList();
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            
            // salvar contato no banco de dados
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;

        }

    }
}
