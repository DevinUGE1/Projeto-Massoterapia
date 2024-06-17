using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Massoterapia.Models
{
    [Table("Avaliacaos")]
    public class Avaliacao
    {
        [Display(Name = "Codigo")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Preenchimento obrigatório")]
        [StringLength(5, ErrorMessage = "Ultrapassou o máximo de caracteres")]
        public string Nota { get; set; }


        [Required(ErrorMessage = "Preenchimento obrigatório")]
        [StringLength(250, ErrorMessage = "Ultrapassou o máximo de caracteres")]
        [DataType(DataType.MultilineText)]
        public string Comentario { get; set; }

        //FK

        //FK da tabela tartamento---------
        [Display(Name = "Tratamento")]
        [Required(ErrorMessage = "Preenchimento obrigatório")]
        public int IdTratamento { get; set; }
        //Relacionamento
        [ForeignKey(nameof(IdTratamento))]
        public Tratamento tratamento { get; set; }

        public Avaliacao()
        {

        }
    }
}
