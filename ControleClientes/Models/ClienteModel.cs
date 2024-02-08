using System.ComponentModel.DataAnnotations;

namespace ControleClientes.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }

        // faz com que o campo seja obrigatório
        [Required(ErrorMessage ="Digite o nome do cliente")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o email do cliente")]
        // valida se o email é valido
        [EmailAddress(ErrorMessage ="Utilize um email válido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite o celular do cliente")]
        // valida se o telefone é valido
        [Phone(ErrorMessage ="Utilize um número de celular válido!")]
        public string Celular { get; set; }

        //public int EnderecoId { get; set; }
        //public EnderecoModel Endereco { get; set; }

        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
