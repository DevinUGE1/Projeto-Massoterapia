using Massoterapia.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Massoterapia.Models
{
    public class RegistroViewModel
    {
        //propriedades
        public int Id { get; set; }

        //cliente + profissional + Administrador + usuario-----------------------------------------------------------
        [Required(ErrorMessage = "Preenchimento obrigatório")]
        [StringLength(50, ErrorMessage = "Ultrapassou o máximo de caracteres")]
        public string Nome { get; set; }

        //cliente-----------------------------------------------------------
        [Required(ErrorMessage = "Preenchimento obrigatório")]
        [StringLength(20, ErrorMessage = "Ultrapassou o máximo de caracteres")]
        [DataType(DataType.PhoneNumber)]
        
        public string Telefone { get; set; }


        [Display(Name = "Celular")]
        [StringLength(20, ErrorMessage = "Ultrapassou o máximo de caracteres")]
        [DataType(DataType.PhoneNumber)]
        public string? Celular { get; set; }

        //profissional-----------------------------------------------------------

        [Display(Name = "Data de nascimento")]
        [Required(ErrorMessage = "Preenchimento obrigatório")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }


        [Required(ErrorMessage = "Preenchimento obrigatório")]
        [ValidateNever]
        public bool Cromoterapia { get; set; }
        public bool Shiatsu { get; set; }
        public bool ShiatsuDaCadeira { get; set; }
        public bool DoIn { get; set; }
        public bool PedrasQuentes { get; set; }
        public bool BambuTerapia { get; set; }
        public bool MassagemRelaxante { get; set; }
        public bool QuickMassagem { get; set; }
        public bool MassagemDesportiva { get; set; }
        public bool MassagemModeladora { get; set; }
        public bool Reflexologia { get; set; }
        public bool Amaromaterapia { get; set; }
        public bool Maxoterapia { get; set; }
        public bool VentoSaterapia { get; set; }
        public bool Auriculoterapia { get; set; }
        public bool DrenagemLinfatica { get; set; }
        public bool TemAKinesioTape { get; set; }


        [Required(ErrorMessage = "Campo obrigatorio")]
        [StringLength(20, ErrorMessage = "Alcansou o limine de caracteres")]
        [ValidateNever]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        [StringLength(70, ErrorMessage = "Alcansou o limine de caracteres")]
        [ValidateNever]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        [StringLength(70, ErrorMessage = "Alcansou o limine de caracteres")]
        [ValidateNever]
        public string Rua { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        [StringLength(10, ErrorMessage = "Alcansou o limine de caracteres")]
        [ValidateNever]
        public string Numero { get; set; }


        [StringLength(30, ErrorMessage = "Alcansou o limine de caracteres")]
        [ValidateNever]
        public string? Complemento { get; set; }

        //Administrador-----------------------------------------------------

        //usuario-----------------------------------------------------------
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

        //[Required(ErrorMessage = "Preenchimento obrigatório")]
        public Perfil Perfil { get; set; }
        public int? IdPerfil { get; set; }

        [Required(ErrorMessage = "Preenchimento obrigatório")]
        public string Sexo { get; set; }
    }


}
