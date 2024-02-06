using ControleClientes.Data;
using ControleClientes.Models;

namespace ControleClientes.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly BancoContext _bancoContext;

        // função para buscar cliente por id
        public ClienteModel ListarPorId(int id)
        {
            // retorna um cliente que tenha id igual ao solicitado
            return _bancoContext.Clientes.FirstOrDefault(x => x.Id == id);
        }

        // injeção de dependencia do banco de dados
        public ClienteRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        // função para buscar todos os clientes
        public List<ClienteModel> BuscarTodos()
        {
            // retorna uma lista de clientes
            return _bancoContext.Clientes.ToList();
        }

        public ClienteModel Adicionar(ClienteModel cliente)
        {

            // salvar cliente no banco de dados
            _bancoContext.Clientes.Add(cliente);
            _bancoContext.SaveChanges();
            return cliente;

        }

        // função para alterar os dados de um cliente existente
        public ClienteModel Atualizar(ClienteModel cliente)
        {
            // buscando o cliente a ser editado no banco por Id
            ClienteModel clienteDB = ListarPorId(cliente.Id);

            // verificando se o cliente existe, se não dispara uma exceção
            if (clienteDB == null) throw new Exception("Houve um erro na atualização do cliente");

            // atribuindo os novos valores para cada campo
            clienteDB.Nome = cliente.Nome;
            clienteDB.Email = cliente.Email;
            clienteDB.Celular = cliente.Celular;

            // atualizando o cliente no banco de dados
            _bancoContext.Clientes.Update(clienteDB);
            _bancoContext.SaveChanges();

            return clienteDB;
        }

        public bool Apagar(int id)
        {
            ClienteModel clienteDB = ListarPorId(id);

            if (clienteDB == null) throw new Exception("Houve um erro na exclusão do cliente");

            _bancoContext.Clientes.Remove(clienteDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
