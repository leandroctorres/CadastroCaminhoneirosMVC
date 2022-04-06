using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroCaminhoneirosMVC.Models
{
    public class EnderecoMotorista
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Cep é obrigatório")]
        public int Cep { get; set; }
        [Required(ErrorMessage = "O campo Logradouro é obrigatório")]
        public string Logradouro { get; set; }
        [Display(Name = "Número")]
        [Required(ErrorMessage = "O campo Número é obrigatório")]
        public int Numero { get; set; }
        [Required(ErrorMessage = "O campo Bairro é obrigatório")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "O campo Cidade é obrigatório")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "O campo Estado é obrigatório")]
        public string Estado { get; set; }
        [Required(ErrorMessage = "O campo Motorista é obrigatório")]
        public int MotoristaId { get; set; }
        public Motorista Motorista { get; set; }


    }
}
