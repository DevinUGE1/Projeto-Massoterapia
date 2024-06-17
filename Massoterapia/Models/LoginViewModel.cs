using Massoterapia.Models;
using System.ComponentModel.DataAnnotations;

namespace Massoterapia.Models
{
    public class LoginViewModel
    {
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Preenchimento obrigatório")]
        [StringLength(250, ErrorMessage = "Ultrapassou o máximo de caracteres")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Preenchimento obrigatório")]
        [StringLength(50, ErrorMessage = "Ultrapassou o máximo de caracteres")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
