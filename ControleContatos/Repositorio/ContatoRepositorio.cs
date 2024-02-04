using ControleContatos.Data;
using ControleContatos.Models;

namespace ControleContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;

        // função para buscar contato por id
        public ContatoModel ListarPorId(int id)
        {
            // retorna um contato que tenha id igual ao solicitado
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }

        // injeção de dependencia do banco de dados
        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        // função para buscar todos os contatos
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

        // função para alterar os dados de um contato existente
        public ContatoModel Atualizar(ContatoModel contato)
        {
            // buscando o contato a ser editado no banco por Id
            ContatoModel contatoDB = ListarPorId(contato.Id);

            // verificando se o contato existe, se não dispara uma exceção
            if (contatoDB == null) throw new Exception("Houve um erro na atualização do contato");

            // atribuindo os novos valores para cada campo
            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;

            // atualizando o contato no banco de dados
            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();

            return contatoDB;
        }
    }
}
