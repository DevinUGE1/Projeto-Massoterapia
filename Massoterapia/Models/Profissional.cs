using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Massoterapia.Models
{
    [Table("Profissionais")]
    public class Profissional
    {
        [Display(Name = "Codigo")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required(ErrorMessage = "Campo obrigatorio")]
        [StringLength(70, ErrorMessage = "Alcansou o limine de caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preenchimento obrigatório")]
        public string Sexo { get; set; }

        [Display(Name = "Data de nascimento")]
        [Required(ErrorMessage = "Preenchimento obrigatório")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        public Especialidade Cromoterapia { get; set; }
        public Especialidade Shiatsu { get; set; }
        public Especialidade ShiatsuDaCadeira { get; set; }
        public Especialidade DoIn { get; set; }
        public Especialidade PedrasQuentes { get; set; }
        public Especialidade BambuTerapia { get; set; }
        public Especialidade MassagemRelaxante { get; set; }
        public Especialidade QuickMassagem { get; set; }
        public Especialidade MassagemDesportiva { get; set; }
        public Especialidade MassagemModeladora { get; set; }
        public Especialidade Reflexologia { get; set; }
        public Especialidade Amaromaterapia { get; set; }
        public Especialidade Maxoterapia { get; set; }
        public Especialidade VentoSaterapia { get; set; }
        public Especialidade Auriculoterapia { get; set; }
        public Especialidade DrenagemLinfatica { get; set; }
        public Especialidade TemAKinesioTape { get; set; }


        [Required(ErrorMessage = "Campo obrigatorio")]
        [StringLength(20, ErrorMessage = "Alcansou o limine de caracteres")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        [StringLength(70, ErrorMessage = "Alcansou o limine de caracteres")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        [StringLength(70, ErrorMessage = "Alcansou o limine de caracteres")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        [StringLength(10, ErrorMessage = "Alcansou o limine de caracteres")]
        public string Numero { get; set; }


        [StringLength(30, ErrorMessage = "Alcansou o limine de caracteres")]
        public string? Complemento { get; set; }

        //relacionamentos da tabela profissional com o tratamento
        public ICollection<Tratamento> Tratamentos { get; set; }

        public Profissional()
        {
            DataNascimento = DateTime.Now;
        }
    }

    public enum Especialidade
   {
        [Display(Name = "Cromoterapia")]
        Cromoterapia = 1,
        [Display(Name = "Shiatsu")]
        Shiatsu = 2,
        [Display(Name = "Shiatsu na Cadeira")]
        ShiatsuDaCadeira = 3,
        [Display(Name = "Do In")]
        DoIn = 4,
        [Display(Name = "PedrasQuentes")]
        PedrasQuentes = 5,
        [Display(Name = "Bambuterapia")]
        BambuTerapia = 6,
        [Display(Name = "MassagemRelaxante")]
        MassagemRelaxante = 7,
        [Display(Name = "QuickMassagem")]
        QuickMassagem = 8,
        [Display(Name = "MassagemDesportiva")]
        MassagemDesportiva = 9,
        [Display(Name = "MassagemModeladora")]
        MassagemModeladora = 10,
        [Display(Name = "Reflexologia")]
        Reflexologia = 11,
        [Display(Name = "Amaromaterapia")]
        Amaromaterapia = 12,
        [Display(Name = "Maxoterapia")]
        Maxoterapia = 13,
        [Display(Name = "Ventosaterapia")]
        VentoSaterapia = 14,
        [Display(Name = "Auriculoterapia")]
        Auriculoterapia = 15,
        [Display(Name = "DrenagemLinfatica")]
        DrenagemLinfatica = 16,
        [Display(Name = "TemAKinesioTape")]
        TemAKinesioTape = 17,
    }
}
