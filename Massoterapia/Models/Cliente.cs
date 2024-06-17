using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Massoterapia.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Display(Name = "Codigo")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required(ErrorMessage = "Preenchimento obrigatório")]
        [StringLength(50, ErrorMessage = "Ultrapassou o máximo de caracteres")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Preenchimento obrigatório")]
        public string Sexo { get; set; }


        [Display(Name = "Data de nascimento")]
        [Required(ErrorMessage = "Preenchimento obrigatório")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }


        [Display(Name = "Telefone")]
        [StringLength(20, ErrorMessage = "Ultrapassou o máximo de caracteres")]
        [DataType(DataType.PhoneNumber)]
        public string? Telefone { get; set; }


        [Display(Name = "Celular")]
        [StringLength(20, ErrorMessage = "Ultrapassou o máximo de caracteres")]
        [DataType(DataType.PhoneNumber)]
        public string? Celular { get; set; }

        //relacionamentos da tabela cliente com o tratamento
        public ICollection<Tratamento> Tratamentos { get; set; }

        public Cliente()
        {
            DataNascimento = DateTime.Now;
        }
    }
}
