using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Massoterapia.Models
{
    public class Usuario
    {
        [Display(Name = "Código")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


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


        [Required(ErrorMessage = "Preenchimento obrigatório")]
        public Perfil Perfil { get; set; }
        public int? IdPerfil { get; set; }


        [DataType(DataType.ImageUrl)]
        public string? Imagem { get; set; }

        public Usuario()
        {

        }
    }

    public enum Perfil
    {
        Cliente,
        Profissional,
        Administrador,
    }


}
