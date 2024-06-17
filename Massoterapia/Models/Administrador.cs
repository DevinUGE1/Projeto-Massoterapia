using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Massoterapia.Models
{
    [Table("Administradores")]
    public class Administrador
    {
        [Display(Name = "Codigo")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Preenchimento obrigatório")]
        [StringLength(50, ErrorMessage = "Ultrapassou o máximo de caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Telefone")]
        [StringLength(20, ErrorMessage = "Ultrapassou o máximo de caracteres")]
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

        public Administrador()
        {

        }
    }
}
