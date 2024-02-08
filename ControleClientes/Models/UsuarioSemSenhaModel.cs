using ControleClientes.Enums;
using System.ComponentModel.DataAnnotations;

namespace ControleClientes.Models
{
    public class UsuarioSemSenhaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite seu nome!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite seu email!")]
        [EmailAddress(ErrorMessage = "Utilize um email válido!")]
        public string Email { get; set; }

    }
}
