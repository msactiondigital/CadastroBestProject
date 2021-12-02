using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroBestProject.Models
{
    public class cadastro
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo NOME é obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo TELEFONE é obrigatório!")]
        [Display(Name = "Telefone Resid: ")]
        public string TelefoneResid { get; set; }

        [Required(ErrorMessage = "O campo CELULAR é obrigatório!")]
        [Display(Name = "Celular: ")]
        public string Celular { get; set; }
    }
}