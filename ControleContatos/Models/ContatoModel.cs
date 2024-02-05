using System.ComponentModel.DataAnnotations;

namespace ControleContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }

        // faz com que o campo seja obrigatório
        [Required(ErrorMessage ="Digite o nome do contato")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o email do contato")]
        // valida se o email é valido
        [EmailAddress(ErrorMessage ="Utilize um email válido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite o celular do contato")]
        // valida se o telefone é valido
        [Phone(ErrorMessage ="Utilize um número de celular válido!")]
        public string Celular { get; set; }
    }
}
