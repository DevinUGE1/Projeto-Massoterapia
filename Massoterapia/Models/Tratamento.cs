using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Massoterapia.Models
{
    [Table("Tratamentos")]
    public class Tratamento
    {
        [Display(Name = "Codigo")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Tecnicas de massagens")]
        [Required(ErrorMessage = "Preenchimento obrigatorio")]
        [StringLength(70, ErrorMessage = "Chegou no limite de caracter")]
        public string TecnicaTratamento { get; set; }

        [Display(Name = "Concluído")]
        public bool TratamentoFinalizado { get; set; }

        [Display(Name ="Data de agendamento")]
        [Required(ErrorMessage = "Preenchimento obrigatorio")]
        [DataType(DataType.DateTime)]
        public DateTime Data { get; set; }

        //Adcionando as FK

        //FK da tabela Cliente--------
        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "Preenchimento obrigatório")]
        public int IdCliente { get; set; }
        //Relacionamento
        [ForeignKey(nameof(IdCliente))]
        public Cliente Cliente { get; set; }



        //FK da tabela profissional---------
        [Display(Name = "Profissional")]
        [Required(ErrorMessage = "Preenchimento obrigatório")]
        public int IdProfissional { get; set; }
        //Relacionamento
        [ForeignKey(nameof(IdProfissional))]
        public Profissional profissional { get; set; }


        //relacionamentos da tabela avaliacao com o tratamento--------
        public ICollection<Avaliacao> avaliacaos { get; set; }

        public Tratamento()
        {
            Data = DateTime.Now;
            TratamentoFinalizado = false;
        }

    }
}
