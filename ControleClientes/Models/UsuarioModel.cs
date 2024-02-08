using ControleClientes.Enums;
using System.ComponentModel.DataAnnotations;

namespace ControleClientes.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite seu nome!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite seu email!")]
        [EmailAddress(ErrorMessage = "Utilize um email válido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite sua senha!")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Digite seu login!")]
        public string Login { get; set; }
        public PerfilEnum Perfil { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }

    }
}
